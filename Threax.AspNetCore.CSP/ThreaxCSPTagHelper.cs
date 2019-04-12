using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    public class ThreaxCSPTagHelper : TagHelper
    {
        private CSPString cspString;
        private IHttpContextAccessor contextAccessor;
        private INonceProvider nonceProvider;

        public ThreaxCSPTagHelper(CSPString options, IHttpContextAccessor contextAccessor, INonceProvider nonceProvider)
        {
            this.cspString = options;
            this.contextAccessor = contextAccessor;
            this.nonceProvider = nonceProvider;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var csp = cspString.Value;
            if (cspString.HasNonce)
            {
                csp = csp.Replace("'nonce-'", $"'nonce-{nonceProvider.GetNonce()}'");
            }
            contextAccessor.HttpContext.Response.Headers.Add("Content-Security-Policy", csp);
            output.SuppressOutput();
        }
    }
}
