using System.Threading;
using System.Threading.Tasks;

namespace BaasBoxNet
{
    public interface IBaasBoxCollections
    {
        Task CreateCollectionAsync(string name);
        Task DeleteCollectionAsync(string name);

        Task CreateCollectionAsync(string name, CancellationToken cancellationToken);
        Task DeleteCollectionAsync(string name, CancellationToken cancellationToken);
    }
}