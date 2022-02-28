using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace HR_Salaries.Pages.MSC
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MDirMaster.FillCombo("id", "LedgerDscrp", "Assets_P_group", groupid_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "Dscrp", "gp_currencies", CurrencyID, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "Dscrp", "Assets_P_States", TheState_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "Dscrp", "Assets_P_Brands", brand_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "Dscrp", "Assets_P_Modules", Module_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "Dscrp", "gp_Countries", IndustryID_DDL, "1=1", lblMessage);

            }

           //Date_show.Text = DateTime.Now.ToString();
        }


        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            PalUpdate.Visible = true;
        }       

        protected void btnSerchUpdate_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();


            cmd_Search.CommandText = @"use [HR]
       SELECT [id]
      ,[ElmintID]
      ,[TheState]
      ,[StateDate]
      ,[Dscrp]
      ,[SerialNo]
      ,[groupid]
      ,[StartDate]
      ,[PurchaseValue]
      ,[PurchaseDate]
      ,[SoldAmount]
      ,[AccountUnitID]
      ,[BranchID]
      ,[barcode]
      ,[brand]
      ,[Module]
      ,[imgurl]
      ,[IndustryID]
      ,[CurrencyID]
      ,[Comments]
      ,[Editor]
      ,[EditDate]
      ,[StartYear]
      ,[StartMonth]
      ,[StateYear]
      ,[StateMonth]
       FROM [HR].[dbo].[Assets_T_Elemints] where [HR].[dbo].[Assets_T_Elemints].[Dscrp] Like '%" + txtUpdate.Text + "%'";

            //cmd_Search.Parameters.AddWithValue("@CONTRACT_REFERENCE", txtUpdate.Text);

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            PalUpdate.Visible = true;
        }

        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdate.Text = "update"; // if Update or Add

            string id = GVUpdate.SelectedRow.Cells[1].Text;
            lbl_id.Text = id;
            SqlCommand cmd_GV = new SqlCommand();



            cmd_GV.CommandText = @"use [HR]
                   SELECT [id]
                  ,[ElmintID]
                  ,[TheState]
                  ,[StateDate]
                  ,[Dscrp]
                  ,[SerialNo]
                  ,[groupid]
                  ,[StartDate]
                  ,[PurchaseValue]
                  ,[PurchaseDate]
                  ,[SoldAmount]
                  ,[AccountUnitID]
                  ,[BranchID]
                  ,[barcode]
                  ,[brand]
                  ,[Module]
                  ,[imgurl]
                  ,[IndustryID]
                  ,[CurrencyID]
                  ,[Comments]
                  ,[Editor]
                  ,[EditDate]
                  ,[StartYear]
                  ,[StartMonth]
                  ,[StateYear]
                  ,[StateMonth]
                  FROM [HR].[dbo].[Assets_T_Elemints] where [HR].[dbo].[Assets_T_Elemints].[id] 
                  Like '%" + id + "%'";

            DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

            Dscrp.Text = dt.Rows[0]["Dscrp"].ToString();
            SerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
            groupid_DDL.Text = dt.Rows[0]["groupid"].ToString();
            PurchaseValue.Text = dt.Rows[0]["PurchaseValue"].ToString();
            PurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
            CurrencyID.Text = dt.Rows[0]["CurrencyID"].ToString();
            Date_show.Text = dt.Rows[0]["StartYear"].ToString() + dt.Rows[0]["StartMonth"].ToString();
            TheState_DDL.Text = dt.Rows[0]["TheState"].ToString() ;
            brand_DDL.Text = dt.Rows[0]["brand"].ToString();


            Panel2.Visible = true;


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

         

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd_update = new SqlCommand();
            SqlCommand cmd_Max = new SqlCommand();


            cmd_Max.CommandText = @"use [HR]
                                    SELECT 
                                    max([ElmintID]) as max_id   
                                    FROM [HR].[dbo].[Assets_T_Elemints]
                                    ";
            DataTable dt = MDirMaster.GetData(cmd_Max, lblMessage);
            String Max_id = dt.Rows[0]["max_id"].ToString();
            int max =( int.Parse(Max_id) ) + 1;


            cmd_update.CommandText = @"USE [HR]

UPDATE [dbo].[Assets_T_Elemints]
   SET 
       [TheState]           =  '" + TheState_DDL.Text + @"'
      ,[StateDate]          =  '" + public_Date.Text + @"'
      ,[Dscrp]              =  '" + Dscrp.Text + @"'
      ,[SerialNo]           =  '" + SerialNo.Text + @"'
      ,[groupid]            =  '" + groupid_DDL.Text + @"'
      ,[StartDate]          =  '" + public_Date.Text + @"'
      ,[PurchaseValue]      =  '" + PurchaseValue.Text + @"'
      ,[PurchaseDate]       =  '" + public_Date.Text + @"'
      ,[barcode]            =  '" + barcode.Text + @"'
      ,[brand]              =  '" + brand_DDL.Text + @"'
      ,[Module]             =  '" + Module_DDL.Text + @"'
      ,[IndustryID]         =  '" + IndustryID_DDL.Text + @"'
      ,[CurrencyID]         =  '" + CurrencyID.Text + @"'
      ,[Comments]           =  '" + Comments.Text + @"'
      ,[Editor]             =  ''
      ,[EditDate]           =  ''
 WHERE id = id_number

";

            cmd_update.Parameters.AddWithValue("@id_number", lbl_id.Text);
            cmd.CommandText = @"USE [HR]

                         insert into [dbo].[Assets_T_Elemints]
                       
                         ([ElmintID]
                         ,[TheState]     
                         ,[StateDate]    
                         ,[Dscrp]        
                         ,[SerialNo]     
                         ,[groupid]      
                         ,[StartDate]    
                         ,[PurchaseValue]
                         ,[PurchaseDate] 
                         ,[AccountUnitID]
                         ,[barcode]      
                         ,[brand]        
                         ,[Module]       
                         ,[IndustryID]   
                         ,[CurrencyID]   
                         ,[Comments]     
                         ,[Editor]       
                         ,[EditDate]  )
                           Values (
                          '" + max + @"'
                         ,'" + TheState_DDL.Text + @"'
                         ,'" + public_Date.Text + @"'
                         ,'" + Dscrp.Text + @"'
                         ,'" + SerialNo.Text + @"'
                         ,'" + groupid_DDL.Text + @"'
                         ,'" + public_Date.Text + @"'
                         ,'" + PurchaseValue.Text + @"'
                         ,'" + public_Date.Text + @"'
                         ,'1'
                         ,'" + barcode.Text + @"'
                         ,'" + brand_DDL.Text + @"'
                         ,'" + Module_DDL.Text + @"'
                         ,'" + IndustryID_DDL.Text + @"'
                         ,'" + CurrencyID.Text + @"'
                         ,'" + Comments.Text + @"'
                         ,''
                         ,''
                         )                        
                     ";
            int num = int.Parse( Numbers.Text);

            if (AddUpdate.Text == "update")
            {
                MDirMaster.Execute(cmd_update, lblMessage, HttpContext.Current.Request.Path);
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    MDirMaster.Execute2(cmd, lblMessage, HttpContext.Current.Request.Path);
                }


                
            }
        }
    }
}
