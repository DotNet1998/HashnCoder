using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace HashnCoder.UserControls
{
    public partial class US_Encoding : UserControl
    {
        public US_Encoding()
        {
            InitializeComponent();
            algoritm.Text = "Base64";
            encdecode.Text = "Encode";
            vvod.Text = "Привет";
        }

        private void encodeGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (algoritm.Text == "Base64" && encdecode.Text == "Encode")    // кодирую текст  в Base64
                {
                    string vvodText = vvod.Text;
                    var vvodTextByte = Encoding.UTF8.GetBytes(vvodText);
                    string enText = Convert.ToBase64String(vvodTextByte);

                    res.Text = enText;

                }

                if (algoritm.Text == "Base64" && encdecode.Text == "Decode") // роскодирую текст из Base64 в обычный 
                {
                    string enText = vvod.Text;
                    var enTextBytes = Convert.FromBase64String(enText);
                    string deText = Encoding.UTF8.GetString(enTextBytes);

                    res.Text = deText;
                }

                if (algoritm.Text == "UrlEncode" && encdecode.Text == "Encode")
                {
                  res.Text =  HttpUtility.UrlEncode(vvod.Text);             // кодирую текс в UrlEncode
                }

                if (algoritm.Text == "UrlEncode" && encdecode.Text == "Decode")
                {
                    res.Text = HttpUtility.UrlDecode(vvod.Text);
                }









            }
            catch { }

        }
    }
}
