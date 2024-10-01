namespace ProjectPublic.Views
{
    partial class LoginForm
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
            this.ucDangNhap1 = new WinformComponentCustome.ucDangNhap();
            this.SuspendLayout();
            // 
            // ucDangNhap1
            // 
            this.ucDangNhap1.Cnn = null;
            this.ucDangNhap1.Location = new System.Drawing.Point(13, 13);
            this.ucDangNhap1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDangNhap1.Name = "ucDangNhap1";
            this.ucDangNhap1.Size = new System.Drawing.Size(539, 288);
            this.ucDangNhap1.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 314);
            this.Controls.Add(this.ucDangNhap1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WinformComponentCustome.ucDangNhap ucDangNhap1;
    }
}