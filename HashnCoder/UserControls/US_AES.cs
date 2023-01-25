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
            byte[] key = new byte[16]; // создаю масив байт с розмерм 128 бит 
            rnd.NextBytes(key); // заполняю его рандомными битами 
            vvodKey.Text = BitConverter.ToString(key).Replace("-", String.Empty).ToLower(); // вывожу в поле для ключа перевожу в стринг 
            return key.ToString(); // возрощаю ключ в с стринг формате 
        }

        public void guna2Button1_Click(object sender, EventArgs e) // Encode  
        {
            try
            {
                // AES - ECB
                //Шифрую - Encode , алгоритм :  AES - ECB
                if (encdecode.Text == "Encode" && sizeKey.Text == "128" && algoritm.Text == "AES-ECB")
                {
                    string vkey = vvodKey.Text;  // беру сгенерированый либо введённые ключ в с поля для пользвоателя 

                    var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 


                    string text = vvod.Text; // текст 

                    res.Text = Encypt.EncryptECB(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (шифрую)
                }
                if (encdecode.Text == "Decode" && sizeKey.Text == "128" && algoritm.Text == "AES-ECB")
                // Дешифрую - Decode  AES - ECB
                {
                    string vkey = vvodKey.Text;

                    var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 


                    string text = vvod.Text; // текст 

                    res.Text = Encypt.DecryptECB(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (дешифрую)
                }


                // AES - CBC
                //Шифрую - Encode , алгоритм :  AES - CBC

                if (encdecode.Text == "Encode" && sizeKey.Text == "128" && algoritm.Text == "AES-CBC")
                {
                    string vkey = vvodKey.Text;  // беру сгенерированый либо введённые ключ в с поля для пользвоателя 

                    var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 


                    string text = vvod.Text; // текст 

                    res.Text = Encypt.EncryptCBC(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (шифрую)
                }
                if (encdecode.Text == "Decode" && sizeKey.Text == "128" && algoritm.Text == "AES-CBC")
                // Дешифрую - Decode  AES - ECB
                {
                    string vkey = vvodKey.Text;

                    var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 


                    string text = vvod.Text; // текст 

                    res.Text = Encypt.DecryptCBC(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (дешифрую)
                }
            }
             catch { };


        }

    }
}
