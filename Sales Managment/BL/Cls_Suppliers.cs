using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sales_Managment.BL
{
    class Cls_Suppliers
    {
 

        public void ADD_Suppliers(string Sup_Name, string Sup_phone, string sup_Company_ID, string Sup_Adreess, string Sup_Notes, byte[] Sup_Photo, string Creterion,int Sup_ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Sup_Name", SqlDbType.NVarChar, 50);
            param[0].Value = Sup_Name;
            param[1] = new SqlParameter("@Sup_phone", SqlDbType.NVarChar, 30);
            param[1].Value = Sup_phone;
            param[2] = new SqlParameter("@sup_Company_ID", SqlDbType.NVarChar, 50);
            param[2].Value = sup_Company_ID;
            param[3] = new SqlParameter("@Sup_Adreess", SqlDbType.NVarChar, 250);
            param[3].Value = Sup_Adreess;
            param[4] = new SqlParameter("@Sup_Notes", SqlDbType.NVarChar, 350);
            param[4].Value = Sup_Notes;
            param[5] = new SqlParameter("@Sup_Photo", SqlDbType.Image);
            param[5].Value = Sup_Photo;
            param[6] = new SqlParameter("@Creterion", SqlDbType.VarChar, 50);
            param[6].Value = Creterion;
            param[7] = new SqlParameter("@Sup_ID", SqlDbType.Int);
            param[7].Value = Sup_ID;
            dal.Excutecommand("ADD_Suppliers", param);
            dal.close();
        }
        public void ADD_SupPayHistory(int ID_ORDER, int Sup_ID, decimal paidValue, string dateOfPayment)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ID_ORDER;
            param[1] = new SqlParameter("@Sup_ID ", SqlDbType.Int);
            param[1].Value = Sup_ID;
            param[2] = new SqlParameter("@paidValue", SqlDbType.Real);
            param[2].Value = paidValue;
            param[3] = new SqlParameter("@dateOfPayment", SqlDbType.NVarChar, 50);
            param[3].Value = dateOfPayment;
            dal.Excutecommand("ADD_SupPayHistory", param);
            dal.close();
        }
        public void update_SupMoney(decimal madfou3, string Reminder_Date, int ID_ORDER)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@madfou3", SqlDbType.Real);
            param[0].Value = madfou3;
            param[1] = new SqlParameter("@Reminder_Date", SqlDbType.NVarChar, 50);
            param[1].Value = Reminder_Date;
            param[2] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[2].Value = ID_ORDER;
            dal.Excutecommand("update_SupMoney", param);
            dal.close();
        }


        public void Edit_Suppliers(string Sup_Name, string Sup_phone, string sup_Company_ID, string Sup_Adreess, string Sup_Notes, byte[] Sup_Photo, string Creterion,int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Sup_Name", SqlDbType.NVarChar, 50);
            param[0].Value = Sup_Name;
            param[1] = new SqlParameter("@Sup_phone", SqlDbType.NVarChar, 30);
            param[1].Value = Sup_phone;
            param[2] = new SqlParameter("@sup_Company_ID", SqlDbType.NVarChar, 50);
            param[2].Value = sup_Company_ID;
            param[3] = new SqlParameter("@Sup_Adreess", SqlDbType.NVarChar, 250);
            param[3].Value = Sup_Adreess;
            param[3] = new SqlParameter("@Sup_Adreess", SqlDbType.NVarChar, 250);
            param[3].Value = Sup_Adreess;
            param[4] = new SqlParameter("@Sup_Notes", SqlDbType.NVarChar, 350);
            param[4].Value = Sup_Notes;
            param[5] = new SqlParameter("@Sup_Photo", SqlDbType.Image);
            param[5].Value = Sup_Photo;
            param[6] = new SqlParameter("@Creterion", SqlDbType.VarChar, 50);
            param[6].Value = Creterion;
            param[7] = new SqlParameter("@ID", SqlDbType.Int);
            param[7].Value = ID;
            dal.Excutecommand("Edit_Suppliers", param);
            dal.close();
        }
        public DataTable get_SupplyerID()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_SupplyerID", null);
            dal.close();
            return dt;
        }
        public DataTable getSup_Deservied_money()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("getSup_Deservied_money", null);
            dal.close();
            return dt;
        }
       
        public DataTable get_suppPayHistory()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_suppPayHistory", null);
            dal.close();
            return dt;
        }
        public DataTable getONESup_Deservied_money(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dt = dal.selectData("getONESup_Deservied_money", param);
            dal.close();
            return dt;
        }
    
        public DataTable get_ONEsuppPayHistory(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dt = dal.selectData("get_ONEsuppPayHistory", param);
            dal.close();
            return dt;
        }
        public void Delete_Suppliers(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dal.Excutecommand("Delete_Suppliers", param);
            dal.close();
        }
        
             public void delete_supPayRecoed(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            dal.Excutecommand("delete_supPayRecoed", param);
            dal.close();
        }
        public DataTable Get_AllSup_info()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("Get_AllSup_info", null);
            dal.close();
            return dt;
        }
        public DataTable Search_suppliers(string ceraterion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ceraterion", SqlDbType.VarChar, 50);
            param[0].Value = ceraterion;
            dt = dal.selectData("Search_suppliers", param);
            dal.close();
            return dt;
        }

    }
}
