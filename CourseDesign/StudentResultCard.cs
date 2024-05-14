using System;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class StudentResultCard : Form
    {
        int tRows = 0;
        Student student = new Student();
        Result result = new Result();

        public StudentResultCard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ReturnToStudentOptions();
        }

        private void StudentResultCard_Load(object sender, EventArgs e)
        {
            try
            {
                student.Email = StudentLogin.SetValueForText1;
                DataTable dt = student.loadData(student);
                label9.Text = dt.Rows[0][1].ToString();
                label11.Text = dt.Rows[0][0].ToString();
                label8.Text = dt.Rows[0][2].ToString();
                label10.Text = dt.Rows[0][3].ToString();

                result.SID = dt.Rows[0][0].ToString();
                DataTable dr = result.Display(result);
                label7.Text = "Your SGPA is " + dr.Rows[0][19].ToString();

                // 加载学生成绩表格
                dataGridView1.DataSource = dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void ReturnToStudentOptions()
        {
            StudentOptions so = new StudentOptions();
            so.Show();
            this.Hide();
        }

        // 在 StudentResultCard 类中添加以下方法：
        private void LoadStudentResultTable(DataTable dr)
        {
            // 清空 DataGridView 的内容
            dataGridView1.Rows.Clear();

            // 检查数据表中是否有数据
            if (dr.Rows.Count > 0)
            {
                // 遍历数据表中的每一行
                foreach (DataRow row in dr.Rows)
                {
                    // 创建一个新的 DataGridViewRow 对象
                    DataGridViewRow dgvRow = new DataGridViewRow();

                    // 将数据表中的每个单元格的值添加到 DataGridViewRow 中
                    foreach (DataColumn column in dr.Columns)
                    {
                        // 创建一个新的 DataGridViewTextBoxCell，并将单元格的值赋给它
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        cell.Value = row[column];

                        // 将 DataGridViewTextBoxCell 添加到 DataGridViewRow 中
                        dgvRow.Cells.Add(cell);
                    }

                    // 将 DataGridViewRow 添加到 DataGridView 中
                    dataGridView1.Rows.Add(dgvRow);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}

