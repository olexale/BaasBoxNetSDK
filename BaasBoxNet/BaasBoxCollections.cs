using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaasBoxNet
{
    public class BaasBoxCollections : IBaasBoxCollections
    {
        private readonly BaasBox _box;

        public BaasBoxCollections(BaasBox box)
        {
            _box = box;
        }

        public Task CreateCollectionAsync(string name)
        {
            return CreateCollectionAsync(name, CancellationToken.None);
        }

        public Task DeleteCollectionAsync(string name)
        {
            return DeleteCollectionAsync(name, CancellationToken.None);
        }

        public Task CreateCollectionAsync(string name, CancellationToken cancellationToken)
        {
            var request = string.Format("admin/collection/{0}", name);
            return _box.RestService.PostAsync<object>(request, null, cancellationToken);
        }

        public Task DeleteCollectionAsync(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}