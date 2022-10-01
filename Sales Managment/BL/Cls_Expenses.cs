using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sales_Managment.BL
{
    class Cls_Expenses
    {
      


        public void add_expense(int Expenses_ID, string Expenses_desc )
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Expenses_ID", SqlDbType.Int);
            param[0].Value = Expenses_ID;
            param[1] = new SqlParameter("@Expenses_desc", SqlDbType.NVarChar, 50);
            param[1].Value = Expenses_desc;
           
            dal.Excutecommand("add_expense", param);
            dal.close();
        }
        public void Add_ExpnsStatement(int ExpStatement_ID, string ExpStatement_date, decimal ExpStatement_Value, string Notes, int Expenses_ID )
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ExpStatement_ID", SqlDbType.Int);
            param[0].Value = ExpStatement_ID;
            param[1] = new SqlParameter("@ExpStatement_date ", SqlDbType.NVarChar,50);
            param[1].Value = ExpStatement_date;
            param[2] = new SqlParameter("@ExpStatement_Value", SqlDbType.Real);
            param[2].Value = ExpStatement_Value;
            param[3] = new SqlParameter("@Notes", SqlDbType.NVarChar, 250);
            param[3].Value = Notes;
            param[4] = new SqlParameter("@Expenses_ID", SqlDbType.Int);
            param[4].Value = Expenses_ID;
            dal.Excutecommand("Add_ExpnsStatement", param);
            dal.close();
        }
        public void Edit_expense(string Expenses_desc,int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Expenses_desc", SqlDbType.NVarChar, 50);
            param[0].Value = Expenses_desc;
            param[1] = new SqlParameter("@ID", SqlDbType.Int);
            param[1].Value = ID;
            dal.Excutecommand("Edit_expense", param);
            dal.close();
        }
        public void Edit_ExpnsStatement( string ExpStatement_date, decimal ExpStatement_Value, string Notes, int Expenses_ID,int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[5];
         
            param[0] = new SqlParameter("@ExpStatement_date ", SqlDbType.NVarChar, 50);
            param[0].Value = ExpStatement_date;
            param[1] = new SqlParameter("@ExpStatement_Value", SqlDbType.Real);
            param[1].Value = ExpStatement_Value;
            param[2] = new SqlParameter("@Notes", SqlDbType.NVarChar, 250);
            param[2].Value = Notes;
            param[3] = new SqlParameter("@Expenses_ID", SqlDbType.Int);
            param[3].Value = Expenses_ID;
            param[4] = new SqlParameter("@ID", SqlDbType.Int);
            param[4].Value = ID;
            dal.Excutecommand("Edit_ExpnsStatement", param);
            dal.close();
        }
        public DataTable get_all_expenses()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_all_expenses", null);
            dal.close();
            return dt;
        }
        public DataTable get_all_expnsStatements()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_all_expnsStatements", null);
            dal.close();
            return dt;
        }
        public DataTable get_ExpensID()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_ExpensID", null);
            dal.close();
            return dt;
        }
        public DataTable get_all_expnsStatementsReport(string FROM_Date, string TO_Date)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FROM_Date ", SqlDbType.NVarChar, 50);
            param[0].Value = FROM_Date;
            param[1] = new SqlParameter("@TO_Date", SqlDbType.NVarChar,50);
            param[1].Value = TO_Date;
            dt = dal.selectData("get_all_expnsStatementsReport", param);
            dal.close();
            return dt;
        }
        public DataTable get_Expens_StatementID()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_Expens_StatementID", null);
            dal.close();
            return dt;
        }
        public DataTable Search_expens(string createrion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@createrion", SqlDbType.VarChar, 50);
            param[0].Value = createrion;
            dt = dal.selectData("Search_expens", param);
            dal.close();
            return dt;
        }
        public DataTable Search_expnsStatements(string createrion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@createrion", SqlDbType.VarChar, 50);
            param[0].Value = createrion;
            dt = dal.selectData("Search_expnsStatements", param);
            dal.close();
            return dt;
        }
        public void Delete_expnsStatements(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dal.Excutecommand("Delete_expnsStatements", param);
            dal.close();
        }
        public void deleteReport_expnsStatementsReport(string FROM_Date, string TO_Date)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FROM_Date ", SqlDbType.NVarChar, 50);
            param[0].Value = FROM_Date;
            param[1] = new SqlParameter("@TO_Date", SqlDbType.NVarChar, 50);
            param[1].Value = TO_Date;
            dal.Excutecommand("deleteReport_expnsStatementsReport", param);
            dal.close();
        }
        public void Delete_expens(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dal.Excutecommand("Delete_expens", param);
            dal.close();
        }
    }
}
