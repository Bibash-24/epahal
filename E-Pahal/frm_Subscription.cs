using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace E_Pahal
{
    public partial class frm_Subscription : Form
    {

        public static Boolean SaveMode_ClientInfo = true;
        public static Boolean SaveMode_SubscriptionInfo = true;
        public static Boolean SaveMode_SubscriptionInfoRenew = true;
        public static Boolean startDate = false;

        public frm_Subscription()
        {
            InitializeComponent();
        }

        private void frm_Subscription_Load(object sender, EventArgs e)
        {
            if (GlobalConnection.strUid == "Admin")
            {
                lbl_CheckedBy.Visible = true;
                txt_CheckedBy.Visible = true;
                btn_VerifySub.Enabled = true;
                lbl_CheckedByR.Visible = true;
                txt_CheckedByR.Visible = true;
            }
            else
            {
                lbl_CheckedBy.Visible = false;
                txt_CheckedBy.Visible = false;
                btn_VerifySub.Enabled = false;
                lbl_CheckedByR.Visible = false;
                txt_CheckedByR.Visible = false;
            }


            txt_formnum.Text = clsAutoNumber.SerialNumber("formid", "EPahal_Client", "C");
            txt_SubID.Text = clsAutoNumber.SerialNumber("Subs_ID", "EPahal_Subscription", "S");
            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
            btn_GenerateReport.Enabled = false;
            btn_GenerateReportR.Enabled = false;


            //LOADING DISTRICT
            cmb_District.DataSource = cls_Subscription.Load_("organization_district");
            cmb_District.DisplayMember = "organization_district";
            cmb_District.Text = "";

            //LOADING REFERED BY
            cmb_referedBy.DataSource = cls_Subscription.Load_("refered_by");
            cmb_referedBy.DisplayMember = "refered_by";
            cmb_referedBy.Text = "";

            //LOADING DISTRICT Search
            dist_search.DataSource = cls_Subscription.Load_("organization_district");
            dist_search.DisplayMember = "organization_district";
            dist_search.Text = "";
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            SaveMode_ClientInfo = true;
            startDate = false;
            txt_formnum.ResetText();
            txt_invoice.ResetText();
            txt_receipt.ResetText();
            txt_orgName.ResetText();
            cmb_District.ResetText();
            txt_orgAdd.ResetText();
            txt_orgPhone.ResetText();
            txt_orgFirst.ResetText();
            txt_orgFirstMobile.ResetText();
            txt_contactPerson.ResetText();
            txt_contactPersonMobile.ResetText();
            txt_email.ResetText();
            chk_supply.Checked = false;
            chk_construction.Checked = false;
            chk_consultancy.Checked = false;
            dtp_startDate.ResetText();
            rb_year1.Checked = false;
            rb_year2.Checked = false;
            rb_year3.Checked = false;
            rb_year5.Checked = false;
            dtp_ExpireDate.ResetText();
            txt_amount.ResetText();
            dtp_recDate.ResetText();
            chk_cash.Checked = false;
            txt_chequeNo.ResetText();
            txt_depositeby.ResetText();
            txt_BankName.ResetText();
            cmb_referedBy.ResetText();
            txt_SubID.ResetText();
            txt_ReceivedBy.ResetText();
            txt_CheckedBy.ResetText();
            txt_fdbck.ResetText();
            txt_rmark.ResetText();
            txt_orgName.Focus();
            txt_formnum.Text = clsAutoNumber.SerialNumber("formid", "EPahal_Client", "C");
            txt_SubID.Text = clsAutoNumber.SerialNumber("Subs_ID", "EPahal_Subscription", "S");
        }

        
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_subscriber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

        private void txt_addsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Add(txt_addsearch.Text);
        }

        private void txt_phsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Pho(txt_phsearch.Text);
        }

        private void txt_emailsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Email(txt_emailsearch.Text);
        }

        private void btn_ResetSearch_Click(object sender, EventArgs e)
        {
            txt_namesearch.ResetText();
            txt_addsearch.ResetText();
            txt_phsearch.ResetText();
            txt_emailsearch.ResetText();
            dist_search.ResetText();
            cmb_sub_type.ResetText();
            cmb_SubscriptionStatus.ResetText();
            dtp_BeginningDate.ResetText();
            dtp_EndingDate.ResetText();
            txt_BeginningDate.ResetText();
            txt_EndingDate.ResetText();
            txt_emailsearch.Focus();
            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
        }

        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = 300;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 0f;
            return cell;
        }

        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(path);
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;

            return cell;
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            try
            {
                PdfContentByte contentByte = writer.DirectContent;
                contentByte.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();
            }
            catch
            {

            }
        }


        private void rb_year1_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(1).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDate.ResetText();
            }
            
        }

        private void rb_year2_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(2).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDate.ResetText();
            }

        }

        private void rb_year3_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(3).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDate.ResetText();
            }

        }

        private void rb_year5_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(5).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDate.ResetText();
            }

        }


        private void txt_orgName_TextChanged(object sender, EventArgs e)
        {
            if (txt_orgName.Text != "")
            {
                errorProvider_Subscription.SetError(txt_orgName, "");
            }
        }

        private void txt_orgName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgAdd.Focus();
            }
        }

        private void txt_orgAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmb_District.Focus();
            }
        }

        private void cmb_District_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgPhone.Focus();
            }
        }

        private void txt_orgPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgFirst.Focus();
            }
        }

        private void txt_orgFirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgFirstMobile.Focus();
            }
        }

        private void txt_orgFirstMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_contactPerson.Focus();
            }
        }

        private void txt_contactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_contactPersonMobile.Focus();
            }
        }

        private void txt_contactPersonMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_fdbck.Focus();
            }
        }

        private void txt_fdbck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_rmark.Focus();
            }
        }

        private void txt_rmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmb_referedBy.Focus();
            }
        }

        private void cmb_referedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_regdate.Focus();
            }
        }

        private void dtp_startDate_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_startDate.Text));
            txtNepaliStartDate.Text = string.Format("{0}", npdate.npDate);
        }

        private void dtp_ExpireDate_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_ExpireDate.Text));
            txtNepaliExpiryDate.Text = string.Format("{0}", npdate.npDate);
        }

        private void dtp_recDate_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_recDate.Text));
            txtNepaliRecDate.Text = string.Format("{0}", npdate.npDate);
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_supply.Focus();
            }
        }

        private void chk_supply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_construction.Focus();
            }
        }

        private void chk_construction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_consultancy.Focus();
            }
        }

        private void chk_consultancy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_startDate.Focus();
            }
        }

        private void dtp_startDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DateTime Temp;
                    if (DateTime.TryParse(Convert.ToDateTime(dtp_startDate.Text).ToShortDateString(), out Temp) == true)
                    {
                        rb_year1.Focus();
                        startDate = true;
                        dtp_startDate_ValueChanged(sender, e);
                    }
                    else
                    {
                        dtp_startDate.Focus();
                    }
                }
            }
            catch
            {

            }
        }

        private void rb_year1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year1.Checked == true)
                {
                    txt_invoice.Focus();
                }
                else
                {
                    rb_year2.Focus();
                }
            }
        }

        private void rb_year2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year2.Checked == true)
                {
                    txt_invoice.Focus();
                }
                else
                {
                    rb_year3.Focus();
                }
            }
        }

        private void rb_year3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year3.Checked == true)
                {
                    txt_invoice.Focus();
                }
                else
                {
                    rb_year5.Focus();
                }
            }
        }

        private void rb_year5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year5.Checked == true)
                {
                    txt_invoice.Focus();
                }
                else
                {
                    rb_year5.Focus();
                }
            }
        }

        private void txtNepaliExpiryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_invoice.Focus();
            }
        }

        private void txtNepaliExpiryDate_Leave(object sender, EventArgs e)
        {
            txt_invoice.Focus();
        }

        private void txt_invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_receipt.Focus();
            }
        }

        private void txt_receipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_amount.Focus();
            }
        }

        private void txt_receipt_Leave(object sender, EventArgs e)
        {
            txt_amount.Focus();
        }
        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_recDate.Focus();
            }
        }

        private void dtp_recDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_cash.Focus();
                dtp_recDate_ValueChanged(sender, e);
            }
        }

        private void txt_cash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_chequeNo.Focus();
            }
        }

        private void txt_chequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_depositeby.Focus();
            }
        }

        private void txt_depositeby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_BankName.Focus();
            }
        }


        private void txt_BankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ReceivedBy.Focus();
            }
        }

        private void txt_ReceivedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GlobalConnection.strUserLoginName == "Admin")
                {
                    txt_CheckedBy.Focus();
                }
                else
                {
                    btn_SaveSub.Focus();
                }
            }
        }

        private void txt_CheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SaveMode_SubscriptionInfo == true)
                {
                    btn_SaveSub.Focus();
                }
                else if (SaveMode_SubscriptionInfo == false)
                {
                    btn_VerifySub.Focus();
                }
                
            }
        }

        
        private void btn_SaveSub_Click(object sender, EventArgs e)
        {
            try
            {
                string NoticeSupply = "";
                string NoticeConstruction = "";
                string NoticeConsultancy = "";
                string Year = "";
                string Cash = "";

                if (chk_supply.Checked == true)
                {
                    NoticeSupply = "Supply";
                }

                if (chk_construction.Checked == true)
                {
                    NoticeConstruction = "Construction";
                }

                if (chk_consultancy.Checked == true)
                {
                    NoticeConsultancy = "Consultancy";
                }

                if (rb_year1.Checked == true)
                {
                    Year = "One Year";
                }
                else if (rb_year2.Checked == true)
                {
                    Year = "Two Year";
                }
                else if (rb_year3.Checked == true)
                {
                    Year = "Three Year";
                }
                else if (rb_year5.Checked == true)
                {
                    Year = "Five Year";
                }

                if (chk_cash.Checked == true)
                {
                    Cash = "Cash";
                }
                else if (chk_cash.Checked == false)
                {
                    Cash = "Not Cash";
                }

                if (txt_orgName.Text == "")
                {
                    errorProvider_Subscription.SetError(txt_orgName, "Can't left blank.");
                    txt_orgName.Focus();
                }

                else if (txt_email.Text == "")
                {
                    errorProvider_Subscription.SetError(txt_email, "Can't left blank.");
                    txt_email.Focus();
                }
                else
                {
                    if (SaveMode_SubscriptionInfo == true)
                    {
                        //SAVING CLIENT INFO
                        txt_formnum.Text = clsAutoNumber.SerialNumber("formid", "EPahal_Client", "C");
                        cls_Subscription.Save_Client_Info(txt_formnum.Text, txt_orgName.Text, txt_orgAdd.Text, cmb_District.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_fdbck.Text, txt_rmark.Text, cmb_referedBy.Text, dtp_regdate.Value, txt_regdate.Text);
                        //SAVING SUBSCRIPTION
                        txt_SubID.Text = clsAutoNumber.SerialNumber("Subs_ID", "EPahal_Subscription", "S");
                        cls_Subscription.Save_Subscription_Info(txt_SubID.Text,txt_formnum.Text,txt_invoice.Text,txt_receipt.Text,txt_email.Text,NoticeSupply,NoticeConstruction,NoticeConsultancy,dtp_startDate.Value,txtNepaliStartDate.Text,Year,dtp_ExpireDate.Value,txtNepaliExpiryDate.Text,txt_ReceivedBy.Text,txt_CheckedBy.Text,txt_amount.Text,dtp_recDate.Value,txtNepaliRecDate.Text,Cash,txt_chequeNo.Text,txt_depositeby.Text,txt_BankName.Text, "New");
                        dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                        SaveMode_SubscriptionInfo = false;
                        btn_SaveSub.Focus();

                    }
                    else if (SaveMode_SubscriptionInfo == false)
                    {
                        DataTable dt_CheckVerify = cls_Subscription.LoadVerified(txt_SubID.Text);
                        if (dt_CheckVerify.Rows[0]["VerifiedBy"].ToString() == "Admin")
                        {
                            MessageBox.Show("Verified record cannot be modified.\nPlease contact your Administrator to modify record.", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult drUpdate;
                            drUpdate = MessageBox.Show("Do you want to Update Data?", GlobalConnection.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (drUpdate == DialogResult.Yes)
                            {
                                //UPDATING CLIENT INFO
                                cls_Subscription.Update_ClientInfo(txt_formnum.Text, txt_orgName.Text, txt_orgAdd.Text, cmb_District.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_fdbck.Text, txt_rmark.Text, cmb_referedBy.Text,dtp_regdate.Value,txt_regdate.Text);
                                //UPDATING SUBSCRIPTION
                                cls_Subscription.Update_SubscriptionInfo(txt_SubID.Text, txt_formnum.Text, txt_invoice.Text, txt_receipt.Text, txt_email.Text, NoticeSupply, NoticeConstruction, NoticeConsultancy, dtp_startDate.Value, txtNepaliStartDate.Text, Year, dtp_ExpireDate.Value, txtNepaliExpiryDate.Text, txt_ReceivedBy.Text, txt_CheckedBy.Text, txt_amount.Text, dtp_recDate.Value, txtNepaliRecDate.Text, Cash, txt_chequeNo.Text, txt_depositeby.Text, txt_BankName.Text);
                                dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                                btn_reset.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DeleteSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveMode_SubscriptionInfo == true)
                {
                    DialogResult drDelete;
                    drDelete = MessageBox.Show("Select a Subscription which you want to delete.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (drDelete == DialogResult.Yes)
                    {
                        btn_reset_Click(sender, e);
                    }
                }
                else if (SaveMode_SubscriptionInfo == false)
                {
                    DataTable dt_CheckVerify = cls_Subscription.LoadVerified(txt_SubID.Text);
                    if (dt_CheckVerify.Rows[0]["VerifiedBy"].ToString() == "Admin")
                    {
                        MessageBox.Show("Verified record cannot be deleted.\nPlease contact your Administrator to delete record.", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult drDelete;
                        drDelete = MessageBox.Show("Do you really want to delete the Subscription \"" + txt_SubID.Text + "\"?", "Confirm Subscriber Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drDelete == DialogResult.Yes)
                        {

                            cls_Subscription.DeleteClientSubscription(txt_SubID.Text);
                            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                            btn_reset_Click(sender, e);
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DeleteInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveMode_ClientInfo == true)
                {
                    DialogResult drDelete;
                    drDelete = MessageBox.Show("Select a Client which you want to delete.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (drDelete == DialogResult.Yes)
                    {
                        btn_reset_Click(sender, e);
                    }
                }
                else if (SaveMode_ClientInfo == false)
                {
                    DialogResult drDelete;
                    drDelete = MessageBox.Show("Do you really want to delete the Client \"" + txt_orgName.Text + "\"?", "Confirm Subscriber Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (drDelete == DialogResult.Yes)
                    {
                        cls_Subscription.Delete(txt_formnum.Text);
                        dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                        btn_reset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_subscriber_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                btn_GenerateReport.Enabled = true;
                txt_formnum.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Form No."].Value.ToString();
                txt_orgName.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Name of Organization"].Value.ToString();
                txt_orgAdd.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Address of Organization"].Value.ToString();
                cmb_District.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["District"].Value.ToString();
                txt_orgPhone.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Phone No."].Value.ToString();
                txt_orgFirst.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["First Person of Organization"].Value.ToString();
                txt_orgFirstMobile.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["First Person Mobile"].Value.ToString();
                txt_contactPerson.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Contact Person"].Value.ToString();
                txt_contactPersonMobile.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Mobile No."].Value.ToString();
                txt_fdbck.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Feedbacks"].Value.ToString();
                txt_rmark.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                cmb_referedBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Refered By"].Value.ToString();
                dtp_regdate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Registration Date in A.D"].Value.ToString();
                txt_regdate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Registration Date in B.S"].Value.ToString();

                txt_SubID.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Subscription ID"].Value.ToString();
                txt_invoice.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Invoice No."].Value.ToString();
                txt_receipt.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Receipt No."].Value.ToString();
                txt_email.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Receiving Email Address"].Value.ToString();
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Supply"].Value.ToString() == "Supply")
                {
                    chk_supply.Checked = true;
                }
                else
                {
                    chk_supply.Checked = false;
                }
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Construction"].Value.ToString() == "Construction")
                {
                    chk_construction.Checked = true;
                }
                else
                {
                    chk_construction.Checked = false;
                }
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Consultancy"].Value.ToString() == "Consultancy")
                {
                    chk_consultancy.Checked = true;
                }
                else
                {
                    chk_consultancy.Checked = false;
                }
                dtp_startDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Start Date in A.D"].Value.ToString();
                txtNepaliStartDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Start Date in B.S"].Value.ToString();
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "One Year")
                {
                    rb_year1.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "Two Year")
                {
                    rb_year2.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "Three Year")
                {
                    rb_year3.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "Five Year")
                {
                    rb_year5.Checked = true;
                }
                dtp_ExpireDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Expire Date in A.D"].Value.ToString();
                txtNepaliExpiryDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Expire Date in B.S"].Value.ToString();
                txt_amount.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received Amount"].Value.ToString();
                dtp_recDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received Amount Date in A.D"].Value.ToString();
                txtNepaliRecDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received Amount Date in B.S"].Value.ToString();
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Cash"].Value.ToString() == "Cash")
                {
                    chk_cash.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Cash"].Value.ToString() == "Not Cash")
                {
                    chk_cash.Checked = false;
                }
                txt_chequeNo.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Cheque No."].Value.ToString();
                txt_depositeby.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Bank Deposited By"].Value.ToString();
                txt_BankName.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Bank Name"].Value.ToString();
                txt_ReceivedBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received By"].Value.ToString();
                txt_CheckedBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Checked By"].Value.ToString();

                SaveMode_ClientInfo = false;
                SaveMode_SubscriptionInfo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dist_search_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.Load_district(dist_search.Text);
        }

        private void sub_type_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.Load_sub_type(cmb_sub_type.Text);
        }
                      

        private void btn_GenerateReport_Click(object sender, EventArgs e)
        {
            try
            {

                //  DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; 
                DataTable dt_Search = cls_Subscription.Search_Particular(txt_formnum.Text);

                //Rectangle pageSize = new Rectangle(216, 720);
                //pageSize.setBackgroundColor(new BaseColor(0xFF, 0xFF, 0xDE));


                Document document = new Document(PageSize.A4, 88f, 8f, 10f, 10f);


                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "__" + DateTime.Now.ToString("yyyyMMdd__hhmmss") + ".pdf", FileMode.Create));
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    iTextSharp.text.BaseColor color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    var spacer = new Paragraph("")
                    {
                        SpacingBefore = 10f,
                        SpacingAfter = 10f,
                    };

                    //Header Image                    
                    cell = ImageCell("../../Resources/epahal.jpg", 30f, PdfPCell.ALIGN_LEFT);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk(GlobalConnection.strCompanyName, FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    phrase.Add(new Chunk("\n"));
                    phrase.Add(new Chunk("            "));
                    phrase.Add(new Chunk(GlobalConnection.strCompanyAddress, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    phrase.Add(new Chunk("\n"));
                    phrase.Add(new Chunk("               Phone: ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    phrase.Add(new Chunk(GlobalConnection.strCompanyAddress, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    //phrase.Add(new Chunk("Kathmandu", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, System.Drawing.Color.Black);
                    DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, System.Drawing.Color.Black);

                    DrawLine(writer, 80f, document.Top - 80f, 80f, document.Top - 1000f, System.Drawing.Color.Black);
                    // DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, System.Drawing.Color.Black);

                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.SetWidths(new float[] { 5f, 5f });
                    table.SpacingBefore = 20f;


                    //Details
                    cell = PhraseCell(new Phrase("Suscriber Detail", FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.RED)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);

                    document.Add(spacer);


                    //Form No

                    table.AddCell(PhraseCell(new Phrase("Form No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Form No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.PaddingLeft = 20f;
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Invoice No
                    table.AddCell(PhraseCell(new Phrase("Invoice No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Invoice No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Receipt No
                    table.AddCell(PhraseCell(new Phrase("Receipt No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Receipt No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Organization Name
                    table.AddCell(PhraseCell(new Phrase("Name Of Organisation:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Name of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Organization Address
                    table.AddCell(PhraseCell(new Phrase("Address of Organization:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Address of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //District
                    table.AddCell(PhraseCell(new Phrase("District:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["District"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Phone No.
                    table.AddCell(PhraseCell(new Phrase("Phone No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Phone No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Org 1st Person
                    table.AddCell(PhraseCell(new Phrase("First Person of Organization:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["First Person of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Org 1st Person Mobile Np
                    table.AddCell(PhraseCell(new Phrase("Mobile No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["First Person Mobile"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Contact Person
                    table.AddCell(PhraseCell(new Phrase("Contact Person:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Contact Person"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Contact Person Mobile
                    table.AddCell(PhraseCell(new Phrase("Mobile No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Mobile No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Feedback
                    table.AddCell(PhraseCell(new Phrase("Feedback:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Feedbacks"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Remarks
                    table.AddCell(PhraseCell(new Phrase("Remarks:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Remarks"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Refered By
                    table.AddCell(PhraseCell(new Phrase("Refered By:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Refered By"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Registration Date
                    table.AddCell(PhraseCell(new Phrase("Registration Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Registration Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);                    

                    //Email
                    table.AddCell(PhraseCell(new Phrase("Service Receiving Email Address:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Receiving Email Address"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Notice Reqd
                    if (chk_supply.Checked == true)
                    {
                        table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Supply"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 50;
                        table.HorizontalAlignment = 200;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);
                    }
                    if (chk_construction.Checked == true)
                    {
                        table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Construction"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 50;
                        table.HorizontalAlignment = 200;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);
                    }
                    if (chk_consultancy.Checked == true)
                    {
                        table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Consultancy"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 50;
                        table.HorizontalAlignment = 200;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);
                    }


                    //start date
                    table.AddCell(PhraseCell(new Phrase("Service Start Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Start Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //service period
                    table.AddCell(PhraseCell(new Phrase("Service Period:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Period"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //expire date
                    table.AddCell(PhraseCell(new Phrase("Service Expiry Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Expire Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Received Amount
                    table.AddCell(PhraseCell(new Phrase("Received Amount:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Received Amount"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Received Date
                    table.AddCell(PhraseCell(new Phrase("Received Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Received Amount Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    if (chk_cash.Checked == false)
                    {
                        try
                        {
                            //Cheque
                            table.AddCell(PhraseCell(new Phrase("Cheque No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cheque No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                            //Bank Deposite
                            table.AddCell(PhraseCell(new Phrase("Bank Deposited By:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Bank Deposited By"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                            //Bank 
                            table.AddCell(PhraseCell(new Phrase("Bank Name:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Bank Name"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                        }
                        catch
                        {
                            //Cash
                            table.AddCell(PhraseCell(new Phrase("Payment Mode:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cash"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);
                        }
                    }


                    //Addtional Information
                    //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    //table.AddCell(PhraseCell(new Phrase(dr["Notes"].ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                    document.Add(table);
                    document.Close();


                    byte[] bytes = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "__" + DateTime.Now.ToString("yyyyMMdd__hhmmss") + ".pdf");
                    //Font blackFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                    var blackFont = FontFactory.GetFont("Arial", "18", Font.Bold);
                    var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                    var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
                    using (MemoryStream stream = new MemoryStream())
                    {
                        PdfReader reader = new PdfReader(bytes);
                        using (PdfStamper stamper = new PdfStamper(reader, stream))
                        {
                            int pages = reader.NumberOfPages;
                            for (int i = 1; i <= pages; i++)
                            {
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_CENTER, new Phrase("Page " + i.ToString() + " of " + pages, blackFont), 300f, 24f, 0);

                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_RIGHT, new Phrase("" + dateOnlyString, blackFont), 549f, 24f, 0);
                            }
                        }

                        bytes = stream.ToArray();

                    }
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "__" + DateTime.Now.ToString("yyyyMMdd__hhmmss") + ".pdf", bytes);

                    MessageBox.Show("PDF Report Successfully Generated in User's Desktop", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
            catch 
            {
                MessageBox.Show("PDF Report Successfully Generated in User's Desktop", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
        }

        private void btn_VerifySub_Click(object sender, EventArgs e)
        {
            string NoticeSupply = "";
            string NoticeConstruction = "";
            string NoticeConsultancy = "";
            string Year = "";
            string Cash = "";

            if (chk_supply.Checked == true)
            {
                NoticeSupply = "Supply";
            }

            if (chk_construction.Checked == true)
            {
                NoticeConstruction = "Construction";
            }

            if (chk_consultancy.Checked == true)
            {
                NoticeConsultancy = "Consultancy";
            }

            if (rb_year1.Checked == true)
            {
                Year = "One Year";
            }
            else if (rb_year2.Checked == true)
            {
                Year = "Two Year";
            }
            else if (rb_year3.Checked == true)
            {
                Year = "Three Year";
            }
            else if (rb_year5.Checked == true)
            {
                Year = "Five Year";
            }

            if (chk_cash.Checked == true)
            {
                Cash = "Cash";
            }
            else if (chk_cash.Checked == false)
            {
                Cash = "Not Cash";
            }

            if (txt_email.Text == "")
            {
                errorProvider_Subscription.SetError(txt_email, "Can't left blank.");
                txt_email.Focus();
            }
            else
            {
                if (SaveMode_SubscriptionInfo == false && GlobalConnection.strUid == "Admin")
                {
                    DialogResult drUpdate;
                    drUpdate = MessageBox.Show("Do you want to Verify Data?", GlobalConnection.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (drUpdate == DialogResult.Yes)
                    {
                        //UPDATING CLIENT INFO
                        cls_Subscription.Update_ClientInfo(txt_formnum.Text, txt_orgName.Text, txt_orgAdd.Text, cmb_District.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_fdbck.Text, txt_rmark.Text, cmb_referedBy.Text, dtp_regdate.Value,txt_regdate.Text);
                        //UPDATING SUBSCRIPTION
                        cls_Subscription.Verify_SubscriptionInfo(txt_SubID.Text, txt_formnum.Text, txt_invoice.Text, txt_receipt.Text, txt_email.Text, NoticeSupply, NoticeConstruction, NoticeConsultancy, dtp_startDate.Value, txtNepaliStartDate.Text, Year, dtp_ExpireDate.Value, txtNepaliExpiryDate.Text, txt_ReceivedBy.Text, txt_CheckedBy.Text, txt_amount.Text, dtp_recDate.Value, txtNepaliRecDate.Text, Cash, txt_chequeNo.Text, txt_depositeby.Text, txt_BankName.Text);
                        dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                        btn_reset.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Permission denied for " + GlobalConnection.strUserLoginName + ". \nPlease contact your Administrator to verify record..", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dtp_BeginningDate_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_BeginningDate.Text));
            txt_BeginningDate.Text = string.Format("{0}", npdate.npDate);
        }

        private void dtp_EndingDate_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_EndingDate.Text));
            txt_EndingDate.Text = string.Format("{0}", npdate.npDate);
        }

        private void txt_namesearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Name(txt_namesearch.Text);
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (txt_email.Text != "")
            {
                errorProvider_Subscription.SetError(txt_email, "");
            }
        }

        private void txt_emailR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_supplyR.Focus();
            }
        }

        private void chk_supplyR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_constructionR.Focus();
            }
        }

        private void chk_constructionR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_consultancyR.Focus();
            }
        }

        private void tab_Payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_startDateR.Focus();
            }
        }

        private void dtp_startDateR_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_startDateR.Text));
            txtNepaliStartDateR.Text = string.Format("{0}", npdate.npDate);
        }

        private void dtp_ExpireDateR_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_ExpireDateR.Text));
            txtNepaliExpiryDateR.Text = string.Format("{0}", npdate.npDate);
        }

        private void dtp_recDateR_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_recDateR.Text));
            txtNepaliRecDateR.Text = string.Format("{0}", npdate.npDate);
        }

        private void dtp_startDateR_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DateTime Temp;
                    if (DateTime.TryParse(Convert.ToDateTime(dtp_startDateR.Text).ToShortDateString(), out Temp) == true)
                    {
                        rb_year1R.Focus();
                        startDate = true;
                        dtp_startDateR_ValueChanged(sender, e);
                    }
                    else
                    {
                        dtp_startDateR.Focus();
                    }
                }
            }
            catch
            {

            }
        }

        private void rb_year1R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year1R.Checked == true)
                {
                    txt_invoiceR.Focus();
                }
                else
                {
                    rb_year2R.Focus();
                }
            }
        }

        private void rb_year2R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year2R.Checked == true)
                {
                    txt_invoiceR.Focus();
                }
                else
                {
                    rb_year3R.Focus();
                }
            }
        }

        private void rb_year3R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year3R.Checked == true)
                {
                    txt_invoiceR.Focus();
                }
                else
                {
                    rb_year5R.Focus();
                }
            }
        }

        private void rb_year5R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rb_year5R.Checked == true)
                {
                    txt_invoiceR.Focus();
                }
                else
                {
                    rb_year5R.Focus();
                }
            }
        }

        private void txtNepaliExpiryDateR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_invoiceR.Focus();
            }
        }

        private void txt_invoiceR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_receiptR.Focus();
            }
        }

        private void txt_receiptR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_amountR.Focus();
            }
        }

        private void txt_amountR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_recDateR.Focus();
            }
        }

        private void dtp_recDateR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chk_cashR.Focus();
                dtp_recDateR_ValueChanged(sender, e);
            }
        }

        private void chk_cashR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_chequeNoR.Focus();
            }
        }

        private void txt_chequeNoR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_depositebyR.Focus();
            }
        }

        private void txt_depositebyR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_BankNameR.Focus();
            }
        }

        private void txt_BankNameR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ReceivedByR.Focus();
            }
        }

        private void txt_ReceivedByR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GlobalConnection.strUserLoginName == "Admin")
                {
                    txt_CheckedByR.Focus();
                }
                else
                {
                    btn_SaveSubR.Focus();
                }
            }
        }

        private void txt_CheckedByR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_SaveSubR.Focus();
            }
        }

        private void txt_emailR_TextChanged(object sender, EventArgs e)
        {
            if (txt_emailR.Text != "")
            {
                errorProvider_Subscription.SetError(txt_emailR, "");
            }
        }

        private void rb_year1R_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDateR.Text = Convert.ToString(Convert.ToDateTime(dtp_startDateR.Text).AddYears(1).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDateR.ResetText();
            }
        }

        private void rb_year2R_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDateR.Text = Convert.ToString(Convert.ToDateTime(dtp_startDateR.Text).AddYears(2).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDateR.ResetText();
            }
        }

        private void rb_year3R_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDateR.Text = Convert.ToString(Convert.ToDateTime(dtp_startDateR.Text).AddYears(3).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDateR.ResetText();
            }
        }

        private void rb_year5R_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_ExpireDateR.Text = Convert.ToString(Convert.ToDateTime(dtp_startDateR.Text).AddYears(5).ToString("MM/dd/yyyy"));
            }
            catch
            {
                dtp_ExpireDateR.ResetText();
            }
        }

        private void txtNepaliExpiryDateR_Leave(object sender, EventArgs e)
        {
            txt_invoiceR.Focus();
        }

        private void txt_receiptR_Leave(object sender, EventArgs e)
        {
            txt_amountR.Focus();
        }

        private void btn_exitR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_resetR_Click(object sender, EventArgs e)
        {
            SaveMode_SubscriptionInfoRenew = true;

            btn_GenerateReportR.Enabled = false;

            txt_invoiceR.ResetText();
            txt_receiptR.ResetText();
            
            txt_emailR.ResetText();
            chk_supplyR.Checked = false;
            chk_constructionR.Checked = false;
            chk_consultancyR.Checked = false;
            dtp_startDateR.ResetText();
            rb_year1R.Checked = false;
            rb_year2R.Checked = false;
            rb_year3R.Checked = false;
            rb_year5R.Checked = false;
            dtp_ExpireDateR.ResetText();
            txt_amountR.ResetText();
            dtp_recDateR.ResetText();
            chk_cashR.Checked = false;
            txt_chequeNoR.ResetText();
            txt_depositebyR.ResetText();
            txt_BankNameR.ResetText();
            
            txt_SubIDR.ResetText();
            txt_ReceivedByR.ResetText();
            txt_CheckedByR.ResetText();
            
            txt_SubIDR.Text = clsAutoNumber.SerialNumber("Subs_ID", "EPahal_Subscription", "S");
        }

        private void tab_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_Payment.SelectedTab == tabNew)
            {
            }
            else if (tab_Payment.SelectedTab == tabRenew)
            {
                btn_resetR_Click(sender, e);
                txt_emailR.Focus();
            }
        }

        private void btn_SaveSubR_Click(object sender, EventArgs e)
        {
            try
            {
                string NoticeSupply = "";
                string NoticeConstruction = "";
                string NoticeConsultancy = "";
                string Year = "";
                string Cash = "";

                if (chk_supplyR.Checked == true)
                {
                    NoticeSupply = "Supply";
                }

                if (chk_constructionR.Checked == true)
                {
                    NoticeConstruction = "Construction";
                }

                if (chk_consultancyR.Checked == true)
                {
                    NoticeConsultancy = "Consultancy";
                }

                if (rb_year1R.Checked == true)
                {
                    Year = "One Year";
                }
                else if (rb_year2R.Checked == true)
                {
                    Year = "Two Year";
                }
                else if (rb_year3R.Checked == true)
                {
                    Year = "Three Year";
                }
                else if (rb_year5R.Checked == true)
                {
                    Year = "Five Year";
                }

                if (chk_cashR.Checked == true)
                {
                    Cash = "Cash";
                }
                else if (chk_cashR.Checked == false)
                {
                    Cash = "Not Cash";
                }

                if (txt_orgName.Text == "")
                {
                    errorProvider_Subscription.SetError(txt_orgName, "Can't left blank.");
                    txt_orgName.Focus();
                }

                else if (txt_emailR.Text == "")
                {
                    errorProvider_Subscription.SetError(txt_emailR, "Can't left blank.");
                    txt_emailR.Focus();
                }
                else
                {
                    if (SaveMode_SubscriptionInfoRenew == true)
                    {
                        //UPDATING CLIENT INFO
                        cls_Subscription.Update_ClientInfo(txt_formnum.Text, txt_orgName.Text, txt_orgAdd.Text, cmb_District.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_fdbck.Text, txt_rmark.Text, cmb_referedBy.Text, dtp_regdate.Value, txt_regdate.Text);
                        //UPDATING PREVIOUS STATUS
                        cls_Subscription.Update_SubscriptionInfoStatus(txt_formnum.Text);
                        //SAVING SUBSCRIPTION
                        txt_SubIDR.Text = clsAutoNumber.SerialNumber("Subs_ID", "EPahal_Subscription", "S");
                        cls_Subscription.Save_Subscription_Info(txt_SubIDR.Text, txt_formnum.Text, txt_invoiceR.Text, txt_receiptR.Text, txt_emailR.Text, NoticeSupply, NoticeConstruction, NoticeConsultancy, dtp_startDateR.Value, txtNepaliStartDateR.Text, Year, dtp_ExpireDateR.Value, txtNepaliExpiryDateR.Text, txt_ReceivedByR.Text, txt_CheckedByR.Text, txt_amountR.Text, dtp_recDateR.Value, txtNepaliRecDateR.Text, Cash, txt_chequeNoR.Text, txt_depositebyR.Text, txt_BankNameR.Text, "Renew");
                        dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                        SaveMode_SubscriptionInfoRenew = false;
                        btn_GenerateReportR.Enabled = true;
                        btn_SaveSubR.Focus();

                    }
                    else if (SaveMode_SubscriptionInfoRenew == false)
                    {
                        DialogResult drUpdate;
                        drUpdate = MessageBox.Show("Do you want to Update Data?", GlobalConnection.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (drUpdate == DialogResult.Yes)
                        {
                            //UPDATING CLIENT INFO
                            cls_Subscription.Update_ClientInfo(txt_formnum.Text, txt_orgName.Text, txt_orgAdd.Text, cmb_District.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_fdbck.Text, txt_rmark.Text, cmb_referedBy.Text, dtp_regdate.Value, txt_regdate.Text);
                            //UPDATING SUBSCRIPTION
                            cls_Subscription.Update_SubscriptionInfo(txt_SubIDR.Text, txt_formnum.Text, txt_invoiceR.Text, txt_receiptR.Text, txt_emailR.Text, NoticeSupply, NoticeConstruction, NoticeConsultancy, dtp_startDateR.Value, txtNepaliStartDateR.Text, Year, dtp_ExpireDateR.Value, txtNepaliExpiryDateR.Text, txt_ReceivedByR.Text, txt_CheckedByR.Text, txt_amountR.Text, dtp_recDateR.Value, txtNepaliRecDateR.Text, Cash, txt_chequeNoR.Text, txt_depositebyR.Text, txt_BankNameR.Text);
                            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                            btn_resetR.Focus();
                            btn_GenerateReportR.Enabled = true;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GenerateReportR_Click(object sender, EventArgs e)
        {
             try
            {

                //  DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; 
                DataTable dt_Search = cls_Subscription.Search_Particular(txt_formnum.Text);

                //Rectangle pageSize = new Rectangle(216, 720);
                //pageSize.setBackgroundColor(new BaseColor(0xFF, 0xFF, 0xDE));


                Document document = new Document(PageSize.A4, 88f, 8f, 10f, 10f);


                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "__" + DateTime.Now.ToString("yyyyMMdd__hhmmss") + ".pdf", FileMode.Create));
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    iTextSharp.text.BaseColor color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    var spacer = new Paragraph("")
                    {
                        SpacingBefore = 10f,
                        SpacingAfter = 10f,
                    };

                    //Header Image                    
                    cell = ImageCell("../../Resources/epahal.jpg", 30f, PdfPCell.ALIGN_LEFT);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk(GlobalConnection.strCompanyName, FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    phrase.Add(new Chunk("\n"));
                    phrase.Add(new Chunk("            "));
                    phrase.Add(new Chunk(GlobalConnection.strCompanyAddress, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    phrase.Add(new Chunk("\n"));
                    phrase.Add(new Chunk("               Phone: ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    phrase.Add(new Chunk(GlobalConnection.strCompanyAddress, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    //phrase.Add(new Chunk("Kathmandu", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, System.Drawing.Color.Black);
                    DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, System.Drawing.Color.Black);

                    DrawLine(writer, 80f, document.Top - 80f, 80f, document.Top - 1000f, System.Drawing.Color.Black);
                    // DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, System.Drawing.Color.Black);

                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.SetWidths(new float[] { 5f, 5f });
                    table.SpacingBefore = 20f;


                    //Details
                    cell = PhraseCell(new Phrase("Suscriber Detail", FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.RED)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);

                    document.Add(spacer);


                    //Form No

                    table.AddCell(PhraseCell(new Phrase("Form No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Form No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.PaddingLeft = 20f;
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Invoice No
                    table.AddCell(PhraseCell(new Phrase("Invoice No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Invoice No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Receipt No
                    table.AddCell(PhraseCell(new Phrase("Receipt No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Receipt No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Organization Name
                    table.AddCell(PhraseCell(new Phrase("Name Of Organisation:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Name of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Organization Address
                    table.AddCell(PhraseCell(new Phrase("Address of Organization:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Address of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //District
                    table.AddCell(PhraseCell(new Phrase("District:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["District"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Phone No.
                    table.AddCell(PhraseCell(new Phrase("Phone No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Phone No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Org 1st Person
                    table.AddCell(PhraseCell(new Phrase("First Person of Organization:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["First Person of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Org 1st Person Mobile Np
                    table.AddCell(PhraseCell(new Phrase("Mobile No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["First Person Mobile"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Contact Person
                    table.AddCell(PhraseCell(new Phrase("Contact Person:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Contact Person"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Contact Person Mobile
                    table.AddCell(PhraseCell(new Phrase("Mobile No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Mobile No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Feedback
                    table.AddCell(PhraseCell(new Phrase("Feedback:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Feedbacks"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Remarks
                    table.AddCell(PhraseCell(new Phrase("Remarks:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Remarks"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Refered By
                    table.AddCell(PhraseCell(new Phrase("Refered By:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Refered By"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Email
                    table.AddCell(PhraseCell(new Phrase("Service Receiving Email Address:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Receiving Email Address"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Notice Reqd
                    if (chk_supply.Checked == true)
                    {
                        table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Supply"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 50;
                        table.HorizontalAlignment = 200;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);
                    }
                    if (chk_construction.Checked == true)
                    {
                        table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Construction"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 50;
                        table.HorizontalAlignment = 200;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);
                    }
                    if (chk_consultancy.Checked == true)
                    {
                        table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Consultancy"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 50;
                        table.HorizontalAlignment = 200;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);
                    }


                    //start date
                    table.AddCell(PhraseCell(new Phrase("Service Start Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Start Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //service period
                    table.AddCell(PhraseCell(new Phrase("Service Period:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Period"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //expire date
                    table.AddCell(PhraseCell(new Phrase("Service Expiry Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Expire Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Received Amount
                    table.AddCell(PhraseCell(new Phrase("Received Amount:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Received Amount"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Received Date
                    table.AddCell(PhraseCell(new Phrase("Received Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Received Amount Date in B.S"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    if (chk_cash.Checked == false)
                    {
                        try
                        {
                            //Cheque
                            table.AddCell(PhraseCell(new Phrase("Cheque No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cheque No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                            //Bank Deposite
                            table.AddCell(PhraseCell(new Phrase("Bank Deposited By:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Bank Deposited By"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                            //Bank 
                            table.AddCell(PhraseCell(new Phrase("Bank Name:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Bank Name"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                        }
                        catch
                        {
                            //Cash
                            table.AddCell(PhraseCell(new Phrase("Payment Mode:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cash"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);
                        }
                    }


                    //Addtional Information
                    //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    //table.AddCell(PhraseCell(new Phrase(dr["Notes"].ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                    document.Add(table);
                    document.Close();


                    byte[] bytes = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "__" + DateTime.Now.ToString("yyyyMMdd__hhmmss") + ".pdf");
                    //Font blackFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                    var blackFont = FontFactory.GetFont("Arial", "18", Font.Bold);
                    var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                    var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
                    using (MemoryStream stream = new MemoryStream())
                    {
                        PdfReader reader = new PdfReader(bytes);
                        using (PdfStamper stamper = new PdfStamper(reader, stream))
                        {
                            int pages = reader.NumberOfPages;
                            for (int i = 1; i <= pages; i++)
                            {
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_CENTER, new Phrase("Page " + i.ToString() + " of " + pages, blackFont), 300f, 24f, 0);

                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_RIGHT, new Phrase("" + dateOnlyString, blackFont), 549f, 24f, 0);
                            }
                        }

                        bytes = stream.ToArray();

                    }
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "__" + DateTime.Now.ToString("yyyyMMdd__hhmmss") + ".pdf", bytes);

                    MessageBox.Show("PDF Report Successfully Generated in User's Desktop", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
            catch 
            {
                MessageBox.Show("PDF Report Successfully Generated in User's Desktop", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
        }

        private void btn_DeleteSubR_Click(object sender, EventArgs e)
        {
            DialogResult drDelete;
            drDelete = MessageBox.Show("Do you really want to delete the Subscription \"" + txt_SubIDR.Text + "\"?", "Confirm Subscriber Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (drDelete == DialogResult.Yes)
            {
                cls_Subscription.DeleteClientSubscription(txt_SubIDR.Text);
                dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                btn_resetR_Click(sender, e);
            }
        }

        private void cmb_SubscriptionStatus_TextChanged(object sender, EventArgs e)
        {
            string SubStatus = "";

            if (cmb_SubscriptionStatus.Text == "All")
            {
                dgv_subscriber.DataSource = cls_Subscription.Search_Subscriber_Status_All_WithoutDate("","","","","");
            }
            else
            {
                if (cmb_SubscriptionStatus.Text == "Verified")
                {
                    SubStatus = "Admin";
                }
                else if (cmb_SubscriptionStatus.Text == "Non-Verified")
                {
                    SubStatus = "";
                }
                dgv_subscriber.DataSource = cls_Subscription.Search_Subscriber_Verified_NonVerified(txt_namesearch.Text, txt_addsearch.Text, cmb_District.Text, txt_phsearch.Text, txt_emailsearch.Text, cmb_sub_type.Text, SubStatus, dtp_BeginningDate.Value, dtp_EndingDate.Value);
            }
        }

        private void cmb_SubscriptionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtp_regdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_email.Focus();
            }
        }

        private void dtp_regdate_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate npdate = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dtp_regdate.Text));
            txt_regdate.Text = string.Format("{0}", npdate.npDate);
        }
    }
}
