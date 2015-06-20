using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using BaasBoxNet;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace BBWPDemo.ViewModels
{
    internal class CollectionsPageViewModel : ViewModel, ICollectionsPageViewModel
    {
        private readonly IBaasBoxCollections _collections;
        private ICommand _create;
        private ICommand _delete;
        private string _name;

        public CollectionsPageViewModel(IBaasBoxCollections collections)
        {
            _collections = collections;
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ICommand Create
        {
            get { return _create ?? (_create = new DelegateCommand(async () => await DoCreateCollection())); }
        }

        public ICommand Delete
        {
            get { return _delete ?? (_delete = new DelegateCommand(async () => await DoDeleteCollection())); }
        }

        private async Task DoCreateCollection()
        {
            try
            {
                await _collections.CreateAsync(Name);
                await new MessageDialog("done").ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async Task DoDeleteCollection()
        {
            try
            {
                await _collections.DeleteAsync(Name);
                await new MessageDialog("done").ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}