using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;

namespace HR_Salaries.Pages.MSC
{
    public partial class Reports : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MDirMaster.FillCombo("id", "month_name", "D_month", month_DDL,  lblMessage);
                MDirMaster.FillCombo("id", "LedgerDscrp", "Assets_P_group", groupid, lblMessage);
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

            string DDYYMM2 = year + '-' + month + '-' + "01";
            DateTime DDYYMM = Convert.ToDateTime(DDYYMM2);

            //اندثار للشهر

            SqlCommand cmd_delete = new SqlCommand();
            cmd_delete.CommandText = @"  delete* FROM[HR].[dbo].[Assets_Disappearance_TBL]
            where[dis_Month] = @month and[dis_Tear] = @year ";

            cmd_delete.Parameters.AddWithValue("@month", month);  //group
            cmd_delete.Parameters.AddWithValue("@year", year);  //group


            ///////////////



            //////////////

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"
                               use Universal_System

SELECT
                              T_Elemints.Dscrp as 'أسم المادة'

                             , ggr.DebrecationRate as 'نسبة الاندثار'
							 , sum(T_Elemints.PurchaseValue) as 'القيمة الحالية'
							 , Count(T_Elemints.Dscrp) 'العدد'

							 , (select sum([DeprecationValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID = T_Deprecations.ElemntID and[Theyear] < @Theyear ) 'أندثار سنوات سابقة'

						  	 ,(select sum([DeprecationValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID = T_Deprecations.ElemntID and[Theyear] = @Theyear and[TheMonth] < @TheMonth ) 'أندثار أشهر سابقة'

							 ,[DeprecationValue_Debit] 'أندثار الشهر'

							 ,(sum(T_Elemints.PurchaseValue) * 2) - (select sum([DeprecationValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID ) 'القيمة الدفترية'
							 ,(select sum([SpareValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and[Theyear] = @Theyear and[TheMonth] < @TheMonth ) 'احتياطي اشهر سابقة'
							 ,[SpareValue_Debit] 'أحتياطي الشهر'
							 ,'0' 'مشتريات الشهر'
							 ,'0' 'مبيعات الشهر'
						
                             FROM[Universal_System].[dbo].[Assets_T_Deprecations]
        T_Deprecations
inner join[Universal_System].[dbo].[Assets_T_Elemints] T_Elemints on  T_Deprecations.ElemntID=T_Elemints.ElmintID
inner join[Universal_System].[dbo].Assets_P_group ggr on T_Elemints.groupid = ggr.id
where T_Elemints.groupid = @groupid and TheMonth = @TheMonth and Theyear = @Theyear


Group by [ElemntID], T_Elemints.Dscrp, ggr.DebrecationRate, [LedgerID]

, T_Deprecations.[SerialNo]
, [Theyear]
, [TheMonth]
, [DeprecationValue_Debit]
, [DeprecationValue_Credit]
, [SpareValue_Debit]
, [SpareValue_Credit]
, T_Deprecations.[AccountUnitID]
, T_Deprecations.[Editor]
, T_Deprecations.[EditDate]
";


           




cmd.Parameters.AddWithValue("@groupid", groupid.SelectedValue);
            cmd.Parameters.AddWithValue("@TheMonth", month_DDL.SelectedValue);
            cmd.Parameters.AddWithValue("@Theyear", year_txt.Text);
            //cmd.Parameters.AddWithValue("@year", year);  

            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            if (Save.Checked)
            {
                MDirMaster.ExportExcel(dt, "Reports");
                
            }
            else {
                MDirMaster.FillGrid(cmd, gvDepartment, lblMessage);
            }

        }
    }
}





//use Universal_System

//SELECT
//                              T_Elemints.Dscrp as 'أسم المادة'

//                             , ggr.DebrecationRate as 'نسبة الاندثار'
//							 , sum(T_Elemints.PurchaseValue) as 'القيمة الحالية'
//							 , Count(T_Elemints.Dscrp) 'العدد'

//							 , (select sum([DeprecationValue_Debit]) from [Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and[Theyear] < 2019 ) 'أندثار سنوات سابقة'

//						  	 ,(select sum([DeprecationValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and[Theyear] = 2019 and[TheMonth] < 5 ) 'أندثار أشهر سابقة'

//							 ,[DeprecationValue_Debit] 'أندثار الشهر'

//							 ,(sum(T_Elemints.PurchaseValue)) -   
//							 (select sum([DeprecationValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and[Theyear] < 2019 ) - 
//							 (select sum([DeprecationValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and[Theyear] = 2019 and[TheMonth] < 5 ) -
//							  [DeprecationValue_Debit]
							 
							 
//							  'القيمة الدفترية' 

//							 /*,(sum(T_Elemints.PurchaseValue)) - (select sum([DeprecationValue_Debit]) from [Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and [Theyear] <= 2019 )  'القيمة الدفترية' */


//							 ,(select sum([SpareValue_Debit]) from[Universal_System].[dbo].[Assets_T_Deprecations] as tt where tt.ElemntID= T_Deprecations.ElemntID and[Theyear] = 2020 and[TheMonth] < 3 ) 'احتياطي اشهر سابقة'
//							 ,[SpareValue_Debit] 'أحتياطي الشهر'
//							 ,'0' 'مشتريات الشهر'
//							 ,'0' 'مبيعات الشهر'
						
//                             FROM[Universal_System].[dbo].[Assets_T_Deprecations]
//T_Deprecations
//inner join[Universal_System].[dbo].[Assets_T_Elemints] T_Elemints on  T_Deprecations.ElemntID=T_Elemints.ElmintID
//inner join[Universal_System].[dbo].Assets_P_group ggr on T_Elemints.groupid = ggr.id
//where T_Elemints.groupid = 1 and TheMonth = 5 and Theyear = 2019


//Group by [ElemntID], T_Elemints.Dscrp, ggr.DebrecationRate, [LedgerID]


//, T_Deprecations.[SerialNo]


//, [Theyear]


//, [TheMonth]


//, [DeprecationValue_Debit]


//, [DeprecationValue_Credit]


//, [SpareValue_Debit]


//, [SpareValue_Credit]


//, T_Deprecations.[AccountUnitID]


//, T_Deprecations.[Editor]


//, T_Deprecations.[EditDate]