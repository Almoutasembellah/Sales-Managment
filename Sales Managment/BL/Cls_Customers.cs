using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sales_Managment.BL
{
    class Cls_Customers
    {
        public void ADD_Customers(string Cus_Name, string Cus_phone, string Cus_NatiID, string Cus_Adreess, string Cus_Notes, byte[] Cus_Photo, string Creterion, int Customer_ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Cus_Name", SqlDbType.NVarChar, 50);
            param[0].Value = Cus_Name;
            param[1] = new SqlParameter("@Cus_phone", SqlDbType.NVarChar, 30);
            param[1].Value = Cus_phone;
            param[2] = new SqlParameter("@Cus_NatiID", SqlDbType.NVarChar, 50);
            param[2].Value = Cus_NatiID;
            param[3] = new SqlParameter("@Cus_Adreess", SqlDbType.NVarChar, 250);
            param[3].Value = Cus_Adreess;
            param[4] = new SqlParameter("@Cus_Notes", SqlDbType.NVarChar, 350);
            param[4].Value = Cus_Notes;
            param[5] = new SqlParameter("@Cus_Photo", SqlDbType.Image);
            param[5].Value = Cus_Photo;
            param[6] = new SqlParameter("@Creterion", SqlDbType.VarChar, 50);
            param[6].Value = Creterion;
            param[7] = new SqlParameter("@Customer_ID", SqlDbType.Int);
            param[7].Value = Customer_ID;
            dal.Excutecommand("ADD_Customers", param);
            dal.close();
        }
        public void Edit_CUSTOMERS(string Cus_Name, string Cus_phone, string Cus_NatiID ,string Cus_Adreess, string Cus_Notes, byte[] Cus_Photo, string Creterion, int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Cus_Name", SqlDbType.NVarChar, 50);
            param[0].Value = Cus_Name;
            param[1] = new SqlParameter("@Cus_phone", SqlDbType.NVarChar, 30);
            param[1].Value = Cus_phone;
            param[2] = new SqlParameter("@Cus_NatiID", SqlDbType.NVarChar, 50);
            param[2].Value = Cus_NatiID;
            param[3] = new SqlParameter("@Cus_Adreess", SqlDbType.NVarChar, 250);
            param[3].Value = Cus_Adreess;
            param[3] = new SqlParameter("@Cus_Adreess", SqlDbType.NVarChar, 250);
            param[3].Value = Cus_Adreess;
            param[4] = new SqlParameter("@Cus_Notes", SqlDbType.NVarChar, 350);
            param[4].Value = Cus_Notes;
            param[5] = new SqlParameter("@Cus_Photo", SqlDbType.Image);
            param[5].Value = Cus_Photo;
            param[6] = new SqlParameter("@Creterion", SqlDbType.VarChar, 50);
            param[6].Value = Creterion;
            param[7] = new SqlParameter("@ID", SqlDbType.Int);
            param[7].Value = ID;
            dal.Excutecommand("Edit_CUST", param);
            dal.close();
        }
        public DataTable get_CustomerID()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_CustomerID", null);
            dal.close();
            return dt;
        }

        public void Delete_Customers(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dal.Excutecommand("Delete_Customers", param);
            dal.close();
        }
        public DataTable Get_cust_info()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("Get_cust_info", null);
            dal.close();
            return dt;
        }
        public DataTable Search_Customers(string ceraterion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ceraterion", SqlDbType.VarChar, 50);
            param[0].Value = ceraterion;
            dt = dal.selectData("Search_Customers", param);
            dal.close();
            return dt;
        }

    }
}

