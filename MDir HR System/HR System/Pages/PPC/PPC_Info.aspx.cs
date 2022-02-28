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
    public partial class PPC_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                MDirMaster.FillCombo("BRANCH_CODE", "BRANCH_Name", "PPC_Branchs", Branch_No, "1=1", lblMessage);
                MDirMaster.FillCombo("Account_Type_CODE", "Account_Type_Name", "PPC_Account_Type", Account_Type, "1=1", lblMessage);
                MDirMaster.FillCombo("Currency_CODE", "Currency_Name", "PPC_Currency", Account_currency, "1=1", lblMessage);
                MDirMaster.FillCombo("Account_Class_CODE", "Account_Class_Name", "PPC_Account_Class", Account_Class, "1=1", lblMessage);

                string today = DateTime.Now.ToString("yyyy-MM-dd");

                Account_opening_date.Text = today;
                Account_opening_date.Enabled = false;

                Branch_No.SelectedIndex = 6;
                Branch_No.Enabled = false;

                Account_Type.SelectedIndex = 2;
                Account_Type.Enabled = false;

                Account_currency.SelectedIndex = 2;
                Account_currency.Enabled = false;

                Account_Class.SelectedIndex = 1;
                Account_Class.Enabled = false;



            }
        }

        String Status_input = "";


        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            ButUpdate.Enabled = false;
            RowsData.Visible = true;
            btnSend.Visible = true;
            btnCancel.Visible = true;
            AddUpdate.Text = "Add";
            
        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            ButAdd.Enabled = false;
            PalUpdate.Visible = true;
            AddUpdate.Text = "Update";
        }

        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {
            btnSend.Visible = true;

            string _Account_number = txtUpdate.Text;

            SqlCommand cmd_Search = new SqlCommand();
            cmd_Search.CommandText = @"SELECT [id]
      ,[Branch_No]
      ,[User_code_A]
      ,[User_code_B]
      ,[Account_opening_date]
      ,[Account_name]
      ,[Account_number]
      ,[IBAN]
      ,[Account_Type]
      ,[Account_currency]
      ,[Account_holder_address]
      ,[Account_holder_mobile]
      ,[Account_Class]
      ,[Name_manager]
      ,[Address_manager]
      ,[profession_manager]
      ,[Mobile_manager]
      ,[Update_Date]
      ,[status]
      ,[other]
  FROM [HR].[dbo].[PPC_Customer_Acc_Info] where Account_number Like '%" + _Account_number + "%'";

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            PalUpdate.Visible = true;

        }





        protected void btnSend_Click(object sender, EventArgs e)
        {


            

                int PIN = MDirMaster.random_(1000, 9999);

                String userID = Session["UserID"].ToString();


                DateTime _opening_date = DateTime.Now;
                string today = DateTime.Now.ToString("yyyy-MM-dd");

                Account_opening_date.Text = today;

                SqlCommand cmd_Add = new SqlCommand();
                SqlCommand cmd_Update = new SqlCommand();



                cmd_Add.CommandText = @"USE [HR]

            INSERT INTO [dbo].[PPC_Customer_Acc_Info]
           ([Branch_No]
           ,[User_code_A]
           ,[User_code_B]
           ,[Account_opening_date]
           ,[Account_name]
           ,[Account_number]
           ,[IBAN]
           ,[Account_Type]
           ,[Account_currency]
           ,[Account_holder_address]
           ,[Account_holder_mobile]
           ,[Account_Class]
           ,[Name_manager]
           ,[Address_manager]
           ,[profession_manager]
           ,[Mobile_manager]
           ,[PIN]
         
           )
     VALUES
           (
        '" + Branch_No.Text + @"',
        '" + userID + @"',
        '" + User_code_B.Text + @"',
        '" + today + @"',
        '" + Account_name.Text + @"',
        '" + Account_number.Text + @"',
        '" + IBAN.Text + @"',
        '" + Account_Type.Text + @"',
        '" + Account_currency.Text + @"',
        '" + Account_holder_address.Text + @"',
        '" + Account_holder_mobile.Text + @"',
        '" + Account_Class.Text + @"',
        '" + Name_manager.Text + @"',
        '" + Address_manager.Text + @"',
        '" + profession_manager.Text + @"',
        '" + Mobile_manager.Text + @"',
        '" + PIN + @"'

)


";

                string iid = "";

                try
                {
                    if (GVUpdate.SelectedRow.Cells[1].Text != null)
                    { iid = GVUpdate.SelectedRow.Cells[1].Text; }
                }
                catch (Exception ee) { lblMessage.Text = ee.ToString(); }



                cmd_Update.CommandText = @"
USE [HR]

UPDATE [dbo].[PPC_Customer_Acc_Info]
   SET 
Branch_No = '" + Branch_No.Text + @"',
User_code_A = '" + User_code_A.Text + @"',
User_code_B = '" + User_code_B.Text + @"',
Account_name = '" + Account_name.Text + @"',
Account_number = '" + Account_number.Text + @"',
IBAN = '" + IBAN.Text + @"',
Account_Type = '" + Account_Type.Text + @"',
Account_currency = '" + Account_currency.Text + @"',
Account_holder_address = '" + Account_holder_address.Text + @"',
Account_holder_mobile = '" + Account_holder_mobile.Text + @"',
Account_Class = '" + Account_Class.Text + @"',
Name_manager = '" + Name_manager.Text + @"',
Address_manager = '" + Address_manager.Text + @"',
profession_manager = '" + profession_manager.Text + @"',
Mobile_manager = '" + Mobile_manager.Text + @"',
Update_Date = '" + today + @"'


 WHERE [id] = '" + iid + "'";




                DateTime DD = DateTime.Now;

                //20/02/2019


                if (Branch_No.SelectedIndex == 0 || Account_Type.SelectedIndex == 0 || Account_currency.SelectedIndex == 0 || Account_Class.SelectedIndex == 0)

                {
                    MDirMaster.Messages(lblMessage, "يجب ملىء الحقول الاجبارية");
                }

                else
                {

                    if (AddUpdate.Text == "Add")
                    {


                    bool check_account = false;

                    check_account = MDirMaster.Get_Account(Account_number.Text, lblMessage);

                    if (check_account == true)
                    {
                        lblMessage.Text = "رقم الحساب مدخل سابقا !!!!";
                    }

                    else
                    {
                        MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
                    }


                        
                    }

                    else if (AddUpdate.Text == "Update")
                    {
                        MDirMaster.Execute(cmd_Update, lblMessage, HttpContext.Current.Request.Path);
                    }

                }

            
           



            
        }
        /// <summary>
        /// //////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 



        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = GVUpdate.SelectedRow.Cells[1].Text;

            //////////////////////////////////
            ///
            SqlCommand cmd_Search_ = new SqlCommand();
            cmd_Search_.CommandText = @"SELECT [id]
                                        ,[Branch_No]
                                        ,[User_code_A]
                                        ,[User_code_B]
                                        ,[Account_opening_date]
                                        ,[Account_name]
                                        ,[Account_number]
                                        ,[IBAN]
                                        ,[Account_Type]
                                        ,[Account_currency]
                                        ,[Account_holder_address]
                                        ,[Account_holder_mobile]
                                        ,[Account_Class]
                                        ,[Name_manager]
                                        ,[Address_manager]
                                        ,[profession_manager]
                                        ,[Mobile_manager]
                                        ,[Update_Date]
                                        ,[status]
                                        ,[other]
                                    FROM [HR].[dbo].[PPC_Customer_Acc_Info] where [id] = '" + id + "'";

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

            Branch_No.Text = dt.Rows[0]["Branch_No"].ToString();
            User_code_A.Text = dt.Rows[0]["User_code_A"].ToString();
            User_code_B.Text = dt.Rows[0]["User_code_B"].ToString();
            Account_opening_date.Text = dt.Rows[0]["Account_opening_date"].ToString();
            Account_name.Text = dt.Rows[0]["Account_name"].ToString();
            Account_number.Text = dt.Rows[0]["Account_number"].ToString();
            IBAN.Text = dt.Rows[0]["IBAN"].ToString();
            Account_Type.Text = dt.Rows[0]["Account_Type"].ToString();
            Account_currency.Text = dt.Rows[0]["Account_currency"].ToString();
            Account_holder_address.Text = dt.Rows[0]["Account_holder_address"].ToString();
            Account_holder_mobile.Text = dt.Rows[0]["Account_holder_mobile"].ToString();
            Account_Class.Text = dt.Rows[0]["Account_Class"].ToString();
            Name_manager.Text = dt.Rows[0]["Name_manager"].ToString();
            Address_manager.Text = dt.Rows[0]["Address_manager"].ToString();
            profession_manager.Text = dt.Rows[0]["profession_manager"].ToString();
            Mobile_manager.Text = dt.Rows[0]["Mobile_manager"].ToString();
            //Create_Date.Text = dt.Rows[0]["Create_Date"].ToString();
            //status.Text = dt.Rows[0]["status"].ToString();

            RowsData.Visible = true;
            PalUpdate.Visible = false;



        }

        protected void Account_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Account_Class.SelectedIndex == 1)
            {
                IndOrCom.Visible = false;
            }
            else if(Account_Class.SelectedIndex == 2)
            {
                IndOrCom.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ButUpdate.Enabled = true;
            ButAdd.Enabled = true;
            RowsData.Visible = false;
            btnSend.Visible = false;
            btnCancel.Visible = false;
        }
    }

    }
