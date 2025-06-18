using FinansalCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;



namespace FinansalCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        FinansalCrmEntities1 db = new FinansalCrmEntities1();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //banka bakiyeleri
            var ziraatBankBalance=db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıfbank").Select(x => x.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(x => x.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString()+ "₺";
            lblVakıfBankBalance.Text = vakifBankBalance.ToString() + "₺";
            lblİsBankBalance.Text = isBankBalance.ToString() + "₺";

            //banka hareketleri

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();//sondan ilk bir kaydı alır yoksa null döner
            lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + "₺ "  + bankProcess1.ProcessDate;
            
            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();// ilk iki tanesini getir skiple 1. yi atla demiş olduk.sondan 2. yi alır
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + "₺ " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();// ilk iki tanesini getir skiple 1. yi atla demiş olduk
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + "₺ " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();// ilk iki tanesini getir skiple 1. yi atla demiş olduk
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + "₺ " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();// ilk iki tanesini getir skiple 1. yi atla demiş olduk
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + "₺ " + bankProcess5.ProcessDate;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {

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
