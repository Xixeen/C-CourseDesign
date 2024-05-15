using FaceRecognize_StudentSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AddStudent : Form
    {
        bool i = true;
        Student student = new Student();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) ||
                (!radioButton1.Checked && !radioButton2.Checked) || (!radioButton3.Checked && !radioButton4.Checked) ||
                string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || i == true)
            {
                MessageBox.Show("Please fill all the required fields");
            }
            else
            {
                try
                {
                    student.Fname = textBox1.Text;
                    student.Address = textBox2.Text;
                    student.Contact = textBox3.Text;

                    if (radioButton1.Checked)
                    {
                        student.Gender = radioButton1.Text;
                    }
                    else
                    {
                        student.Gender = radioButton2.Text;
                    }

                    if (radioButton3.Checked)
                    {
                        student.FeeStatus = radioButton3.Text;
                    }
                    else
                    {
                        student.FeeStatus = radioButton4.Text;
                    }

                    student.Semester = comboBox1.Text;
                    student.Department = comboBox2.Text;

                    using (MemoryStream stream = new MemoryStream())
                    {
                        pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        student.Picture = stream.ToArray();
                    }

                    // Assuming the student ID will be assigned by the database automatically
                    student.Email = "temp@whu.edu.cn"; // Temporary email, will be updated later

                    var success = student.InsertStudent(student);

                    if (success)
                    {
                        ClearControls();
                        MessageBox.Show("Student added successfully");

                        // Retrieve the newly inserted student ID and update the email
                        dataGridView1.DataSource = student.GetStudent();
                        student.ID = dataGridView1.Rows[0].Cells["ID"].Value.ToString();
                        student.Email = student.ID + "@whu.edu.cn";
                        student.UpdateEmail(student);

                        dataGridView1.DataSource = student.GetStudent();
                    }
                    else
                    {
                        MessageBox.Show("Error occurred! Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while entering data: " + ex.Message);
                }
            }
        }

        private void ClearControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            pictureBox1.Image = null;
            i = true;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bpic1 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                    pictureBox1.Image = bpic1;
                    i = false;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminOptions ado = new AdminOptions();
            ado.Show();
            this.Hide();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
