using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Drawing2D;


namespace FacilityMonitoring
{
    public partial class frmcomscifacilities : Form
    {
        private string login_user;
        public frmcomscifacilities(string login_user)
        {
            InitializeComponent();
            this.login_user = login_user;
        }

        Class1 comsci = new Class1("127.0.0.1", "cs311malabon", "root", " ");


        private void frmcomscifacilities_Load(object sender, EventArgs e)
        {
            if (login_user == "User")
            {
                groupBox1.Hide();
            }
            else
            {
                groupBox1.Show();
            }
           
          
            try
            {
                
                DataTable dt = comsci.GetData("SELECT name AS name,location AS location, information AS information, status AS status, image AS image,image2 AS image2,capacity AS capacity, users AS users , reserved_date AS reserved_date, equipments AS equipments FROM tblcomscifacilities ");
                dataGridView1.DataSource = dt;
                // Hide the third column in the DataGridView
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[2].Visible = false;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on frmcomscifacilities_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnadd_Click(object sender, EventArgs e)
        {

            frmnewcomsci newComsci = new frmnewcomsci("Add new Comsci Facility", "add", "", "","","", login_user);
            newComsci.Show();
        }



        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmcomscifacilities_Load(sender, e);

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
                    comsci.executeSQL("DELETE FROM tblcomscifacilities WHERE name = '" + selectedUsername + "'");

                    // Check if the row was deleted from the database
                    if (comsci.rowAffected > 0)
                    {
                        // Remove the selected row from the DataGridView
                        dataGridView1.Rows.RemoveAt(rowIndex);

                        comsci.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString("MM-dd-yyyy") + "' , '" +
                                    DateTime.Now.ToLongTimeString() + "' , 'Delete' , '" + selectedUsername + "' ,'" + login_user + "', 'facilitiy')");
                        MessageBox.Show("Deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on btndelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if ((e.Exception) is System.Data.ConstraintException)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "must be unique value";
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "must be unique value";

                    MessageBox.Show(e.Exception.Message, "Error ConstraintException",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Suppress a ConstraintException
                    e.ThrowException = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: dataGridView1_DataError",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private List<Image> images = new List<Image>();
        private int currentImageIndex = 0;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            images.Clear();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                frmviewgrid myview = new frmviewgrid();
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                byte[] imageData = (byte[])row.Cells["image"].Value;
                byte[] imageData2 = (byte[])row.Cells["image2"].Value;

                if (imageData != null && imageData.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(ms);
                            images.Add(image);
                            myview.pictureBox1.Image = images[currentImageIndex];
                            myview.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            myview.nextButton.Click += NextButton_Click;
                            myview.prevButton.Click += PrevButton_Click;
                        }
                    }
                    catch (ArgumentException)
                    {
                        // Handle invalid image format error
                        images.Add(Image.FromFile(@"C:\Users\admin\Pictures\white default.jpg"));
                        myview.pictureBox1.Image = images[currentImageIndex];
                        myview.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        myview.nextButton.Click += NextButton_Click;
                        myview.prevButton.Click += PrevButton_Click;
                    }
                }
                else
                {
                    // Assign default value to image2
                    images.Add(Image.FromFile(@"C:\Users\admin\Pictures\white default.jpg"));
                }

                if (imageData2 != null && imageData2.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms2 = new MemoryStream(imageData2))
                        {
                            Image image2 = Image.FromStream(ms2);
                            images.Add(image2);
                        }
                    }
                    catch (ArgumentException)
                    {
                        // Handle invalid image format error
                        images.Add(Image.FromFile(@"C:\Users\admin\Pictures\white default.jpg"));
                    }
                }
                else
                {
                    // Assign default value to image2
                    images.Add(Image.FromFile(@"C:\Users\admin\Pictures\white default.jpg"));
                }

                myview.txtnamefacility.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                myview.txtlocationfacility.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                myview.txtinformationfacility.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                myview.txtstatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                myview.txtcapacity.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                myview.txtusers.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                myview.txtdatereserved.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                myview.txtequipments.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                myview.ShowDialog();

                frmcomscifacilities_Load(sender, e);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currentImageIndex++;

            // Get the index of the currently selected row
            int currentRowIndex = dataGridView1.SelectedRows[0].Index;

            // Get the index of the row that was originally selected
            int originalRowIndex = dataGridView1.CurrentRow.Index;

            // Check if the current row is the same as the original

            if (currentRowIndex == originalRowIndex)
            {
                if (currentImageIndex >= images.Count)
                {
                    currentImageIndex = 0;
                }
                frmviewgrid myview = Application.OpenForms.OfType<frmviewgrid>().FirstOrDefault();
                if (myview != null)
                {
                    myview.pictureBox1.Image = images[currentImageIndex];
                    myview.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    myview.txtnamefacility.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    myview.txtlocationfacility.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    myview.txtinformationfacility.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    myview.txtstatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    myview.txtcapacity.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    myview.txtusers.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    myview.txtdatereserved.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    myview.txtequipments.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                }
            }
            else
            {
                // Clear the images list and reset the current image index
                images.Clear();
                currentImageIndex = 0;
            }
        }
        private void PrevButton_Click(object sender, EventArgs e)
        {
            currentImageIndex--;

            // Get the index of the currently selected row
            int currentRowIndex = dataGridView1.SelectedRows[0].Index;

            // Get the index of the row that was originally selected
            int originalRowIndex = dataGridView1.CurrentRow.Index;

            // Check if the current row is the same as the original
            if (currentRowIndex == originalRowIndex)
            {
                if (currentImageIndex < 0)
                {
                    currentImageIndex = images.Count - 1;
                }
                frmviewgrid myview = Application.OpenForms.OfType<frmviewgrid>().FirstOrDefault();
                if (myview != null)
                {
                    myview.pictureBox1.Image = images[currentImageIndex];
                    myview.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    myview.txtnamefacility.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    myview.txtlocationfacility.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    myview.txtinformationfacility.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    myview.txtstatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    myview.txtcapacity.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    myview.txtusers.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    myview.txtdatereserved.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    myview.txtequipments.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                }
            }
            else
            {
                // Clear the images list and reset the current image index
                images.Clear();
                currentImageIndex = 0;
            }
        }
        private void btnedit_Click(object sender, EventArgs e)
        {

        frmnewcomsci updateFacility = new frmnewcomsci ("Update equipment", "edit", "","","","" ,login_user);

            updateFacility.txtnamefacility.Enabled = false;
            updateFacility.txtnamefacility.Text = selectedUsername;
            updateFacility.Show();

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = comsci.GetData("SELECT name AS Name, location AS Location, status AS Status, users AS users, reserved_date FROM tblcomscifacilities WHERE name <> '" + login_user + "' AND (name LIKE '%" + txtsearch.Text + "%' OR location LIKE '%" + txtsearch.Text + "%'  OR information LIKE '%" + txtsearch.Text + "%' OR status LIKE '%" + txtsearch.Text + "%'  OR users LIKE '%" + txtsearch.Text + "%'OR reserved_date LIKE '%" + txtsearch.Text + "%') ORDER BY name");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on txtsearch_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
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
    }
}
