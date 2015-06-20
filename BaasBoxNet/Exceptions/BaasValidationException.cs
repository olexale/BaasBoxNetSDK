namespace BaasBoxNet.Exceptions
{
    public class BaasValidationException : BaasException
    {
        public BaasValidationException()
        {
        }

        public BaasValidationException(string message) : base(message)
        {
        }
    }
}