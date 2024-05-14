using System;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class StudentOptions : Form
    {
        Student student = new Student();

        public StudentOptions()
        {
            InitializeComponent();
        }

        // 关闭窗体按钮点击事件
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 查看学生成绩按钮点击事件
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowStudentResultCard();
        }

        // 返回登录按钮点击事件
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReturnToStudentLogin();
        }

        // 查看费用状态按钮点击事件
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowFeeStatus();
        }

        // 显示学生成绩窗体
        private void ShowStudentResultCard()
        {
            StudentResultCard src = new StudentResultCard();
            src.Show();
            this.Hide();
        }

        // 返回到学生登录窗体
        private void ReturnToStudentLogin()
        {
            StudentLogin ado = new StudentLogin();
            ado.Show();
            this.Hide();
        }

        // 显示费用状态
        private void ShowFeeStatus()
        {
            try
            {
                // 获取当前登录学生的邮箱
                student.Email = StudentLogin.SetValueForText1;
                // 通过邮箱查询学生信息，包括费用状态
                DataTable dt = student.checkEmail(student);

                if (dt.Rows.Count > 0)
                {
                    // 显示费用状态
                    MessageBox.Show("Your Fee status is: " + dt.Rows[0][5].ToString());
                }
                else
                {
                    // 如果未找到相关信息，则显示提示信息
                    MessageBox.Show("No fee status found.");
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况，显示错误信息
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
