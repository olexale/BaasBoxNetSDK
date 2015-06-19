using System.Threading;
using System.Threading.Tasks;
using BaasBoxNet.Models;

namespace BaasBoxNet
{
    public interface IBaasBoxUserManagement
    {
        bool IsAuthenticated { get; }
        Task<BaasUser> SignupAsync(string username, string password);
        Task<BaasUser> LoginAsync(string username, string password);
        Task LogoutAsync();

        /// <summary>
        ///     After you call this API the authentication token is not valid anymore and should call Login again.
        /// </summary>
        /// <param name="oldPassword">old password</param>
        /// <param name="newPassword">new password</param>
        /// <returns></returns>
        Task ChangePasswordAsync(string oldPassword, string newPassword);

        Task ResetPasswordAsync(string username);

        Task<BaasUser> SignupAsync(string username, string password, CancellationToken cancellationToken);
        Task<BaasUser> LoginAsync(string username, string password, CancellationToken cancellationToken);
        Task LogoutAsync(CancellationToken cancellationToken);
        Task ChangePasswordAsync(string oldPassword, string newPassword, CancellationToken cancellationToken);
        Task ResetPasswordAsync(string username, CancellationToken cancellationToken);
    }
}