using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BaasBoxNet;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace BBWPDemo.ViewModels
{
    internal class DocumentsPageViewModel : ViewModel, IDocumentsPageViewModel
    {
        private readonly IBaasBoxDocuments _documents;
        private string _collection;
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

        private Task DoCreate()
        {
            throw new NotImplementedException();
        }

        private Task DoModify()
        {
            throw new NotImplementedException();
        }

        private Task DoDelete()
        {
            throw new NotImplementedException();
        }
    }
}