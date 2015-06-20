using System.Windows.Input;

namespace BBWPDemo.ViewModels
{
    internal interface ICollectionsPageViewModel
    {
        string Name { get; set; }
        ICommand Create { get; }
        ICommand Delete { get; }
    }
}