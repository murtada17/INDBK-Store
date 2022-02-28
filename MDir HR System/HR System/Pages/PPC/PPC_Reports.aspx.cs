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
    public partial class PPC_Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // 25 me
                // 46 bable
                // 47 sada

                string dep = Session["depID"].ToString();
                string branch_ = Session["BranchID"].ToString();
                MDirMaster.FillCombo("Processes_Type_CODE", "Processes_Type_Name", "PPC_Processes_Type", proccess_type, "[Processes_Type_CODE] in (3,1,4)", lblMessage);
                MDirMaster.FillCombo("user_id", "user_text", "PPC_USERS", DLL_user, "1=1", lblMessage);

                if (branch_ == "46")
                {

                    proccess_type.Text = "3";
                    proccess_type.Enabled = false;
                    DLL_user.Text = "2";
                    DLL_user.Enabled = false;    
                }

                else if (branch_ == "47")
                {
                    proccess_type.Text = "3";
                    proccess_type.Enabled = false;
                    DLL_user.Text = "3";
                    DLL_user.Enabled = false;
                }


                lblMessage.Text = "";
               
            }
        }

        protected void GetTransactions_Click(object sender, EventArgs e)
        {
            string dep = Session["depID"].ToString();
            string branch_ = Session["BranchID"].ToString();

            string users = DLL_user.Text;
            string users_ = "";

            if(users == "0")
            {
                users_ = "1009,1010,1011,1012,1013,1015,1016,1017,1018,1019,1020,1021,1022";
            }
            else if (users == "1")
            {
                users_ = "1009,1010,1011,1012,1013";
            }
            else if (users == "2")
            {
                users_ = "1015,1016,1022";
            }
            else if (users == "3")
            {
                users_ = "1017,1018,1019,1020,1021";
            }


            try
            {
                if (FromDate.Text == null || FromDate.Text == "" || ToDate.Text == null || ToDate.Text == "" || proccess_type.SelectedValue == "0")
                {
                    lblMessage.Text = "يرجى تحديد التاريخ او نوع الحركة";
                }

                else
                {

                    string proccess_type_ = proccess_type.SelectedValue;

                    //2020-09-17
                    string _fromDate = FromDate.Text;
                    string _dd = _fromDate.Substring(8, 2);
                    string _MM = _fromDate.Substring(5, 2);
                    string _yy = _fromDate.Substring(0, 4);
                    string _fromDate2 = _yy + "-" + _MM + "-" + _dd;

                    string _ToDate = ToDate.Text;
                    string _dd2 = _ToDate.Substring(8, 2);
                    string _MM2 = _ToDate.Substring(5, 2);
                    string _yy2 = _ToDate.Substring(0, 4);
                    string _ToDate2 = _yy2 + "-" + _MM2 + "-" + _dd2;

                    ReportDocument Report = new ReportDocument();

                    if (branch_ == "46" || branch_ == "47")
                    {
                        Report.Load(Server.MapPath("~/Reports/ReportSource/BrReport22.rpt"));
                    }
                    else
                    {
                        Report.Load(Server.MapPath("~/Reports/ReportSource/BrReport2.rpt"));
                    }

                    //Report.Load(Server.MapPath("~/Reports/ReportSource/BrReport2.rpt"));
                    Report.SetDatabaseLogon("HR", "1HR12IIB18", "10.10.16.30", "HR");
                    Report.SetParameterValue("fromDate", _fromDate2);
                    Report.SetParameterValue("toDate", _ToDate2);
                    Report.SetParameterValue("type", proccess_type_);
                    Report.SetParameterValue("user", users_);
                    CrystalReportViewer1.ReportSource = Report;

                    //
                   
                   // Report.PrintToPrinter(1, false, 0, 0);




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

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }




    
    }



