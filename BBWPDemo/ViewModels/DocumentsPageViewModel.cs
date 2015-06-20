using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using BaasBoxNet;
using BBWPDemo.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace BBWPDemo.ViewModels
{
    internal class DocumentsPageViewModel : ViewModel, IDocumentsPageViewModel
    {
        private readonly IBaasBoxDocuments _documents;
        private string _collection;
        private Contact _contact;
        private ICommand _create;
        private ICommand _delete;
        private ICommand _modify;
        private string _name;

        public DocumentsPageViewModel(IBaasBoxDocuments documents)
        {
            _documents = documents;
        }

        public string Collection
        {
            get { return _collection; }
            set { SetProperty(ref _collection, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ICommand Create
        {
            get { return _create ?? (_create = new DelegateCommand(async () => await DoCreate())); }
        }

        public ICommand Modify
        {
            get { return _modify ?? (_modify = new DelegateCommand(async () => await DoModify())); }
        }

        public ICommand Delete
        {
            get { return _delete ?? (_delete = new DelegateCommand(async () => await DoDelete())); }
        }

        private async Task DoCreate()
        {
            try
            {
                var d = new Contact {BaasDocumentClass = Collection, Name = Name};
                _contact = await _documents.CreateAsync(d);
                await new MessageDialog("Document created! Id = " + _contact.BaasDocumentId).ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async Task DoModify()
        {
            if (_contact == null)
            {
                await new MessageDialog("Create document first").ShowAsync();
                return;
            }

            try
            {
                _contact.Name = Name;
                _contact = await _documents.ModifyAsync(_contact);
                await new MessageDialog("Document modified! Id = " + _contact.BaasDocumentId).ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async Task DoDelete()
        {
            if (_contact == null)
            {
                await new MessageDialog("Create document first").ShowAsync();
                return;
            }

            try
            {
                await _documents.DeleteAsync(_contact.BaasDocumentClass, _contact.BaasDocumentId);
                _contact = null;
                await new MessageDialog("Document deleted!").ShowAsync();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}