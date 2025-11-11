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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace bank_projet
{
    public partial class frmMangerUsers : Form
    {
        public frmMangerUsers()
        {
            InitializeComponent();
        }

        private void frmMangerUsers_Load(object sender, EventArgs e)
        {
            dgvListUser.DataSource = clsUsersBL.ShowLastUsers();
         
        }

        public void ResetUser()
        {
            dgvListUser.DataSource = clsUsersBL.ShowLastUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

            clsUsersBL User = new clsUsersBL();

            User.UserName = txtUserName.Text;
            User.FirstName = txtFirtName.Text;
            User.LastName = txtLastName.Text;
            User.Password = textPassword.Text;
            User.Parmeter =int.Parse( txtPermissions.Text);
            User.Phone = txtPhone.Text;

            if(User.Save())
            {
                MessageBox.Show("Save Successfully.");
                ResetUser();
            }
            else
                MessageBox.Show(" Dont Save Successfully.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnUpdate.BackColor = Color.CornflowerBlue;

            clsUsersBL User = clsUsersBL.FindByPassword(dgvListUser.CurrentRow.Cells[5].Value.ToString());
            if (User == null)
            {
                MessageBox.Show("No Value");
            }
            else
            {

                txtUserName.Text = User.UserName;
                txtFirtName.Text = User.FirstName;
                txtLastName.Text = User.LastName;
                textPassword.Text = User.Password;
                txtPermissions.Text = User.Parmeter.ToString();
                txtPhone.Text = User.Phone;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnDelete.Enabled = true;

            btnDelete.BackColor = Color.Firebrick;  

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clsUsersBL User = clsUsersBL.FindByPassword(dgvListUser.CurrentRow.Cells[5].Value.ToString());
            if (User == null)
            {
                MessageBox.Show("No Value");
            }
            User.UserName = txtUserName.Text;
            User.FirstName = txtFirtName.Text;
            User.LastName = txtLastName.Text;
        
            User.Parmeter = int.Parse(txtPermissions.Text);
            User.Phone = txtPhone.Text;


            if (User.Save())
            {
                MessageBox.Show("Save Successfully","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ResetUser();
            }
            else
                MessageBox.Show(" Dont Save Successfully");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvListUser.DataSource = clsUsersBL.Sheresh(txtFiliterValue.Text);
            btnResetdgv.Visible = true;
        }

        private void btnDataLogin_Click(object sender, EventArgs e)
        {
            Form frmDataLog = new frmDataLog();
            frmDataLog.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUsersBL User1 = clsUsersBL.FindByPassword(dgvListUser.CurrentRow.Cells[5].Value.ToString());
            if (User1 == null)
            {
                MessageBox.Show("No ");
            }
            else
            {
                if (User1.DelteUser(User1.Password))
                {
                    
                    ResetUser();
                }
                else
                {
                    MessageBox.Show("Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
        }

        private void btnResetdgv_Click(object sender, EventArgs e)
        {
            dgvListUser.DataSource = clsUsersBL.ShowLastUsers();
        }

    }
}
