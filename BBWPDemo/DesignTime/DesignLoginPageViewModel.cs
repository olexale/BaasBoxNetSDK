using System.Windows.Input;
using BBWPDemo.ViewModels;

namespace BBWPDemo.DesignTime
{
    public class DesignLoginPageViewModel : ILoginPageViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand Login { get; private set; }
        public ICommand Signup { get; private set; }
    }
}