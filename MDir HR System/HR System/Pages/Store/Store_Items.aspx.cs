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

namespace HR_Salaries.Pages.Store
{
    public partial class Store_Items : System.Web.UI.Page
    {
        int add_udate = 0; // Add = 1 & update = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
               // MDirMaster.FillCombo("value", "describtion", "CBS_Month", month_DDL, "1=1 ORDER BY describtion DESC", lblMessage);
            }
        }

        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            AddUpdate.Text = "1";
            Panel_Add_Update.Visible = true;

        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            PanelSearch.Visible = true;
            AddUpdate.Text = "2";
        }

        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = GVUpdate.SelectedRow.Cells[1].Text;

            SqlCommand cmd_Search3 = new SqlCommand();
            SqlCommand cmd_Search4 = new SqlCommand();

            cmd_Search3.CommandText = @"
SELECT  [id]
      ,[item_name]
      ,[status]
  FROM [HR].[dbo].[Store_Items]
                                  WHERE $WhereString
                                
                                ";


            cmd_Search4.CommandText = cmd_Search3.CommandText.Replace("$WhereString", " [id] Like '%" + id + "%' ");

            DataTable dt = MDirMaster.GetData(cmd_Search4, lblMessage);

            item_name.Text = dt.Rows[0]["item_name"].ToString();
            

            Panel_Add_Update.Visible = true;
            Panel3.Visible = true;




        }

        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {

            // get month & years :
           

            SqlCommand cmd_Search = new SqlCommand();
            SqlCommand cmd_Search2 = new SqlCommand();
            cmd_Search2.CommandText = @"SELECT  [id]
      ,[item_name]
      ,[status]
  FROM [HR].[dbo].[Store_Items]
                                  WHERE $WhereString
                                
                                ";

            cmd_Search.CommandText = cmd_Search2.CommandText.Replace("$WhereString", "[item_name] Like '%" + txtUpdate.Text + "%' ");

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            //Panel_Add_Update.Visible = true;





           
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            string iid = "";
            if (AddUpdate.Text == "2")
            {
                 iid = GVUpdate.SelectedRow.Cells[1].Text;
            }
            


            DateTime dateee = DateTime.Now;
            string DD = dateee.ToString("yyyy-MM-dd");




            String userID = Session["UserID"].ToString();

            SqlCommand cmd_Add = new SqlCommand();
            SqlCommand cmd_Update = new SqlCommand();
            SqlCommand cmd_check = new SqlCommand();
            

       

            // Add query
            cmd_Add.CommandText = @"
            INSERT INTO [HR].[dbo].[Store_Items]
           ([item_name]
          
           )
             VALUES
           ('" + item_name.Text + @"'
          
           )

                                    ";



            cmd_Update.CommandText = @"

            UPDATE [HR].[dbo].[Store_Items]
               SET  
            [item_name] = '" + item_name.Text + @"'
            
            
            WHERE [id] = '" + iid + "'";



            cmd_check.CommandText = @"

                                    select * from [HR].[dbo].[Store_Items] where [item_name] = '" + item_name.Text + @"'


                                    ";

            bool check_if_exist = check_Enterd(cmd_check);


            if (check_if_exist == true)
            {
                lbl.Text = "المادة مدخلة مسبقا !!!";
                lbl.BackColor = System.Drawing.Color.Red;
            }




            else {


                if (AddUpdate.Text == "1")
                {


                    MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);


                }

                if (AddUpdate.Text == "2")
                {
                    MDirMaster.Execute(cmd_Update, lblMessage, HttpContext.Current.Request.Path);
                }

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void getValue_Click(object sender, EventArgs e)
        {
            add_update_panel.Visible = true;

        }



        public static bool check_Enterd(SqlCommand cmd)
        {
            bool status_ = false;
            DataTable dt = MDirMaster.GetData2(cmd);
            if (dt.Rows.Count >0)
            {
               status_ = true;
            }
           else
            {
                status_ = false;
            }
            return status_;
        }



    }
}