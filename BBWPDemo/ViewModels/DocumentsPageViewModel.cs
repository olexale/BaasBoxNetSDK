using System.Windows.Input;
using Microsoft.Practices.Prism.Mvvm;

namespace BBWPDemo.ViewModels
{
    internal class DocumentsPageViewModel : ViewModel, IDocumentsPageViewModel
    {

        public string Collection { get; set; }
        public string Name { get; set; }
        public ICommand Create { get; private set; }
        public ICommand Modify { get; private set; }
        public ICommand Delete { get; private set; }
    }
}