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

namespace HR_Salaries.Pages.PPC
{
    public partial class Benefits_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblMessage.Text = "";


                Label1.Visible = false;
                Label2.Visible = false;
                Label6.Visible = false;
                from_.Visible = false;
                to_.Visible = false;
                Label3.Visible = false;
                Label5.Visible = false;


            }
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
                                  FROM [HR].[dbo].[PPC_Processes] 
                                  where id = '" + id + "'";

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

           

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void GetTransactions_Click(object sender, EventArgs e)
        {


            if (FromDate.Text == null || FromDate.Text =="" || ToDate.Text == null || ToDate.Text == "")
            {
                lblMessage.Text = "يرجى تحديد التاريخ";
            }

            else
            {
                //2020-09-17
            string _fromDate = FromDate.Text;
            string _dd = _fromDate.Substring(8, 2);
            string _MM = _fromDate.Substring(5, 2);
            string _yy = _fromDate.Substring(0, 4);
            string _fromDate2 = _yy+"-"+ _MM + "-" + _dd;

            string _ToDate = ToDate.Text;
            string _dd2 = _ToDate.Substring(8, 2);
            string _MM2 = _ToDate.Substring(5, 2);
            string _yy2 = _ToDate.Substring(0, 4);
            string _ToDate2 = _yy2 + "-" + _MM2 + "-" + _dd2;


            SqlCommand cmd_Search_ = new SqlCommand();
            SqlCommand cmd_Search_2 = new SqlCommand();

            cmd_Search_2.CommandText = @"
                                                                       SELECT pr.[id]
                                      
                                      ,format(pr.[Process_Date],'dd-MM-yyyy') 'تاريخ العملية'
									  ,cu.Account_name 'اسم الزبون'
                                      ,pr.[From_Account] 'من حساب'

                                      ,pr.[Process_Commission] 'العمولة'
                                      ,pr.[other] 'نوع العملية'
                                  FROM [HR].[dbo].[PPC_Processes] pr left join [HR].[dbo].[PPC_Customer_Acc_Info] cu on pr.From_Account = cu.Account_number
                                  WHERE [Process_Date] between '@FromDate' and '@ToDate' and [Verification_status] = 1 and [Process_Type] in (1,2,3)
                                        
                                                                            ";

            cmd_Search_.CommandText = cmd_Search_2.CommandText.Replace("@FromDate", _fromDate2).Replace("@ToDate", _ToDate2) ;

            MDirMaster.FillGrid(cmd_Search_, GVReversedSearch, lblMessage);




                SqlCommand _cmd_Search_ = new SqlCommand();
                SqlCommand _cmd_Search_2 = new SqlCommand();

                _cmd_Search_2.CommandText =
                    @"SELECT sum([Process_Commission]) as 'sumBenefits'
                FROM[HR].[dbo].[PPC_Processes]
                WHERE[Process_Date] between '@FromDate' and '@ToDate' and[Verification_status] = 1 and [Process_Type] in (1,2,3)";

                _cmd_Search_.CommandText = _cmd_Search_2.CommandText.Replace("@FromDate", _fromDate2).Replace("@ToDate", _ToDate2);

                DataTable dt = MDirMaster.GetData(_cmd_Search_, lblMessage);

                string sumBenefits = dt.Rows[0]["sumBenefits"].ToString();


                Label1.Text = "مجموع العمولة : ";
                Label2.Text = sumBenefits;

                Label6.Text = "دينار عراقي";


                from_.Text = _fromDate2;
                to_.Text = _ToDate2 ;

                Label3.Text = "الفترة من";
                Label5.Text = "الى";




                if (dt.Rows.Count > 0 )
                {
                    Label1.Visible = true;
                    Label2.Visible = true;
                    Label6.Visible = true;
                    from_.Visible = true;
                    to_.Visible = true;
                    Label3.Visible = true;
                    Label5.Visible = true;
                }


            }

            




        }
    }

}

