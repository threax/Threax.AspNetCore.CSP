namespace Threax.AspNetCore.CSP
{
    public interface INonceProvider
    {
        string GetNonce();
    }
}