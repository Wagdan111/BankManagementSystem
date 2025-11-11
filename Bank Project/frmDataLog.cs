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
    public partial class frmDataLog : Form
    {
        public frmDataLog()
        {
            InitializeComponent();
        }

        private void frmDataLog_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDataLogBL.ShowDataLog();
        }

    }
}
