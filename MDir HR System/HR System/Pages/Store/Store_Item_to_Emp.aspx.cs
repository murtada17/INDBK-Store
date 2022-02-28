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
    public partial class Store_Item_to_Emp : System.Web.UI.Page
    {
          int add_udate = 0; // Add = 1 & update = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                // MDirMaster.FillCombo("value", "describtion", "CBS_Month", month_DDL, "1=1 ORDER BY describtion DESC", lblMessage);
               // MDirMaster.FillCombo("id", "item_name", "Store_Items", item_name, "1=1", lblMessage);

                MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
               // MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);
            }
        }

        protected void ddlIDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string con = "";
            //con = "[DepartmentID] = " + ddlIDepartment.SelectedValue;
            //if (Convert.ToInt32(ddlIDepartment.SelectedValue) > 0)
            //{
            //    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlISection, con, lblMessage);
            //}
            //else
            //{
            //    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlISection, true, lblMessage);
            //}
            //if (ddlISection.Items.Count > 1)
            //{
            //    //ddlISection.SelectedValue = "3";
            //}
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
                                       SELECT [id]
                                      ,[item_name]
                                      ,[item_number]
                                      ,[quantity]
                                      ,[unit_price]
                                      ,[total_rice]
                                      ,[purchas_date]
                                     
                                  FROM [HR].[dbo].[store]
                                  WHERE $WhereString
                                
                                ";


            cmd_Search4.CommandText = cmd_Search3.CommandText.Replace("$WhereString", " [id] Like '%" + id + "%' ");

            DataTable dt = MDirMaster.GetData(cmd_Search4, lblMessage);

            //item_name.Text = dt.Rows[0]["item_name"].ToString();
            

            Panel_Add_Update.Visible = true;
            Panel3.Visible = true;




        }

        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {

            // get month & years :
           

            SqlCommand cmd_Search = new SqlCommand();
            SqlCommand cmd_Search2 = new SqlCommand();
            cmd_Search2.CommandText = @"SELECT [id]
                                      ,[item_name]
                                      ,[item_number]
                                      ,[quantity]
                                      ,[unit_price]
                                      ,[total_rice]
                                      ,[purchas_date]
                                      ,[entry_date]
                                  FROM [HR].[dbo].[store]
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

            //int qunt = Int32.Parse(quantity.Text);
            //int unt_pri = Int32.Parse(unit_price.Text);
            //int totall = qunt * unt_pri;

            // Add query
           // cmd_Add.CommandText = @"
           // INSERT INTO [HR].[dbo].[store]
           //([item_name]
           //,[item_number]
           //,[quantity]
           //,[unit_price]
           //,[total_rice]
           //,[purchas_date]
           //)
           //  VALUES
           //('" + item_name.Text + @"',
           //'" + item_number.Text + @"',
           //'" + quantity.Text + @"',
           //'" + unit_price.Text + @"',
           //'" + totall + @"',
           //'" + purchas_date.Text + @"'
           //)

           //                         ";



            //cmd_Update.CommandText = @"

            //UPDATE [HR].[dbo].[store]
            //   SET  
            //[item_name] = '" + item_name.Text + @"',  
            //[quantity] = '" + quantity.Text + @"',
            //[unit_price] = '" + unit_price.Text + @"',
            //[totall] = '" + totall + @"',
            //[purchas_date] = '" + purchas_date.Text + @"'
            
            //WHERE [id] = '" + iid + "'";



            



   

            if (AddUpdate.Text == "1")
            {


                MDirMaster.Execute(cmd_Add, lblMessage, HttpContext.Current.Request.Path);


            }

            if (AddUpdate.Text == "2")
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

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idBrn_ = ddlSBranch.Text;

            if (idBrn_ != "17")
            { 
                MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
            }

            else
            {
                MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, "DepartmentID = 17", lblMessage);
            }
        }

        protected void ddlSDep_SelectedIndexChanged(object sender, EventArgs e)
        {
               string idDep_ = ddlSDep.Text;
               MDirMaster.FillCombo("EmpID", "FirstNameAR", "EmployeesTBL", ddlEmployee, "DepartmentID = " + idDep_, lblMessage);
        }
    }
}