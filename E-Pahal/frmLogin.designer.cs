namespace E_Pahal
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpLogInfo = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pb_User = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pctbLogin = new System.Windows.Forms.PictureBox();
            this.pb_Login = new System.Windows.Forms.PictureBox();
            this.grpLogInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Login)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(133, 135);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(131, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // grpLogInfo
            // 
            this.grpLogInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grpLogInfo.Controls.Add(this.pb_User);
            this.grpLogInfo.Controls.Add(this.txtPassword);
            this.grpLogInfo.Controls.Add(this.txtUserName);
            this.grpLogInfo.Controls.Add(this.lblPassword);
            this.grpLogInfo.Controls.Add(this.lblUserName);
            this.grpLogInfo.Controls.Add(this.btnQuit);
            this.grpLogInfo.Controls.Add(this.btnLogin);
            this.grpLogInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpLogInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLogInfo.Location = new System.Drawing.Point(502, 39);
            this.grpLogInfo.Name = "grpLogInfo";
            this.grpLogInfo.Size = new System.Drawing.Size(272, 210);
            this.grpLogInfo.TabIndex = 5;
            this.grpLogInfo.TabStop = false;
            this.grpLogInfo.Text = "Log In Please";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(133, 109);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(131, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(51, 141);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(51, 112);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 16);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // pb_User
            // 
            this.pb_User.Image = ((System.Drawing.Image)(resources.GetObject("pb_User.Image")));
            this.pb_User.Location = new System.Drawing.Point(105, 22);
            this.pb_User.Name = "pb_User";
            this.pb_User.Size = new System.Drawing.Size(100, 78);
            this.pb_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_User.TabIndex = 4;
            this.pb_User.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.Location = new System.Drawing.Point(174, 171);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 27);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.Location = new System.Drawing.Point(54, 171);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(119, 27);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pctbLogin
            // 
            this.pctbLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pctbLogin.Image = ((System.Drawing.Image)(resources.GetObject("pctbLogin.Image")));
            this.pctbLogin.Location = new System.Drawing.Point(0, 0);
            this.pctbLogin.Name = "pctbLogin";
            this.pctbLogin.Size = new System.Drawing.Size(774, 39);
            this.pctbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbLogin.TabIndex = 4;
            this.pctbLogin.TabStop = false;
            // 
            // pb_Login
            // 
            this.pb_Login.Image = global::E_Pahal.Properties.Resources.Eclat_Login_ePahal;
            this.pb_Login.Location = new System.Drawing.Point(1, 39);
            this.pb_Login.Name = "pb_Login";
            this.pb_Login.Size = new System.Drawing.Size(498, 209);
            this.pb_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Login.TabIndex = 6;
            this.pb_Login.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(774, 249);
            this.Controls.Add(this.grpLogInfo);
            this.Controls.Add(this.pctbLogin);
            this.Controls.Add(this.pb_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(794, 292);
            this.MinimumSize = new System.Drawing.Size(794, 292);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.grpLogInfo.ResumeLayout(false);
            this.grpLogInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Login)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grpLogInfo;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pctbLogin;
        private System.Windows.Forms.PictureBox pb_Login;
        private System.Windows.Forms.PictureBox pb_User;
    }
}

