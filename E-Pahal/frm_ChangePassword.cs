using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//FOR IMAGE PROCESSING
using System.Threading;
using System.IO;

namespace E_Pahal
{
    public partial class frm_ChangePassword : Form
    {
        public frm_ChangePassword()
        {
            InitializeComponent();
        }

        private void frm_ChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                txt_LoginName.Focus();
                lbl_LoginInfo.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            // bool abc= cls_UserInfo.checkUserPassword(txt_LoginName.Text, txt_OldPassword.Text);
            if (txt_NewPassword.Text == "")
            {
                MessageBox.Show("Cannot be left blank", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NewPassword.Focus();
            }
            else if (txt_ConfirmPassword.Text == "")
            {
                MessageBox.Show("Cannot be left blank", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ConfirmPassword.Focus();
            }
            else if (txt_NewPassword.Text != txt_ConfirmPassword.Text)
            {
                MessageBox.Show("Password Mismatch", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NewPassword.ResetText();
                txt_ConfirmPassword.ResetText();
                txt_NewPassword.Focus();
            }

            else
            {
                
                int temp = string.CompareOrdinal(GlobalConnection.strUserLoginName, txt_LoginName.Text);
                if (temp != 0)
                {
                    MessageBox.Show("User Login Name cannot be modified.", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataTable dtLogin = cls_UserInfo.checkUserPassword(txt_LoginName.Text, txt_OldPassword.Text);
                    if (dtLogin.Rows.Count == 1)
                    {
                        try
                        {
                            cls_UserInfo.updateUserPassword(txt_LoginName.Text, txt_ConfirmPassword.Text, GlobalConnection.strUid, DateTime.Now);
                            lbl_LoginInfo.ResetText();
                            txt_LoginName.ResetText();
                            txt_OldPassword.ResetText();
                            txt_NewPassword.ResetText();
                            txt_ConfirmPassword.ResetText();
                            btn_Cancel.Focus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login Name or Password", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } 
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_LoginName_TextChanged(object sender, EventArgs e)
        {
            lbl_LoginInfo.Text = txt_LoginName.Text;
        }

        private void txt_LoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_OldPassword.Focus();
            }
        }

        private void txt_OldPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = string.CompareOrdinal(GlobalConnection.strUserLoginName, txt_LoginName.Text);
                if (temp != 0)
                {
                    MessageBox.Show("Unauthorized Use.\nYour account will be deactivated if you attempt to change password of other user.", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataTable dtLogin = cls_UserInfo.checkUserPassword(txt_LoginName.Text, txt_OldPassword.Text);
                    if (dtLogin.Rows.Count == 1)
                    {
                        txt_NewPassword.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login Name or Password", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_LoginName.Focus();
                    }
                } 
            }
        }

        private void txt_NewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ConfirmPassword.Focus();
            }
        }

        private void txt_ConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ChangePassword.Focus();
            }
        }

        
    }
}
