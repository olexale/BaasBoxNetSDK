using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BaasBoxNet.Models;

namespace BaasBoxNet
{
    public interface IBaasBoxDocuments
    {
        Task<T> CreateAsync<T>(T document) where T : BaasDocument;
        Task<T> RetrieveAsync<T>(string collection, string id) where T : BaasDocument;
        Task<IEnumerable<T>> RetrieveByQueryAsync<T>(string collection, string query) where T : BaasDocument;
        Task<int> CountAsync(string collection);
        Task<T> ModifyAsync<T>(T document) where T : BaasDocument;
        Task DeleteAsync(string collection, string id);

        Task<T> CreateAsync<T>(T document, CancellationToken cancellationToken) where T : BaasDocument;

        Task<T> RetrieveAsync<T>(string collection, string id, CancellationToken cancellationToken)
            where T : BaasDocument;

        Task<IEnumerable<T>> RetrieveByQueryAsync<T>(string collection, string query,
            CancellationToken cancellationToken) where T : BaasDocument;

        Task<int> CountAsync(string collection, CancellationToken cancellationToken);
        Task<T> ModifyAsync<T>(T document, CancellationToken cancellationToken) where T : BaasDocument;
        Task DeleteAsync(string collection, string id, CancellationToken cancellationToken);
    }
}