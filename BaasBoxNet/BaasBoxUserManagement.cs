using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BaasBoxNet.Models;

namespace BaasBoxNet
{
    public sealed class BaasBoxUserManagement
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

        public Task<BaasUser> SignupAsync(string username, string password, CancellationToken cancellationToken)
        {
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            return _box.RestService.PostAsync<BaasUser>("user", requestBody, cancellationToken);
        }

        public Task<BaasUser> LoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("appcode", _box.Config.AppCode)
            });
            return _box.RestService.PostAsync<BaasUser>("login", requestBody, cancellationToken);
        }

        public Task LogoutAsync(CancellationToken cancellationToken)
        {
            return _box.RestService.PostAsync<object>("logout", null, cancellationToken);
        }

        public Task ChangePasswordAsync(string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("old", oldPassword),
                new KeyValuePair<string, string>("new", newPassword)
            });
            return _box.RestService.PutAsync<object>("me/password", requestBody, cancellationToken);
        }

        public Task ResetPasswordAsync(string username, CancellationToken cancellationToken)
        {
            var requestUrl = string.Format("user/{0}/password/reset", username);
            return _box.RestService.GetAsync<object>(requestUrl, cancellationToken);
        }
    }
}