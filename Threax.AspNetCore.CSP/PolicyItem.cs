using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    public class PolicyItem
    {
        public PolicyItem()
        {
            
        }

        /// <summary>
        /// Set this to true to include 'self' in this policy. This will allow
        /// connections back to the site that served the content. Default: true.
        /// </summary>
        public bool IncludeSelf { get; set; } = true;

        /// <summary>
        /// Set this to true to include 'self' in this policy. This will allow
        /// connections back to the site that served the content. Default: true.
        /// </summary>
        public PolicyItem SetIncludeSelf(bool value)
        {
            this.IncludeSelf = value;
            return this;
        }

        /// <summary>
        /// Set this to true to include 'unsafe-inline' in the policy. This allows
        /// inline elements on the page for this policy type. Default: false.
        /// </summary>
        public bool IncludeUnsafeInline { get; set; } = false;

        /// <summary>
        /// Set this to true to include 'unsafe-inline' in the policy. This allows
        /// inline elements on the page for this policy type. Default: false.
        /// </summary>
        public PolicyItem SetIncludeUnsafeInline(bool value)
        {
            this.IncludeUnsafeInline = value;
            return this;
        }

        /// <summary>
        /// Any additional entries you want to include, this can be any supported
        /// value.
        /// </summary>
        public List<String> Entries { get; set; }

        /// <summary>
        /// Any additional entries you want to include, this can be any supported
        /// value.
        /// </summary>
        public PolicyItem SetEntries(IEnumerable<String> value)
        {
            this.Entries = value.ToList();
            return this;
        }

        /// <summary>
        /// Set a list of styles that will be hashed and included in the policy. This way
        /// you can specify inline styles if you don't want it to be unlimited by setting
        /// IncludeUnsafeInline to true. Default: null.
        /// </summary>
        //public List<String> InlineStyles { get; set; }

        public override sealed string ToString()
        {
            var sb = new StringBuilder(1024);
            if (IncludeSelf)
            {
                sb.Append("'self' ");
            }
            if (IncludeUnsafeInline)
            {
                sb.Append("'unsafe-inline' ");
            }
            if(Entries != null)
            {
                foreach(var entry in Entries)
                {
                    sb.Append(entry);
                    sb.Append(" ");
                }
            }

            //Hash inline here

            return sb.ToString(0, sb.Length > 0 ? sb.Length - 1 : 0);
        }
    }
}
