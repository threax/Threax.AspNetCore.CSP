using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    class NonceProvider : INonceProvider
    {
        private int nonceSize;
        private String nonce = null;

        public NonceProvider(int nonceSize)
        {
            this.nonceSize = nonceSize;
        }

        public String GetNonce()
        {
            if (nonce == null)
            {
                using (var rng = RNGCryptoServiceProvider.Create())
                {
                    var bytes = new byte[nonceSize];
                    rng.GetBytes(bytes);

                    nonce = Convert.ToBase64String(bytes);
                }
            }
            return nonce;
        }
    }
}
