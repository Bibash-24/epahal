using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace E_Pahal
{
    class cls_UserInfo
    {
        public static int MaxPlus_Admin;
        public static string generated_id_Admin;

        public static void AutoID_Admin(string FirstLetter, string TableField, string TableName)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlDataAdapter da = new SqlDataAdapter();
                da = new SqlDataAdapter("SELECT substring (MAX(" + TableField + "),2,5) FROM " + TableName + " ", GlobalConnection.cn);
                DataSet ds = new DataSet();

                da.Fill(ds, "Admin");
                string MaxNo = ds.Tables[0].Rows[0][0].ToString();
                if (MaxNo == "")
                {
                    MaxPlus_Admin = 1;
                }
                else
                {
                    MaxPlus_Admin = Convert.ToInt16(MaxNo) + 1;
                }

                if (MaxPlus_Admin < 10)
                {
                    generated_id_Admin = FirstLetter + "000" + Convert.ToString(MaxPlus_Admin);
                }
                else if (MaxPlus_Admin >= 10 && MaxPlus_Admin < 100)
                {
                    generated_id_Admin = FirstLetter + "00" + Convert.ToString(MaxPlus_Admin);
                }
                else if (MaxPlus_Admin >= 100 && MaxPlus_Admin < 1000)
                {
                    generated_id_Admin = FirstLetter + "0" + Convert.ToString(MaxPlus_Admin);
                }
                else if (MaxPlus_Admin >= 1000 && MaxPlus_Admin < 10000)
                {
                    generated_id_Admin = FirstLetter + Convert.ToString(MaxPlus_Admin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void saveActivated_Userinfo(string Userid, string Firstname, string Middlename, string Lastname, string Gender, string Martialstatus, string ContactAddress, string CitizenshipPassport, DateTime UserissueDateAD, string UserissueDateBS, string Issueplace, string Department, string Position, string Contact1, string Contact2, string Contact3, string Email1, string Email2, string Loginname, string Loginpassword, string CreateBy, DateTime CreateDate, string ActivatedBy, DateTime ActivatedDate, string ActivateStatus, byte[] UserPhoto)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "INSERT INTO user_info(user_id,user_fname,user_mname,user_lname,user_gender,user_martial_status,user_contact_address,user_citizenship_passport_no,user_issue_date_ad,user_issue_date_bs,user_issue_place,user_department,user_position,user_contact_no1,user_contact_no2,user_contact_no3,user_email1,user_email2,user_login_name,user_login_pwd,user_createby,user_create_date,user_activateby,user_activate_date,user_active_status,user_photo) VALUES" + "(@user_id, @user_fname, @user_mname,@user_lname, @user_gender,@user_martial_status,@user_contact_address,@user_citizenship_passport_no,@user_issue_date_ad,@user_issue_date_bs,@user_issue_place,@user_department,@user_position,@user_contact_no1,@user_contact_no2,@user_contact_no3,@user_email1,@user_email2,@user_login_name,@user_login_pwd, @user_createby,@user_create_date,@user_activateby,@user_activate_date,@user_active_status,@user_photo)";
                cmd.Parameters.AddWithValue("@user_id", Userid);
                cmd.Parameters.AddWithValue("@user_fname", Firstname);
                cmd.Parameters.AddWithValue("@user_mname", Middlename);
                cmd.Parameters.AddWithValue("@user_lname", Lastname);
                cmd.Parameters.AddWithValue("@user_gender", Gender);
                cmd.Parameters.AddWithValue("@user_martial_status", Martialstatus);
                cmd.Parameters.AddWithValue("@user_contact_address", ContactAddress);
                cmd.Parameters.AddWithValue("@user_citizenship_passport_no", CitizenshipPassport);
                cmd.Parameters.AddWithValue("@user_issue_date_ad", UserissueDateAD);
                cmd.Parameters.AddWithValue("@user_issue_date_bs", UserissueDateBS);
                cmd.Parameters.AddWithValue("@user_issue_place", Issueplace);
                cmd.Parameters.AddWithValue("@user_department", Department);
                cmd.Parameters.AddWithValue("@user_position", Position);
                cmd.Parameters.AddWithValue("@user_contact_no1", Contact1);
                cmd.Parameters.AddWithValue("@user_contact_no2", Contact2);
                cmd.Parameters.AddWithValue("@user_contact_no3", Contact3);
                cmd.Parameters.AddWithValue("@user_email1", Email1);
                cmd.Parameters.AddWithValue("@user_email2", Email2);
                cmd.Parameters.AddWithValue("@user_login_name", Loginname);
                cmd.Parameters.AddWithValue("@user_login_pwd", Loginpassword);
                cmd.Parameters.AddWithValue("@user_createby", CreateBy);
                cmd.Parameters.AddWithValue("@user_create_date", CreateDate);
                cmd.Parameters.AddWithValue("@user_activateby", ActivatedBy);
                cmd.Parameters.AddWithValue("@user_activate_date", ActivatedDate);
                cmd.Parameters.AddWithValue("@user_active_status", ActivateStatus);
                cmd.Parameters.AddWithValue("@user_photo", UserPhoto);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void saveDeactivated_Userinfo(string Userid, string Firstname, string Middlename, string Lastname, string Gender, string Martialstatus, string ContactAddress, string CitizenshipPassport, DateTime UserissueDateAD, string UserissueDateBS, string Issueplace, string Department, string Position, string Contact1, string Contact2, string Contact3, string Email1, string Email2, string Loginname, string Loginpassword, string CreateBy, DateTime CreateDate, string DeactivatedBy, DateTime DeactivatedDate, string ActivateStatus, byte[] UserPhoto)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "INSERT INTO user_info(user_id,user_fname,user_mname,user_lname,user_gender,user_martial_status,user_contact_address,user_citizenship_passport_no,user_issue_date_ad,user_issue_date_bs,user_issue_place,user_department,user_position,user_contact_no1,user_contact_no2,user_contact_no3,user_email1,user_email2,user_login_name,user_login_pwd,user_createby,user_create_date,user_deactivateby,user_deactivate_date,user_active_status,user_photo) VALUES" + "(@user_id, @user_fname, @user_mname,@user_lname, @user_gender,@user_martial_status,@user_contact_address,@user_citizenship_passport_no,@user_issue_date_ad,@user_issue_date_bs,@user_issue_place,@user_department,@user_position,@user_contact_no1,@user_contact_no2,@user_contact_no3,@user_email1,@user_email2,@user_login_name,@user_login_pwd, @user_createby,@user_create_date,@user_deactivateby,@user_deactivate_date,@user_active_status,@user_photo)";
                cmd.Parameters.AddWithValue("@user_id", Userid);
                cmd.Parameters.AddWithValue("@user_fname", Firstname);
                cmd.Parameters.AddWithValue("@user_mname", Middlename);
                cmd.Parameters.AddWithValue("@user_lname", Lastname);
                cmd.Parameters.AddWithValue("@user_gender", Gender);
                cmd.Parameters.AddWithValue("@user_martial_status", Martialstatus);
                cmd.Parameters.AddWithValue("@user_contact_address", ContactAddress);
                cmd.Parameters.AddWithValue("@user_citizenship_passport_no", CitizenshipPassport);
                cmd.Parameters.AddWithValue("@user_issue_date_ad", UserissueDateAD);
                cmd.Parameters.AddWithValue("@user_issue_date_bs", UserissueDateBS);
                cmd.Parameters.AddWithValue("@user_issue_place", Issueplace);
                cmd.Parameters.AddWithValue("@user_department", Department);
                cmd.Parameters.AddWithValue("@user_position", Position);
                cmd.Parameters.AddWithValue("@user_contact_no1", Contact1);
                cmd.Parameters.AddWithValue("@user_contact_no2", Contact2);
                cmd.Parameters.AddWithValue("@user_contact_no3", Contact3);
                cmd.Parameters.AddWithValue("@user_email1", Email1);
                cmd.Parameters.AddWithValue("@user_email2", Email2);
                cmd.Parameters.AddWithValue("@user_login_name", Loginname);
                cmd.Parameters.AddWithValue("@user_login_pwd", Loginpassword);
                cmd.Parameters.AddWithValue("@user_createby", CreateBy);
                cmd.Parameters.AddWithValue("@user_create_date", CreateDate);
                cmd.Parameters.AddWithValue("@user_deactivateby", DeactivatedBy);
                cmd.Parameters.AddWithValue("@user_deactivate_date", DeactivatedDate);
                cmd.Parameters.AddWithValue("@user_active_status", ActivateStatus);
                cmd.Parameters.AddWithValue("@user_photo", UserPhoto);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void saveCounter_User(string Userid, DateTime CbDate, double Cash, int Bank_Tr, double Bank, int Card_Tr, double Card, int Credit_Tr, double Credit, string CreateBy, DateTime CreateDate)
        {
            try
            {
                
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "INSERT INTO counter_balance(cb_user, cb_date, cb_cash, cb_bank_no, cb_bank, cb_card_no, cb_card, cb_credit_no, cb_credit, cb_save, cb_save_date) VALUES" + "(@cb_user, @cb_date, @cb_cash, @cb_bank_no, @cb_bank, @cb_card_no, @cb_card, @cb_credit_no, @cb_credit, @cb_save, @cb_save_date)";
                cmd.Parameters.AddWithValue("@cb_user", Userid);
                cmd.Parameters.AddWithValue("@cb_date", CbDate);
                cmd.Parameters.AddWithValue("@cb_cash", Cash);
                cmd.Parameters.AddWithValue("@cb_bank_no", Bank_Tr);
                cmd.Parameters.AddWithValue("@cb_bank", Bank);
                cmd.Parameters.AddWithValue("@cb_card_no", Card_Tr);
                cmd.Parameters.AddWithValue("@cb_card", Card);
                cmd.Parameters.AddWithValue("@cb_credit_no", Credit_Tr);
                cmd.Parameters.AddWithValue("@cb_credit", Credit);
                cmd.Parameters.AddWithValue("@cb_save", CreateBy);
                cmd.Parameters.AddWithValue("@cb_save_date", CreateDate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User:" + Userid + "\nSaved Successfully", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable Load_CounterUser_Balance(string UserID)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select cb_user, cb_date, cb_cash, cb_bank_no, cb_bank, cb_card_no, cb_card, cb_credit_no, cb_credit FROM counter_balance WHERE cb_user = '"+ UserID + "'", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void updateCounterUser_Balance(string Userid, string UserName, DateTime CbDate, double Cash, int Bank_Tr, double Bank, int Card_Tr, double Card, int Credit_Tr, double Credit, string CreateBy, DateTime CreateDate)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "UPDATE counter_balance set cb_date=@cb_date,cb_cash=@cb_cash,cb_bank_no=@cb_bank_no,cb_bank=@cb_bank,cb_card_no=@cb_card_no,cb_card=@cb_card,cb_credit_no=@cb_credit_no,cb_credit=@cb_credit,cb_update=@cb_update,cb_update_date=@cb_update_date where cb_user='" + Userid + "'";
                cmd.Parameters.AddWithValue("@cb_date", CbDate);
                cmd.Parameters.AddWithValue("@cb_cash", Cash);
                cmd.Parameters.AddWithValue("@cb_bank_no", Bank_Tr);
                cmd.Parameters.AddWithValue("@cb_bank", Bank);
                cmd.Parameters.AddWithValue("@cb_card_no", Card_Tr);
                cmd.Parameters.AddWithValue("@cb_card", Card);
                cmd.Parameters.AddWithValue("@cb_credit_no", Credit_Tr);
                cmd.Parameters.AddWithValue("@cb_credit", Credit);
                cmd.Parameters.AddWithValue("@cb_update", CreateBy);
                cmd.Parameters.AddWithValue("@cb_update_date", CreateDate);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void updateActivated_Userinfo(string Userid, string updateFirstname, string updateMiddlename, string updateLastname, string updateGender, string updateMartialstatus, string ContactAddress, string updateCitizenshipPassport, DateTime updateUserissueDateAD, string updateUserissueDateBS, string updateIssueplace, string updateDepartment, string updatePosition, string updateContact1, string updateContact2, string updateContact3, string updateEmail1, string updateEmail2, string updateCreateBy, DateTime updateCreateDate, string ActivatedBy, DateTime ActivatedDate, string ActivatedStatus, byte[] UserPhoto)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "update user_info set user_fname=@user_fname,user_mname=@user_mname,user_lname=@user_lname,user_gender=@user_gender,user_martial_status=@user_martial_status,user_contact_address=@user_contact_address,user_citizenship_passport_no=@user_citizenship_passport_no,user_issue_date_ad=@user_issue_date_ad,user_issue_date_bs=@user_issue_date_bs,user_issue_place=@user_issue_place,user_department=@user_department,user_position=@user_position,user_contact_no1=@user_contact_no1,user_contact_no2=@user_contact_no2,user_contact_no3=@user_contact_no3,user_email1=@user_email1,user_email2=@user_email2,user_updateby=@user_updateby,user_update_date=@user_update_date,user_activateby=@user_activateby,user_activate_date=@user_activate_date,user_active_status=@user_active_status,user_photo=@user_photo where user_id='" + Userid + "'";
                cmd.Parameters.AddWithValue("@user_fname", updateFirstname);
                cmd.Parameters.AddWithValue("@user_mname", updateMiddlename);
                cmd.Parameters.AddWithValue("@user_lname", updateLastname);
                cmd.Parameters.AddWithValue("@user_gender", updateGender);
                cmd.Parameters.AddWithValue("@user_martial_status", updateMartialstatus);
                cmd.Parameters.AddWithValue("@user_contact_address", ContactAddress);
                cmd.Parameters.AddWithValue("@user_citizenship_passport_no", updateCitizenshipPassport);
                cmd.Parameters.AddWithValue("@user_issue_date_ad", updateUserissueDateAD);
                cmd.Parameters.AddWithValue("@user_issue_date_bs", updateUserissueDateBS);
                cmd.Parameters.AddWithValue("@user_issue_place", updateIssueplace);
                cmd.Parameters.AddWithValue("@user_department", updateDepartment);
                cmd.Parameters.AddWithValue("@user_position", updatePosition);
                cmd.Parameters.AddWithValue("@user_contact_no1", updateContact1);
                cmd.Parameters.AddWithValue("@user_contact_no2", updateContact2);
                cmd.Parameters.AddWithValue("@user_contact_no3", updateContact3);
                cmd.Parameters.AddWithValue("@user_email1", updateEmail1);
                cmd.Parameters.AddWithValue("@user_email2", updateEmail2);
                cmd.Parameters.AddWithValue("@user_updateby", updateCreateBy);
                cmd.Parameters.AddWithValue("@user_update_date", updateCreateDate);
                cmd.Parameters.AddWithValue("@user_activateby", ActivatedBy);
                cmd.Parameters.AddWithValue("@user_activate_date", ActivatedDate);
                cmd.Parameters.AddWithValue("@user_active_status", ActivatedStatus);
                cmd.Parameters.AddWithValue("@user_photo", UserPhoto);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("User:" + Userid + "\nUpdated Successfully", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void updateDeactivated_Userinfo(string Userid, string updateFirstname, string updateMiddlename, string updateLastname, string updateGender, string updateMartialstatus, string ContactAddress, string updateCitizenshipPassport, DateTime updateUserissueDateAD, string updateUserissueDateBS, string updateIssueplace, string updateDepartment, string updatePosition, string updateContact1, string updateContact2, string updateContact3, string updateEmail1, string updateEmail2, string updateCreateBy, DateTime updateCreateDate, string DeActivatedBy, DateTime DeActivatedDate, string ActivatedStatus, byte[] UserPhoto)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "update user_info set user_fname=@user_fname,user_mname=@user_mname,user_lname=@user_lname,user_gender=@user_gender,user_martial_status=@user_martial_status,user_contact_address=@user_contact_address,user_citizenship_passport_no=@user_citizenship_passport_no,user_issue_date_ad=@user_issue_date_ad,user_issue_date_bs=@user_issue_date_bs,user_issue_place=@user_issue_place,user_department=@user_department,user_position=@user_position,user_contact_no1=@user_contact_no1,user_contact_no2=@user_contact_no2,user_contact_no3=@user_contact_no3,user_email1=@user_email1,user_email2=@user_email2,user_updateby=@user_updateby,user_update_date=@user_update_date,user_deactivateby=@user_deactivateby,user_deactivate_date=@user_deactivate_date,user_active_status=@user_active_status,user_photo=@user_photo where user_id='" + Userid + "'";
                cmd.Parameters.AddWithValue("@user_fname", updateFirstname);
                cmd.Parameters.AddWithValue("@user_mname", updateMiddlename);
                cmd.Parameters.AddWithValue("@user_lname", updateLastname);
                cmd.Parameters.AddWithValue("@user_gender", updateGender);
                cmd.Parameters.AddWithValue("@user_martial_status", updateMartialstatus);
                cmd.Parameters.AddWithValue("@user_contact_address", ContactAddress);
                cmd.Parameters.AddWithValue("@user_citizenship_passport_no", updateCitizenshipPassport);
                cmd.Parameters.AddWithValue("@user_issue_date_ad", updateUserissueDateAD);
                cmd.Parameters.AddWithValue("@user_issue_date_bs", updateUserissueDateBS);
                cmd.Parameters.AddWithValue("@user_issue_place", updateIssueplace);
                cmd.Parameters.AddWithValue("@user_department", updateDepartment);
                cmd.Parameters.AddWithValue("@user_position", updatePosition);
                cmd.Parameters.AddWithValue("@user_contact_no1", updateContact1);
                cmd.Parameters.AddWithValue("@user_contact_no2", updateContact2);
                cmd.Parameters.AddWithValue("@user_contact_no3", updateContact3);
                cmd.Parameters.AddWithValue("@user_email1", updateEmail1);
                cmd.Parameters.AddWithValue("@user_email2", updateEmail2);
                cmd.Parameters.AddWithValue("@user_updateby", updateCreateBy);
                cmd.Parameters.AddWithValue("@user_update_date", updateCreateDate);
                cmd.Parameters.AddWithValue("@user_deactivateby", DeActivatedBy);
                cmd.Parameters.AddWithValue("@user_deactivate_date", DeActivatedDate);
                cmd.Parameters.AddWithValue("@user_active_status", ActivatedStatus);
                cmd.Parameters.AddWithValue("@user_photo", UserPhoto);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("User:" + Userid + "\nUpdated Successfully", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void deleteUserinfo(string Userid, string updateFirstname, string updateMiddlename, string updateLastname)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "update user_info set user_drop_status=@user_drop_status where user_id='" + Userid + "'";
                cmd.Parameters.AddWithValue("@user_drop_status", true);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User:" + updateFirstname + updateMiddlename + updateLastname + "\n Deleted Successfully", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable Load_(string Name)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT " + Name + " FROM user_info WHERE " + Name + " != 'NULL' AND " + Name + " != '' ORDER BY " + Name + " ASC", GlobalConnection.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "user_info");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable Load_All_User(string UserID)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID], user_login_name+ ': ' + user_fname + ' ' + user_mname+ ' ' + user_lname+ ' ' [User Name] from user_info WHERE user_id LIKE '%" + UserID + "%' ORDER BY user_login_name ASC", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable LoadUserInfo()
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID],user_active_status[T],user_fname[First Name],user_mname[Middle Name],user_lname[Last Name],user_gender[Gender],user_martial_status[Martial Status],user_contact_address[Address],user_citizenship_passport_no[Citizenship Passport No],user_issue_date_ad[Issue Date AD],user_issue_date_bs[Issue Date BS],user_issue_place[Issue Place],user_department[Department],user_position[Position],user_contact_no1[Contact No 1],user_contact_no2[Contact No 2],user_contact_no3[Contact No 3],user_email1[Email 1],user_email2[Email 2] from user_info WHERE user_id !='Admin' AND user_drop_status = '0' ORDER BY user_id DESC", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable Load_All_User4Admin()
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID] from user_info", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable LoadUserInfo_Name(string Name)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID],user_active_status[T],user_fname[First Name],user_mname[Middle Name],user_lname[Last Name],user_gender[Gender],user_martial_status[Martial Status],user_contact_address[Address],user_citizenship_passport_no[Citizenship Passport No],user_issue_date_ad[Issue Date AD],user_issue_date_bs[Issue Date BS],user_issue_place[Issue Place],user_department[Department],user_position[Position],user_contact_no1[Contact No 1],user_contact_no2[Contact No 2],user_contact_no3[Contact No 3],user_email1[Email 1],user_email2[Email 2] from user_info WHERE user_fname LIKE '%" + Name + "%' AND user_drop_status = '0' AND user_id !='Admin' OR user_lname LIKE '%" + Name + "%' AND user_drop_status = '0' AND user_id !='Admin' ORDER BY user_id DESC", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable LoadUserInfo_Contact(string Contact)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID],user_active_status[T],user_fname[First Name],user_mname[Middle Name],user_lname[Last Name],user_gender[Gender],user_martial_status[Martial Status],user_contact_address[Address],user_citizenship_passport_no[Citizenship Passport No],user_issue_date_ad[Issue Date AD],user_issue_date_bs[Issue Date BS],user_issue_place[Issue Place],user_department[Department],user_position[Position],user_contact_no1[Contact No 1],user_contact_no2[Contact No 2],user_contact_no3[Contact No 3],user_email1[Email 1],user_email2[Email 2] from user_info WHERE user_contact_no1 LIKE '%" + Contact + "%' AND user_drop_status = '0' AND user_id !='Admin' OR user_contact_no2 LIKE '%" + Contact + "%' AND user_drop_status = '0' AND user_id !='Admin' OR user_contact_no3 LIKE '%" + Contact + "%' AND user_drop_status = '0' AND user_id !='Admin'  ORDER BY user_id DESC", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable LoadUserInfo_Department(string Department)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID],user_active_status[T],user_fname[First Name],user_mname[Middle Name],user_lname[Last Name],user_gender[Gender],user_martial_status[Martial Status],user_contact_address[Address],user_citizenship_passport_no[Citizenship Passport No],user_issue_date_ad[Issue Date AD],user_issue_date_bs[Issue Date BS],user_issue_place[Issue Place],user_department[Department], user_position[Position],user_contact_no1[Contact No 1],user_contact_no2[Contact No 2],user_contact_no3[Contact No 3],user_email1[Email 1],user_email2[Email 2] from user_info WHERE user_department LIKE '%" + Department + "%' AND user_drop_status = '0' AND user_id !='Admin'  ORDER BY user_id DESC", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static DataTable LoadUserInfo_Position(string Position)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_id[User ID],user_active_status[T],user_fname[First Name],user_mname[Middle Name],user_lname[Last Name],user_gender[Gender],user_martial_status[Martial Status],user_contact_address[Address],user_citizenship_passport_no[Citizenship Passport No],user_issue_date_ad[Issue Date AD],user_issue_date_bs[Issue Date BS],user_issue_place[Issue Place],user_department[Department], user_position[Position],user_contact_no1[Contact No 1],user_contact_no2[Contact No 2],user_contact_no3[Contact No 3],user_email1[Email 1],user_email2[Email 2] from user_info WHERE user_position LIKE '%" + Position + "%' AND user_drop_status = '0' AND user_id !='Admin' ORDER BY user_id DESC", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable Load_UserPhoto(string UserID)
        {
            SqlDataAdapter da_ItemType = null;
            DataSet ds_ItemType = null;
            try
            {
                GlobalConnection.PerformConnection();
                da_ItemType = new SqlDataAdapter("SELECT user_photo FROM user_info where user_id = '" + UserID + "'", GlobalConnection.cn);
                ds_ItemType = new DataSet();
                da_ItemType.Fill(ds_ItemType, "user_photo");
                return ds_ItemType.Tables["user_photo"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable CheckLoginName()
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_login_name from user_info", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static DataTable checkUserPassword(string loginName, string passwword)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;

                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select user_login_name,user_login_pwd from user_info WHERE user_login_name ='" + loginName + "' AND user_login_pwd='" + passwword + "'", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "user");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }


        public static void updateUserPassword(string updateLoginname, string updateLoginpassword, string ChangedBy, DateTime updateCreateDate)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "update user_info set user_login_pwd=@user_login_pwd,user_updateby=@user_updateby,user_update_date=@user_update_date where user_login_name='" + updateLoginname + "'";

               
                cmd.Parameters.AddWithValue("@user_login_pwd", updateLoginpassword);
                cmd.Parameters.AddWithValue("@user_updateby", ChangedBy);
                cmd.Parameters.AddWithValue("@user_update_date", updateCreateDate);

                cmd.ExecuteNonQuery();
                MessageBox.Show("User: " + updateLoginname + "\nPassword Changed Successfully", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
