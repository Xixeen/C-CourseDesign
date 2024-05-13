using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceRecognize_StudentSystem
{
    public partial class AddAdmin : Form
    {
        bool i = true;
        bool _streaming;
        Capture _capture;

        Admin admin = new Admin();
        public AddAdmin()
        {
            InitializeComponent();
           
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {

        }

        private void AddAdmin_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // _capture = new Capture();
            if (!_streaming)
            {
                i = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                Application.Idle += streaming;
                button_login.Text = @"Capture";
                //_streaming = false;
            }
            else
            {
                i = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                button_login.Text = @"Open Camera";
                Application.Idle -= streaming;
                //_streaming = false;
                pictureBox2.Image = pictureBox1.Image;


            }
            _streaming = !_streaming;
        }
    }
}
