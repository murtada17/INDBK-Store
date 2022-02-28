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

namespace HR_Salaries.Pages.CBS
{
    public partial class ControllPanel : System.Web.UI.Page
    {
        int add_udate = 0; // Add = 1 & update = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                MDirMaster.FillCombo("value", "describtion", "CBS_Month", month_DDL, "1=1 ORDER BY describtion DESC", lblMessage);
                MDirMaster.FillCombo("value", "describtion", "CBS_Years", years_DDL, "1=1 ORDER BY value DESC", lblMessage);



            }
        }

        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            RowsData.Visible = true;
            Panel3.Visible = true;
            AddUpdate.Text = "1";

        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            //RowsData.Visible = true;
            PalUpdate.Visible = true;
            AddUpdate.Text = "2";
            int ATaT = 2;
        }

        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            // get month & years :
            int month_img = int.Parse( month_DDL.SelectedValue);
            int years_img = int.Parse(years_DDL.SelectedValue);




            string id = GVUpdate.SelectedRow.Cells[1].Text;

            SqlCommand cmd_Search = new SqlCommand();
                        cmd_Search.CommandText = @"SELECT [Coll_ContractCode]
                  ,[Coll_CollateralCode]
                  ,[Status_]
                  ,[Date_DB]
                  ,[user_update]
                FROM [HR].[dbo].[CBS_Contract_Collateral]
            where [RowID] = '" + id + "'";
            DataTable dt = MDirMaster.GetData(cmd_Search, lblMessage);

            Coll_ContractCode.Text = dt.Rows[0]["Coll_ContractCode"].ToString();
            Coll_CollateralCode.Text = dt.Rows[0]["Coll_CollateralCode"].ToString();
            RowsData.Visible = true;
            Panel3.Visible = true;
        }

        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {

            // get month & years :
            int month_img = int.Parse(month_DDL.SelectedValue);
            int years_img = int.Parse(years_DDL.SelectedValue);


            SqlCommand cmd_Search = new SqlCommand();
            SqlCommand cmd_Search2 = new SqlCommand();
            cmd_Search.CommandText = @"SELECT [RowID]
      ,[Coll_ContractCode]
      ,[Coll_CollateralCode]
      ,[Status_]
      ,[Date_DB]
      ,[user_update]
    FROM [HR].[dbo].[CBS_Contract_Collateral]
    tesxReplace";

            //where Coll_ContractCode Like '%" + txtUpdate.Text + "%'  and [date_month] = '" + month_img + "' and  [date_year] = '" + years_img + "'

            if (txtUpdate.Text == "")
            {
                cmd_Search2.CommandText = cmd_Search.CommandText.Replace("tesxReplace", "where [date_month] = '" + month_img + "' and  [date_year] = '" + years_img + "'");
            }
            else
            {
                cmd_Search2.CommandText = cmd_Search.CommandText.Replace("tesxReplace", "where Coll_ContractCode Like '%" + txtUpdate.Text + "%'  and [date_month] = '" + month_img + "' and  [date_year] = '" + years_img + "'");

            }



            MDirMaster.FillGrid(cmd_Search2, GVUpdate, lblMessage);

            PalUpdate.Visible = true;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            // get month & years :
            int month_img = int.Parse(month_DDL.SelectedValue);
            int years_img = int.Parse(years_DDL.SelectedValue);


            string iid = "";
            try
            {
            string id = GVUpdate.SelectedRow.Cells[1].Text;
                iid = id;
            }
            catch
            {

            }

            DateTime DD = DateTime.Now;
            String userID = Session["UserID"].ToString();

            SqlCommand cmd_Add = new SqlCommand();
            SqlCommand cmd_Update = new SqlCommand();


            // Add query
            cmd_Add.CommandText = @"USE [HR]


        INSERT INTO [dbo].[CBS_Contract_Collateral]
           ([Coll_ContractCode]
           ,[Coll_CollateralCode]
           ,[Status_]
           ,[Date_DB]
           ,[user_update]
           ,[date_month]
           ,[date_year]
                        )
        VALUES
           (
                '" + Coll_ContractCode.Text + @"',
                '" + Coll_CollateralCode.Text + @"',
                '" + "1" + @"',
                '" + DD + @"',
                '" + userID + @"',
                '" + month_img + @"',
                '" + years_img + @"'
            )";

            // Update query

            cmd_Update.CommandText = @"
USE [HR]

UPDATE [dbo].[CBS_Contract_Collateral]
   SET [Coll_ContractCode] = '" + Coll_ContractCode.Text + @"'
      ,[Coll_CollateralCode] = '" + Coll_CollateralCode.Text + @"'
      ,[Date_DB] = '" + DD + @"'
      ,[user_update] = '" + userID + @"'
      ,[date_month] = '" + month_img + @"'
      ,[date_year] = '"+years_img +@"'

 WHERE [RowID] = '" + iid + "'";



            bool ifAcess = MDirMaster.check_ifAces(int.Parse(Coll_ContractCode.Text), int.Parse(Coll_CollateralCode.Text), month_img, years_img,lblMessage);




            if (AddUpdate.Text == "1")
            {
                if (ifAcess == true)
                {
                    lblMessage.Text = "الضمانة لهذ القرض مدخلة مسبقا !!!";
                }
                else
                {
                    MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);
                }
            
            }

            else if (AddUpdate.Text == "2")
            {
                MDirMaster.Execute(cmd_Update, lblMessage, HttpContext.Current.Request.Path);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void getValue_Click(object sender, EventArgs e)
        {
            add_update_panel.Visible = true;

        }
    }
}