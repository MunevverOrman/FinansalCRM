using FinansalCrm.Models;
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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }

        FinansalCrmEntities1 db = new FinansalCrmEntities1();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var values = db.CategoryDb.ToList();
            dataGridView1.DataSource = values;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var values = db.CategoryDb.ToList();
            dataGridView1.DataSource = values;


        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            CategoryDb category = new CategoryDb();
            category.CategoryName = categoryName;
            db.CategoryDb.Add(category);
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı şekilde eklendi", "Kategori İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.CategoryDb.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);
            var values = db.CategoryDb.Find(id);
            values.CategoryName = categoryName;
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı şekilde güncellendi", "Kategori İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var updatedValues = db.CategoryDb.ToList();
            dataGridView1.DataSource = updatedValues;

        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.CategoryDb.Find(id);
            db.CategoryDb.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı şekilde silindi", "Kategori İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            var values = db.CategoryDb.ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide(); // Mevcut formu gizle
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide(); // Mevcut formu gizle

        }

        private void btnBliilsForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnSpendings_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcesses_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.Show();
        }
    }
}
