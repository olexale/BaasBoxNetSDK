using System.Collections.Generic;
using System.Net.Http;
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
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            return _box.RestService.PostAsync<BaasUser>("user", requestBody);
        }

        public Task<BaasUser> LoginAsync(string username, string password)
        {
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("appcode", _box.Config.AppCode)
            });
            return _box.RestService.PostAsync<BaasUser>("login", requestBody);
        }

        public Task LogoutAsync()
        {
            return _box.RestService.PostAsync<object>("logout", null);
        }

        public Task ChangePasswordAsync(string oldPassword, string newPassword)
        {
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("old", oldPassword),
                new KeyValuePair<string, string>("new", newPassword)
            });
            return _box.RestService.PutAsync<object>("me/password", requestBody);
        }

        public Task ResetPasswordAsync(string username)
        {
            var requestUrl = string.Format("user/{0}/password/reset", username);
            return _box.RestService.GetAsync<object>(requestUrl);
        }
    }
}