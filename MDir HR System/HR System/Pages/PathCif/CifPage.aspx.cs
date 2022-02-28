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

namespace HR_Salaries.Pages.PathCif
{
    public partial class CifPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MDirMaster.FillCombo("BRANCH_CODE", "BRANCH_Name", "Path_Branchs", BRANCH_CODE, "1=1", lblMessage);
                MDirMaster.FillCombo("Region_code", "Region_Name", "Path_Region", Region_code, "1=1", lblMessage);
                MDirMaster.FillCombo("ECO_SECTOR_CODE", "ECO_SECTOR_Name", "Path_ECO_SECTOR", ECO_SECTOR, "1=1", lblMessage);
                MDirMaster.FillCombo("SUB_ECO_SECTOR_ID", "SUB_ECO_SECTOR_NAME", "Path_SUB_ECO_SECTOR", SUB_ECO_SECTOR, "1=1", lblMessage);
                MDirMaster.FillCombo("COUNTRY_CODE", "COUNTRY_NAME", "Path_COUNTRY", COUNTRY, "1=1", lblMessage);
                MDirMaster.FillCombo("NATION_CODE", "NATION_NAME", "Path_NATION", NATION_CODE, "1=1", lblMessage);
                MDirMaster.FillCombo("RESIDENT_CODE", "RESIDENT_NAME", "Path_RESIDENT", RESIDENT, "1=1", lblMessage);
                MDirMaster.FillCombo("TYPE_CODE", "TYPE_NAME", "Path_TYPE", TYPE, "1=1", lblMessage);
                MDirMaster.FillCombo("CIF_TYPE_CODE", "CIF_TYPE_NAME", "Path_CIF_TYPE", CIF_TYPE, "1=1", lblMessage);
                MDirMaster.FillCombo("Division_CODE", "Division_NAME", "Path_Division", Division, "1=1", lblMessage);
                MDirMaster.FillCombo("Dept_CODE", "Dept_NAME", "Path_Dept", Dept, "1=1", lblMessage);
                MDirMaster.FillCombo("language_CODE", "language_NAME", "Path_language", language, "1=1", lblMessage);
                MDirMaster.FillCombo("sexe_CODE", "sexe_NAME", "Path_sexe", sexe, "1=1", lblMessage);
                MDirMaster.FillCombo("MARITAL_STATUS_CODE", "MARITAL_STATUS_NAME", "Path_MARITAL_STATUS", MARITAL_STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("civil_code_CODE", "civil_code_NAME", "Path_civil_code", civil_code, "1=1", lblMessage);
                MDirMaster.FillCombo("id_type_CODE", "id_type_NAME", "Path_id_type", id_type, "1=1", lblMessage);
                MDirMaster.FillCombo("PRIORITY_CODE_CODE", "PRIORITY_CODE_NAME", "Path_PRIORITY_CODE", PRIORITY_CODE, "1=1", lblMessage);
                MDirMaster.FillCombo("Relation_code_CODE", "Relation_code_NAME", "Path_Relation_code", Relation_code, "1=1", lblMessage);
                MDirMaster.FillCombo("Legal_Status_CODE", "Legal_Status_NAME", "Path_Legal_Status", Legal_Status, "1=1", lblMessage);
                MDirMaster.FillCombo("CIF_PROFILE_CODE", "CIF_PROFILE_NAME", "Path_CIF_PROFILE", CIF_PROFILE, "1=1", lblMessage);
                MDirMaster.FillCombo("OCCUP_POSITION_CODE", "OCCUP_POSITION_NAME", "Path_OCCUP_POSITION", OCCUP_POSITION, "1=1", lblMessage);
                MDirMaster.FillCombo("RELIGION_CODE", "RELIGION_NAME", "Path_RELIGION", RELIGION, "1=1", lblMessage);
                MDirMaster.FillCombo("STATUS_CODE", "STATUS_NAME", "Path_STATUS", STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("MAIL_STMT_CODE", "MAIL_STMT_NAME", "Path_MAIL_STMT", MAIL_STMT, "1=1", lblMessage);



    }
        }
        protected void ButAdd_OnClick(object sender, EventArgs e)
        {       
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {



            // Filter for required dropdownlist

            int ECO_SECTOR_v = ECO_SECTOR.SelectedIndex;
            int SUB_ECO_SECTOR_v = SUB_ECO_SECTOR.SelectedIndex;
            int COUNTRY_v = COUNTRY.SelectedIndex;
            int NATION_CODE_v = NATION_CODE.SelectedIndex;
            int RESIDENT_v = RESIDENT.SelectedIndex;
            int TYPE_v = TYPE.SelectedIndex;
            int CIF_TYPE_v = CIF_TYPE.SelectedIndex;
            int Division_v = Division.SelectedIndex;
            int Dept_v = Dept.SelectedIndex;
            int language_v = language.SelectedIndex;
            int MARITAL_STATUS_v = MARITAL_STATUS.SelectedIndex;
            int id_type_v = id_type.SelectedIndex;
            int Legal_Status_v = Legal_Status.SelectedIndex;
            int STATUS_v = STATUS.SelectedIndex;






            DateTime DD = DateTime.Now;

                //20/02/2019


            if (ECO_SECTOR_v == 0  || SUB_ECO_SECTOR_v == 0 || COUNTRY_v == 0 || NATION_CODE_v == 0 || RESIDENT_v == 0 || TYPE_v == 0 || CIF_TYPE_v == 0 
                || Division_v == 0 || Dept_v == 0 || language_v == 0 || MARITAL_STATUS_v == 0 || id_type_v == 0 || Legal_Status_v == 0 || STATUS_v == 0)

            {
                MDirMaster.Messages(lblMessage, "يجب ملىء الحقول الاجبارية");
            }

            else
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"

        INSERT INTO [dbo].[Path_CIF]
           ([COMP_CODE]
           ,[BRANCH_CODE]
           ,[CIF_NO]
           ,[SHORT_NAME_ENG]
           ,[LONG_NAME_ENG]
           ,[SHORT_NAME_ARAB]
           ,[LONG_NAME_ARAB]
           ,[Region_code]
           ,[ECO_SECTOR]
           ,[SUB_ECO_SECTOR]
           ,[COUNTRY]
           ,[NATION_CODE]
           ,[RESIDENT]
           ,[TYPE]
           ,[CIF_TYPE]
           ,[id_no]
           ,[Division]
           ,[Dept]
           ,[language]
           ,[additional_reference]
           ,[first_name_eng]
           ,[sec_name_eng]
           ,[third_name_eng]
           ,[last_name_eng]
           ,[first_name_ar]
           ,[sec_name_ar]
           ,[third_name_ar]
           ,[last_name_ar]
           ,[sexe]
           ,[birth_date]
           ,[place_of_birth]
           ,[ADD_STRING1]
           ,[MARITAL_STATUS]
           ,[civil_code]
           ,[id_type]
           ,[PRIORITY_CODE]
           ,[mother_first_name]
           ,[mother_last_name]
           ,[Relation_code]
           ,[Legal_Status]
           ,[CIF_PROFILE]
           ,[OCCUP_POSITION]
           ,[EDUC_LEVEL]
           ,[RELIGION]
           ,[MAIL_STMT]
           ,[PERIOD]
           ,[MODE_COMM]
           ,[DESCRIPTION]
           ,[DATE_CREATED]
           ,[CREATED_BY]
           ,[MODIFIED_BY]
           ,[DATE_MODIFIED]
           ,[APPROVED_BY]
           ,[DATE_APPROVED]
           ,[DELETED_BY]
           ,[DATE_DELETED]
           ,[STATUS]
           ,[ADDRESS1_ENG]
           ,[ADDRESS2_ENG]
           ,[ADDRESS3_ENG]
           ,[ADDRESS4_ENG]
           ,[ADDRESS1_ARAB]
           ,[ADDRESS2_ARAB]
           ,[ADDRESS3_ARAB]
           ,[ADDRESS4_ARAB]
           ,[STREET_DETAILS_ENG]
           ,[TEL]
           ,[HOME_TEL]
           ,[WORK_TEL]
           ,[OTHER_TEL]
           ,[MOBILE]
           ,[FAX]
           ,[EMAIL]
           ,[PO_BOX]
           ,[PASSPORT_NO]
           ,[PASSPORT_ISSUE_PLACE]
           ,[PASSPORT_ISSUE_DATE]
           ,[PASSPORT_EXPIRY_DATE]
           ,[Old_Account]
           )
        VALUES
           (
            '" + COMP_CODE.Text + @"',
            '" + BRANCH_CODE.Text + @"',
            '" + CIF_NO.Text + @"',
            '" + SHORT_NAME_ENG.Text + @"',
            '" + LONG_NAME_ENG.Text + @"',
            '" + SHORT_NAME_ARAB.Text + @"',
            '" + LONG_NAME_ARAB.Text + @"',
            '" + Region_code.Text + @"',
            '" + ECO_SECTOR.Text + @"',
            '" + SUB_ECO_SECTOR.Text + @"',
            '" + COUNTRY.Text + @"',
            '" + NATION_CODE.Text + @"',
            '" + RESIDENT.Text + @"',
            '" + TYPE.Text + @"',
            '" + CIF_TYPE.Text + @"',
            '" + id_no.Text + @"',
            '" + Division.Text + @"',
            '" + Dept.Text + @"',
            '" + language.Text + @"',
            '" + additional_reference.Text + @"',
            '" + first_name_eng.Text + @"',
            '" + sec_name_eng.Text + @"',
            '" + third_name_eng.Text + @"',
            '" + last_name_eng.Text + @"',
            '" + first_name_ar.Text + @"',
            '" + sec_name_ar.Text + @"',
            '" + third_name_ar.Text + @"',
            '" + last_name_ar.Text + @"',
            '" + sexe.Text + @"',
            '" + birth_date.Text + @"',
            '" + place_of_birth.Text + @"',
            '" + ADD_STRING1.Text + @"',
            '" + MARITAL_STATUS.Text + @"',
            '" + civil_code.Text + @"',
            '" + id_type.Text + @"',
            '" + PRIORITY_CODE.Text + @"',
            '" + mother_first_name.Text + @"',
            '" + mother_last_name.Text + @"',
            '" + Relation_code.Text + @"',
            '" + Legal_Status.Text + @"',
            '" + CIF_PROFILE.Text + @"',
            '" + OCCUP_POSITION.Text + @"',
            '" + EDUC_LEVEL.Text + @"',
            '" + RELIGION.Text + @"',
            '" + MAIL_STMT.Text + @"',
            '" + PERIOD.Text + @"',
            '" + MODE_COMM.Text + @"',
            '" + DESCRIPTION.Text + @"',
            '" + DATE_CREATED.Text + @"',
            '" + CREATED_BY.Text + @"',
            '" + MODIFIED_BY.Text + @"',
            '" + DATE_MODIFIED.Text + @"',
            '" + APPROVED_BY.Text + @"',
            '" + DATE_APPROVED.Text + @"',
            '" + DELETED_BY.Text + @"',
            '" + DATE_DELETED.Text + @"',
            '" + STATUS.Text + @"',
            '" + ADDRESS1_ENG.Text + @"',
            '" + ADDRESS2_ENG.Text + @"',
            '" + ADDRESS3_ENG.Text + @"',
            '" + ADDRESS4_ENG.Text + @"',
            '" + ADDRESS1_ARAB.Text + @"',
            '" + ADDRESS2_ARAB.Text + @"',
            '" + ADDRESS3_ARAB.Text + @"',
            '" + ADDRESS4_ARAB.Text + @"',
            '" + STREET_DETAILS_ENG.Text + @"',
            '" + TEL.Text + @"',
            '" + HOME_TEL.Text + @"',
            '" + WORK_TEL.Text + @"',
            '" + OTHER_TEL.Text + @"',
            '" + MOBILE.Text + @"',
            '" + FAX.Text + @"',
            '" + EMAIL.Text + @"',
            '" + PO_BOX.Text + @"',
            '" + PASSPORT_NO.Text + @"',
            '" + PASSPORT_ISSUE_PLACE.Text + @"',
            '" + PASSPORT_ISSUE_DATE.Text + @"',
            '" + PASSPORT_EXPIRY_DATE.Text + @"',
            '" + Old_Account.Text + @"'
            )
         ";
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);

                UploadThisFile(FilePic, "Pic" ,CIF_NO.Text);
                UploadThisFile(FileSic, "Sig", CIF_NO.Text);
                

            }

            
        }



        protected void UploadThisFile(FileUpload upload,String type, String name)
        {
            if (upload.HasFile)
            {
                string theFileName = Path.Combine(Server.MapPath("~/Uploads"), type + name + ".jpg");
                if (upload.HasFile)
                {
                    upload.SaveAs(theFileName);
                }

            }
        }





        protected void _UpdateChange(object sender, EventArgs e)
        {

        }

        protected void _AddChange(object sender, EventArgs e)
        {

        }
    }
}