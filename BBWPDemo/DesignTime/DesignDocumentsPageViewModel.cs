using System.Windows.Input;
using BBWPDemo.ViewModels;

namespace BBWPDemo.DesignTime
{
    internal class DesignDocumentsPageViewModel : IDocumentsPageViewModel
    {
        public string Collection { get; set; }
        public string Name { get; set; }
        public ICommand Create { get; private set; }
        public ICommand Modify { get; private set; }
        public ICommand Delete { get; private set; }
    }
}