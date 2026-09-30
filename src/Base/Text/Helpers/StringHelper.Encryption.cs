namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;

    public static partial class StringHelper
    {
        /// <summary>
        /// Gets the crypt key.
        /// </summary>
        /// <value>The crypt key.</value>
        private static byte[] cryptKey
        {
            get
            {
                return new byte[]
				{
					0x0E,
					0x41,
					0x6A,
					0x29,
					0x94,
					0x12,
					0xEB,
					0x63
				};
            }
        }        

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <see href="http://www.codeproject.com/dotnet/encryption_decryption.asp" />
        /// <see href="http://dobon.net/vb/dotnet/string/encryptstring.html" />
        public static string EncryptString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            else
            {
                byte[] bytIn = Encoding.UTF8.GetBytes(source);

                // create a MemoryStream so that the process can be done without I/O files
                using (MemoryStream ms = new MemoryStream())
                {
                    using (DESCryptoServiceProvider mobjCryptoService =
                         new DESCryptoServiceProvider())
                    {
                        byte[] bytKey = cryptKey;

                        // set the private key
                        mobjCryptoService.Key = bytKey;
                        mobjCryptoService.IV = bytKey;

                        // create an Encryptor from the Provider Service instance
                        using (ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor())
                        {
                            // create Crypto Stream that transforms a stream using the encryption
                            using (CryptoStream cs = new CryptoStream(
                                ms,
                                encrypto,
                                CryptoStreamMode.Write))
                            {
                                // write out encrypted content into MemoryStream
                                cs.Write(bytIn, 0, bytIn.Length);
                                cs.FlushFinalBlock();

                                // http://www.codeproject.com/dotnet/encryption_decryption.asp?msg=749582#xx749582xx
                                byte[] byteOut = ms.GetBuffer();
                                return System.Convert.ToBase64String(
                                    byteOut,
                                    0,
                                    (int)ms.Length);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Decrypt a previously encrypted string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <see href="http://www.codeproject.com/dotnet/encryption_decryption.asp" />
        /// <see href="http://dobon.net/vb/dotnet/string/encryptstring.html" />
        public static string DecryptString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            else
            {
                // convert from Base64 to binary
                byte[] bytIn = Convert.FromBase64String(source);
                // create a MemoryStream with the input
                using (MemoryStream ms = new MemoryStream(
                    bytIn,
                    0,
                    bytIn.Length))
                {
                    byte[] bytKey = cryptKey;

                    // set the private key.
                    using (DESCryptoServiceProvider mobjCryptoService =
                        new DESCryptoServiceProvider())
                    {
                        mobjCryptoService.Key = bytKey;
                        mobjCryptoService.IV = bytKey;

                        // create a Decryptor from the Provider Service instance
                        using (ICryptoTransform encrypto =
                            mobjCryptoService.CreateDecryptor())
                        {
                            // create Crypto Stream that transforms a 
                            // stream using the decryption
                            using (CryptoStream cs = new CryptoStream(
                                ms,
                                encrypto,
                                CryptoStreamMode.Read))
                            {
                                // read out the result from the Crypto Stream
                                using (StreamReader sr = new StreamReader(
                                    cs,
                                    Encoding.UTF8))
                                {
                                    return sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
