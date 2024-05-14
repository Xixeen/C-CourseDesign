using System;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class Update : Form
    {
        Student student = new Student();

        public Update()
        {
            InitializeComponent();
        }

        // 单击 DataGridView 行标头时加载数据到文本框和控件中
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadDataFromGridToControls(e.RowIndex);
        }

        // 加载数据到文本框和控件中
        private void LoadDataFromGridToControls(int index)
        {
            if (index >= 0 && index < dataGridView1.Rows.Count)
            {
                textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                radioButton1.Checked = dataGridView1.Rows[index].Cells[4].Value.ToString().StartsWith("M");
                radioButton2.Checked = !radioButton1.Checked;
                radioButton4.Checked = dataGridView1.Rows[index].Cells[5].Value.ToString().StartsWith("Paid");
                radioButton3.Checked = !radioButton4.Checked;
                comboBox1.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
            }
        }

        // 搜索按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            SearchStudentAndUpdate();
        }

        // 加载窗体时加载学生数据到 DataGridView
        private void Update_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = student.AllStudent();
        }

        // 更新按钮点击事件
        private void button_login_Click(object sender, EventArgs e)
        {
            UpdateStudent();
        }

        // 返回管理员选项按钮点击事件
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReturnToAdminOptions();
        }

        // 从数据库搜索学生并更新数据到文本框和控件中
        private void SearchStudentAndUpdate()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter ID to load data");
                return;
            }

            student.ID = textBox1.Text;
            DataTable dt = student.SearchStudent(student, "ID");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No record found!!!!!");
            }
            else
            {
                LoadDataFromGridToControls(0);
            }
        }

        // 更新学生信息
        private void UpdateStudent()
        {
            student.ID = textBox1.Text;
            student.Fname = textBox4.Text;
            student.Address = textBox2.Text;
            student.Contact = textBox3.Text;
            student.Gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
            student.FeeStatus = radioButton4.Checked ? radioButton4.Text : radioButton3.Text;
            student.Semester = comboBox1.Text;
            student.Department = comboBox2.Text;

            if (student.UpdateStudent(student))
            {
                MessageBox.Show("Record updated successfully");
                dataGridView1.DataSource = student.GetAllStudent();
            }
            else
            {
                MessageBox.Show("No updation");
            }
        }

        // 退出按钮点击事件
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 返回管理员选项
        private void ReturnToAdminOptions()
        {
            AdminOptions ad = new AdminOptions();
            ad.Show();
            this.Hide();
        }
    }
}
