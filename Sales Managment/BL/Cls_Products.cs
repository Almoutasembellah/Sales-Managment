using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sales_Managment.BL
{
    class Cls_Products
    {
        public DataTable get_Categories()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();


            DataTable dt = new DataTable();
            dt = dal.selectData("get_Categories", null);
            dal.close();
            return dt;
        }
        public DataTable get_all_Products()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();


            DataTable dt = new DataTable();
            dt = dal.selectData("get_all_Products", null);
            dal.close();
            return dt;
        }
     
        public DataTable get_ProductID()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_ProductID", null);
            dal.close();
            return dt;
        }
        public void ADD_Product(string ID_PRODUCT,string Product_Name, int Product_QTY_InStock, decimal Product_buy_Price,
         decimal Product_Sale_Price, string BarCode,decimal MinQty,decimal MaxDiscount, int ID_CAT, string Creterion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            param[0].Value = ID_PRODUCT;
            param[1] = new SqlParameter("@Product_Name", SqlDbType.NVarChar, 50);
            param[1].Value = Product_Name;
            param[2] = new SqlParameter("@Product_QTY_InStock", SqlDbType.Int);
            param[2].Value = Product_QTY_InStock;
            param[3] = new SqlParameter("@Product_buy_Price", SqlDbType.Real);
            param[3].Value = Product_buy_Price;
            param[4] = new SqlParameter("@Product_Sale_Price", SqlDbType.Real);
            param[4].Value = Product_Sale_Price;
            param[5] = new SqlParameter("@BarCode", SqlDbType.NVarChar, 50);
            param[5].Value = BarCode;
            param[6] = new SqlParameter("@MinQty", SqlDbType.Float);
            param[6].Value = MinQty;
            param[7] = new SqlParameter("@MaxDiscount", SqlDbType.Float);
            param[7].Value = MaxDiscount;
            param[8] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[8].Value = ID_CAT;
            param[9] = new SqlParameter("@Creterion", SqlDbType.VarChar,50);
            param[9].Value = Creterion;
            dal.Excutecommand("ADD_Product", param);
            dal.close();
        }
        public void EDIT_Product(string ID_PRODUCT, string Product_Name, int Product_QTY_InStock, decimal Product_buy_Price,
          decimal Product_Sale_Price, string BarCode, decimal MinQty, decimal MaxDiscount, int ID_CAT, string Creterion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            param[0].Value = ID_PRODUCT;
            param[1] = new SqlParameter("@Product_Name", SqlDbType.NVarChar, 50);
            param[1].Value = Product_Name;
            param[2] = new SqlParameter("@Product_QTY_InStock", SqlDbType.Int);
            param[2].Value = Product_QTY_InStock;
            param[3] = new SqlParameter("@Product_buy_Price", SqlDbType.Real);
            param[3].Value = Product_buy_Price;
            param[4] = new SqlParameter("@Product_Sale_Price", SqlDbType.Real);
            param[4].Value = Product_Sale_Price;
            param[5] = new SqlParameter("@BarCode", SqlDbType.NVarChar, 50);
            param[5].Value = BarCode;
            param[6] = new SqlParameter("@MinQty", SqlDbType.Float);
            param[6].Value = MinQty;
            param[7] = new SqlParameter("@MaxDiscount", SqlDbType.Float);
            param[7].Value = MaxDiscount;
            param[8] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[8].Value = ID_CAT;
            param[9] = new SqlParameter("@Creterion", SqlDbType.VarChar, 50);
            param[9].Value = Creterion;
            dal.Excutecommand("ADD_Product", param);
            dal.close();
        }
        public DataTable verifyProductID(String ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            Param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = dal.selectData("verifyProductID", Param);
            dal.close();
            return dt;
        }
        public DataTable GET_ALL_PRODUCTS_INGRIDVIEW()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();


            DataTable dt = new DataTable();
            dt = dal.selectData("GET_ALL_PRODUCTS_INGRIDVIEW", null);
            dal.close();
            return dt;
        }
        public DataTable Search_product(String ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            Param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = dal.selectData("Search_product", Param);
            dal.close();
            return dt;
        }
        public void Delete_Product(string ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            dal.Excutecommand("Delete_Product", param);
            dal.close();
        }
        
              public void Delete_ALLProductS()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            dal.Excutecommand("Delete_ALLProductSt", null);
            dal.close();
        }
        public DataTable get_picture_product(String ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            Param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = dal.selectData("get_picture_product", Param);
            dal.close();
            return dt;
        }
    }
}

