using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using BaasBoxNet;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace BBWPDemo.ViewModels
{
    internal class LoginPageViewModel : ViewModel, ILoginPageViewModel
    {
        private readonly IBaasBoxUserManagement _boxUserManagement;
        private readonly INavigationService _navigationService;
        private ICommand _login;
        private string _password;
        private ICommand _signup;
        private string _username;

        public LoginPageViewModel(INavigationService navigationService, IBaasBoxUserManagement boxUserManagement)
        {
            _navigationService = navigationService;
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
            try
            {
                await _boxUserManagement.LoginAsync(Username, Password);
                _navigationService.Navigate(Experiences.UserManagement.ToString(), null);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async Task DoSignup()
        {
            try
            {
                await _boxUserManagement.SignupAsync(Username, Password);
                _navigationService.Navigate(Experiences.UserManagement.ToString(), null);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}