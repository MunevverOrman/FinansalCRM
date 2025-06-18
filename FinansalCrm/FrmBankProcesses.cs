using FinansalCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansalCrm
{
    public partial class FrmBankProcesses : Form
    {
        public FrmBankProcesses()
        {
            InitializeComponent();
        }

        FinansalCrmEntities1 db = new FinansalCrmEntities1();
        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            var values = db.Banks.ToList();
            dataGridView1.DataSource = values;
            cmbBankType.DataSource = values;




        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Banks.ToList();
            dataGridView1.DataSource = values;

        }

        private void btn_Click(object sender, EventArgs e)
        {
            string description = txtBankProcessDescription.Text;
            DateTime processDate = DateTime.Parse(dtpBankProcessDate.Text);
            string processType = txtBankProcessType.Text;
            decimal amount = decimal.Parse(txtBankProcessAmount.Text);
            BankProcesses bankProcesses = new BankProcesses();
            db.BankProcesses.Add(bankProcesses);
            bankProcesses.Description = description;
            bankProcesses.ProcessDate = processDate;
            bankProcesses.ProcessType = processType;
            bankProcesses.Amount = amount;
            bankProcesses.BankId = int.Parse(cmbBankType.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Banka Harekeeti Başarılı Bir Şekilde Sisteme Eklendi", "Banka Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;



        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string descriptipn = txtBankProcessDescription.Text;
            DateTime processDate = DateTime.Parse(dtpBankProcessDate.Text);
            string processType = txtBankProcessType.Text;
            decimal amount = decimal.Parse(txtBankProcessAmount.Text);

            int id = int.Parse(txtBankProcessId.Text);
            var updatedValue = db.BankProcesses.Find(id);
            updatedValue.Description = descriptipn;
            updatedValue.ProcessDate = processDate;
            updatedValue.ProcessType = processType;
            updatedValue.Amount = amount;
            updatedValue.BankId = int.Parse(cmbBankType.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Banka Hareketi Başarılı Bir Şekilde Güncellendi", "Banka Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.BankProcesses.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBankProcessId.Text);
            var removeValue = db.BankProcesses.Find(id);
            db.BankProcesses.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı şekilde sistemden silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnBills_Click(object sender, EventArgs e)
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

        private void btnSettings_Click(object sender, EventArgs e)
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
