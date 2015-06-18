using System;

namespace BaasBoxNet
{
    public sealed class BaasBox
    {
        private static BaasBox _defaultClient;
        private readonly BaasBoxConfig _config;

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
            _config = config;
            UserManagement = new BaasUserManagement();
        }

        public BaasUserManagement UserManagement { get; private set; }

        /// <summary>
        ///     BaasBox instance for this device
        /// </summary>
        public static BaasBox Default
        {
            get { return _defaultClient; }
        }

        internal static BaasBox DefaultChecked
        {
            get
            {
                if (_defaultClient == null)
                    throw new InvalidOperationException("Trying to use implicit client, but no default initialized");
                return _defaultClient;
            }
        }
    }
}