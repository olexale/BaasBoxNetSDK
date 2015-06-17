namespace BaasBoxNet
{
    public interface IBaasBox
    {
        string Version { get; }
        string ApiVersion { get; }
        string MinApiVersion { get; }
        IBaasBoxConfig Config { get; }
        IBaasBox InitDefault(IBaasBoxConfig config);
    }
}