using System.Windows.Input;

namespace BBWPDemo.ViewModels
{
    internal interface IUserManagementPageViewModel
    {
        ICommand Logout { get; }
        ICommand ResetPassword { get; }
        ICommand ChangePassword { get; }
        string OldPassword { get; set; }
        string NewPassword { get; set; }
    }
}