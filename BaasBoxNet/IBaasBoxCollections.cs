using System.Threading.Tasks;

namespace BaasBoxNet
{
    public interface IBaasBoxCollections
    {
        Task CreateCollectionAsync(string name);
        Task DeleteCollectionAsync(string name);
    }
}