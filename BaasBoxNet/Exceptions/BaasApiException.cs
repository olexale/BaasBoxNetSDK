namespace BaasBoxNet.Exceptions
{
    /// <summary>
    ///     A subclass of BaasException. This is the root of all the
    ///     exception thrown by the remote server; if it crashes or the request made is
    ///     invalid, a subclass of BaasApiException is thrown by the SDK.
    /// </summary>
    public class BaasApiException : BaasException
    {
        public BaasApiException(int code, int httpStatus, string resource, string method, string apiVersion,
            string detailMessage)
            : base(detailMessage)
        {
            Code = code;
            HttpStatus = httpStatus;
            Resource = resource;
            Method = method;
            ApiVersion = apiVersion;
        }

        public int HttpStatus { get; private set; }
        public string Resource { get; private set; }
        public string Method { get; private set; }
        public string ApiVersion { get; private set; }
        public int Code { get; private set; }
    }
}