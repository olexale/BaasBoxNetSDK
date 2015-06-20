using System.Threading;
using System.Threading.Tasks;

namespace BaasBoxNet
{
    internal class BaasBoxCollections : IBaasBoxCollections
    {
        private readonly BaasBox _box;

        public BaasBoxCollections(BaasBox box)
        {
            _box = box;
        }

        public Task CreateAsync(string name)
        {
            return CreateAsync(name, CancellationToken.None);
        }

        public Task DeleteAsync(string name)
        {
            return DeleteAsync(name, CancellationToken.None);
        }

        public Task CreateAsync(string name, CancellationToken cancellationToken)
        {
            var request = string.Format("admin/collection/{0}", name);
            return _box.RestService.PostAsync<object>(request, null, cancellationToken);
        }

        public Task DeleteAsync(string name, CancellationToken cancellationToken)
        {
            var request = string.Format("admin/collection/{0}", name);
            return _box.RestService.DeleteAsync(request, cancellationToken);
        }
    }
}