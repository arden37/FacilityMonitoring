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

namespace FacilityMonitoring
{
    public partial class frmnewcomsci : Form
    {
        private String title, action, name, location, information, status, login_user;
        string rbcapacity;
        Class1 newcomsci = new Class1("127.0.0.1", "cs311malabon", "root ", " ");

        public frmnewcomsci(string title, string action, string name, string location,string information,string status, string login_user)
        {
            frmmain main = new frmmain ("","");
            InitializeComponent();
            this.Text = title;
            this.action = action;
            this.name = name;
            this.location = location;
            this.information = information;
            this.status = status;         
            this.login_user = login_user;
        }

        private void frmnewcomsci_Load(object sender, EventArgs e)
        {
            if (this.action == "add")
            {
                cmbstat.Visible = false;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                textBox1.Text = opf.FileName;
            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
 ;
            this.Hide();
        }

   

        private void btnenable_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            btnenable.Hide();
                btndisable.Show();
        }

        private void btndisable_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            btndisable.Hide();
            btnenable.Show();
        }

        private void btnbrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                textBox1.Text = opf.FileName;
            }
        }

        private void btnsave2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
               
            }
        }

     

        private void cmbusers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbusers.Text = cmbusers.Text;
        }

     

        private void cmbstat_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblsatus.Text = cmbstat.Text;
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
                      

                            MemoryStream ms = new MemoryStream();
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            byte[] img = ms.ToArray();
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                            byte[] img2 = new byte[0];
                            if (pictureBox2.Image != null)
                            {
                                MemoryStream ms2 = new MemoryStream();
                                pictureBox2.Image.Save(ms2, pictureBox2.Image.RawFormat);
                                img2 = ms2.ToArray();
                            }
                           


                            if (rb1.Checked)
                            {
                                rbcapacity = "10-30";
                            }
                            else if (rb2.Checked)
                            {
                                rbcapacity = "30-50";
                            }
                            else
                            {
                                rbcapacity = "50 and above";
                            }



                             

                                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=cs311malabon;uid=root;password="))
                            {
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand("INSERT INTO tblcomscifacilities (name, location, information, status, image,image2,capacity,users, reserved_date, equipments) VALUES (@name, @location, @info, @status, @image,@image2,@capacity,@users, @reserved_date, @equipments)", conn);
                       

                                if (dateTimePicker1.Enabled == true) 
                                {
                                    cmd.Parameters.AddWithValue("@name", txtnamefacility.Text);
                                    cmd.Parameters.AddWithValue("@location", txtlocationfacility.Text);
                                    cmd.Parameters.AddWithValue("@info", txtinformationfacility.Text);
                                    cmd.Parameters.AddWithValue("@status", cmbstat.Text);
                                    cmd.Parameters.AddWithValue("@image", img);
                                    cmd.Parameters.AddWithValue("@image2", img2);
                         
                                    cmd.Parameters.AddWithValue("@capacity", rbcapacity);
                                    cmd.Parameters.AddWithValue("@users", cmbusers.Text);
                                    cmd.Parameters.AddWithValue("@reserved_date", dateTimePicker1.Text);
                                    cmd.Parameters.AddWithValue("@equipments", txtequipments.Text);
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@name", txtnamefacility.Text);
                                    cmd.Parameters.AddWithValue("@location", txtlocationfacility.Text);
                                    cmd.Parameters.AddWithValue("@info", txtinformationfacility.Text);
                                    cmd.Parameters.AddWithValue("@status", cmbstat.Text);
                                    cmd.Parameters.AddWithValue("@image", img);
                                    cmd.Parameters.AddWithValue("@image2", img2);
                            
                                    cmd.Parameters.AddWithValue("@capacity", rbcapacity);
                                    cmd.Parameters.AddWithValue("@users", cmbusers.Text);
                                    cmd.Parameters.AddWithValue("@reserved_date", " ");
                                    cmd.Parameters.AddWithValue("@equipments", txtequipments.Text);
                                    cmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("facility Added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            if (newcomsci.rowAffected > 0)
                            {
                                newcomsci.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString("MM-dd-yyyy") + "' , '" +
                                    DateTime.Now.ToLongTimeString() + "' , 'Add' , '" + txtnamefacility.Text + "' ,'" + login_user + "', 'facilitiy')");
                                MessageBox.Show("New Facility Added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                          
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Error on save (add)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else //edit
                     {
                        if (errorCount == 0)
                        {
                            
                            try
                            {
                                MemoryStream ms = new MemoryStream();
                                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                                byte[] img = ms.ToArray();
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                                byte[] img2 = new byte[0];
                                if (pictureBox2.Image != null)
                                {
                                    MemoryStream ms2 = new MemoryStream();
                                    pictureBox2.Image.Save(ms2, pictureBox2.Image.RawFormat);
                                    img2 = ms2.ToArray();
                                }

                               
                                if (rb1.Checked)
                                {
                                    rbcapacity = "10-30";
                                }
                                else if (rb2.Checked)
                                {
                                    rbcapacity = "30-50";
                                }
                                else
                                {
                                    rbcapacity = "50 and above";
                                }

                                string reservedDate = " ";
                                if (dateTimePicker1.Enabled == true)
                                {
                                    reservedDate = dateTimePicker1.Text;
                                }

                                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=cs311malabon;uid=root;password="))
                                {
                                    conn.Open();
                                    MySqlCommand cmd = new MySqlCommand("UPDATE tblcomscifacilities SET location = @location, information = @info, status = @status, image = @image, image2 = @image2, capacity = @capacity, users = @users, reserved_date = @reserved_date, equipments = @equipments WHERE name = @name", conn);

                                    cmd.Parameters.AddWithValue("@location", txtlocationfacility.Text);
                                    cmd.Parameters.AddWithValue("@info", txtinformationfacility.Text);
                                    cmd.Parameters.AddWithValue("@status", cmbstat.Text);
                                    cmd.Parameters.AddWithValue("@image", img);
                                    cmd.Parameters.AddWithValue("@image2", img2);
                                 
                                    cmd.Parameters.AddWithValue("@capacity", rbcapacity);
                                    cmd.Parameters.AddWithValue("@reserved_date", reservedDate);
                                    cmd.Parameters.AddWithValue("@equipments", txtequipments.Text);
                                    cmd.Parameters.AddWithValue("@name", txtnamefacility.Text);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Facility updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public void validateForm()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtnamefacility.Text))
            {
                errorProvider1.SetError(txtnamefacility, "Cannot be empty");
            }

            if (string.IsNullOrEmpty(txtinformationfacility.Text))
            {
                errorProvider1.SetError(txtinformationfacility, "Cannot be empty");
            }

            if (string.IsNullOrEmpty(txtlocationfacility.Text))
            {
                errorProvider1.SetError(txtlocationfacility, "Cannot be empty");
            }
            if (string.IsNullOrEmpty(cmbusers.Text))
            {
                errorProvider1.SetError(cmbusers, "Cannot be empty");
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Pls add picture");
            }

            if (action == "add")
            {
                try
                {
                    DataTable dt = newcomsci.GetData("SELECT * FROM tblcomscifacilities WHERE name = '" + txtnamefacility.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtnamefacility, "facility name is already in use");
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