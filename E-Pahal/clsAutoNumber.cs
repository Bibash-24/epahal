using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace E_Pahal
{
    class clsAutoNumber
    {
        //public static int MaxPlus;
        //public static string AutoNumber;
        public static string SerialNumber(string tableField, string tableName, string FirstLetter)
        {
            GlobalConnection.PerformConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("SELECT substring (MAX(" + tableField + "),2,5) FROM " + tableName + "", GlobalConnection.cn);
            DataSet ds = new DataSet();

            da.Fill(ds, tableName);

            string MaxNo = ds.Tables[0].Rows[0][0].ToString();
            if (MaxNo == "")
            {
                MaxPlus = 1;
            }
            else
            {
                MaxPlus = Convert.ToInt16(MaxNo) + 1;
            }


            if (MaxPlus < 10)
            {
                AutoNumber = FirstLetter + "000" + Convert.ToString(MaxPlus);
            }
            else if (MaxPlus >= 10 && MaxPlus < 100)
            {
                AutoNumber = FirstLetter + "00" + Convert.ToString(MaxPlus);
            }
            else if (MaxPlus >= 100 && MaxPlus < 1000)
            {
                AutoNumber = FirstLetter + "0" + Convert.ToString(MaxPlus);
            }
            else if (MaxPlus >= 1000 && MaxPlus < 10000)
            {
                AutoNumber = FirstLetter + Convert.ToString(MaxPlus);
            }
            return AutoNumber;
        }
         //////////////-REPEATING WITH OFFLINE
        
        public static SqlDataAdapter daID = null;
        public static DataSet dsID = null;
        public static int MaxPlus;
        public static string AutoNumber;

        public static string AutoSerialNumber(string tableField, string tableName, string FirstLetter,DataSet datasetAutoNumber)
        {
            if (GlobalConnection.ServerAvailable == true)
            {
                GlobalConnection.PerformConnection();
                daID = new SqlDataAdapter();
                daID = new SqlDataAdapter("SELECT substring (MAX(" + tableField + "),2,5) FROM " + tableName + "",GlobalConnection.cn);
                dsID = new DataSet();

                daID.Fill(dsID, tableName);
                
                string MaxNo = dsID.Tables[0].Rows[0][0].ToString();
                AutoNumber = num(MaxNo, FirstLetter);
                return AutoNumber;
            }
            else if (GlobalConnection.ServerAvailable == false)
            {
                // creating dataview object using constructor and passing parameters

                //It creates dataview from dataset ds of offlinetable with arguments as studentid shouldnt be null, show studentid fields of current rows.
                DataView autonumberdv = new DataView(datasetAutoNumber.Tables[tableName], tableField + " is not null", tableField, DataViewRowState.CurrentRows);
                //This will filter the dataview by using max function. This dsplay the fiels which have highest id.
                autonumberdv.RowFilter = ""+tableField+" = Max("+tableField+")";
                    
              
                string MaxValue = autonumberdv[0].Row[tableField].ToString();
                string MaxNo = MaxValue.Substring(1, 4);
                AutoNumber = num(MaxNo, FirstLetter);
                return AutoNumber;

            }
            else
            {
                return null;
            }
        }
        
        
        public static string num(string MaxNo, string FirstLetter)
        {

            if (MaxNo == "")
            {
                MaxPlus = 1;
            }
            else
            {
                MaxPlus = Convert.ToInt16(MaxNo) + 1;
            }


            if (MaxPlus < 10)
            {
                AutoNumber = FirstLetter + "000" + Convert.ToString(MaxPlus);
            }
            else if (MaxPlus >= 10 && MaxPlus < 100)
            {
                AutoNumber = FirstLetter + "00" + Convert.ToString(MaxPlus);
            }
            else if (MaxPlus >= 100 && MaxPlus < 1000)
            {
                AutoNumber = FirstLetter + "0" + Convert.ToString(MaxPlus);
            }
            else if (MaxPlus >= 1000 && MaxPlus < 10000)
            {
                AutoNumber = FirstLetter + Convert.ToString(MaxPlus);
            }

            return AutoNumber;

        }
       
       
    }
}
