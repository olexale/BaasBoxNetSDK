using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaasBoxNet.Models;
using Newtonsoft.Json;

namespace BaasBoxNet
{
    internal class BaasBoxUserManagement
        : IBaasBoxUserManagement
    {
        private readonly BaasBox _box;

        internal BaasBoxUserManagement(BaasBox box)
        {
            _box = box;
        }

        public bool IsAuthenticated
        {
            get { return _box.User != null && !string.IsNullOrWhiteSpace(_box.User.Session); }
        }

        public Task<BaasUser> SignupAsync(string username, string password)
        {
            return SignupAsync(username, password, CancellationToken.None);
        }

        public Task<BaasUser> LoginAsync(string username, string password)
        {
            return LoginAsync(username, password, CancellationToken.None);
        }

        public Task LogoutAsync()
        {
            return LogoutAsync(CancellationToken.None);
        }

        public Task ChangePasswordAsync(string oldPassword, string newPassword)
        {
            return ChangePasswordAsync(oldPassword, newPassword, CancellationToken.None);
        }

        public Task ResetPasswordAsync(string username)
        {
            return ResetPasswordAsync(username, CancellationToken.None);
        }

        public async Task<BaasUser> SignupAsync(string username, string password, CancellationToken cancellationToken)
        {
            var requestBody = new Dictionary<string, string>
            {
                {"username", username},
                {"password", password}
            };
            var jsonData = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var user = await _box.RestService.PostAsync<LoginResponse>("user", data, cancellationToken);
            _box.User = new BaasUser
            {
                Name = user.User.Name,
                Roles = user.User.Roles,
                Session = user.Session,
                SignupDate = user.SignupDate,
                Status = user.User.Status
            };
            return _box.User;
        }

        public async Task<BaasUser> LoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            var requestBody = new Dictionary<string, string>
            {
                {"username", username},
                {"password", password},
                {"appcode", _box.Config.AppCode}
            };
            var request = new FormUrlEncodedContent(requestBody);
            var user = await _box.RestService.PostAsync<LoginResponse>("login", request, cancellationToken);
            _box.User = new BaasUser
            {
                Name = user.User.Name,
                Roles = user.User.Roles,
                Session = user.Session,
                SignupDate = user.SignupDate,
                Status = user.User.Status
            };
            return _box.User;
        }

        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            await _box.RestService.PostAsync<object>("logout", null, cancellationToken);
            _box.User.Session = string.Empty;
        }

        public Task ChangePasswordAsync(string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            var requestBody = new Dictionary<string, string>
            {
                {"old", oldPassword},
                {"new", newPassword}
            };
            var jsonData = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return _box.RestService.PutAsync<object>("me/password", data, cancellationToken);
        }

        public Task ResetPasswordAsync(string username, CancellationToken cancellationToken)
        {
            var requestUrl = string.Format("user/{0}/password/reset", username);
            return _box.RestService.GetAsync<object>(requestUrl, cancellationToken);
        }

        private class LoginResponse
        {
            [JsonProperty("signUpDate")]
            public DateTime SignupDate { get; set; }

            [JsonProperty("X-BB-SESSION")]
            public string Session { get; set; }

            [JsonProperty("user")]
            public BaasUser User { get; set; }
        }
    }
}