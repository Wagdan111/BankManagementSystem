using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
namespace bank_projet
{
    public partial class frmMangerClients : Form
    {
        public frmMangerClients()
        {
            InitializeComponent();
        }
      
        public void ShowClient()
        {
            dgvLastClient.DataSource = Client_CodingMain.ShowListClient();
        }

        public void ShowClientbyOrderAccoutAsc()
        {
            dgvLastClient.DataSource = Client_CodingMain.ShowListClientbyOrderbyAsc();
        }

        public void ShowClientbyOrderAccoutDesc()
        {
            dgvLastClient.DataSource = Client_CodingMain.ShowClientbyOrderAccoutDesc();
        }

        public void FillCombobox()
        {
            DataTable data = Client_CodingMain.ShowListClient();
            foreach(DataRow row  in data.Rows)
            {
                comAccountNumber.Items.Add(row["AccoutNumber"]);
            }
        }


        private void comAccountNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comAccountNumber.Text != "")
            {

                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtEmail.Enabled = true;
                txtPhone.Enabled = true;
                txtPinCode.Enabled = true;
                btnUpdate.Enabled = true;

                numAccountBalace.Enabled = true;

                Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAccountNumber.Text);
                if (Client == null)
                {
                    MessageBox.Show("no");
                }
                else
                {
                    txtPinCode.Text = Client.Pincode;
                    txtFirstName.Text = Client.FirstName;
                    txtLastName.Text = Client.LastName;
                    txtEmail.Text = Client.Email;
                    txtPhone.Text = Client.Phone;
                    numBalance.Value = Client.AccountBalance;
                }

            }
        }

        private void butAddNewClient_Click(object sender, EventArgs e)
        {
            Client_CodingMain client = new Client_CodingMain();


            client.Pincode = textPinCode.Text;
            client.FirstName = textFirstName.Text;
            client.Email = textEmail.Text;
            client.Phone = textPhone.Text;
            client.LastName = textLastName.Text;
            client.AccountBalance = Convert.ToInt32(numAccountBalace.Value);
            client.AccountNumber = textAccounNumber.Text;

            if (client.Save())
            {

                MessageBox.Show("Save Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPinCode.Text = "";
                textAccounNumber.Text = "";
                textFirstName.Text = "";
                textEmail.Text = "";
                textPhone.Text = "";
                textLastName.Text = "";
                numAccountBalace.Value = 0;
                ShowClient();
            }
            else
            {
                MessageBox.Show("Failed to Save");
            }
        }
        void EnadelBtn1()
        {
            if (textAccounNumber.Text != "" && textLastName.Text != "" && textEmail.Text != "" && textPhone.Text != "" && textFirstName.Text != "" && textPinCode.Text != "" && numAccountBalace.Value != 0)
                butAddNewClient.Enabled = true;
            else
                butAddNewClient.Enabled = false;
        }

        private void textAccounNumber_TextChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void textPinCode_TextChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void textFirstName_TextChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void textLastName_TextChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void textPhone_TextChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void numAccountBalace_ValueChanged(object sender, EventArgs e)
        {
            EnadelBtn1();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Client_CodingMain Client = Client_CodingMain.FindbyAccountNumber(comAccountNumber.Text);

            if (Client == null)
            {
                MessageBox.Show("no");
            }

            Client.Pincode = txtPinCode.Text;
            Client.FirstName = txtFirstName.Text;
            Client.LastName = txtLastName.Text;
            Client.Email = txtEmail.Text;
            Client.Phone = txtPhone.Text;
            numAccountBalace.Value = Client.AccountBalance;
            if (Client.Save())
            {
                MessageBox.Show("Update Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowClient();
            }

            else
            {
                MessageBox.Show("Failed to Save");
            }
        }

        private void BtnBack_Click_2(object sender, EventArgs e)
        {
            Form frmServices = new frmServices();
            frmServices.Show();
            this.Close();
        }

        private void textFindClientByName_TextChanged(object sender, EventArgs e)
        {
            dgvLastClient.DataSource = Client_CodingMain.SearcehByName(textFindClientByName.Text);
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            ShowClientbyOrderAccoutDesc();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ShowClientbyOrderAccoutAsc();
        }

        private void Manger_Clients_Load(object sender, EventArgs e)
        {
            FillCombobox();
            lbPassword.Text = UserInfo.UserName;
            lbCurrentUser.Text=UserInfo.Password;
            lbCountClients.Text = Client_CodingMain.CountsClients()+"Client(s) Found";
           ShowClient();
           
           
        }
    }
}
