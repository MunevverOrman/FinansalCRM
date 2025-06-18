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
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }

        FinansalCrmEntities1 db = new FinansalCrmEntities1();
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var values = db.Spending.ToList();
            dataGridView1.DataSource = values;

            var values2 = db.CategoryDb.ToList();
            cmbCategoriId.DataSource = values2;
            cmbCategoriId.DisplayMember = "CategoryName";
            cmbCategoriId.ValueMember = "CategoryId";





        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            var values = db.Spending.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAddSpending_Click(object sender, EventArgs e)
        {
            string SpendingTitle = txtSpendingTitle.Text;
            decimal SpendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime SpendingDate = DateTime.Parse(dtpSpendingDate.Text);
            Spending spending = new Spending();
            db.Spending.Add(spending);
            spending.SpendingTitle = SpendingTitle;
            spending.SpendingAmount = SpendingAmount;
            spending.SpendingDate = SpendingDate;
            spending.CategoryId = int.Parse(cmbCategoriId.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Harcamalar başarılı şekilde sisteme eklendi", "Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Spending.ToList();
            dataGridView1.DataSource = values;





        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            string SpendingTitle = txtSpendingTitle.Text;
            decimal SpendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime SpendingDate = DateTime.Parse(dtpSpendingDate.Text);
            int id = int.Parse(txtSpendingId.Text);
            var updatedValue = db.Spending.Find(id);
            updatedValue.SpendingTitle = SpendingTitle;
            updatedValue.SpendingAmount = SpendingAmount;
            updatedValue.SpendingDate = SpendingDate;
            updatedValue.CategoryId = int.Parse(cmbCategoriId.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Harcama başarılı şekilde güncellendi", "Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Spending.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnRemoveSpending_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            var removeValue = db.Spending.Find(id);
            db.Spending.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Harcama başarılı şekilde silindi", "Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Spending.ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm= new FrmCategories();
            frm.Show();
            this.Hide(); // Mevcut formu gizle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnSpending_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcess_Click(object sender, EventArgs e)
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
