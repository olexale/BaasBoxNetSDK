using System.Threading;
using System.Threading.Tasks;

namespace BaasBoxNet
{
    public interface IBaasBoxCollections
    {
        Task CreateAsync(string name);
        Task DeleteAsync(string name);

        Task CreateAsync(string name, CancellationToken cancellationToken);
        Task DeleteAsync(string name, CancellationToken cancellationToken);
    }
}