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
    public partial class PPC_Process_Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
               // MDirMaster.FillCombo("Process_Commission_Type_CODE", "Process_Commission_Type_Name", "PPC_Process_Commission_Type", Process_Commission_Type, "1=1", lblMessage);

                SqlCommand cmd_Search_ = new SqlCommand();
                cmd_Search_.CommandText = @"
                                            SELECT [id]
                                                  ,[Process_Commission_Code]
                                                  ,[Process_Commission_Type]
                                                  ,[Process_Commission_Value_percentage]
                                                  ,[Process_Commission_Value_fixed]
                                                  ,[Process_Min_Commission]
                                                  ,[Process_Commission_Status]
                                                  ,[other]
                                              FROM [HR].[dbo].[PPC_Process_Rate]
                                            ";

                DataTable dt = MDirMaster.GetData(cmd_Search_, lblMessage);

                Process_Commission_Value_percentage.Text = dt.Rows[0]["Process_Commission_Value_percentage"].ToString();
                Process_Commission_Value_fixed.Text = dt.Rows[0]["Process_Commission_Value_fixed"].ToString();
                Process_Min_Commission.Text = dt.Rows[0]["Process_Min_Commission"].ToString();

                int type = int.Parse(dt.Rows[0]["Process_Commission_Type"].ToString()) ;

                if(type == 1) { CB_1.Checked = true; Process_Commission_Value_percentage.Enabled = true;
                    Process_Commission_Value_fixed.Enabled = false;
                }
                if(type == 2) { CB_2.Checked = true; Process_Commission_Value_fixed.Enabled = true;
                    Process_Commission_Value_percentage.Enabled = false;
                }

            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            int Process_Commission_Type_ = 0;

            if (CB_1.Checked == true) {
                Process_Commission_Type_ = 1;
                
            }
            if (CB_2.Checked == true) {
                Process_Commission_Type_ = 2;
                
            }



            SqlCommand cmd_Update = new SqlCommand();
            cmd_Update.CommandText = @"
            UPDATE [dbo].[PPC_Process_Rate]
            SET
            [Process_Commission_Type] = '" + Process_Commission_Type_  + @"'
            ,[Process_Commission_Value_percentage] = '" + Process_Commission_Value_percentage.Text + @"'
            ,[Process_Commission_Value_fixed] = '" + Process_Commission_Value_fixed.Text + @"'
            ,[Process_Min_Commission] = '" + Process_Min_Commission.Text + @"'
            ";

            MDirMaster.Execute(cmd_Update, lblMessage, HttpContext.Current.Request.Path);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void CB_1_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_1.Checked == true) {
                CB_2.Checked = false;
                Process_Commission_Value_percentage.Enabled = true;
                Process_Commission_Value_fixed.Enabled = false;
            }
        }

        protected void CB_2_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_2.Checked == true) {
                CB_1.Checked = false;
                Process_Commission_Value_fixed.Enabled = true;
                Process_Commission_Value_percentage.Enabled = false;
            }
        }
    }

    }
