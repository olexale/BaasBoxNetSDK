using System.Windows.Input;
using BBWPDemo.ViewModels;

namespace BBWPDemo.DesignTime
{
    internal class DesignDashboardPageViewModel : IDashboardPageViewModel
    {
        public ICommand OpenUserManagement { get; private set; }
        public ICommand OpenCollections { get; private set; }
        public ICommand OpenDocument { get; private set; }
    }
}