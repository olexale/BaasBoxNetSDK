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
        Task ChangePasswordAsync(string oldPassword, string newPassword);
        Task ResetPasswordAsync(string username);
    }
}