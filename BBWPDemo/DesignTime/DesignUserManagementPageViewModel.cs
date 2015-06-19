using System.Windows.Input;
using BBWPDemo.ViewModels;

namespace BBWPDemo.DesignTime
{
    internal class DesignUserManagementPageViewModel : IUserManagementPageViewModel
    {
        public ICommand Logout { get; private set; }
        public ICommand ResetPassword { get; private set; }
        public ICommand ChangePassword { get; private set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}