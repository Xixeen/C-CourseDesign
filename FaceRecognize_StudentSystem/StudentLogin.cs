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
                student.Email = textBox_usrname.Text.Trim();
                student.Password = textBox_password.Text.Trim();

                // 打印输入的邮箱
                Console.WriteLine($"Input Email: {student.Email}");

                // 检查用户输入是否为空
                if (string.IsNullOrWhiteSpace(student.Email))
                {
                    MessageBox.Show("Please enter your email."); // 显示请输入邮箱提示
                    return;
                }

                // 检查用户邮箱是否存在
                var emailCheckResult = student.checkEmail(student);
                Console.WriteLine($"Rows Count: {emailCheckResult.Rows.Count}"); // 打印查询结果的行数

                if (emailCheckResult.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email id"); // 显示无效的邮箱提示
                    return;
                }

                // 获取数据库中的密码
                var passwordFromDatabase = emailCheckResult.Rows[0]["Password"].ToString();
                Console.WriteLine($"Password from DB: {passwordFromDatabase}"); // 打印数据库中的密码

                // 检查密码是否为空
                if (string.IsNullOrWhiteSpace(passwordFromDatabase))
                {
                    // 提示用户设置密码
                    MessageBox.Show("You are first time user!!!!\nSet your password, we will save it for later. Please enter your password and click login again.");

                    // 检查用户是否输入密码
                    if (string.IsNullOrWhiteSpace(student.Password))
                    {
                        MessageBox.Show("Please enter your password."); // 提示用户输入密码
                        return;
                    }

                    // 更新数据库中的密码
                    student.UpdatePassword(student);
                    MessageBox.Show("Password set successfully. You can now log in with your new password.");
                }
                else if (passwordFromDatabase == student.Password)
                {
                    // 密码正确，跳转到学生选项窗体
                    SetValueForText1 = student.Email;
                    SetValueForText2 = student.Password;
                    StudentOptions admin = new StudentOptions(); // 创建学生选项窗体的实例
                    this.Hide(); // 隐藏当前窗体
                    admin.Show(); // 显示学生选项窗体
                }
                else
                {
                    MessageBox.Show("Wrong Password"); // 显示密码错误提示
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message); // 显示异常消息
                                                                     // 在这里可以记录错误日志，例如：
                                                                     // Logger.LogError(ex);
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

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
