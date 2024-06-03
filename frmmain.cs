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
    public partial class frmmain : Form
    {
        public String username, usertype;

        public void frmmain_Load(object sender, EventArgs e)
        {
            lblusername.Text = "Username: " + username;
            lblusertype.Text = "Usertype: " + usertype;
            if (usertype == "User")
            {
                frmcomscifacilities comsci = new frmcomscifacilities("");
                comsci.groupBox1.Visible = false;
                accountsToolStripMenuItem.Visible = false;
                collegeToolStripMenuItem.Visible = true;
                juniorHighSchoolToolStripMenuItem.Visible = true;
                seniorHighSchoolToolStripMenuItem.Visible = true;
                elementaryToolStripMenuItem.Visible = true;
                commonAreasToolStripMenuItem.Visible = true;
              
            }
            else if (usertype == "Technical")
            {
                frmcomscifacilities comsci = new frmcomscifacilities("");
                comsci.groupBox1.Show();
                accountsToolStripMenuItem.Visible = false;
                collegeToolStripMenuItem.Visible = false;
                juniorHighSchoolToolStripMenuItem.Visible = false;
                seniorHighSchoolToolStripMenuItem.Visible = false;
                elementaryToolStripMenuItem.Visible =false;
                commonAreasToolStripMenuItem.Visible = false;
         
            }
            else
            {
                accountsToolStripMenuItem.Visible = true;
                collegeToolStripMenuItem.Visible = false;
                juniorHighSchoolToolStripMenuItem.Visible = false;
                seniorHighSchoolToolStripMenuItem.Visible = false;
                elementaryToolStripMenuItem.Visible = false;
                commonAreasToolStripMenuItem.Visible = false;

            }
        }

       

   

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
                this.Hide();
            frmlogin login = new frmlogin();
            login.Show();
            frmaccounts acc = new frmaccounts("");
            acc.Hide();
            frmlogs logs = new frmlogs("");
            logs.Hide();


        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccounts accounts = new frmaccounts(username);
            accounts.Show();
           
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogs logs = new frmlogs(username);
            logs.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcomscifacilities college = new frmcomscifacilities(username);
            college.Show();

        }

        public frmmain(String username, String usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }
    }
}
