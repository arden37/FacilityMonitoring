using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacilityMonitoring
{
    public partial class frmcollege : Form
    {
        public frmcollege()
        {
            InitializeComponent();
        }

        private void btncomsci_Click(object sender, EventArgs e)
        {
            frmcomscifacilities comsci = new frmcomscifacilities("");
            comsci.Show();
            this.Hide();
        }

        private void btnfm_Click(object sender, EventArgs e)
        {

        }

        private void frmcollege_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
