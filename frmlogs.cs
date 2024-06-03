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
    public partial class frmlogs : Form
    {
        private string login_user;
        public frmlogs(string login_user)
        {
            InitializeComponent();
            this.login_user = login_user;
        }
        
        Class1 logs = new Class1("127.0.0.1", "cs311malabon", "root", " ");

        private void frmlogs_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = logs.GetData("SELECT * FROM tbllogs ");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on frmcomscifacilities_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int rowSelected = 0;
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

                    // Execute the SQL DELETE statement
                    logs.executeSQL("DELETE FROM tbllogs WHERE datelog = '" + selectedUsername + "'");

                    // Check if the row was deleted from the database
                    if (logs.rowAffected > 0)
                    {
                        // Log the delete operation
                        logs.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString("MM-dd-yyyy") + "' , '" + DateTime.Now.ToLongTimeString() + "' , 'Delete' , '" + " " + "' , '" + login_user + "' , 'facility')");

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

        

        private void btnback_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
