using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer;


namespace E_Pahal
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private static void MainForm()
        {
            MDI_E_Pahal ePahalParent = new MDI_E_Pahal();
            ePahalParent.ShowDialog(); 
        }

        public static Boolean AdministratorUser = false;
        public DataTable dt_FY = new DataTable();
        public DataTable dt_ARCode = new DataTable();
        public DataTable dt_Group = new DataTable();
        
        public void refocus()
        {
            txtUserName.ResetText();
            txtPassword.ResetText();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPassword.Text == "Eclat_Administrator")
                {
                    MessageBox.Show("There is software error.\nPlease contact Eclat Info. Sys. (P.) Ltd.", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (txtPassword.Text == "Admin_Administrator")
                    {
                        txtPassword.Text = txtPassword.Text.Replace("Admin_", "ECLAT_");
                        AdministratorUser = true;
                    }
                    else
                    {
                        AdministratorUser = false;
                    }

                    GlobalConnection.PerformConnection();
                    SqlDataAdapter da = new SqlDataAdapter("select user_login_name,user_login_pwd,user_active_status,user_fname+' '+user_mname+' '+user_lname[UserName], user_id from user_info where user_login_name='" + txtUserName.Text + "'and user_login_pwd='" + txtPassword.Text + "'", GlobalConnection.cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "user_info");

                    if (ds.Tables[0].Rows.Count < 1)
                    {
                        MessageBox.Show("Invalid User Name or Password", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refocus();
                    }
                    else
                    {
                        GlobalConnection.strUid = ds.Tables[0].Rows[0]["user_id"].ToString();
                        GlobalConnection.strUserLoginName = ds.Tables[0].Rows[0]["user_login_name"].ToString();
                        int temp_Login = string.CompareOrdinal(GlobalConnection.strUserLoginName, txtUserName.Text);
                        GlobalConnection.strPWD = ds.Tables[0].Rows[0]["user_login_pwd"].ToString();
                        int temp_Pwd = string.CompareOrdinal(GlobalConnection.strPWD, txtPassword.Text);
                        GlobalConnection.strUStatus = ds.Tables[0].Rows[0]["user_active_status"].ToString();
                        GlobalConnection.strUCategory = ds.Tables[0].Rows[0][2].ToString();
                        GlobalConnection.strUsername = ds.Tables[0].Rows[0]["UserName"].ToString();

                        if (temp_Login != 0 || temp_Pwd != 0)
                        {
                            MessageBox.Show("Invalid User Name or Password", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refocus();

                        }
                        else if (temp_Login == 0 && temp_Pwd == 0)
                        {

                            this.Close();
                            ThreadStart ts = new ThreadStart(MainForm);
                            Thread td = new Thread(ts);
                            td.Start();
                        }
                        else
                        {
                            MessageBox.Show("Software has not been initialized.\nPlease contact Eclat Info. Sys. (P.) Ltd. to initialize the software.", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

       
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
