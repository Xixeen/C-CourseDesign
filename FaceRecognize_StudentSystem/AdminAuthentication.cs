using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI; 
using FaceRecognitionDotNet;
using MySql.Data.MySqlClient;
using Project;

namespace FaceRecognize_StudentSystem
{
    public partial class AdminAuthentication : Form
    {
        private Capture _capture = null;
        private FaceRecognition _faceRecognition;
        private static string myConn = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        bool _streaming = false;
        public AdminAuthentication()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // 移除边框

            // 设置模型路径
            string modelPath = @"E:\VSPRO\C#_CourseDesign\models"; // 绝对路径
            _faceRecognition = FaceRecognition.Create(modelPath);
        }
        private void StartCamera()
        {
            _capture = new Capture();
            _capture.ImageGrabbed += ProcessFrame;
            _capture.Start();
        }
        private bool CompareImages(Bitmap capturedImage, byte[] dbImage)
        {
            Bitmap dbBitmap;
            using (var ms = new MemoryStream(dbImage))
            {
                dbBitmap = new Bitmap(ms);
            }

            var capturedFace = FaceRecognition.LoadImage(capturedImage);
            var dbFace = FaceRecognition.LoadImage(dbBitmap);

            var capturedEncodings = _faceRecognition.FaceEncodings(capturedFace).FirstOrDefault();
            var dbEncodings = _faceRecognition.FaceEncodings(dbFace).FirstOrDefault();

            if (capturedEncodings == null || dbEncodings == null)
                return false;

            return FaceRecognition.CompareFaces(new[] { dbEncodings }, capturedEncodings).FirstOrDefault();
        }
        private void streaming(object sender, EventArgs e)
        {

            try
            {
                var img = _capture.QueryFrame().ToImage<Bgr, byte>();
                var bmp = img.Bitmap;
                pictureBox1.Image = bmp;

            }
            catch (Exception)
            {
                MessageBox.Show("Time Out");
                SelectRole sr = new SelectRole();
                sr.Show();
                this.Hide();
            }

        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture == null) return;

            using (Mat frame = new Mat())
            {
                _capture.Retrieve(frame, 0);
                Bitmap bitmap = ConvertMatToBitmap(frame); // 将 Mat 转换为 Bitmap
                pictureBox1.Image = bitmap; // 显示在 PictureBox 上
            }
        }
        private Bitmap ConvertMatToBitmap(Mat mat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                mat.ToImage<Bgr, Byte>().ToBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return new Bitmap(ms);
            }
        }
        public List<Admin> GetAdmins()
        {
            var admins = new List<Admin>();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(Admin.SelectQuery, con))
                {
                    using (MySqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var admin = new Admin
                            {
                                ID = reader.GetInt32("ID"),
                                Name = reader.GetString("Name"),
                                Picture = reader["Picture"] as byte[]
                            };
                            admins.Add(admin);
                        }
                    }
                }
            }
            return admins;
        }

        private void AdminAuthentication_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_streaming)
            {
                StartCamera();
                pictureBox1.Visible = true; // 显示摄像头画面
                pictureBox2.Visible = false; // 隐藏捕获的图像
                button1.Text = "Capture";
            }
            else
            {
                // 确保捕获的图像有效
                if (pictureBox1.Image != null)
                {
                    pictureBox2.Image = new Bitmap(pictureBox1.Image); // 保存捕获的图像
                }
                StopCamera();
                pictureBox1.Visible = false; // 隐藏摄像头画面
                pictureBox2.Visible = true; // 显示捕获的图像
                button1.Text = "Open Camera";
            }
            _streaming = !_streaming;
        }

        private void StopCamera()
        {
            if (_capture != null)
            {
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No image captured.");
                return;
            }

            var admins = GetAdmins();
            Bitmap capturedImage = pictureBox2.Image as Bitmap;

            foreach (var admin in admins)
            {
                if (admin.Picture == null)
                {
                    continue; // 跳过没有图片的管理员记录
                }

                if (CompareImages(capturedImage, admin.Picture))
                {
                    // 显示欢迎信息
                    string welcomeMessage = $"欢迎您：管理员：{admin.Name}，ID号：{admin.ID}";
                    MessageBox.Show(welcomeMessage, "欢迎", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdminOptions adminOptions = new AdminOptions();
                    adminOptions.Show();
                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Authentication failed.");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SelectRole sr = new SelectRole();
            sr.Show();
            this.Hide();
        }
    }
}
