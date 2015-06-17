namespace BaasBoxNet.Exceptions
{
    /// <summary>
    ///     A subclass of BaasApiException indicating an error due a wrong
    ///     request. When a BaasClientException is thrown the SDK made an error during
    ///     the request; misspelling the URI or putting a wrong parameter value.
    ///     More info about the error could be found in the class parameters values.
    /// </summary>
    public class BaasClientException
        : BaasApiException
    {
        public BaasClientException(int code, int httpStatus, string resource, string method, string apiVersion,
            string detailMessage) : base(code, httpStatus, resource, method, apiVersion, detailMessage)
        {
        }
    }
}