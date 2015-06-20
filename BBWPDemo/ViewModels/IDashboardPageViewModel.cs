using System.Windows.Input;

namespace BBWPDemo.ViewModels
{
    internal interface IDashboardPageViewModel
    {
        ICommand OpenUserManagement { get; }
        ICommand OpenCollections { get; }
        ICommand OpenDocument { get; }
    }
}