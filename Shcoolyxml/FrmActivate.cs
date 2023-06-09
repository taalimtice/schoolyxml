using FoxLearn.License;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Schooly
{
    public partial class FrmActivate : Form
    {
        public FrmActivate()
        {
            InitializeComponent();
        }

        string hash = "Yahy Bourihane Schooly";
        private void FrmActivate_Load(object sender, EventArgs e)
        {
            txt_ProductId.Text = ComputerInfo.GetComputerId();
            txt_Key.Text = Properties.Settings.Default.Key;
            txt_creationDate.Text = Properties.Settings.Default.Creation;
            txt_expirationDate.Text = Properties.Settings.Default.Expiration;
            txt_KeyCrypt.Text = Properties.Settings.Default.Key_crypt;
            txt_daysLeft.Text = Properties.Settings.Default.DaysLeft;

     
        }

        private void rbTrial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrial.Checked)
                txt_date.Text = "15";
        }

        private void rbFull_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFull.Checked) 
                txt_date.Text = "700";
        }

        private void btn_Activate_Click(object sender, EventArgs e)
        {
            try
            {


                if (rbTrial.Checked)
                {
                    byte[] data = UTF8Encoding.UTF8.GetBytes(txt_ProductId.Text);
                    using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = mD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                        using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7

                        })
                        {
                            ICryptoTransform transform = triple.CreateEncryptor();
                            byte[] res = transform.TransformFinalBlock(data, 0, data.Length);
                            txt_KeyCrypt.Text = Convert.ToBase64String(res, 0, res.Length);
                            SKGL.Validate val = new SKGL.Validate();
                            val.secretPhase = txt_KeyCrypt.Text;
                            
                            val.Key = txt_Key.Text;
                            if (val.DaysLeft < 0 | val.DaysLeft > 15)
                            {
                                MessageBox.Show("كود التفعيل غير صالح");

                            }else
                            {
                                txt_creationDate.Text = (val.CreationDate).ToString();
                                txt_expirationDate.Text = (val.ExpireDate).ToString();
                                txt_daysLeft.Text = (val.DaysLeft).ToString();
                                MessageBox.Show("Successfull registration with Trial period", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                            }
                           
                           
                        }
                    }

                }
                else
                {
                    byte[] data = UTF32Encoding.UTF32.GetBytes(txt_ProductId.Text);
                    using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = mD5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));
                        using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7

                        })
                        {
                            ICryptoTransform transform = triple.CreateEncryptor();
                            byte[] res = transform.TransformFinalBlock(data, 0, data.Length);
                            txt_KeyCrypt.Text = Convert.ToBase64String(res, 0, res.Length);
                            SKGL.Validate val = new SKGL.Validate();
                            val.secretPhase = txt_KeyCrypt.Text;
                            val.Key = txt_Key.Text;
                            if (val.DaysLeft < 0 | val.DaysLeft > 700)
                            {
                                MessageBox.Show("كود التفعيل غير صالح");
                            }
                            else
                            {
                                txt_creationDate.Text = (val.CreationDate).ToString();
                                txt_expirationDate.Text = (val.ExpireDate).ToString();
                                txt_daysLeft.Text = (val.DaysLeft).ToString();
                                MessageBox.Show("Successfull registration with Full version ", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                            }
                        }
                    }

                }
                Properties.Settings.Default.Key = txt_Key.Text;
                Properties.Settings.Default.Creation = txt_creationDate.Text;
                Properties.Settings.Default.Expiration = txt_expirationDate.Text;
                Properties.Settings.Default.Key_crypt = txt_KeyCrypt.Text;
                Properties.Settings.Default.licType = rbFull.Checked?"FULL":"TRIAL";
                Properties.Settings.Default.DaysLeft = txt_daysLeft.Text;


                Properties.Settings.Default.Save();
                Application.Restart();
            }
            catch (Exception)
            {

                MessageBox.Show("Contact Developper ", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Properties.Settings.Default.Key = "";
                Properties.Settings.Default.Creation = "";
                Properties.Settings.Default.Expiration = "";
                Properties.Settings.Default.Key_crypt = "";
                Properties.Settings.Default.licType = "";

                Properties.Settings.Default.Save();

                Application.Restart();

            }
        }
    }
}
