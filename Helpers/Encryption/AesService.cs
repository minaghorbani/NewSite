using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace  Helpers.Encryption
{
    public class AesService
    {
        public static string EncryptStringToBytes_Aes(string input, byte[] key, byte[] iV)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("input");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iV == null || iV.Length <= 0)
                throw new ArgumentNullException("iV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            string encryptedStr = Convert.ToBase64String(encrypted);
            return encryptedStr;
        }

        public static string DecryptStringFromBytes_Aes(string encryptedStr, byte[] key, byte[] iV)
        {
            byte[] encrypted = Convert.FromBase64String(encryptedStr);

            if (encrypted == null || encrypted.Length <= 0)
                throw new ArgumentNullException("encrypted");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iV == null || iV.Length <= 0)
                throw new ArgumentNullException("iV");

            string orginalText = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encrypted))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            orginalText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return orginalText;
        }
    }
}