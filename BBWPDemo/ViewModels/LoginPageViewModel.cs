using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using BaasBoxNet;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace BBWPDemo.ViewModels
{
    internal class LoginPageViewModel : ViewModel, ILoginPageViewModel
    {
        private readonly IBaasBoxUserManagement _boxUserManagement;
        private ICommand _login;
        private string _password;
        private ICommand _signup;
        private string _username;

        public LoginPageViewModel(IBaasBoxUserManagement boxUserManagement)
        {
            _boxUserManagement = boxUserManagement;
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand Login
        {
            get { return _login ?? (_login = new DelegateCommand(async () => await DoLogin())); }
        }

        public ICommand Signup
        {
            get { return _signup ?? (_signup = new DelegateCommand(async () => await DoSignup())); }
        }

        private async Task DoLogin()
        {
            string message;
            try
            {
                var user = await _boxUserManagement.LoginAsync(Username, Password);
                message = "Login successful. Session = " + user.Session;
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            await new MessageDialog(message).ShowAsync();
        }

        private async Task DoSignup()
        {
            string message;
            try
            {
                var user = await _boxUserManagement.LoginAsync(Username, Password);
                message = "Signup successful. Session = " + user.Session;
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            await new MessageDialog(message).ShowAsync();
        }
    }
}