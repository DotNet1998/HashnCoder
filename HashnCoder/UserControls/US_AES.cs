using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using ScrollBars = System.Windows.Forms.ScrollBars;

namespace HashnCoder.UserControls
{
    public partial class US_AES : UserControl
    {

        public US_AES()
        {
            InitializeComponent();
            encdecode.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на изменения текста вручную в комбо-боксе 
            encdecode.Text = "Encode"; // выбор значения в комбобоксе по умолчанию

            sizeKey.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на изменения текста вручную в комбо-боксе 
            sizeKey.Text = "128"; // выбор значения в комбобоксе по умолчанию

            algoritm.DropDownStyle = ComboBoxStyle.DropDownList; // запрет на изменения текста вручную в комбо-боксе 
            algoritm.Text = "AES-ECB"; // выбор значения в комбобоксе по умолчанию

            vvodKey.Text = "Введите ключ, или сгенерируйте."; //подсказка
            vvod.Text = "\"Привет\""; // текст при по умолчанию  в поле для ввода текста
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
                res.ScrollBars = ScrollBars.Vertical; ; //добавляю перемотку текста вниз вверх

                string vkey = vvodKey.Text;
                var vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 
                byte[] IV = new byte[16]; // юзаю такой же масив байт что и для ключа 
                string text = vvod.Text; // текст 

                // AES - ECB
                //Шифрую - Encode , алгоритм :  AES - ECB
                if (encdecode.Text == "Encode" && sizeKey.Text == "128" && algoritm.Text == "AES-ECB")
                {
                    vkey = vvodKey.Text;  // беру сгенерированый либо введённые ключ в с поля для пользвоателя 

                    vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    text = vvod.Text; // текст 

                    res.Text = Encypt.Encrypt(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (шифрую)
                }

                if (encdecode.Text == "Decode" && sizeKey.Text == "128" && algoritm.Text == "AES-ECB")
                // Дешифрую - Decode  AES - ECB
                {
                    vkey = vvodKey.Text;

                    vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    text = vvod.Text; // текст 

                    res.Text = Encypt.Decrypt(text, vodkey, IV);  // Подаю аршументы в метод класса Encrypt  (дешифрую)
                }


                // AES - CBC
                //Шифрую - Encode , алгоритм :  AES - CBC

                if (encdecode.Text == "Encode" && sizeKey.Text == "128" && algoritm.Text == "AES-CBC")
                {
                    vkey = vvodKey.Text;  // беру сгенерированый либо введённые ключ в с поля для пользвоателя 

                    vodkey = Encoding.UTF8.GetBytes(vkey);

                    text = vvod.Text; // текст                    

                    // подаю AES - CBC
                    res.Text = Encypt.Encrypt(text, vodkey, IV, 128, 128, CipherMode.CBC, PaddingMode.PKCS7); // Подаю аршументы в метод класса Encrypt  (шифрую)
                }

                if (encdecode.Text == "Decode" && sizeKey.Text == "128" && algoritm.Text == "AES-CBC")
                // Дешифрую - Decode  AES - СBC
                {
                    vkey = vvodKey.Text;

                    vodkey = Encoding.UTF8.GetBytes(vkey);//ключ 

                    text = vvod.Text; // текст 

                    // подаю AES - CBC
                    res.Text = Encypt.Decrypt(text, vodkey, IV, 128, 128, CipherMode.CBC, PaddingMode.PKCS7);  // Подаю аршументы в метод класса Encrypt  (дешифрую)
                }
            }
            catch { };


        }

        private void guna2Button3_Click(object sender, EventArgs e) // скопировать
        {
            try
            {
                Clipboard.SetText(res.Text);
            }
            catch { MessageBox.Show("Поле пустое"); }
        }

        private void guna2Button2_Click(object sender, EventArgs e) //вставить
        {
            try
            {
                if (Clipboard.ContainsText() == true)
                {
                    string someText = Clipboard.GetText();
                    vvod.Text += someText;
                }
            }
            catch { MessageBox.Show("Буфер обмена пуст"); }
        }

        private void vvodKey_MouseClick(object sender, MouseEventArgs e) //Подсказка 
        {
            if (vvodKey.Text == "Введите ключ, или сгенерируйте.")
                vvodKey.Clear();  // убераю подсказку после нажатия на поле ввода ключа
        }
    }
}
