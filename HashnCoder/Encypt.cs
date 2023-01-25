﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using System.Net.Sockets;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Ocsp;

namespace HashnCoder
{
    internal class Encypt


    {

        //Шифрую - Encrypt       //AES - ECB                                                                                              //AES- ECB
        public static string EncryptECB(string text, byte[] key, byte[] iv, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
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



        // Дешифрую - Decrypt        //AES - ECB                                                                                        //AES- ECB
        public static string DecryptECB(string text, byte[] key, byte[] iv, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
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
                return Encoding.UTF8.GetString(dest); //Padding is invalid and cannot be removed. 
            }



        }


        //Шифрую - Encrypt      //AES- CBC                                                                                            //AES- CBC
        public static string EncryptCBC(string text, byte[] key, byte[] iv, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
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

        // Дешифрую - Decrypt           //AES- CBC                                                                                     //AES- CBC
        public static string DecryptCBC(string text, byte[] key, byte[] iv, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
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
                return Encoding.UTF8.GetString(dest); //Padding is invalid and cannot be removed. 
            }



        }



    }
}