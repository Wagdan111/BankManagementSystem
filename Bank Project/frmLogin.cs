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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsersBL Userinfo = clsUsersBL.FindbyPasswordandUserName(txtPassword.Text, txtUserName.Text);
            if (Userinfo == null)
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                clsDataLogBL data = new clsDataLogBL();
                data.DataLog = DateTime.Now;
                data.UserID = clsUsersBL.FindbyPasswordandUserName(txtPassword.Text, txtUserName.Text).ID;

                if (data.Save())
                {
                    UserInfo.UserName = txtUserName.Text;
                    UserInfo.Password = txtPassword.Text;
                    UserInfo.frmLogin = this;

                    Form frmServices = new frmServices(this);
                    frmServices.Show();
                    this.Hide();
                     
                }

            }

           
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
          
            timer1.Enabled= true;
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString();
        }

       

    }
}
