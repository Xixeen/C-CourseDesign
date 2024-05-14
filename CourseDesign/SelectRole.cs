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

        // 点击标签关闭应用程序
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 点击管理员图像框跳转到管理员身份验证界面
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdimnAuthentication ad = new AdimnAuthentication();
            this.Hide(); // 隐藏当前窗体
            ad.Show();  // 显示管理员身份验证界面
        }

        // 点击学生图像框跳转到学生登录界面
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            StudentLogin so = new StudentLogin();
            so.Show();   // 显示学生登录界面
            this.Hide(); // 隐藏当前窗体
        }
    }
}
