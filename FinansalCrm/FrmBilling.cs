using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinansalCrm.Models;

namespace FinansalCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinansalCrmEntities1 db = new FinansalCrmEntities1();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values=db.Bills.ToList();
            dataGridView1.DataSource = values;



        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            string title =txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period=txtBillPeriod.Text;


            Bills bill = new Bills();
            bill.BillTitle = title;
            bill.BillAmount = amount;
            bill.BillPeriod = period;
            db.Bills.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı şekilde sisteme eklendi","Ödeme & Faturalar", MessageBoxButtons.OK,MessageBoxIcon.Information);

            var values=db.Bills.ToList();
            dataGridView1.DataSource = values;


        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtBillId.Text);
            var removeValue = db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı şekilde sistemden silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            int id = int.Parse(txtBillId.Text);

            var values=db.Bills.Find(id);

           
            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı şekilde sistemde güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.Bills.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide(); // Mevcut formu gizle

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void btnBanks_Click(object sender, EventArgs e)
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
