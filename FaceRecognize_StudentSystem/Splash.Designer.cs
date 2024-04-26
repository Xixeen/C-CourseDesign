using Guna.UI2.WinForms;
namespace FaceRecognize_StudentSystem
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2CustomRadioButton1 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.SuspendLayout();
            // 
            // guna2CustomRadioButton1
            // 
            this.guna2CustomRadioButton1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton1.CheckedState.BorderThickness = 0;
            this.guna2CustomRadioButton1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2CustomRadioButton1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomRadioButton1.Name = "guna2CustomRadioButton1";
            this.guna2CustomRadioButton1.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomRadioButton1.TabIndex = 0;
            this.guna2CustomRadioButton1.Text = "guna2CustomRadioButton1";
            this.guna2CustomRadioButton1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CustomRadioButton1.UncheckedState.BorderThickness = 2;
            this.guna2CustomRadioButton1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomRadioButton1.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 782);
            this.Controls.Add(this.guna2CustomRadioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2CustomRadioButton guna2CustomRadioButton1;
    }
}