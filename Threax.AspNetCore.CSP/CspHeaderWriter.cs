using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    public class CspHeaderWriter : ICspHeaderWriter
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly INonceProvider nonceProvider;

        public CspHeaderWriter(IHttpContextAccessor contextAccessor, INonceProvider nonceProvider)
        {
            this.contextAccessor = contextAccessor;
            this.nonceProvider = nonceProvider;
        }

        public void AddContentSecurityPolicy(CSPOptions cspOptions)
        {
            var csp = cspOptions.ToString();
            if (cspOptions.HasNonce)
            {
                csp = csp.Replace("'nonce-'", $"'nonce-{nonceProvider.GetNonce()}'");
            }
            contextAccessor.HttpContext.Response.Headers.Add("Content-Security-Policy", csp);
        }
    }
}
