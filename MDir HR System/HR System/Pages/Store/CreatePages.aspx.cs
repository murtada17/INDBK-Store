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
    public partial class CreatePages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();
            cmd_Search.CommandText = @"SELECT COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH 
                                        FROM information_schema.columns 
                                        WHERE table_name = '"+ table_name.Text +"'";
            DataTable dt = MDirMaster.GetData(cmd_Search, lblMessage);
            WriteDataToFile26(dt, "C:\\Users\\dell\\Desktop\\path\\", "data");
            for (int i =0; i >= dt.Rows.count(); i++)
            {
                string table = dt.Rows[i]["COLUMN_NAME"].ToString();

                

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }



        public static void WriteDataToFile26(DataTable dt, string submittedFilePath, String BatchName)
        {


            StreamWriter sw = new StreamWriter(submittedFilePath + BatchName + ".txt"); //create the file



            string dat = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            string tim = dat_Time;

            // File Header
            string line1 = "FH";
            line1 += bankid.ToString().PadLeft(8, '0');   // bank id number
            line1 += "BATCH-MISC"; // File Label
            line1 += datProcessing;         // Processing Date datProcessing  line1 += dat;   
            line1 += SequenceNumber.ToString().PadLeft(4, '0');       // Sequence Number
            line1 += "0001";       // Layout Version 

            sw.WriteLine(line1);
            // File Header


            // Batch Header



            string line_bHeader = "BH";
            line_bHeader += DSlipNu.ToString().PadLeft(11, '0');  // Deposit Slip Number
            line_bHeader += datBatchDate;        // Batch Date  datBatchDate     line_bHeader += dat;     
            line_bHeader += TraType.ToString().PadLeft(3, '0');      // Transaction Type
            line_bHeader += TraCategory.ToString().PadLeft(3, '0');      // Transaction Category
            line_bHeader += "N";         // Reversal Indicator 
            line_bHeader += ccy;         // Batch Currency
            line_bHeader += exp;         // Batch Currency Exponent


            sw.WriteLine(line_bHeader);


            // Batch Header


            // 
            int se = 0;
            foreach (DataRow dr in dt.Rows)
            {
                se = se + 1;
                string line = "RD";
                //line += SlipNumber.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += se.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += TransactionDate;
                line += tim;               // Transaction Time
                line += dr["Card_number"].ToString().PadRight(19, ' '); // CardNumber
                line += "".ToString().PadRight(11, ' ');  // Account Number
                line += "".ToString().PadRight(19, ' ');  //Settlement Account
                line += "Payment".ToString().PadRight(25, ' ');  // Transaction Narrativ
                line += ((dr["Full Salary"].ToString().Replace(".", "")).PadLeft(18, '0'));  // Amount

                sw.WriteLine(line);
            }
            // Batch Trailer
            foreach (DataRow dr1 in fullsalary.Rows)
            {
                string line_Batch_Trailer = "BT";
                //line_Batch_Trailer += "1".ToString().PadLeft(10, '0'); //Number Slips
                line_Batch_Trailer += dt.Rows.Count.ToString().PadLeft(10, '0');
                line_Batch_Trailer += (dr1["FullSalary"].ToString().Replace(".", "").PadLeft(18, '0')); //Total Amount
                                                                                                        //line_Batch_Trailer += "2000000".ToString().PadLeft(18, '0'); //Total Amount
                sw.WriteLine(line_Batch_Trailer);
                // Batch Trailer
            }



            // File Trailer
            string line_File_Trailer = "FT"; // Identifler
            line_File_Trailer += "1".ToString().PadLeft(10, '0'); // Number Batches

            sw.WriteLine(line_File_Trailer);

            // File Trailer

            sw.Close();
        }



    }




}

