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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bank_projet
{
    public partial class frmCurrencys : Form
    {
        public frmCurrencys()
        {
            InitializeComponent();
        }

        public void FillCombox()
        {
           DataTable dataTable= clsCurrencyBL.ShowCurrency();

            foreach (DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["Code"]);
                comNameCode1.Items.Add(row["Code"]);
                comNameCode2.Items.Add(row["Code"]);
            }
        }
        private void frmCurrencys_Load(object sender, EventArgs e)
        {
           FillCombox();
            dataGridView1.DataSource = clsCurrencyBL.ShowCurrency();
            this.ShowIcon = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            comboBox1.SelectedIndex = 0;
            comNameCode1.SelectedIndex = 0;
            comNameCode2.SelectedIndex=1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsCurrencyBL.SearcehByCode(txtFiliterValue.Text);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            clsCurrencyBL currency = clsCurrencyBL.FindbyCode(comboBox1.Text);
            if (currency == null)
            {
                MessageBox.Show("nu");
            }
            else
            {
                panel1.Visible = true;
                lbCountry.Text = currency.Country;
                lbCode.Text = currency.Code;
                lbName.Text = currency.Name;
                lbRoat.Text = currency.Rote.ToString();
            }
        }

        private void comNameCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsCurrencyBL currency = clsCurrencyBL.FindbyCode(comNameCode1.Text);
            if (currency == null)
            {
                MessageBox.Show("null");
            }
            else
            {
                panel2.Visible = true;
                lbtP3CountryFrom.Text = currency.Country;
                lbtP3CodeFrom.Text = currency.Code;
                lbtP3NameFrom.Text = currency.Name;
                lbtP3RoatFrom.Text = currency.Rote.ToString();
            }
        }

        private void comNameCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsCurrencyBL currency = clsCurrencyBL.FindbyCode(comNameCode2.Text);
            if (currency == null)
            {
                MessageBox.Show("nu");
            }
            else
            {
                panel3.Visible = true;
                lbtP3CountryTo.Text = currency.Country;
                lbtP3CodeTo.Text = currency.Code;
                lbtP3NameTo.Text = currency.Name;
                lbtP3RoatTo.Text = currency.Rote.ToString();
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clsCurrencyBL currency = clsCurrencyBL.FindbyCode(comboBox1.Text);
            
            if (currency == null)
            {
                MessageBox.Show("nu");
            }
            else
            {
                currency.Rote = Convert.ToInt32(numValueNewRoat.Value);
                if (currency.Save())
                {
                    MessageBox.Show("Save Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lbRoat.Text = currency.Rote.ToString();
                }
                else
                {
                    MessageBox.Show("no");
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
           MessageBox.Show("This action has not been implemented yet.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
