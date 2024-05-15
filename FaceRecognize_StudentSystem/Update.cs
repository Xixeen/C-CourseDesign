using FaceRecognize_StudentSystem;
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadDataFromGridToControls(e.RowIndex);
        }

        private void LoadDataFromGridToControls(int index)
        {
            if (index >= 0 && index < dataGridView1.Rows.Count)
            {
                textBox1.Text = dataGridView1.Rows[index].Cells["ID"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[index].Cells["Fname"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[index].Cells["Address"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[index].Cells["Contact"].Value.ToString();
                radioButton1.Checked = dataGridView1.Rows[index].Cells["Gender"].Value.ToString().StartsWith("M");
                radioButton2.Checked = !radioButton1.Checked;
                radioButton4.Checked = dataGridView1.Rows[index].Cells["FeeStatus"].Value.ToString().StartsWith("Paid");
                radioButton3.Checked = !radioButton4.Checked;
                comboBox1.Text = dataGridView1.Rows[index].Cells["Semester"].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[index].Cells["Department"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchStudentAndUpdate();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = student.AllStudent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            UpdateStudent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReturnToAdminOptions();
        }

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

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ReturnToAdminOptions()
        {
            AdminOptions ad = new AdminOptions();
            ad.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
