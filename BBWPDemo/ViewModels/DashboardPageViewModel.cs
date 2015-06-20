using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace BBWPDemo.ViewModels
{
    internal class DashboardPageViewModel : ViewModel, IDashboardPageViewModel
    {
        private readonly INavigationService _navigationService;
        private ICommand _openUserManagement;

        public DashboardPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand OpenUserManagement
        {
            get
            {
                return _openUserManagement ??
                       (_openUserManagement =
                           new DelegateCommand(
                               () => _navigationService.Navigate(Experiences.UserManagement.ToString(), null)));
            }
        }
    }
}