using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sales_Managment.DAL
{
    class DataAccessLayer
    {
        //the difference between Procedure &Function is that procedure do not return anything(void) while function return something
        // Datatable is one table while Dataset is set of tables(mini database)
        SqlConnection SqlConnection;
        //constructor to initialize the connection
        public DataAccessLayer()
        {
            string MOD = Properties.Settings.Default.Mode;
            if (MOD == "SQL")
            {
                SqlConnection = new SqlConnection(@"Server= " + Properties.Settings.Default.Server + ";Database=" + Properties.Settings.Default.Database +
                    ";Integrated Security=false ; User ID= " + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.password + "");
            }
            else
            {
                SqlConnection = new SqlConnection(@"Server= " + Properties.Settings.Default.Server + ";Database=" + Properties.Settings.Default.Database +
                   ";Integrated Security=True ");
            }
        }
        //Method to open the connection
        public void open()
        {
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
        }
        //Method to close the connection
        public void close()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
        //method (function ) to read data from database
        public DataTable selectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //method (procedure) to Insert,Delete and Update database
        public void Excutecommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}

