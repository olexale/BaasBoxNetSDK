using System.Windows.Input;

namespace BBWPDemo.ViewModels
{
    interface IDashboardPageViewModel
    {
        ICommand OpenUserManagement { get; }
    }
}