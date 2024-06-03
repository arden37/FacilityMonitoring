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
    public partial class frmaccounts : Form
    {
        private string login_user;
        public frmaccounts(string login_user)
        {
            InitializeComponent();
            this.login_user = login_user;
        }
        Class1 accounts = new Class1("127.0.0.1", "cs311malabon", "root", " ");


  

        private void frmaccounts_Load_1(object sender, EventArgs e)
        {
            

            try
            {
                DataTable dt = accounts.GetData("SELECT username AS username ,password AS password, usertype AS usertype, status AS status, createdby AS createdby FROM tblaccounts ");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on frmcomscifacilities_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       
        


        private void btnadd_Click(object sender, EventArgs e)
        {
            frmnewaccount newAccount = new frmnewaccount("Add new Comsci Facility", "add", "", "",  login_user);
            newAccount.Show();
        }
        private int rowSelected = 0;

        String selectedUsername;
        int rowIndex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 rowIndex = dataGridView1.CurrentCell.RowIndex;

                // Get the username of the selected row
                 selectedUsername = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: dataGridView1_DataError",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnedit_Click(object sender, EventArgs e)
        {

            frmnewaccount editAccount = new frmnewaccount("View Violators", "edit", "", "", login_user);
            editAccount.txtusername.Enabled = false;

           editAccount.txtusername.Text = selectedUsername;
            

            editAccount.Show();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Confirm delete operation
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    // Get the index of the selected row
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;

                    // Get the username of the selected row
                    string selectedUsername = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

                    frmnewaccount newacc = new frmnewaccount();
                    newacc.txtusername.Text = selectedUsername;
                    // Execute the SQL DELETE statement
                    accounts.executeSQL("DELETE FROM tblaccounts WHERE username = '" + selectedUsername + "'");

                    // Check if the row was deleted from the database
                    if (accounts.rowAffected > 0)
                    {
                        // Log the delete operation
                        accounts.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString("MM-dd-yyyy") + "' , '" + DateTime.Now.ToLongTimeString() + "' , 'Delete' , '" + " " + "' , '" + login_user + "' , 'Violators')");

                        // Remove the selected row from the DataGridView
                        dataGridView1.Rows.RemoveAt(rowIndex);

                        MessageBox.Show("Deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on btndelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT name AS Name, location AS Location, status AS Status, users AS users, reserved_date FROM tblcomscifacilities WHERE name <> '" + login_user + "' AND (name LIKE '%" + txtsearch.Text + "%' OR location LIKE '%" + txtsearch.Text + "%' OR information LIKE '%" + txtsearch.Text + "%' OR status LIKE '%" + txtsearch.Text + "%') ORDER BY name");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on txtsearch_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnrefresh_Click(object sender, EventArgs e)
        {

            frmaccounts_Load_1(sender, e);
        }

      

        

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
