namespace BaasBoxNet
{
    /// <summary>
    ///     The configuration for BaasBox client
    /// </summary>
    public sealed class BaasBoxConfig
    {
        public BaasBoxConfig()
        {
            HttpPort = 9000;
            ApiDomain = "10.0.2.2";
            AppCode = "1234567890";
        }

        /// <summary>
        ///     The port number of the server connection, default is <code>9000</code>.
        /// </summary>
        public int HttpPort { get; set; }

        /// <summary>
        ///     The domain name of the server, default is <code>"10.0.2.2</code> -refers to the localhost from emulator.
        /// </summary>
        public string ApiDomain { get; set; }

        /// <summary>
        ///     The BaasBox app code, default is <code>1234567890</code>.
        /// </summary>
        public string AppCode { get; set; }
    }
}