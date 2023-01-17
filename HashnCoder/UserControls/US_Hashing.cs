using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace HashnCoder.UserControls
{
    public partial class US_Hashing : UserControl
    {
        public US_Hashing()
        {
            InitializeComponent();
     
            vvod.Text = "Привет";
        }
    
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string pass = vvod.Text;
            res.ScrollBars = ScrollBars.Horizontal;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            res.Text =  $"MD5: {BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower()}";

            SHA1 sh1 = new SHA1CryptoServiceProvider();
             checkSum = sh1.ComputeHash(Encoding.UTF8.GetBytes(pass));
            res.Text += $"\r\nSHA-1: {BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower()}";

            SHA256 sha256 = new SHA256CryptoServiceProvider();
            checkSum = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            res.Text += $"\r\nSHA256: {BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower()}";

            SHA384 sha384 = new SHA384CryptoServiceProvider();
            checkSum = sha384.ComputeHash(Encoding.UTF8.GetBytes(pass));
            res.Text += $"\r\nSHA384: {BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower()}";

            SHA512 sha512 = new SHA512CryptoServiceProvider();
            checkSum = sha512.ComputeHash(Encoding.UTF8.GetBytes(pass));
            res.Text += $"\r\nSHA512: {BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower()}";
        }

       
    }
}
