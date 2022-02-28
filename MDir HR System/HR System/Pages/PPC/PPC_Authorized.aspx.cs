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
    public partial class PPC_Authorized : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //GridViewAdd

            }
        }

        String Status_input = "";


        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            ButUpdate.Enabled = false;
            //RowsData.Visible = true;
            PalAdd.Visible = true;
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
            cmd_Search.CommandText = @"SELECT TOP 1000 [id]
                                         ,[Account_No]
                                         ,[Authorized_Name]
                                         ,[Authorized_Address]
                                         ,[Authorization_profession]
                                         ,[Authorization_mobile]
                                         ,[status]
                                         ,[other]
                                     FROM [HR].[dbo].[PPC_Authorized] where Account_No = '" + _Account_number + "'";
                                    
            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            PalUpdate.Visible = true;

        }





        protected void btnSend_Click(object sender, EventArgs e)
        {

            String userID = Session["UserID"].ToString();


            DateTime _opening_date = DateTime.Now;
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            SqlCommand cmd_Add = new SqlCommand();
            SqlCommand cmd_Update = new SqlCommand();



            cmd_Add.CommandText = @"USE [HR]

            INSERT INTO [dbo].[PPC_Authorized]
                       ([Account_No]
                       ,[Authorized_Name]
                       ,[Authorized_Address]
                       ,[Authorization_profession]
                       ,[Authorization_mobile]
                      
                       )
                 VALUES
                       (
            
            '" + Account_No.Text + @"',
            '" + Authorized_Name.Text + @"',
            '" + Authorized_Address.Text + @"',
            '" + Authorization_profession.Text + @"',
            '" + Authorization_mobile.Text + @"'
            
                                 )";

            //idUpdate
            string iid = idUpdate.Text;

            cmd_Update.CommandText = @"

USE [HR]

UPDATE [dbo].[PPC_Authorized]
   SET [Account_No] = '" + Account_No.Text + @"'
      ,[Authorized_Name] = '" + Authorized_Name.Text + @"'
      ,[Authorized_Address] = '" + Authorized_Address.Text + @"'
      ,[Authorization_profession] = '" + Authorization_profession.Text + @"'
      ,[Authorization_mobile] = '" + Authorization_mobile.Text + @"'
     
 WHERE [id] = '" + iid + "'";
           



            DateTime DD = DateTime.Now;


         

                if (AddUpdate.Text == "Add")
                {
                    MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
                }

                else if (AddUpdate.Text == "Update")
                {
                    MDirMaster.Execute(cmd_Update, lblMessage, HttpContext.Current.Request.Path);
                }

            
        }

        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = GVUpdate.SelectedRow.Cells[1].Text;
            idUpdate.Text = id;

            SqlCommand cmd_Search_ = new SqlCommand();
            cmd_Search_.CommandText = @"SELECT [id]
                                         ,[Account_No]
                                         ,[Authorized_Name]
                                         ,[Authorized_Address]
                                         ,[Authorization_profession]
                                         ,[Authorization_mobile]
                                         ,[status]
                                         ,[other]
                                           FROM [HR].[dbo].[PPC_Authorized]
                                         where [id] = '" + id + "'";

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

            Account_No.Text = dt.Rows[0]["Account_No"].ToString();
            Authorized_Name.Text = dt.Rows[0]["Authorized_Name"].ToString();
            Authorized_Address.Text = dt.Rows[0]["Authorized_Address"].ToString();
            Authorization_profession.Text = dt.Rows[0]["Authorization_profession"].ToString();
            Authorization_mobile.Text = dt.Rows[0]["Authorization_mobile"].ToString();
          

            RowsData.Visible = true;
            PalUpdate.Visible = false;



        }

       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ButUpdate.Enabled = true;
            ButAdd.Enabled = true;
            RowsData.Visible = false;
            btnSend.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnSerchAdd_Click(object sender, EventArgs e)
        {
            btnSend.Visible = true;

            string _Account_number = txtAdd.Text;

            SqlCommand cmd_Search = new SqlCommand();
            cmd_Search.CommandText = @"SELECT [id]
      
                                    ,[Account_name]
                                    ,[Account_number]
     
                                     FROM [HR].[dbo].[PPC_Customer_Acc_Info] where Account_number Like '%" + _Account_number + "%'";

            MDirMaster.FillGrid(cmd_Search, GridViewAdd, lblMessage);

          //  PalUpdate.Visible = true;

        }

        protected void GridViewAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = GridViewAdd.SelectedRow.Cells[1].Text;

            SqlCommand cmd_Search_ = new SqlCommand();
            cmd_Search_.CommandText = @"SELECT [id]
      
                                    ,[Account_name]
                                    ,[Account_number]
     
                                     FROM [HR].[dbo].[PPC_Customer_Acc_Info] 
                                     where id = '" + id + "'";

            DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

            Account_No.Text = dt.Rows[0]["Account_number"].ToString();
          
            RowsData.Visible = true;
            PalAdd.Visible = false;


        }
    }

    }
