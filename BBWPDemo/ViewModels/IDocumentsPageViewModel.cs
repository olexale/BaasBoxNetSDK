using System.Windows.Input;

namespace BBWPDemo.ViewModels
{
    internal interface IDocumentsPageViewModel
    {
        string Collection { get; set; }
        string Name { get; set; }
        ICommand Create { get; }
        ICommand Modify { get; }
        ICommand Delete { get; }
    }
}