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
