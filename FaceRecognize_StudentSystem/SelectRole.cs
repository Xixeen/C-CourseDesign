using FaceRecognize_StudentSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class SelectRole : Form
    {
        public SelectRole()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminAuthentication ad = new AdminAuthentication();
            this.Hide();
            ad.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            StudentLogin so = new StudentLogin();
            so.Show();
            this.Hide();
        }

        private void SelectRole_Load(object sender, EventArgs e)
        {

        }
    }
}
