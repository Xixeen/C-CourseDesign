using Project;
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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;  // 设置启动位置为屏幕中心

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            ProgressIndicator1.Start();
            if (startpoint > 40)
            {
                SelectRole login = new SelectRole();
                //AddAdmin addAdmin = new AddAdmin();
                //AdminOptions adminOptions = new AdminOptions();
                ProgressIndicator1.Stop();
                timer1.Stop();
                this.Hide();
                //addAdmin.Show();
                //adminOptions.Show();
                login.Show();
            }
        }

        private void ProgressIndicator1_Click(object sender, EventArgs e)
        {

        }
    }
}
