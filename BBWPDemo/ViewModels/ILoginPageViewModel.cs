using System.Windows.Input;

namespace BBWPDemo.ViewModels
{
    public interface ILoginPageViewModel
    {
        string Username { get; set; }
        string Password { get; set; }
        ICommand Login { get; }
        ICommand Signup { get; }
    }
}