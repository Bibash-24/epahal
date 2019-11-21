using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Pahal
{
    class cls_Subscription
    {
       
        //DATA ADAPTER AND DATA SET FOR ENQUIRY SELECTED RECORD
        public static SqlDataAdapter daStudentInfo = null;
        public static SqlDataAdapter daStudentInfoo = null;
        public static DataSet dsStudentInfo = null;
        public static DataSet dsStudentInfoo = null;

        public static void Save_Client_Info(string formNo, string OrgName, string OrgAdd, string OrgDist, string OrgPhone, string OrgFirstPerson, string OrgFirstPersonMobile, string ContactPerson, string ContactMobile, string FeedBack , string Remarks, string ReferedBy, DateTime RegDate, string NRegDate)
        {
            try
            {
                GlobalConnection.PerformConnection();

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "INSERT INTO EPahal_Client(formID,organization_name,organization_address,organization_district,organization_phone,organization_first_persion,organization_first_persion_mobile,contact_person,contact_person_moble,feedback,remarks,refered_by,reg_date,reg_ndate,CreateBy,CreateDate) VALUES" + "(@formID,@organization_name,@organization_address,@organization_district,@organization_phone,@organization_first_persion,@organization_first_persion_mobile,@contact_person,@contact_person_moble,@feedback,@remarks,@refered_by,@reg_date,@reg_ndate,@CreateBy,@CreateDate)";
                cmd.Parameters.AddWithValue("@formID", formNo);
                cmd.Parameters.AddWithValue("@organization_name", OrgName);
                cmd.Parameters.AddWithValue("@organization_address", OrgAdd);
                cmd.Parameters.AddWithValue("@organization_district", OrgDist);
                cmd.Parameters.AddWithValue("@organization_phone", OrgPhone);
                cmd.Parameters.AddWithValue("@organization_first_persion", OrgFirstPerson);
                cmd.Parameters.AddWithValue("@organization_first_persion_mobile", OrgFirstPersonMobile);
                cmd.Parameters.AddWithValue("@contact_person", ContactPerson);
                cmd.Parameters.AddWithValue("@contact_person_moble", ContactMobile);
                cmd.Parameters.AddWithValue("@feedback", FeedBack);
                cmd.Parameters.AddWithValue("@remarks", Remarks); 
                cmd.Parameters.AddWithValue("@refered_by", ReferedBy); 
                cmd.Parameters.AddWithValue("@reg_date", RegDate);
                cmd.Parameters.AddWithValue("@reg_ndate", NRegDate);
                cmd.Parameters.AddWithValue("@CreateBy", GlobalConnection.strUid);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                //MessageBox.Show(GlobalConnection.DataSaved, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update_ClientInfo(string formNo, string OrgName, string OrgAdd, string OrgDist, string OrgPhone, string OrgFirstPerson, string OrgFirstPersonMobile, string ContactPerson, string ContactMobile, string FeedBack, string Remarks, string ReferedBy, DateTime RegDate,string NRegDate)
        {
            try
            {
                GlobalConnection.PerformConnection();

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "UPDATE EPahal_Client set organization_name=@organization_name,organization_address=@organization_address,organization_district=@organization_district,organization_phone=@organization_phone,organization_first_persion=@organization_first_persion,organization_first_persion_mobile=@organization_first_persion_mobile,contact_person=@contact_person,contact_person_moble=@contact_person_moble,feedback=@feedback,remarks=@remarks,refered_by=@refered_by,reg_date=@reg_date,reg_ndate=@reg_ndate,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate where formID = '" + formNo + "'";
                cmd.Parameters.AddWithValue("@organization_name", OrgName);
                cmd.Parameters.AddWithValue("@organization_address", OrgAdd);
                cmd.Parameters.AddWithValue("@organization_district", OrgDist);
                cmd.Parameters.AddWithValue("@organization_phone", OrgPhone);
                cmd.Parameters.AddWithValue("@organization_first_persion", OrgFirstPerson);
                cmd.Parameters.AddWithValue("@organization_first_persion_mobile", OrgFirstPersonMobile);
                cmd.Parameters.AddWithValue("@contact_person", ContactPerson);
                cmd.Parameters.AddWithValue("@contact_person_moble", ContactMobile);
                cmd.Parameters.AddWithValue("@feedback", FeedBack);
                cmd.Parameters.AddWithValue("@remarks", Remarks);
                cmd.Parameters.AddWithValue("@refered_by", ReferedBy);
                cmd.Parameters.AddWithValue("@reg_date", RegDate);
                cmd.Parameters.AddWithValue("@reg_ndate", NRegDate);
                cmd.Parameters.AddWithValue("@UpdateBy", GlobalConnection.strUid);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                //MessageBox.Show(GlobalConnection.DataUpdate, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Save_Subscription_Info(string SubID, string FormID, string invoice, string receipt, string email, string noticeSupply, string noticeConstruction, string noticeConsultancy, DateTime startdate, string NStartDate, string period, DateTime ExpireDate, string NExpiryDate, string receivedby, string checkedby, string amount, DateTime recDate, string NRecDate, string cash, string chequeNo, string DepositedBy, string BankName, string SubType)
        {
            try
            {
                GlobalConnection.PerformConnection();


                //Subs_ID, Client_ID, Invoice_no, receipt_no, service_email, notice_type_supply, notice_type_construction, notice_type_consultancy, service_start_date, service_start_ndate, service_period, service_expire_date, service_expire_ndate, receive_amount, receive_amount_date, receive_amount_ndate, cash, cheque_no, deposite_by, bank_name, received_by, sub_type, checked_by, CreateBy, CreateDate

                //, , , receipt_no, service_email, 
                //, , , service_start_date, , service_period, service_expire_date, 

                //service_expire_ndate, receive_amount, receive_amount_date, 
                //, cash, cheque_no, deposite_by, bank_name, 
                //received_by, , checked_by, , 

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "INSERT INTO EPahal_Subscription(Subs_ID, Client_ID, Invoice_no, receipt_no, service_email, notice_type_supply, notice_type_construction, notice_type_consultancy, service_start_date, service_start_ndate, service_period, service_expire_date, service_expire_ndate, receive_amount, receive_amount_date, receive_amount_ndate, cash, cheque_no, deposite_by, bank_name, received_by, sub_type, checked_by, CreateBy, CreateDate) VALUES" + "(@Subs_ID, @Client_ID, @Invoice_no, @receipt_no, @service_email, @notice_type_supply, @notice_type_construction, @notice_type_consultancy, @service_start_date, @service_start_ndate, @service_period, @service_expire_date, @service_expire_ndate, @receive_amount, @receive_amount_date, @receive_amount_ndate, @cash, @cheque_no, @deposite_by, @bank_name, @received_by, @sub_type, @checked_by, @CreateBy, @CreateDate)";
                cmd.Parameters.AddWithValue("@Subs_ID", SubID);
                cmd.Parameters.AddWithValue("@Client_ID", FormID);
                cmd.Parameters.AddWithValue("@Invoice_no", invoice);
                cmd.Parameters.AddWithValue("@receipt_no", receipt);
                cmd.Parameters.AddWithValue("@service_email", email);
                cmd.Parameters.AddWithValue("@notice_type_supply", noticeSupply);
                cmd.Parameters.AddWithValue("@notice_type_construction", noticeConstruction);
                cmd.Parameters.AddWithValue("@notice_type_consultancy", noticeConsultancy);
                cmd.Parameters.AddWithValue("@service_start_date", startdate);
                cmd.Parameters.AddWithValue("@service_start_ndate", NStartDate);
                cmd.Parameters.AddWithValue("@service_period", period);
                cmd.Parameters.AddWithValue("@service_expire_date", ExpireDate);
                cmd.Parameters.AddWithValue("@service_expire_ndate", NExpiryDate);
                cmd.Parameters.AddWithValue("@receive_amount", amount);
                cmd.Parameters.AddWithValue("@receive_amount_date", recDate);
                cmd.Parameters.AddWithValue("@receive_amount_ndate", NRecDate);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@cheque_no", chequeNo);
                cmd.Parameters.AddWithValue("@deposite_by", DepositedBy);
                cmd.Parameters.AddWithValue("@bank_name", BankName);
                cmd.Parameters.AddWithValue("@received_by", receivedby);
                cmd.Parameters.AddWithValue("@sub_type", SubType);
                cmd.Parameters.AddWithValue("@checked_by", checkedby);
                cmd.Parameters.AddWithValue("@CreateBy", GlobalConnection.strUid);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show(GlobalConnection.DataSaved, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        public static void Update_SubscriptionInfo(string SubID, string FormID, string invoice, string receipt, string email, string noticeSupply, string noticeConstruction, string noticeConsultancy, DateTime startdate, string NStartDate, string period, DateTime ExpireDate, string NExpiryDate, string receivedby, string checkedby, string amount, DateTime recDate, string NRecDate, string cash, string chequeNo, string DepositedBy, string BankName)
        {
            try
            {
                GlobalConnection.PerformConnection();

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                //Subs_ID, Client_ID, Invoice_no, receipt_no, service_email, notice_type_supply, notice_type_construction, notice_type_consultancy, service_start_date, service_start_ndate, service_period, service_expire_date, service_expire_ndate, receive_amount, receive_amount_date, receive_amount_ndate, cash, cheque_no, deposite_by, bank_name, received_by, sub_type, checked_by, CreateBy, CreateDate
                cmd.CommandText = "UPDATE EPahal_Subscription set Subs_ID=@Subs_ID,Client_ID=@Client_ID,Invoice_no=@Invoice_no,receipt_no=@receipt_no,service_email=@service_email,notice_type_supply=@notice_type_supply,notice_type_construction=@notice_type_construction,notice_type_consultancy=@notice_type_consultancy,service_start_date=@service_start_date,service_start_ndate=@service_start_ndate,service_period=@service_period,service_expire_date=@service_expire_date,service_expire_ndate=@service_expire_ndate,receive_amount=@receive_amount,receive_amount_date=@receive_amount_date,receive_amount_ndate=@receive_amount_ndate,cash=@cash,cheque_no=@cheque_no,deposite_by=@deposite_by,bank_name=@bank_name,received_by=@received_by,sub_type=@sub_type,checked_by=@checked_by,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate where Subs_ID= '" + SubID + "'";
                cmd.Parameters.AddWithValue("@Subs_ID", SubID);
                cmd.Parameters.AddWithValue("@Client_ID", FormID);
                cmd.Parameters.AddWithValue("@Invoice_no", invoice);
                cmd.Parameters.AddWithValue("@receipt_no", receipt);
                cmd.Parameters.AddWithValue("@service_email", email);
                cmd.Parameters.AddWithValue("@notice_type_supply", noticeSupply);
                cmd.Parameters.AddWithValue("@notice_type_construction", noticeConstruction);
                cmd.Parameters.AddWithValue("@notice_type_consultancy", noticeConsultancy);
                cmd.Parameters.AddWithValue("@service_start_date", startdate);
                cmd.Parameters.AddWithValue("@service_start_ndate", NStartDate);
                cmd.Parameters.AddWithValue("@service_period", period);
                cmd.Parameters.AddWithValue("@service_expire_date", ExpireDate);
                cmd.Parameters.AddWithValue("@service_expire_ndate", NExpiryDate);
                cmd.Parameters.AddWithValue("@receive_amount", amount);
                cmd.Parameters.AddWithValue("@receive_amount_date", recDate);
                cmd.Parameters.AddWithValue("@receive_amount_ndate", NRecDate);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@cheque_no", chequeNo);
                cmd.Parameters.AddWithValue("@deposite_by", DepositedBy);
                cmd.Parameters.AddWithValue("@bank_name", BankName);
                cmd.Parameters.AddWithValue("@received_by", receivedby);
                cmd.Parameters.AddWithValue("@sub_type", "New");
                cmd.Parameters.AddWithValue("@checked_by", checkedby);
                cmd.Parameters.AddWithValue("@UpdateBy", GlobalConnection.strUid);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show(GlobalConnection.DataUpdate, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Verify_SubscriptionInfo(string SubID, string FormID, string invoice, string receipt, string email, string noticeSupply, string noticeConstruction, string noticeConsultancy, DateTime startdate, string NStartDate, string period, DateTime ExpireDate, string NExpiryDate, string receivedby, string checkedby, string amount, DateTime recDate, string NRecDate, string cash, string chequeNo, string DepositedBy, string BankName)
        {
            try
            {
                GlobalConnection.PerformConnection();

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                //Subs_ID, Client_ID, Invoice_no, receipt_no, service_email, notice_type_supply, notice_type_construction, notice_type_consultancy, service_start_date, service_start_ndate, service_period, service_expire_date, service_expire_ndate, receive_amount, receive_amount_date, receive_amount_ndate, cash, cheque_no, deposite_by, bank_name, received_by, sub_type, checked_by, CreateBy, CreateDate
                cmd.CommandText = "UPDATE EPahal_Subscription set Subs_ID=@Subs_ID,Client_ID=@Client_ID,Invoice_no=@Invoice_no,receipt_no=@receipt_no,service_email=@service_email,notice_type_supply=@notice_type_supply,notice_type_construction=@notice_type_construction,notice_type_consultancy=@notice_type_consultancy,service_start_date=@service_start_date,service_start_ndate=@service_start_ndate,service_period=@service_period,service_expire_date=@service_expire_date,service_expire_ndate=@service_expire_ndate,receive_amount=@receive_amount,receive_amount_date=@receive_amount_date,receive_amount_ndate=@receive_amount_ndate,cash=@cash,cheque_no=@cheque_no,deposite_by=@deposite_by,bank_name=@bank_name,received_by=@received_by,sub_type=@sub_type,checked_by=@checked_by,VerifiedBy=@VerifiedBy,VerifiedDate=@VerifiedDate where Subs_ID= '" + SubID + "'";
                cmd.Parameters.AddWithValue("@Subs_ID", SubID);
                cmd.Parameters.AddWithValue("@Client_ID", FormID);
                cmd.Parameters.AddWithValue("@Invoice_no", invoice);
                cmd.Parameters.AddWithValue("@receipt_no", receipt);
                cmd.Parameters.AddWithValue("@service_email", email);
                cmd.Parameters.AddWithValue("@notice_type_supply", noticeSupply);
                cmd.Parameters.AddWithValue("@notice_type_construction", noticeConstruction);
                cmd.Parameters.AddWithValue("@notice_type_consultancy", noticeConsultancy);
                cmd.Parameters.AddWithValue("@service_start_date", startdate);
                cmd.Parameters.AddWithValue("@service_start_ndate", NStartDate);
                cmd.Parameters.AddWithValue("@service_period", period);
                cmd.Parameters.AddWithValue("@service_expire_date", ExpireDate);
                cmd.Parameters.AddWithValue("@service_expire_ndate", NExpiryDate);
                cmd.Parameters.AddWithValue("@receive_amount", amount);
                cmd.Parameters.AddWithValue("@receive_amount_date", recDate);
                cmd.Parameters.AddWithValue("@receive_amount_ndate", NRecDate);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@cheque_no", chequeNo);
                cmd.Parameters.AddWithValue("@deposite_by", DepositedBy);
                cmd.Parameters.AddWithValue("@bank_name", BankName);
                cmd.Parameters.AddWithValue("@received_by", receivedby);
                cmd.Parameters.AddWithValue("@sub_type", "New");
                cmd.Parameters.AddWithValue("@checked_by", checkedby);
                cmd.Parameters.AddWithValue("@VerifiedBy", GlobalConnection.strUid);
                cmd.Parameters.AddWithValue("@VerifiedDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show(GlobalConnection.DataVerified, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Delete(string formno)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    //  DELETING DATABASE TABLE

                    SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                    cmd.CommandText = "UPDATE EPahal_Client SET estatus=0 WHERE formID='" + formno + "'";
                    //cmd.Parameters.AddWithValue("@pp_deleteby", GlobalConnection.strUid);
                    //cmd.Parameters.AddWithValue("@pp_deletedate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(GlobalConnection.DataDelete, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        public static void DeleteClientSubscription(string subno)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    //  DELETING DATABASE TABLE

                    SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                    cmd.CommandText = "UPDATE EPahal_Subscription SET sub_dstatus=0 WHERE Subs_ID='" + subno + "'";
                    //cmd.Parameters.AddWithValue("@pp_deleteby", GlobalConnection.strUid);
                    //cmd.Parameters.AddWithValue("@pp_deletedate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(GlobalConnection.DataDelete, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        public static DataTable Search_Subscriber_Status_All_WithoutDate(string OrgName, string OrgAdd, string OrgDist, string OrgPhNo, string OrgEmail)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE  EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 AND EPahal_Client.organization_name like '%" + OrgName + "%' AND EPahal_Client.organization_address like '%" + OrgAdd + "%'AND EPahal_Client.organization_district like '%" + OrgDist + "%'AND EPahal_Client.organization_phone like '%" + OrgPhNo + "%'AND EPahal_Subscription.service_email like '%" + OrgEmail + "%'ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable Search_Subscriber_Status_All_WithDate(string OrgName, string OrgAdd, string OrgDist, string OrgPhNo, string OrgEmail, string Status, DateTime BDate, DateTime EDate)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE  EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 AND EPahal_Client.organization_name like '%" + OrgName + "%' AND EPahal_Client.organization_address like '%" + OrgAdd + "%'AND EPahal_Client.organization_district like '%" + OrgDist + "%'AND EPahal_Client.organization_phone like '%" + OrgPhNo + "%'AND EPahal_Subscription.service_email like '%" + OrgEmail + "%'AND EPahal_Subscription.VerifiedBy LIKE '%" + Status + "%' AND EPahal_Subscription.service_start_date BETWEEN '" + BDate + "' AND '" + EDate + "' ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable Search_Subscriber_Verified_NonVerified(string OrgName, string OrgAdd, string OrgDist, string OrgPhNo, string OrgEmail, string Type, string Status, DateTime BDate, DateTime EDate)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE  EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 AND EPahal_Client.organization_name like '%" + OrgName + "%' AND EPahal_Client.organization_address like '%" + OrgAdd + "%'AND EPahal_Client.organization_district like '%" + OrgDist + "%'AND EPahal_Client.organization_phone like '%" + OrgPhNo + "%'AND EPahal_Subscription.service_email like '%" + OrgEmail + "%'AND EPahal_Subscription.sub_type = '" + Type + "'AND EPahal_Subscription.VerifiedBy like '" + Status + "%'AND EPahal_Subscription.service_start_date BETWEEN '" + BDate + "' AND '" + EDate + "' ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }



        public static DataTable LoadSubscriber()
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE  EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Name(string Name)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE organization_name LIKE LTRIM('%" + Name + "%') AND EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Add(string Add)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE organization_address LIKE LTRIM('%" + Add + "%') AND EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Pho(string Pho)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE organization_phone LIKE LTRIM('%" + Pho + "%') AND EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Email(string Email)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE service_email LIKE LTRIM('%" + Email + "%') AND EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable Load_(string Name)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT " + Name + " FROM EPahal_Client WHERE " + Name + " != 'NULL' AND " + Name + " != '' ORDER BY " + Name + " ASC", GlobalConnection.cn);
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

        public static DataTable Load_district(string district)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE organization_district LIKE '%" + district + "%' AND EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

        public static DataTable Load_sub_type(string sub)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE sub_type = '" + sub + "' AND EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public static DataTable Search_Selection()
        {
            GlobalConnection.PerformConnection();
            daStudentInfo = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE  EPahal_Client.estatus = 1 AND EPahal_Subscription.sub_status = 1 AND EPahal_Subscription.sub_dstatus=1 ORDER BY EPahal_Client.formID DESC", GlobalConnection.cn);
            dsStudentInfo = new DataSet();
            daStudentInfo.Fill(dsStudentInfo, "subscriber_search");
            DataTable dt_search = dsStudentInfo.Tables["subscriber_search"];
            return dt_search;
        }

        public static DataTable Search_Particular(string fno)
        {
            GlobalConnection.PerformConnection();
            daStudentInfo = new SqlDataAdapter("select EPahal_Client.formID[Form No.],EPahal_Client.organization_name[Name of Organization],EPahal_Client.organization_address[Address of Organization],EPahal_Client.organization_district[District],EPahal_Client.organization_phone[Phone No.],EPahal_Client.organization_first_persion[First Person of Organization],EPahal_Client.organization_first_persion_mobile[First Person Mobile],EPahal_Client.contact_person[Contact Person],EPahal_Client.contact_person_moble[Mobile No.],EPahal_Client.refered_by[Refered By],EPahal_Client.feedback[Feedbacks],EPahal_Client.remarks[Remarks],EPahal_Client.reg_date[Registration Date in A.D],EPahal_Client.reg_ndate[Registration Date in B.S],EPahal_Subscription.Subs_ID[Subscription ID],EPahal_Subscription.Invoice_no[Invoice No.],EPahal_Subscription.receipt_no[Receipt No.],EPahal_Subscription.service_email[Service Receiving Email Address],EPahal_Subscription.notice_type_supply[Supply],EPahal_Subscription.notice_type_construction[Construction],EPahal_Subscription.notice_type_consultancy[Consultancy],EPahal_Subscription.service_start_date[Service Start Date in A.D],EPahal_Subscription.service_start_ndate[Service Start Date in B.S],EPahal_Subscription.service_period[Service Period],EPahal_Subscription.service_expire_date[Service Expire Date in A.D],EPahal_Subscription.service_expire_ndate[Service Expire Date in B.S],EPahal_Subscription.receive_amount[Received Amount],EPahal_Subscription.receive_amount_date[Received Amount Date in A.D],EPahal_Subscription.receive_amount_ndate[Received Amount Date in B.S],EPahal_Subscription.cash[Cash],EPahal_Subscription.cheque_no[Cheque No.],EPahal_Subscription.deposite_by[Bank Deposited By],EPahal_Subscription.bank_name[Bank Name],EPahal_Subscription.sub_type[Subscription Type],EPahal_Subscription.received_by[Received By],EPahal_Subscription.checked_by[Checked By] from EPahal_Client INNER JOIN EPahal_Subscription ON EPahal_Client.formID=EPahal_Subscription.Client_ID WHERE EPahal_Client.formID = '" + fno + "'", GlobalConnection.cn);
            dsStudentInfo = new DataSet();
            daStudentInfo.Fill(dsStudentInfo, "subscriber_search");
            DataTable dt_search = dsStudentInfo.Tables["subscriber_search"];
            return dt_search;
        }

        public static DataTable LoadVerified(string SubID)
        {
            try
            {
                SqlDataAdapter da = null;
                DataSet ds = null;
                GlobalConnection.PerformConnection();
                da = new SqlDataAdapter("Select VerifiedBy from EPahal_Subscription where Subs_ID = '" + SubID + "' ", GlobalConnection.cn);
                ds = new DataSet();
                da.Fill(ds, "icat");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static void Update_SubscriptionInfoStatus(string FormID)
        {
            try
            {
                GlobalConnection.PerformConnection();
                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "UPDATE EPahal_Subscription set sub_status=@sub_status where Client_ID= '" + FormID + "'";
                cmd.Parameters.AddWithValue("@sub_status", 0);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }


}
