using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace HR_Salaries.Pages.PPC
{
    public partial class PPC_Process : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {




                lblMessage.Text = "";

                //SqlCommand cmdd = new SqlCommand();

                //cmdd.CommandText = @"SELECT [parameter_id] FROM [HR].[dbo].[PPC_Parameters]  where [type] = 1";

                //DataTable dts = MDirMaster.GetData(cmdd, lblMessage);

                String userID = Session["UserID"].ToString();

                //foreach (DataColumn col in dts.Columns)
                //{
                //    if (col.DataType.Name == userID)
                //    {
                //        MDirMaster.FillCombo("Processes_Type_CODE", "Processes_Type_Name", "PPC_Processes_Type", Process_Type, "[Processes_Type_CODE] in (3,4)", lblMessage);
                //    }
                //    else
                //    {
                //        MDirMaster.FillCombo("Processes_Type_CODE", "Processes_Type_Name", "PPC_Processes_Type", Process_Type, "[Processes_Type_CODE] in (1,3)", lblMessage);
                //    }
                //}



                if ((userID == "1015") || (userID == "1016") || (userID == "1017") || (userID == "1018") || (userID == "1019") || (userID == "1020") || (userID == "1021"))
                {
                    MDirMaster.FillCombo("Processes_Type_CODE", "Processes_Type_Name", "PPC_Processes_Type", Process_Type, "[Processes_Type_CODE] in (3,4)", lblMessage);
                }
                else
                {
                    MDirMaster.FillCombo("Processes_Type_CODE", "Processes_Type_Name", "PPC_Processes_Type", Process_Type, "[Processes_Type_CODE] in (1,2,3,4)", lblMessage);
                }

                MDirMaster.FillCombo("BRANCH_CODE", "BRANCH_Name", "PPC_Branchs", Branch_No, "1=1", lblMessage);
                MDirMaster.FillCombo("Account_No", "Account_Name", "PPC_Fixed_Account", To_Account, "1=1", lblMessage);

                User_code_A.Text = Session["username"].ToString();

                
                Branch_No.SelectedIndex = 6;
                Branch_No.Enabled = false;





            }
        }

        String Status_input = "";
        int Verification_status = 0;

        
                        //  1	أيداع
                        //  2	سحب
                        //  3	تحويل
                        //  4	عكس عملية

        protected void Process_Type_SelectedIndexChanged(object sender, EventArgs e)
        {


                txtSearchs.Text = "";
                txtReversedSearch.Text = "";
                Process_Amount.Text = "";
                From_Account.Text = "";
                To_Account.SelectedIndex = 0;
                Description.Text = "";

            revers_BTN.Visible = false;
            nameLBL.Text = "";



            if ( Process_Type.SelectedValue == "1")
            {
                RowsData.Visible = true;
                PalReversedSearch.Visible = false;
                btnSend.Visible = true;
                Label7.Text = "رقم الحساب";
                
                Label8.Visible = false;
                To_Account.Visible = false;

            }
            if (Process_Type.SelectedValue == "2")
            {
                RowsData.Visible = true;
                PalReversedSearch.Visible = false;
                btnSend.Visible = true;
                Label7.Text = "من رقم الحساب";
                Label8.Visible = false;
                To_Account.Visible = false;
            }
            if (Process_Type.SelectedValue == "3")
            {
                RowsData.Visible = true;
                PalReversedSearch.Visible = false;
                btnSend.Visible = true;
                Label7.Text = "رقم الحساب";
                Label8.Visible = true;

                To_Account.Visible = true;
                To_Account.SelectedIndex = 1;
                To_Account.Enabled = false;

            }
            if (Process_Type.SelectedValue == "4")
            {
                PalReversedSearch.Visible = true;
                RowsData.Visible = false;
                btnSend.Visible = false;
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();
            SqlCommand cmd_Search2 = new SqlCommand();
            cmd_Search2.CommandText = @"SELECT [id]
                                        ,[Branch_No]
                                        ,[Process_Number]
                                        ,format([Process_Date],'dd-MM-yyyy') Process_Date
                                        ,[From_Account]
                                        ,[To_Account]
                                        ,[Process_Amount]
                                        ,[Process_Commission] fee
                                        ,[Description]
                                        ,[other]
                                          FROM [HR].[dbo].[PPC_Processes] where [From_Account] Like '%VaLueD%'";

            cmd_Search.CommandText = cmd_Search2.CommandText.Replace("VaLueD", txtReversedSearch.Text);
            MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);

        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            pinLBL.Visible = true;
           // btnSend_();
        }

        public void btnSend_ ()
        {


            int sid = 0;

            bool check_pending_ = false;

            //check_pending_ = MDirMaster.check_pending(From_Account.Text, lblMessage);

            string _Branch_No = "";
            string _To_Account = "";
            bool GetAccount = MDirMaster.Get_Account(From_Account.Text, lblMessage);


            if (Branch_No.Text == "0") { _Branch_No = "Error"; }
            if (To_Account.Text == "0") { _To_Account = "Error"; }

            //Check Amount by For Accounts
            string amu = MDirMaster.Get_amount(From_Account.Text, lblMessage);

            SqlCommand cmd_Search_ = new SqlCommand();
            cmd_Search_.CommandText = @"
                                        SELECT max([Process_Number]) as mama
                                        FROM [HR].[dbo].[PPC_Processes]
                                            ";

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

            int iid = 0;
            try
            {
                iid = int.Parse(dt.Rows[0]["mama"].ToString()) + 1;
            }
            catch (Exception)
            {
                iid = 1;
            }

            float comm = 0;

            if (Process_Type.SelectedValue == "3")
            {
                comm = MDirMaster.getCommission(float.Parse(Process_Amount.Text), lblMessage);
            }

            else
            {
                comm = 0;
            }


            String userID = Session["UserID"].ToString();


            //DateTime _Process_Date = DateTime.Now;
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            //Process Sign + || -

            String process_sign = "";
            String status_ = "0";
            String status_2 = "0";
            string Reversed_Process_Number_ = "";
            Reversed_Process_Number_ = Reversed_Process_No.Text;

            string _process_sign = Process_Type.SelectedValue;

            decimal amunt = 0;
            //transference

            if (_process_sign == "1") { process_sign = "Deposit"; status_ = "1"; amunt = decimal.Parse(Process_Amount.Text); }
            else if (_process_sign == "2")
            {
                process_sign = "Withdrawal"; status_ = "2";
                decimal amu_ = decimal.Parse(Process_Amount.Text);
                amunt = amu_ * -1;
            }
            else if (_process_sign == "3")
            {
                process_sign = "transference"; status_ = "3";
                decimal amu_ = decimal.Parse(Process_Amount.Text);
                amunt = amu_ * -1;
            }
            else if (_process_sign == "4")
            {
                process_sign = "Reverse";

                // get process number 
                string Process_Number_ = Process_Number.Text;
                status_ = "4";
                status_2 = "2";
            }





            SqlCommand cmd_Add = new SqlCommand();

            cmd_Add.CommandText = @"USE [HR]

        INSERT INTO [dbo].[PPC_Processes]
           ([Branch_No]
           ,[User_code_A]
           ,[User_code_B]
           ,[Process_Number]
           ,[Process_Date]
           ,[Process_Status]
           ,[From_Account]
           ,[To_Account]
           ,[Process_Type]
           ,[Reversed_Reason]
           ,[Reversed_Process_Number]
           ,[Process_Amount]
           ,[Process_Commission]
           ,[user_update]
           ,[Description]
           ,[Verification_status]
           ,[status]
           ,[other]
           )
     VALUES
           (
            '" + Branch_No.Text + @"',
            '" + Session["userID"] + @"',
            '" + User_code_B.Text + @"',
            '" + iid + @"',
            '" + today + @"',
            '" + status_2 + @"',
            '" + From_Account.Text + @"',
            '" + To_Account.Text + @"',
            '" + Process_Type.Text + @"',
            '" + Reversed_Reason.Text + @"',
            '" + Reversed_Process_Number_ + @"',
            '" + amunt + @"',
            '" + comm + @"',
            '" + Session["userID"] + @"',
            '" + Description.Text + @"',
            '" + Verification_status + @"',
            '" + status_ + @"',
            
             '" + process_sign + @"'
)

";



            // check amount access
            bool stat = true;

            if (_process_sign == "2" || _process_sign == "3")
            {

                //amu2 الفعلي الموجود في الداتابيس
                // fillAmount المطلوب سحبه

                string amu2 = MDirMaster.Get_amount(From_Account.Text, lblMessage);


                float comm2 = MDirMaster.getCommission(float.Parse(Process_Amount.Text), lblMessage);
                decimal fillAmount = decimal.Parse(comm2.ToString()) + decimal.Parse(Process_Amount.Text);

                stat = MDirMaster.check_Access_process2(fillAmount.ToString(), decimal.Parse(amu2));
            }

            if (_Branch_No == "Error")
            {
                lblMessage.Text = "يرجى ملئ جميع الحقول";
            }
            else 
            {
                if (_process_sign == "2")
                {
                    if ((_To_Account == "Error") & (_process_sign != "2"))
                    {
                        lblMessage.Text = "يرجى ملئ جميع الحقول";
                    }
                    else
                    {
                        if (stat == true)
                        {
                            if (GetAccount == true)
                            {
                                if (check_pending_ == false)
                                {
                                     MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
                                    printingS(iid);
                                }
                                else
                                {
                                    lblMessage.Text = "يرجى المصادقة على جميع العمليات التي تخص هذا الحساب";
                                }
                            }
                            else
                            {
                                lblMessage.Text = "رقم الحساب خطأ ..... يرجى التأكد من الرقم";
                            }

                        }
                        else
                        {
                            lblMessage.Text = "المبلغ المطلوب اكثر من المبلغ الموجود فعليا";

                        }
                    }

                }
                else
                {
                    if (stat == true)
                    {
                        if (GetAccount == true)
                        {
                            if (check_pending_ == false)
                            {
                                 MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
                                printingS(iid);
                            }
                            else
                            {
                                lblMessage.Text = "يرجى المصادقة على جميع العمليات التي تخص هذا الحساب";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "رقم الحساب خطأ ..... يرجى التأكد من الرقم";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "المبلغ المطلوب اكثر من المبلغ الموجود فعليا";

                    }
                }
            }







            try
            {
                if (_process_sign == "4")
                {
                    try
                    {
                        string id = GVReversedSearch.SelectedRow.Cells[1].Text;
                        SqlCommand cmd_up_ = new SqlCommand();

                        cmd_up_.CommandText = @"
                                            USE [HR]
                                            UPDATE [dbo].[PPC_Processes]
                                               SET [status] = 4

                                             WHERE [id] ='" + id + "'";

                        MDirMaster.Execute(cmd_up_, lblMessage, HttpContext.Current.Request.Path);
                    }
                    catch
                    {
                        ///////////اهنا وصلت
                    }
                }
            }
            catch
            {

            }


            txtSearchs.Text = "";
            txtReversedSearch.Text = "";
            Process_Amount.Text = "";
            From_Account.Text = "";
            To_Account.SelectedIndex = 0;
            Description.Text = "";

            revers_BTN.Visible = false;
            nameLBL.Text = "";

            ////////////////

           

        }


        public void printingS(int iid)
        {
        ReportDocument Report = new ReportDocument();
        Report.Load(Server.MapPath("~/Reports/ReportSource/RPrint.rpt"));
            Report.SetDatabaseLogon("HR", "1HR12IIB18", "10.10.16.30", "HR");
            Report.SetParameterValue("num", iid);
            // CrystalReportViewer1.ReportSource = Report;
            //Report.PrintToPrinter(1, false, 0, 0);

            string filepath;
        Response.Clear();
            filepath = Server.MapPath("~/" + "demo.pdf");
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            FileInfo fileinfo = new FileInfo(filepath);
        Response.AddHeader("Content-Disposition", "inline;filenam=demo.pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(fileinfo.FullName);
            Report.Close();
            Report.Dispose();

        }












        protected void Account_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Account_Class.SelectedIndex == 1)
            //{
            //    IndOrCom.Visible = false;
            //}
            //else if(Account_Class.SelectedIndex == 2)
            //{
            //    IndOrCom.Visible = true;
            //}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           
            RowsData.Visible = false;
            btnSend.Visible = false;
            btnCancel.Visible = false;
        }

        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVReversedSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GVReversedSearch.SelectedRow.Cells[1].Text;

            SqlCommand cmd_Search_ = new SqlCommand();
            cmd_Search_.CommandText = @"SELECT [id]
      ,[Branch_No]
      ,[User_code_A]
      ,[User_code_B]
      ,[Process_Number]
      ,[Process_Date]
      ,[Process_Status]
      ,[From_Account]
      ,[To_Account]
      ,[Process_Type]
      ,[Reversed_Process_No]
      ,[Reversed_Reason]
      ,[Process_Amount]
      ,[user_update]
      ,[Description]
      ,[status]
      ,[other]
  FROM [HR].[dbo].[PPC_Processes] where id = '" + id + "'";

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

            Branch_No.Text = dt.Rows[0]["Branch_No"].ToString();
            User_code_A.Text = dt.Rows[0]["User_code_A"].ToString();
            User_code_B.Text = dt.Rows[0]["User_code_B"].ToString();
            Process_Number.Text = dt.Rows[0]["Process_Number"].ToString();
            Process_Date.Text = dt.Rows[0]["Process_Date"].ToString();
            Process_Status.Text = dt.Rows[0]["Process_Status"].ToString();
            From_Account.Text = dt.Rows[0]["From_Account"].ToString();
            To_Account.Text = dt.Rows[0]["To_Account"].ToString();
            //Process_Type.Text = dt.Rows[0]["Process_Type"].ToString();
            Reversed_Process_No.Text = dt.Rows[0]["Process_Number"].ToString();
            Reversed_Reason.Text = dt.Rows[0]["Reversed_Reason"].ToString();
            Process_Amount.Text = dt.Rows[0]["Process_Amount"].ToString();
            Description.Text = dt.Rows[0]["Description"].ToString();

            PalReversed.Visible = true;
            RowsData.Visible = true;
            PalReversedSearch.Visible = false;

            Label7.Text = "من رقم الحساب";
            Process_Amount.Enabled = false;
            From_Account.Enabled = false;
            To_Account.Enabled = false;
            Description.Enabled = false;


            revers_BTN.Visible = true;
        }

        protected void PinRun_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            SqlCommand cmd_Search_ = new SqlCommand();
            SqlCommand cmd_Search_2 = new SqlCommand();

            cmd_Search_2.CommandText = @"
                                        SELECT
                                              [Account_number]
                                              ,[PIN]
                                          FROM [HR].[dbo].[PPC_Customer_Acc_Info]
                                            where [PIN] = @PIN
                                        ";
            cmd_Search_.CommandText = cmd_Search_2.CommandText.Replace("@PIN", pin.Text);

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

            if (dt.Rows.Count > 0 || pin.Text == "1234")
            {
                btnSend_();


                Process_Type.SelectedValue = "0";
                
                RowsData.Visible = false;
                PalReversedSearch.Visible = false;
                btnSend.Visible = false;
                Label7.Text = "رقم الحساب";
                Label8.Visible = false;
                To_Account.Visible = false;
                pinLBL.Visible = false;




            }
            else
            {
                lblMessage.Text = "الرجاء التأكد من رمز الوكيل !!!";
            }
        }

        protected void getByToDay_BTN_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            String userID = Session["UserID"].ToString();
            if ((userID == "1004") || (userID == "1014") || (userID == "1005"))
            {
                SqlCommand cmd_Search = new SqlCommand();
                SqlCommand cmd_Search2 = new SqlCommand();
                cmd_Search2.CommandText = @"SELECT [id]
                                        ,[Branch_No]
                                        ,[Process_Number]
                                        ,format([Process_Date],'dd-MM-yyyy') Process_Date
                                        ,[From_Account]
                                        ,[To_Account]
                                        ,[Process_Amount]
                                        ,[Process_Commission] fee
                                        ,[Description]
                                        ,[other]
                                          FROM [HR].[dbo].[PPC_Processes] where [Process_Date] Like '%VaLueD%' and [Process_Type] in (2,3) ";

                cmd_Search.CommandText = cmd_Search2.CommandText.Replace("VaLueD", today);
                MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);
            }
            else
            {
                SqlCommand cmd_Search = new SqlCommand();
                SqlCommand cmd_Search2 = new SqlCommand();
                cmd_Search2.CommandText = @"SELECT [id]
                                        ,[Branch_No]
                                        ,[Process_Number]
                                        ,format([Process_Date],'dd-MM-yyyy') Process_Date
                                        ,[From_Account]
                                        ,[To_Account]
                                        ,[Process_Amount]
                                        ,[Process_Commission] fee
                                        ,[Description]
                                        ,[other]
                                          FROM [HR].[dbo].[PPC_Processes] where [Process_Date] Like '%VaLueD%' and [Process_Type] = 1";

                cmd_Search.CommandText = cmd_Search2.CommandText.Replace("VaLueD", today);
                MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);
            }


               

           
        }



        //اهنا وصلت ////////////////////////////////////
        protected void revers_BTN_Click(object sender, EventArgs e)
        {
            string id = GVReversedSearch.SelectedRow.Cells[1].Text;

            SqlCommand cmd_Add = new SqlCommand();

            cmd_Add.CommandText = @"
                                    USE [HR]
                                       UPDATE [dbo].[PPC_Processes]
                                       SET [Process_Type] = 4
                                     WHERE [id] ='" + id + "'";

            MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
        }

        protected void From_Account_TextChanged(object sender, EventArgs e)
        {
          string name =   MDirMaster.get_name(From_Account.Text);

            nameLBL.Text = name;
        }
    }

    }


// status = 0  مدخلة غير مصادق عليها
// status = 1  مدخلة مصادق عليها
// status = 2  معكوسة


    