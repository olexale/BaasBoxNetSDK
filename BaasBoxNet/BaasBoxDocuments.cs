using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaasBoxNet.Exceptions;
using BaasBoxNet.Models;
using Newtonsoft.Json;

namespace BaasBoxNet
{
    internal class BaasBoxDocuments : IBaasBoxDocuments
    {
        private readonly IEnumerable<string> _baasDocumentProperties;
        private readonly BaasBox _box;

        public BaasBoxDocuments(BaasBox box)
        {
            _box = box;
            _baasDocumentProperties = typeof (BaasDocument).GetRuntimeProperties().Select(p => p.Name);
        }

        public Task<T> CreateAsync<T>(T document) where T : BaasDocument
        {
            return CreateAsync(document, CancellationToken.None);
        }

        public Task<T> RetrieveAsync<T>(string collection, string id) where T : BaasDocument
        {
            return RetrieveAsync<T>(collection, id, CancellationToken.None);
        }

        public Task<IEnumerable<T>> RetrieveByQueryAsync<T>(string collection, string query) where T : BaasDocument
        {
            return RetrieveByQueryAsync<T>(collection, query, CancellationToken.None);
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
            if (string.IsNullOrWhiteSpace(document.BaasDocumentClass))
                throw new BaasValidationException("Document collection name is missing");

            var requestBody = GetDocumentCustomPropertiesDictionary(document);
            var jsonData = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var requestUrl = string.Format("document/{0}", document.BaasDocumentClass);
            return _box.RestService.PostAsync<T>(requestUrl, data, cancellationToken);
        }

        public Task<T> RetrieveAsync<T>(string collection, string id, CancellationToken cancellationToken)
            where T : BaasDocument
        {
            var requestUrl = string.Format("document/{0}/{1}", collection, id);
            return _box.RestService.GetAsync<T>(requestUrl, cancellationToken);
        }

        public Task<IEnumerable<T>> RetrieveByQueryAsync<T>(string collection, string query,
            CancellationToken cancellationToken) where T : BaasDocument
        {
            var requestUrl = string.Format("document/{0}{1}", collection, query);
            return _box.RestService.GetAsync<IEnumerable<T>>(requestUrl, cancellationToken);
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

        private Dictionary<string, string> GetDocumentCustomPropertiesDictionary<T>(T document) where T : BaasDocument
        {
            return typeof (T).GetRuntimeProperties()
                .Where(p => _baasDocumentProperties.All(b => b != p.Name) && p.CanRead)
                .ToDictionary(property => property.Name, property => property.GetValue(document).ToString());
        }
    }
}