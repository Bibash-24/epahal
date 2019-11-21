using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace E_Pahal
{
    class GlobalConnection
    {
        public static SqlConnection cn;
        //SERVER INFORMATION
        public static string strServer = @"DESKTOP-5UI1E43";
        public static string strSUid = "sa";
        public static string strSPwd = "nikesh";
        public static string strDatabase = "eduMediatorTest";

        //CONNECTION DETAILS
        

        //USER INFORMATION
        public static string strUid;

        

        public static string strUserLoginName;
        public static string strUsername;
        public static string strPWD;
        public static string strUCategory;
        public static string strUStatus;
        public static string strUpdateDelete = "";
        public static string strClintId = "";
        public static string strClintName = "";


        
      
        //SERVER STATUS NFORMATION
        public static Boolean ServerAvailable;

        public static string DataSaved = "Record Saved Sucessfully.";
        public static string DataUpdate = "Record Updated Sucessfully.";
        public static string DataVerified = "Record Verified Sucessfully.";
        public static string DataDelete = "Record Deleted Sucessfully.";
        
        public static string DataAdd = "Adding New Record.";

        public static string ProjectName = "E-Pahal";
        
        //ORGANIZATION INFORMATION
        public static string strCompanyName = "E-Pahal Nepal Pvt. Ltd.";
        public static string strCompanyAddress = "Tokha, Kathmandu, Nepal";
        public static string strCompanyContactInfo = "+977-1-4359609";



        public static string con_string;

        public static void PerformConnection()
        {
            try
            {
                //cn = new SqlConnection("Server=" + strServer + ";Uid=" + strSUid + ";Pwd=" + strSPwd + ";Database=" + strDatabase);
                con_string = @"Data Source=localhost;Initial Catalog=EPahal;Integrated Security=true";
                cn = new SqlConnection(con_string);
                cn.Open();
                ServerAvailable = true;
            }
            catch
            {
                ServerAvailable = false;
            }

            
        }

    }
}
