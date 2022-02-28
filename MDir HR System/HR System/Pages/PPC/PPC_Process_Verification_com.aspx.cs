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
    public partial class PPC_Process_Verification_com : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                MDirMaster.FillCombo("Processes_Type_CODE", "Processes_Type_Name", "PPC_Processes_Type", Process_Type, "1=1", lblMessage);
                MDirMaster.FillCombo("BRANCH_CODE", "BRANCH_Name", "PPC_Branchs", Branch_No, "1=1", lblMessage);
                MDirMaster.FillCombo("Account_No", "Account_Name", "PPC_Fixed_Account", To_Account, "1=1", lblMessage);

                User_code_A.Text = Session["username"].ToString();

                String userID = Session["UserID"].ToString();
                if ((userID == "1015") || (userID == "1016"))
                {
                    SqlCommand cmd_Search = new SqlCommand();

                    cmd_Search.CommandText = @"SELECT Pro.[id]
                               ,Bra.BRANCH_Name 'الفرع'
                               ,usr.UserName 'المخول ب'
                               ,usr2.UserName 'المخول أ'
                               ,[Process_Number] 'رقم العملية'
                               ,Format([Process_Date],'dd/MM/yyyy') 'تاريخ العملية'
                               ,[From_Account] 'من رقم حساب'
                               ,[To_Account] 'الى رقم حساب'
                               ,[Process_Amount] 'المبلغ'
                               ,[Process_Commission] 'العمولة'
                               ,[Description] 'الملاحظات'
                               ,[Verification_status] 
                               
                              FROM [HR].[dbo].[PPC_Processes] as Pro 
	                            	left join [HR].[dbo].[PPC_Branchs] as Bra on Pro.[Branch_No] = Bra.BRANCH_CODE
	                            	left join [HR].[dbo].UsersTBL as usr on Pro.User_code_A = usr.UserID
	                            	left join [HR].[dbo].UsersTBL as usr2 on Pro.User_code_B = usr2.UserID
  
                              where [Verification_status] = 0 and [Process_Type] = 3 and [user_update] in (1004,1014,1005)";



                    MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);
                }

                else
                {

                     SqlCommand cmd_Search = new SqlCommand();
                    
                                    cmd_Search.CommandText = @"SELECT Pro.[id]
                                                   ,Bra.BRANCH_Name 'الفرع'
                                                   ,usr.UserName 'المخول ب'
                                                   ,usr2.UserName 'المخول أ'
                                                   ,[Process_Number] 'رقم العملية'
                                                   ,Format([Process_Date],'dd/MM/yyyy') 'تاريخ العملية'
                                                   ,[From_Account] 'من رقم حساب'
                                                   ,[To_Account] 'الى رقم حساب'
                                                   ,[Process_Amount] 'المبلغ'
                                                   ,[Process_Commission] 'العمولة'
                                                   ,[Description] 'الملاحظات'
                                                   ,[Verification_status] 
                                                   
                                                  FROM [HR].[dbo].[PPC_Processes] as Pro 
                    	                            	left join [HR].[dbo].[PPC_Branchs] as Bra on Pro.[Branch_No] = Bra.BRANCH_CODE
                    	                            	left join [HR].[dbo].UsersTBL as usr on Pro.User_code_A = usr.UserID
                    	                            	left join [HR].[dbo].UsersTBL as usr2 on Pro.User_code_B = usr2.UserID
                      
                                                  where [Verification_status] = 0 and [Process_Type] in (1,2,4) and [user_update] not in (1004,1014,1005)";
                    
                                    
                    
                                    MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);
                    
                }

                   



                Branch_No.Enabled = false;





            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string _Account_number = txtReversedSearch.Text;



            SqlCommand cmd_Search2 = new SqlCommand();
            SqlCommand cmd_Search = new SqlCommand();

            cmd_Search2.CommandText = @"SELECT Pro.[id]
                               ,Bra.BRANCH_Name 'الفرع'
                               ,usr.UserName 'المخول ب'
                               ,usr2.UserName 'المخول أ'
                               ,[Process_Number] 'رقم العملية'
                               ,Format([Process_Date],'dd/MM/yyyy') 'تاريخ العملية'
                               ,[From_Account] 'من رقم حساب'
                               ,[To_Account] 'الى رقم حساب'
                               ,[Process_Amount] 'المبلغ'
                               ,[Process_Commission] 'العمولة'
                               ,[Description] 'الملاحظات'
                               ,[Verification_status] 
                               
                              FROM [HR].[dbo].[PPC_Processes] as Pro 
	                            	left join [HR].[dbo].[PPC_Branchs] as Bra on Pro.[Branch_No] = Bra.BRANCH_CODE
	                            	left join [HR].[dbo].UsersTBL as usr on Pro.User_code_A = usr.UserID
	                            	left join [HR].[dbo].UsersTBL as usr2 on Pro.User_code_B = usr2.UserID
  
                              where [Verification_status] = 0 and From_Account =  _Account_number ";


            cmd_Search.CommandText = cmd_Search2.CommandText.Replace("_Account_number", _Account_number);



            MDirMaster.FillGrid(cmd_Search, GVReversedSearch, lblMessage);




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


            PalReversedSearch.Visible = false;
            RowsData.Visible = true;
            btnSend.Visible = true;
            btnCancel.Visible = true;

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Add = new SqlCommand();

            cmd_Add.CommandText = @"
                                    USE [HR]
                                       UPDATE [dbo].[PPC_Processes]
                                       SET [Verification_status] = 1
                                     WHERE [Process_Number] ='" + Process_Number.Text + "'";

            MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Add = new SqlCommand();

            cmd_Add.CommandText = @"
                                    USE [HR]
                                       UPDATE [dbo].[PPC_Processes]
                                       SET [Verification_status] = 2
                                     WHERE [Process_Number] ='" + Process_Number.Text + "'";

            MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
        }
    }

    }


// status = 0  مدخلة غير مصادق عليها
// status = 1  مدخلة مصادق عليها
// status = 2  معكوسة
