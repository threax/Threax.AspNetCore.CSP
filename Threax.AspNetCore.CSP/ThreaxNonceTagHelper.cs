using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    [HtmlTargetElement(Attributes = "csp-nonce")]
    public class ThreaxNonceTagHelper : TagHelper
    {
        private INonceProvider nonceProvider;

        public ThreaxNonceTagHelper(INonceProvider nonceProvider)
        {
            this.nonceProvider = nonceProvider;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("csp-nonce");
            output.Attributes.Add("nonce", new HtmlString(nonceProvider.GetNonce()));
        }
    }
}
