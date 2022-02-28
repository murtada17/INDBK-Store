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
    public partial class PPC_RePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string branch_ = Session["BranchID"].ToString();

                SqlCommand cmd_Search = new SqlCommand();
                SqlCommand cmd_Search2 = new SqlCommand();

                cmd_Search2.CommandText = @"SELECT 
								Pro.Process_Number 'رقم العملية'
                               ,usr.UserName 'المخول ب' 
                               ,[Process_Number] 'رقم العملية'
							   ,info.[Account_name] 'الاسم'
                               ,Format([Process_Date],'dd/MM/yyyy') 'تاريخ العملية'
                               ,[From_Account] 'من رقم حساب'
                               ,[To_Account] 'الى رقم حساب'
                               ,[Process_Amount] 'المبلغ'
                               ,[Description] 'الملاحظات'
							   ,emp.[BranchID]
                              
                               
                              FROM [HR].[dbo].[PPC_Processes] as Pro 
	                            	left join [HR].[dbo].[PPC_Branchs] as Bra on Pro.[Branch_No] = Bra.BRANCH_CODE
	                            	left join [HR].[dbo].UsersTBL as usr on Pro.User_code_A = usr.UserID
	                            	left join [HR].[dbo].UsersTBL as usr2 on Pro.User_code_B = usr2.UserID
									left join [HR].[dbo].[PPC_Customer_Acc_Info] info on Pro.[From_Account] = info.[Account_number]
									left join [HR].[dbo].[EmployeesTBL] emp on usr.EmpID = emp.[EmpID]
  
                              where [Verification_status] = 1 and [Process_Type] = 3 and emp.BranchID = @BrchI
                                ORDER BY [Process_Number] DESC ";

                cmd_Search.CommandText = cmd_Search2.CommandText.Replace("@BrchI", branch_);
                MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

             string branch_ = Session["BranchID"].ToString();


            if (txtReversedSearch.Text == "" || txtReversedSearch.Text == null)
            {
                lblMessage.Text = "يرجى ملئ حقل رقم العملية";
            }

            else
            {
                SqlCommand cmd_Search2 = new SqlCommand();
                SqlCommand cmd_Search = new SqlCommand();

                cmd_Search2.CommandText = @"SELECT 
								Pro.Process_Number 'رقم العملية'
                               ,usr.UserName 'المخول ب' 
                               ,[Process_Number] 'رقم العملية'
							   ,info.[Account_name] 'الاسم'
                               ,Format([Process_Date],'dd/MM/yyyy') 'تاريخ العملية'
                               ,[From_Account] 'من رقم حساب'
                               ,[To_Account] 'الى رقم حساب'
                               ,[Process_Amount] 'المبلغ'
                               ,[Description] 'الملاحظات'
							   ,emp.[BranchID]
                              
                               
                              FROM [HR].[dbo].[PPC_Processes] as Pro 
	                            	left join [HR].[dbo].[PPC_Branchs] as Bra on Pro.[Branch_No] = Bra.BRANCH_CODE
	                            	left join [HR].[dbo].UsersTBL as usr on Pro.User_code_A = usr.UserID
	                            	left join [HR].[dbo].UsersTBL as usr2 on Pro.User_code_B = usr2.UserID
									left join [HR].[dbo].[PPC_Customer_Acc_Info] info on Pro.[From_Account] = info.[Account_number]
									left join [HR].[dbo].[EmployeesTBL] emp on usr.EmpID = emp.[EmpID]
  
                              where [Verification_status] = 1 and [Process_Type] = 3 and emp.BranchID = @BrchI and Pro.Process_Number = @NuM";


                cmd_Search.CommandText = cmd_Search2.CommandText.Replace("@BrchI", branch_).Replace("@NuM", txtReversedSearch.Text);



                MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);


            }



        }

        protected void GVReversedSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            string iid = GVReversedSearch.SelectedRow.Cells[1].Text;
            string name = GVReversedSearch.SelectedRow.Cells[4].Text;
            string datee = GVReversedSearch.SelectedRow.Cells[5].Text;

            ReportDocument Report = new ReportDocument();
            Report.Load(Server.MapPath("~/Reports/ReportSource/RPrint2.rpt"));
            Report.SetDatabaseLogon("HR", "1HR12IIB18", "10.10.16.30", "HR");
            Report.SetParameterValue("num", iid);
            Report.SetParameterValue("datee", datee);
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

        protected void btnSend_Click(object sender, EventArgs e)
        {

        }
    }

    }
