using System;
using System.Text;
using System.Security.Cryptography;

namespace HashnCoder
{
    internal class Encypt

    {
        //Шифрую - Encrypt       //AES - ECB                                                                                              //AES- ECB
        public static string Encrypt(string text, byte[] key, byte[] iv, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.BlockSize = blocksize;
                aes.KeySize = keysize;
                aes.Mode = cipher;
                aes.Padding = padding;

                byte[] src = Encoding.UTF8.GetBytes(text);
                using (ICryptoTransform encrypt = aes.CreateEncryptor(key, iv))
                {
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                    encrypt.Dispose();
                    return Convert.ToBase64String(dest);
                }
            }
            catch { return "Извените, произошла непредвиденная ошибка, перезапустите программу"; };
        }



        // Дешифрую - Decrypt        //AES - ECB                                                                                        //AES- ECB
        public static string Decrypt(string text, byte[] key, byte[] iv, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.BlockSize = blocksize;
                aes.KeySize = keysize;
                aes.Mode = cipher;
                aes.Padding = padding;

                byte[] src = Convert.FromBase64String(text);
                using (ICryptoTransform decrypt = aes.CreateDecryptor(key, iv))
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    decrypt.Dispose();
                    return Encoding.UTF8.GetString(dest); //Заполнение недействительно и не может быть удалено.
                }
            }
            catch { return "Извените, произошла непредвиденная ошибка, перезапустите программу"; };

        }


      

    }
}
