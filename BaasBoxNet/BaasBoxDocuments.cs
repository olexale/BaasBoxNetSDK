using System;
using System.Threading;
using System.Threading.Tasks;
using BaasBoxNet.Models;

namespace BaasBoxNet
{
    internal class BaasBoxDocuments : IBaasBoxDocuments
    {
        private readonly BaasBox _box;

        public BaasBoxDocuments(BaasBox box)
        {
            _box = box;
        }

        public Task<T> CreateAsync<T>(T document) where T : BaasDocument
        {
            return CreateAsync(document, CancellationToken.None);
        }

        public Task<T> RetrieveAsync<T>(string collection, string id) where T : BaasDocument
        {
            return RetrieveAsync<T>(collection, id, CancellationToken.None);
        }

        public Task<int> CountAsync(string collection)
        {
            return CountAsync(collection, CancellationToken.None);
        }

        public Task<T> ModifyAsync<T>(T document) where T : BaasDocument
        {
            return ModifyAsync(document, CancellationToken.None);
        }

        public Task DeleteAsync(string collection, string id)
        {
            return DeleteAsync(collection, id, CancellationToken.None);
        }

        public Task<T> CreateAsync<T>(T document, CancellationToken cancellationToken) where T : BaasDocument
        {
            throw new NotImplementedException();
        }

        public Task<T> RetrieveAsync<T>(string collection, string id, CancellationToken cancellationToken)
            where T : BaasDocument
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(string collection, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> ModifyAsync<T>(T document, CancellationToken cancellationToken) where T : BaasDocument
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string collection, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}