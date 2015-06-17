using System;

namespace BaasBoxNet
{
    public sealed class BaasBox
    {
        private static BaasBox _defaultClient;
        private readonly BaasBoxConfig _config;

        public BaasBox(BaasBoxConfig config)
        {
            _config = config;
        }


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