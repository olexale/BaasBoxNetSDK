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
    internal class UserManagementPageViewModel : ViewModel, IUserManagementPageViewModel
    {
        private readonly BaasBox _box;
        private readonly INavigationService _navigationService;
        private readonly IBaasBoxUserManagement _userManagement;
        private ICommand _changePassword;
        private ICommand _logout;
        private string _newPassword;
        private string _oldPassword;
        private ICommand _resetPassword;

        public UserManagementPageViewModel(INavigationService navigationService, BaasBox box,
            IBaasBoxUserManagement userManagement)
        {
            _navigationService = navigationService;
            _box = box;
            _userManagement = userManagement;
        }

        public ICommand Logout
        {
            get { return _logout ?? (_logout = new DelegateCommand(async () => await DoLogout())); }
        }

        public ICommand ResetPassword
        {
            get
            {
                return _resetPassword ?? (_resetPassword = new DelegateCommand(async () => await DoResetPassword()));
            }
        }

        public ICommand ChangePassword
        {
            get
            {
                return _changePassword ?? (_changePassword = new DelegateCommand(async () => await DoChangePassword()));
            }
        }

        public string OldPassword
        {
            get { return _oldPassword; }
            set { SetProperty(ref _oldPassword, value); }
        }

        public string NewPassword
        {
            get { return _newPassword; }
            set { SetProperty(ref _newPassword, value); }
        }

        private async Task DoLogout()
        {
            try
            {
                await _userManagement.LogoutAsync();
                _navigationService.Navigate(Experiences.Login.ToString(), null);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async Task DoResetPassword()
        {
            try
            {
                await _userManagement.ResetPasswordAsync(_box.User.Name);
                await new MessageDialog("done").ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async Task DoChangePassword()
        {
            try
            {
                await _userManagement.ChangePasswordAsync(OldPassword, NewPassword);
                await new MessageDialog("done").ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}