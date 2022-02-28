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
    public partial class Disappearance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MDirMaster.FillCombo("id", "month_name", "D_month", month_DDL, "1=1", lblMessage);
                //year_txt
            }
        }
        protected void ButAdd_OnClick(object sender, EventArgs e)
        {       
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string month = month_DDL.Text.ToString();

            string year = year_txt.Text;

            string DDYYMM2 = year + '-' + month.PadLeft(2,'0') + '-' + "01";
            DateTime DDYYMM = Convert.ToDateTime(DDYYMM2);


            DateTime dateTime = new DateTime();
            dateTime = Convert.ToDateTime(DateTime.ParseExact(DDYYMM2, "yyyy-MM-dd", CultureInfo.InvariantCulture));

            //اندثار للشهر

            SqlCommand cmd_del = new SqlCommand();
            cmd_del.CommandText = @"delete
                                    FROM [HR].[dbo].[Assets_T_Deprecations] 
                                    where [Theyear] = @Theyear and [TheMonth] = @TheMonth";

            cmd_del.Parameters.AddWithValue("@TheMonth", month_DDL.SelectedValue);
            cmd_del.Parameters.AddWithValue("@Theyear", year_txt.Text);
            DataTable dt_ = MDirMaster.GetData(cmd_del, lblMessage);



            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"use [HR]
            insert into [HR].[dbo].[Assets_T_Deprecations]
            
            SELECT 
            	  gro.ElementAccountChart
            	  ,ele.[SerialNo]
            	  ,@year
            	  ,@month
            	  ,sum((ele.[PurchaseValue] * ([DebrecationRate] * 0.01 )) / 12 )as 'DeprecationValue_Debit'
            	  ,'0' 'DeprecationValue_Credit'
            	  ,'0' 'SpareValue_Debit'
            	  ,'0' 'SpareValue_Credit'
            	  ,ele.[AccountUnitID]	  
            	  ,ele.[Editor]
                  ,ele.[EditDate]
            	  ,ele.[ElmintID]
                  FROM [HR].[dbo].[Assets_T_Elemints] as ele left join [HR].[dbo].Assets_P_group as gro on ele.groupid = gro.id 
              
                  where StateDate < @DDYYMM
			      GROUP BY ele.[ElmintID],gro.ElementAccountChart,ele.[SerialNo]
            	  ,ele.StartYear
            	  ,ele.StartMonth,ele.[AccountUnitID]	  
            	  ,ele.[Editor]
                  ,ele.[EditDate]
            	  ,ele.[ElmintID]
            ";

            cmd.Parameters.AddWithValue("@DDYYMM", DDYYMM2);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@month", month);
            //cmd.Parameters.AddWithValue("@year", year);  

            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
        }
    }
}