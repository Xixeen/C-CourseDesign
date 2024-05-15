using System;
using System.Windows.Forms;

namespace Project
{
    public partial class StudentLogin : Form
    {
        Student student = new Student(); // 创建一个 Student 类的实例

        // 用于在不同窗体间传递用户名和密码的静态变量
        public static String SetValueForText1 = "";
        public static String SetValueForText2 = "";

        public StudentLogin()
        {
            InitializeComponent();
        }

        // 当关闭按钮被点击时触发的事件
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 退出应用程序
        }

        // 登录按钮点击事件及密码文本框点击事件的通用处理
        private void LoginHandler()
        {
            try
            {
                // 获取用户输入的邮箱和密码
                student.Email = textBox_usrname.Text;
                student.Password = textBox_password.Text;

                // 检查用户邮箱是否存在
                var emailCheckResult = student.checkEmail(student);
                if (emailCheckResult.Rows.Count == 1)
                {
                    MessageBox.Show("Invalid email id"); // 显示无效的邮箱提示
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(textBox_password.Text))
                    {
                        MessageBox.Show("Please Enter Password"); // 显示请输入密码提示
                    }
                    else
                    {
                        var passwordFromDatabase = emailCheckResult.Rows[0][10].ToString();
                        // 如果密码为空，则提示用户设置密码
                        if (string.IsNullOrWhiteSpace(passwordFromDatabase))
                        {
                            MessageBox.Show("You are first time user!!!!\nSet your password, we will save it for later"); // 显示设置密码提示
                        }
                        else if (passwordFromDatabase == textBox_password.Text)
                        {
                            // 如果密码正确，则跳转到学生选项窗体
                            SetValueForText1 = textBox_usrname.Text;
                            SetValueForText2 = textBox_password.Text;
                            StudentOptions admin = new StudentOptions(); // 创建学生选项窗体的实例
                            this.Hide(); // 隐藏当前窗体
                            admin.Show(); // 显示学生选项窗体
                        }
                        else
                        {
                            MessageBox.Show("Wrong Password"); // 显示密码错误提示
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message); // 显示异常消息
            }
        }

        // 登录按钮点击事件
        private void button_login_Click(object sender, EventArgs e)
        {
            LoginHandler();
        }

        // 密码文本框点击事件
        private void textBox_password_Click(object sender, EventArgs e)
        {
            LoginHandler();
        }

        // 返回按钮点击事件
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                SelectRole sr = new SelectRole(); // 创建选择角色窗体的实例
                sr.Show(); // 显示选择角色窗体
                this.Hide(); // 隐藏当前窗体
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message); // 显示异常消息
            }
        }

        private void StudentLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
