using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank_projet
{
    public partial class frmClientsTransatctions : Form
    {
        public frmClientsTransatctions()
        {
            InitializeComponent();
        }
        private void frmClientsTransatctions_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
           
            FillCombox();
            labPassword.Text = UserInfo.Password;
             labUserName.Text = UserInfo.UserName;

            dataGridView1.DataSource = Client_CodingMain.ShowAccoutNumber();
            lbCountClients.Text = Client_CodingMain.CountsClients() + "Client(s) Found";
            lbTotalBalance.Text = clsCurrencyBL.SumAccountBalance().ToString();
            comAcountNumber.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comAccounNumberFrom.SelectedIndex = 0;
            comAccounNumberTo.SelectedIndex = 1;
        }

        public void FillCombox()
        {
            DataTable data = Client_CodingMain.ShowListClient();
            foreach(DataRow row in  data.Rows)
            {
                comAcountNumber.Items.Add(row["AccoutNumber"]);
                comboBox2.Items.Add(row["AccoutNumber"]);
                comAccounNumberTo.Items.Add(row["AccoutNumber"]);
                comAccounNumberFrom.Items.Add(row["AccoutNumber"]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAcountNumber.Text);
            if (Client == null)
            {
                MessageBox.Show("no");
            }
            label3.Visible = true;

            label3.Text = "$" + Client.AccountBalance;


        }
       
        private void butDeposiite_Click(object sender, EventArgs e)
        {
            string Deposite1= label3.Text.Substring(1, label3.Text.Length - 1);
            int a = 0;
            int b = 0;
            int Deposite = 0;
            a = Convert.ToInt32(Deposite1);
            b = Convert.ToInt32(numericUpDown1.Value);
            Deposite =a+b ;
            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAcountNumber.Text);
            if (Client == null)
            {
                MessageBox.Show("no");
            }
            Client.AccountBalance= Deposite;

            if(Client.Save())
            {
                MessageBox.Show("Deposited successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                label3.Text = "$" + Client.AccountBalance;
            }

            else 
            {
                MessageBox.Show("Failed to Save.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string WithDrow = label6.Text.Substring(1, label6.Text.Length - 1);
            int a = 0;
            int b = 0;
            int Deposite = 0;
            a = Convert.ToInt32(WithDrow);
            b = Convert.ToInt32(numericUpDown2.Value);
            Deposite = a - b;
            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comboBox2.Text);
            if (Client == null)
            {
                MessageBox.Show("no");
            }
            Client.AccountBalance = Deposite;

            if (Client.Save())
            {

                MessageBox.Show("Withdrawn successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label6.Text = "$" + Client.AccountBalance;
            }

            else
            {
                MessageBox.Show("Failed to Save.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comboBox2.Text);
            if (Client == null)
            {
                MessageBox.Show("no");
            }
            label6.Visible = true;

            label6.Text = "$" + Client.AccountBalance;
        }

        private void textFindClientByName_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Client_CodingMain.SearcehAccountNumberByName(textFindClientByName.Text);
        }

        private void comAccounNumberFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAccounNumberFrom.Text);
            if (Client == null)
            {
                MessageBox.Show("no");
            }
            lbBalanceFrom.Visible = true;
            lbBalanceFrom.Text = Client.AccountBalance.ToString();
        }

        private void comAccounNumberTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAccounNumberTo.Text);
            if (Client == null)
            {
                MessageBox.Show("no");
            }
            lbBalanceTo.Visible = true;
            lbBalanceTo.Text = Client.AccountBalance.ToString();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
         //   int Deposite = 0;
            a = Convert.ToInt32(lbBalanceFrom.Text);
            a-= Convert.ToInt32(numericUpDown3.Value);
            b = Convert.ToInt32(lbBalanceTo.Text);
            b+= Convert.ToInt32(numericUpDown3.Value);
           // Deposite = a - b;
            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAccounNumberTo.Text);
            Client_CodingMain Client2 = Client_CodingMain.FindbyAccountNumber(comAccounNumberFrom.Text);
            if (Client == null&& Client2 == null)
            {
                MessageBox.Show("no");
            }
            Client.AccountBalance = b;
            Client2.AccountBalance = a;

            if (Client.Save()&& Client2.Save())
            {

                MessageBox.Show("Save successfully.");
                lbBalanceFrom.Text = Client2.AccountBalance.ToString();

                lbBalanceTo.Text = Client.AccountBalance.ToString();
            }

            else
            {
                MessageBox.Show("Failed to Save.");
            }
        }

    }
}
