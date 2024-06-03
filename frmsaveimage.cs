using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;

namespace FacilityMonitoring
{
    public partial class frmsaveimage : Form
    {
        Class1 saveimage = new Class1("127.0.0.1", "cs311malabon", "root ", " ");
        public frmsaveimage()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] img = ms.ToArray();



            saveimage.executeSQL("INSERT INTO tblcomscifacilities (image) VALUES ('" + img + "' ");


            MessageBox.Show("facility Added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
