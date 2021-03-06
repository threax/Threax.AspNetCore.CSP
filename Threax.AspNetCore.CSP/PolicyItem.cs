﻿using System;
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
        /// This will be true if this policy item has a nonce.
        /// </summary>
        internal bool HasNonce { get; set; } = false;

        /// <summary>
        /// Call this to include 'self' in this policy. This will allow
        /// connections back to the site that served the content.
        /// </summary>
        public PolicyItem AddSelf()
        {
            this.Entries.Add("'self'");
            return this;
        }

        /// <summary>
        /// Add 'none'. This makes no urls match.
        /// </summary>
        /// <returns></returns>
        public PolicyItem AddNone()
        {
            this.Entries.Add("'none'");
            return this;
        }

        /// <summary>
        /// Add 'nonce-'. A unique nonce will be generated per request.
        /// </summary>
        /// <returns></returns>
        public PolicyItem AddNonce()
        {
            this.Entries.Add("'nonce-'");
            this.HasNonce = true;
            return this;
        }

        /// <summary>
        /// Call this to include 'unsafe-inline' in the policy. This allows
        /// inline elements on the page for this policy type.
        /// </summary>
        public PolicyItem AddUnsafeInline()
        {
            this.Entries.Add("'unsafe-inline'");
            return this;
        }

        /// <summary>
        /// Call this to include 'unsafe-eval' in the policy. This allows
        /// eval statements to run.
        /// </summary>
        public PolicyItem AddUnsafeEval()
        {
            this.Entries.Add("'unsafe-eval'");
            return this;
        }

        /// <summary>
        /// Add data:. This allows the data protocol.
        /// </summary>
        /// <returns></returns>
        public PolicyItem AddData()
        {
            this.Entries.Add("data:");
            return this;
        }

        /// <summary>
        /// Any additional entries you want to include, this can be any supported
        /// value.
        /// </summary>
        public List<String> Entries { get; set; } = new List<string>();

        /// <summary>
        /// Any additional entries you want to include, this can be any supported
        /// value. This will append the entries to whatever you have added so far.
        /// </summary>
        public PolicyItem AddEntries(params String[] values)
        {
            if (values != null)
            {
                this.Entries.AddRange(values);
            }
            return this;
        }

        /// <summary>
        /// Any additional entries you want to include, this can be any supported
        /// value. This will append the entries to whatever you have added so far.
        /// </summary>
        public PolicyItem AddEntries(IEnumerable<String> values)
        {
            if (values != null)
            {
                this.Entries.AddRange(values);
            }
            return this;
        }

        /// <summary>
        /// Set a list of styles that will be hashed and included in the policy. This way
        /// you can specify inline styles if you don't want it to be unlimited by setting
        /// IncludeUnsafeInline to true. Default: null.
        /// </summary>
        //public PolicyItem AddInlineStyles (Not Implemented)

        public override sealed string ToString()
        {
            var sb = new StringBuilder(1024);

            if(Entries != null)
            {
                foreach(var entry in Entries)
                {
                    sb.Append(entry);
                    sb.Append(" ");
                }
            }

            return sb.ToString(0, sb.Length > 0 ? sb.Length - 1 : 0);
        }
    }
}
