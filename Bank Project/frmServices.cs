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
    public partial class frmServices : Form
    {
        public frmServices()
        {
            InitializeComponent();
            this.FormClosing += frmServices_FormClosing;
        }
        private void frmServices_Load(object sender, EventArgs e)
        { 
            lbUser.Text = UserInfo.UserName;
            lbPassword.Text = UserInfo.Password;
        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            Form frmMangerClients = new frmMangerClients();
            frmMangerClients.Show();
        }

        private void btnClientsTransction_Click(object sender, EventArgs e)
        {
            Form frmClientsTransatctions = new frmClientsTransatctions();
            frmClientsTransatctions.Show();
        }

        private void btnCurrencyExchange_Click(object sender, EventArgs e)
        {
            Form frmCurrencys = new frmCurrencys();
            frmCurrencys.Show();

        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            Form frmMangerUsers = new frmMangerUsers();
            frmMangerUsers.Show();
        }

        private void frmServices_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserInfo.frmLogin.Close();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            UserInfo.frmLogin.Show();
            this.Close();
            
        }
    }
}
