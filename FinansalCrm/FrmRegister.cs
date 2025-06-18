using FinansalCrm.Models;
using FinansalCrm;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansalCrm
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }
        FinansalCrmEntities1 db = new FinansalCrmEntities1();

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            bool isUser = db.Users.Any(u => u.Username == username); //Kullanıcı kontrolü
            if (isUser == false)
            {
                if (username != "" && password != "" && username != "Kullanıcı Adı" && password != "Şifre")
                {
                    Users user = new Users();
                    user.Username = username;
                    user.Password = password;
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Hesabınız Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmLogin frm = new FrmLogin();
                    frm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Eksik bir tuşlama yapıldı.\nTekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı sistemde mevcuttur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}