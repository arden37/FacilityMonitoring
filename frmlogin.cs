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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (chkshowpass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

       

    
        Class1 login = new Class1("127.0.0.1", "cs311malabon", "root ", " ");
        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = login.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "' AND password = '" + txtpassword.Text + "'AND status = 'ACTIVE'");
                //check if there record retrieved
                if (dt.Rows.Count > 0)
                {
                    frmmain main = new frmmain(txtusername.Text, dt.Rows[0].Field<string>("usertype"));
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password or account is disabled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Login button", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


     

     

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }

        private void chkshowpass_CheckedChanged_1(object sender, EventArgs e)
        {
            txtpassword_TextChanged(sender, e);
        }

        private void txtpassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToChar(e.KeyChar) == 13)
            {
                btnlogin_Click_1(sender, e);
            }
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            frmcomscifacilities comscie = new frmcomscifacilities("");
            comscie.Hide();
            frmaccounts acc = new frmaccounts("");
            acc.Hide();
            frmlogs logs = new frmlogs("");
            logs.Hide();
            this.Close();
        }

        private void txtpassword_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
