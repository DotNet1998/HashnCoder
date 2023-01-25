using System;
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
using Org.BouncyCastle.Crypto.Generators;

namespace HashnCoder.UserControls
{
    public partial class US_AES : UserControl
    {
        public US_AES()
        {
            InitializeComponent();
        }
        public static Random rnd = new Random((int)DateTime.Now.Ticks); // Боссовский рандом
        private void guna2Button4_Click(object sender, EventArgs e) //GENERATE KEY
        {
            key(); // вызываю метод чтоб сгенерировать ключ 
        }

        public string key()  // метод для генерирования ключа и передаю этот ключ в кнопку Encode
        {
            byte[] key = new byte[16];
            rnd.NextBytes(key);
            vvodKey.Text = BitConverter.ToString(key).Replace("-", String.Empty).ToLower();
            return key.ToString();
        }

        public void guna2Button1_Click(object sender, EventArgs e) // Encode 
        {
            //Шифрую - Encode
            if (encdecode.Text == "Encode" && sizeKey.Text == "128")
            {
                string vkey = vvodKey.Text;

                var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 


                string text = vvod.Text; // текст 

                res.Text = Encypt.Encryptt(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (шифрую)
            }
            if (encdecode.Text == "Decode" && sizeKey.Text == "128")
            // Дешифрую - Decode 
            {
                string vkey = vvodKey.Text;

                var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 


                string text = vvod.Text; // текст 

                res.Text = Encypt.Decrypt(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (дешифрую)
            }


        }

    }
}
