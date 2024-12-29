namespace rentalCar
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MyProgress = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.MyCar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.MyProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyCar)).BeginInit();
            this.SuspendLayout();
            // 
            // MyProgress
            // 
            this.MyProgress.Controls.Add(this.MyCar);
            this.MyProgress.FillColor = System.Drawing.Color.LightSlateGray;
            this.MyProgress.FillThickness = 8;
            this.MyProgress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MyProgress.ForeColor = System.Drawing.Color.White;
            this.MyProgress.Location = new System.Drawing.Point(190, 82);
            this.MyProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MyProgress.Minimum = 0;
            this.MyProgress.Name = "MyProgress";
            this.MyProgress.ProgressColor = System.Drawing.Color.White;
            this.MyProgress.ProgressColor2 = System.Drawing.Color.White;
            this.MyProgress.ProgressThickness = 8;
            this.MyProgress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.MyProgress.Size = new System.Drawing.Size(183, 183);
            this.MyProgress.TabIndex = 2;
            this.MyProgress.Text = "guna2CircleProgressBar1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Araç Kiralama Sistemi";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(246, 297);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 95;
            this.label9.Text = "EFIA";
            // 
            // MyCar
            // 
            this.MyCar.Image = ((System.Drawing.Image)(resources.GetObject("MyCar.Image")));
            this.MyCar.ImageRotate = 0F;
            this.MyCar.Location = new System.Drawing.Point(36, 28);
            this.MyCar.Margin = new System.Windows.Forms.Padding(2);
            this.MyCar.Name = "MyCar";
            this.MyCar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.MyCar.Size = new System.Drawing.Size(98, 114);
            this.MyCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MyCar.TabIndex = 0;
            this.MyCar.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(570, 366);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MyProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox MyCar;
        private Guna.UI2.WinForms.Guna2CircleProgressBar MyProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
    }
}