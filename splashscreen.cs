using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FacilityMonitoring
{
    public partial class splashscreen : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

            );

        public splashscreen()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            progressBar1.Value = 0;
        }

        private void Progressbar1_Click(object sender, EventArgs e)
        {

        }

        private void splashscreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            progressBar1.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                frmlogin log = new frmlogin();
                log.Show();
                this.Hide();
            }
        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
