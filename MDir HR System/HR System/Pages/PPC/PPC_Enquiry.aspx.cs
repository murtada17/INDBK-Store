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
    public partial class PPC_Enquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblMessage.Text = "";

                string branchID = Session["BranchID"].ToString();

                if (branchID == "46" || branchID == "47")
                {
                    txtAccount.Text = "68";
                    txtAccount.Enabled = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (txtAccount.Text == null || txtAccount.Text == "")
            {
                lblMessage.Text = "يرجى ملئ حقل رقم الحساب";
            }
            else
            {


                
               // string depID = Session["depID"].ToString();
                

                string Amount = MDirMaster.Get_amount(txtAccount.Text, lblMessage);

                SqlCommand cmd_Search_ = new SqlCommand();
                SqlCommand cmd_Search_2 = new SqlCommand();

                cmd_Search_2.CommandText = @"
                                    select '', Pro.[From_Account] as 'رقم الحساب' , Inf.Account_name 'الاسم' , sum(Pro.[Process_Amount]) - sum ([Process_Commission]) as 'الرصيد' ,
                                    case 
                                    when Inf.Account_currency = 368 then 'IQD' 
                                    when Inf.Account_currency = 840 then 'USD' 
                                    end 'العملة'
                                     FROM [HR].[dbo].[PPC_Processes] Pro 
                                     left join [HR].[dbo].[PPC_Customer_Acc_Info] Inf on Pro.From_Account = Inf.Account_number				 
                                     where [From_Account] = @@Input
                                     and [Verification_status] = 1
                                     and [Process_Type] not in (4)
                                     group by  [From_Account],Account_currency, Inf.Account_name
                                                                            ";

                cmd_Search_.CommandText = cmd_Search_2.CommandText.Replace("@@Input", txtAccount.Text);

                MDirMaster.FillGrid(cmd_Search_, GridView1, lblMessage);

                lblMessage.Text = "";
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
            string aditionalTXT = "";
            if (txtAccount.Text == null || txtAccount2.Text == "")
            {
                aditionalTXT = "";
            }
            else
            {
                aditionalTXT = " and [From_Account] = " + txtAccount2.Text + " order by pro.[Process_Number]";
            }

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

            //cmd_Search_2.CommandText = @"
            //                        SELECT [id]
            //                          ,[Branch_No] 'الفرع'
            //                          ,format([Process_Date],'dd-MM-yyyy') 'تاريخ العملية'
                                      
            //                          ,[From_Account] 'من حساب'
            //                          ,[To_Account] 'الى حساب'
            //                          ,[Process_Amount] 'المبلغ'
            //                          ,[Process_Commission] 'العمولة'
            //                          ,[other] 'نوع العملية'
            //                      FROM [HR].[dbo].[PPC_Processes]
            //                      WHERE [Process_Date] between '@FromDate' and '@ToDate' and [Verification_status] = 1 and [Process_Type] = 3
            //                                                                ";

                cmd_Search_2.CommandText = @"SELECT pro.[id]
                                      ,pro.[Process_Number] 'رقم العملية'
                                      ,format(pro.[Process_Date],'dd-MM-yyyy') 'تاريخ العملية'
                                      
                                      ,pro.[From_Account] 'من حساب'
                                      ,pro.[To_Account] 'الى حساب'
									  ,inf.Account_name 'الاسم'
                                      ,pro.[Process_Amount] 'المبلغ'
                                      ,pro.[Process_Commission] 'العمولة'
                                      ,pro.[other] 'نوع العملية'
									  ,case 
									      when (pro.[user_update] = '1') then 'ادمن' 
										  when (pro.[user_update] = '1009') then 'الفرع' 
										  when (pro.[user_update] = '1010') then 'الفرع' 
										  when (pro.[user_update] = '1011') then 'الفرع' 
										  when (pro.[user_update] = '1013') then 'الفرع' 

										  when (pro.[user_update] = '1012') then 'قطع بابل' 
										  when (pro.[user_update] = '1015') then 'قطع بابل'  
										  when (pro.[user_update] = '1016') then 'قطع بابل' 
                                          when (pro.[user_update] = '1022') then 'قطع بابل'

										 
										 when (pro.[user_update] = '1017') then 'قطع السدة' 
										 when (pro.[user_update] = '1018') then 'قطع السدة' 
										 when (pro.[user_update] = '1019') then 'قطع السدة' 
										 when (pro.[user_update] = '1020') then 'قطع السدة' 
										 when (pro.[user_update] = '1021') then 'قطع السدة' 
										  end   'مصدر العملية'

									

                                  FROM [HR].[dbo].[PPC_Processes] pro left join [HR].[dbo].[PPC_Customer_Acc_Info] inf on pro.[From_Account] = inf.[Account_number]
                                  WHERE [Process_Date] between '@FromDate' and '@ToDate' and [Verification_status] = 1 and [Process_Type] in (1,3)
                                    ";





                    //cmd_Search_.CommandText = cmd_Search_2.CommandText.Replace("@FromDate", _fromDate2).Replace("@ToDate", _ToDate2) + aditionalTXT;
              




                cmd_Search_.CommandText = cmd_Search_2.CommandText.Replace("@FromDate", _fromDate2).Replace("@ToDate", _ToDate2) + aditionalTXT;

            MDirMaster.FillGrid(cmd_Search_, GVReversedSearch, lblMessage);






            }

            




        }
    }

}

