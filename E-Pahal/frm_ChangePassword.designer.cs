namespace E_Pahal
{
    partial class frm_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangePassword));
            this.tsc_ChangePassword = new System.Windows.Forms.ToolStripContainer();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.gb_ChangePassword = new System.Windows.Forms.GroupBox();
            this.txt_NewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.txt_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.txt_OldPassword = new System.Windows.Forms.TextBox();
            this.txt_LoginName = new System.Windows.Forms.TextBox();
            this.lbl_ConfirmPassword = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_LoginName = new System.Windows.Forms.Label();
            this.pb_ChangePassword = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsc_ChangePassword.ContentPanel.SuspendLayout();
            this.tsc_ChangePassword.SuspendLayout();
            this.gb_ChangePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ChangePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsc_ChangePassword
            // 
            // 
            // tsc_ChangePassword.ContentPanel
            // 
            this.tsc_ChangePassword.ContentPanel.Controls.Add(this.pictureBox1);
            this.tsc_ChangePassword.ContentPanel.Controls.Add(this.lbl_LoginInfo);
            this.tsc_ChangePassword.ContentPanel.Controls.Add(this.gb_ChangePassword);
            this.tsc_ChangePassword.ContentPanel.Controls.Add(this.pb_ChangePassword);
            this.tsc_ChangePassword.ContentPanel.Size = new System.Drawing.Size(351, 221);
            this.tsc_ChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc_ChangePassword.Location = new System.Drawing.Point(0, 0);
            this.tsc_ChangePassword.Name = "tsc_ChangePassword";
            this.tsc_ChangePassword.Size = new System.Drawing.Size(351, 221);
            this.tsc_ChangePassword.TabIndex = 0;
            this.tsc_ChangePassword.Text = "toolStripContainer1";
            // 
            // lbl_LoginInfo
            // 
            this.lbl_LoginInfo.AutoSize = true;
            this.lbl_LoginInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_LoginInfo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoginInfo.ForeColor = System.Drawing.Color.Red;
            this.lbl_LoginInfo.Location = new System.Drawing.Point(2, 19);
            this.lbl_LoginInfo.Name = "lbl_LoginInfo";
            this.lbl_LoginInfo.Size = new System.Drawing.Size(98, 22);
            this.lbl_LoginInfo.TabIndex = 164;
            this.lbl_LoginInfo.Text = "Upper Info";
            // 
            // gb_ChangePassword
            // 
            this.gb_ChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gb_ChangePassword.Controls.Add(this.txt_NewPassword);
            this.gb_ChangePassword.Controls.Add(this.label1);
            this.gb_ChangePassword.Controls.Add(this.btn_Cancel);
            this.gb_ChangePassword.Controls.Add(this.btn_ChangePassword);
            this.gb_ChangePassword.Controls.Add(this.txt_ConfirmPassword);
            this.gb_ChangePassword.Controls.Add(this.txt_OldPassword);
            this.gb_ChangePassword.Controls.Add(this.txt_LoginName);
            this.gb_ChangePassword.Controls.Add(this.lbl_ConfirmPassword);
            this.gb_ChangePassword.Controls.Add(this.lbl_Password);
            this.gb_ChangePassword.Controls.Add(this.lbl_LoginName);
            this.gb_ChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ChangePassword.Location = new System.Drawing.Point(0, 50);
            this.gb_ChangePassword.Name = "gb_ChangePassword";
            this.gb_ChangePassword.Size = new System.Drawing.Size(351, 171);
            this.gb_ChangePassword.TabIndex = 1;
            this.gb_ChangePassword.TabStop = false;
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.Location = new System.Drawing.Point(127, 55);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.Size = new System.Drawing.Size(179, 20);
            this.txt_NewPassword.TabIndex = 2;
            this.txt_NewPassword.UseSystemPasswordChar = true;
            this.txt_NewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NewPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Password";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Location = new System.Drawing.Point(233, 106);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "&Exit";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btn_ChangePassword.Image")));
            this.btn_ChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ChangePassword.Location = new System.Drawing.Point(79, 106);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(148, 28);
            this.btn_ChangePassword.TabIndex = 4;
            this.btn_ChangePassword.Text = "&Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // txt_ConfirmPassword
            // 
            this.txt_ConfirmPassword.Location = new System.Drawing.Point(127, 77);
            this.txt_ConfirmPassword.Name = "txt_ConfirmPassword";
            this.txt_ConfirmPassword.Size = new System.Drawing.Size(179, 20);
            this.txt_ConfirmPassword.TabIndex = 3;
            this.txt_ConfirmPassword.UseSystemPasswordChar = true;
            this.txt_ConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ConfirmPassword_KeyDown);
            // 
            // txt_OldPassword
            // 
            this.txt_OldPassword.Location = new System.Drawing.Point(127, 33);
            this.txt_OldPassword.Name = "txt_OldPassword";
            this.txt_OldPassword.Size = new System.Drawing.Size(179, 20);
            this.txt_OldPassword.TabIndex = 1;
            this.txt_OldPassword.UseSystemPasswordChar = true;
            this.txt_OldPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_OldPassword_KeyDown);
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.Location = new System.Drawing.Point(127, 11);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Size = new System.Drawing.Size(179, 20);
            this.txt_LoginName.TabIndex = 0;
            this.txt_LoginName.TextChanged += new System.EventHandler(this.txt_LoginName_TextChanged);
            this.txt_LoginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_LoginName_KeyDown);
            // 
            // lbl_ConfirmPassword
            // 
            this.lbl_ConfirmPassword.AutoSize = true;
            this.lbl_ConfirmPassword.Location = new System.Drawing.Point(35, 79);
            this.lbl_ConfirmPassword.Name = "lbl_ConfirmPassword";
            this.lbl_ConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.lbl_ConfirmPassword.TabIndex = 2;
            this.lbl_ConfirmPassword.Text = "Confirm Password";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(35, 36);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(72, 13);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Old Password";
            // 
            // lbl_LoginName
            // 
            this.lbl_LoginName.AutoSize = true;
            this.lbl_LoginName.Location = new System.Drawing.Point(35, 14);
            this.lbl_LoginName.Name = "lbl_LoginName";
            this.lbl_LoginName.Size = new System.Drawing.Size(64, 13);
            this.lbl_LoginName.TabIndex = 0;
            this.lbl_LoginName.Text = "Login Name";
            // 
            // pb_ChangePassword
            // 
            this.pb_ChangePassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_ChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("pb_ChangePassword.Image")));
            this.pb_ChangePassword.Location = new System.Drawing.Point(0, 0);
            this.pb_ChangePassword.Name = "pb_ChangePassword";
            this.pb_ChangePassword.Size = new System.Drawing.Size(351, 50);
            this.pb_ChangePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ChangePassword.TabIndex = 0;
            this.pb_ChangePassword.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(287, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 165;
            this.pictureBox1.TabStop = false;
            // 
            // frm_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 221);
            this.Controls.Add(this.tsc_ChangePassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(367, 260);
            this.MinimumSize = new System.Drawing.Size(367, 260);
            this.Name = "frm_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frm_ChangePassword_Load);
            this.tsc_ChangePassword.ContentPanel.ResumeLayout(false);
            this.tsc_ChangePassword.ContentPanel.PerformLayout();
            this.tsc_ChangePassword.ResumeLayout(false);
            this.tsc_ChangePassword.PerformLayout();
            this.gb_ChangePassword.ResumeLayout(false);
            this.gb_ChangePassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ChangePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc_ChangePassword;
        private System.Windows.Forms.GroupBox gb_ChangePassword;
        private System.Windows.Forms.PictureBox pb_ChangePassword;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.TextBox txt_ConfirmPassword;
        private System.Windows.Forms.TextBox txt_OldPassword;
        private System.Windows.Forms.TextBox txt_LoginName;
        private System.Windows.Forms.Label lbl_ConfirmPassword;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_LoginName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_NewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}