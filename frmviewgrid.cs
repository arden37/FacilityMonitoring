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
    public partial class frmviewgrid : Form
    {
        public frmviewgrid()
        {
            InitializeComponent();
        }

  
        public void ShowImage(byte[] imgData)
        {
            using (MemoryStream ms = new MemoryStream(imgData))
            {
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;
            }
        }

       

        private void btnback_Click_1(object sender, EventArgs e)
        {
       
            
           
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {

        }

        private void frmviewgrid_Load(object sender, EventArgs e)
        {

        }
      

        private void nextButton_Click(object sender, EventArgs e)
        {
         

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
