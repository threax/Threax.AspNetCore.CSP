namespace Threax.AspNetCore.CSP
{
    public interface ICspHeaderWriter
    {
        void AddContentSecurityPolicy(CSPOptions cspOptions);
    }
}