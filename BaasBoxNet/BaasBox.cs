using BaasBoxNet.Models;
using BaasBoxNet.Services;

namespace BaasBoxNet
{
    /// <summary>
    ///     BaasBox .Net SDK client
    /// </summary>
    public sealed class BaasBox
    {
        /// <summary>
        ///     BaasBox simplified constructor
        /// </summary>
        /// <param name="apiDomain">Server Url</param>
        /// <param name="appCode">Application code</param>
        public BaasBox(string apiDomain, string appCode)
            : this(new BaasBoxConfig {ApiDomain = apiDomain, AppCode = appCode})
        {
        }

        /// <summary>
        ///     BaasBox client constructor
        /// </summary>
        /// <param name="config"></param>
        public BaasBox(BaasBoxConfig config)
        {
            Config = config;
            UserManagement = new BaasBoxUserManagement(this);
            RestService = new RestService(this);
            Collections = new BaasBoxCollections(this);
            Documents = new BaasBoxDocuments(this);
        }

        public BaasUser User { get; set; }

        public BaasBoxConfig Config { get; private set; }

        public IBaasBoxUserManagement UserManagement { get; private set; }

        public IBaasBoxCollections Collections { get; private set; }

        public IBaasBoxDocuments Documents { get; private set; }

        internal RestService RestService { get; private set; }
    }
}