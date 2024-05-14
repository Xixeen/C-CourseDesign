using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognize_StudentSystem
{
    public partial class AdminOptions : Form
    {
        public AdminOptions()
        {
            InitializeComponent();
        }

        private void AdminOptions_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AddAdmin add = new AddAdmin();
            this.Hide();
            add.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
