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
    public partial class frmnewaccount : Form
    {
        private String title, action, username, usertype, login_user;

      
        Class1 newaccounts = new Class1("127.0.0.1", "cs311malabon", "root ", " ");
        public frmnewaccount()
        {
            InitializeComponent();
        }


        private void btnback_Click(object sender, EventArgs e)
        {
            frmaccounts account = new frmaccounts("");
            account.Show();
            this.Hide();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            {
                validateForm();
                countErrors();
                if (errorCount == 0)
                {
                    if (action == "add")
                    {
                        try
                        {
                            cmbstatus.Text = "Active";
                            newaccounts.executeSQL("INSERT INTO tblaccounts (username, password, usertype, status, createdby) VALUES ('" +txtusername.Text + "' , '" + txtpassword.Text + "','" + cmbusertype.Text + "','" + cmbstatus.Text + "','" + login_user + "')");

                            if (newaccounts.rowAffected > 0)
                            {
                                frmmain main = new frmmain("", "");
                                newaccounts.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString("MM-dd-yyyy") + "' , '" +
                                    DateTime.Now.ToLongTimeString() + "' , 'Add' , '" + txtusername.Text + "' ,'" + login_user + "', 'accounts')"); ;
                                MessageBox.Show("Account Added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                frmaccounts accounts = new frmaccounts(login_user);
                                accounts.Show();
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Error on save (add)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //edit
                    else
                    {
                        if (errorCount == 0)
                        {
                            try
                            {

                               
                                newaccounts.executeSQL("UPDATE tblaccounts SET  password = '" + txtpassword.Text + "', usertype = '" + cmbusertype.Text + "' , status = '" + cmbstatus.Text + "' WHERE username ='" + txtusername.Text + "'");


                                if (newaccounts.rowAffected > 0)
                                {
                                    newaccounts.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString("MM-dd-yyyy") + "' , '" +
                                    DateTime.Now.ToLongTimeString() + "' , 'Edit' , '" + txtusername.Text + "' , '" + login_user +
                                    "' , 'Accounts')");
                                    MessageBox.Show("Account Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message, "Error on save (edit)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }


                }

            }
        }

        private void lblinformation_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToChar(e.KeyChar) == 13)
            {
                btnsave_Click(sender, e);
            }
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

        private void chkshowpass_CheckedChanged(object sender, EventArgs e)
        {
            txtpassword_TextChanged(sender, e);
        }

        public frmnewaccount(string title, string action, string username, string usertype, string login_user)
        {

            InitializeComponent();


            this.Text = title;
            this.action = action;
            this.username = username;
            this.usertype = usertype;
            this.login_user = login_user;



        }
        public void validateForm()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Cannot be empty");
            }

            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Cannot be empty");
            }


            if (string.IsNullOrEmpty(cmbusertype.Text))
            {
                errorProvider1.SetError(cmbusertype, "Cannot be empty");
            }
            if (string.IsNullOrEmpty(cmbstatus.Text))
            {
                errorProvider1.SetError(cmbstatus, "Cannot be empty");
            }
            if (action == "add")
            {
                try
                {
                    DataTable dt = newaccounts.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtusername, " username is already in use");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error on validating existing user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int errorCount;
        public void countErrors()
        {
            errorCount = 0;
            foreach (Control c in errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    errorCount++;
                }
            }
        }



    }
}
