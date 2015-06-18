using System;
using System.Threading.Tasks;
using System.Windows.Input;
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

        private Task DoLogin()
        {
            throw new NotImplementedException();
        }

        private Task DoSignup()
        {
            throw new NotImplementedException();
        }
    }
}