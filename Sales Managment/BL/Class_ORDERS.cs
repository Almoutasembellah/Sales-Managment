using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Sales_Managment.BL
{
    class Class_ORDERS
    {
        public DataTable get_invoice_num()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_invoice_num", null);
            dal.close();
            return dt; 
        }
       


        public void Add_BuyOrder(int ID_ORDER, string ORDER_DESC, string ORDER_DATE, int Sup_ID, string Byer_Name,decimal Price_Matloob)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ID_ORDER;
            param[1] = new SqlParameter("@ORDER_DESC", SqlDbType.NVarChar, 50);
            param[1].Value = ORDER_DESC;
            param[2] = new SqlParameter("@ORDER_DATE", SqlDbType.NVarChar,50);
            param[2].Value = ORDER_DATE;
            param[3] = new SqlParameter("@Sup_ID ", SqlDbType.Int);
            param[3].Value = Sup_ID;
            param[4] = new SqlParameter("@Byer_Name", SqlDbType.NVarChar, 50);
            param[4].Value = Byer_Name;
            param[5] = new SqlParameter("@Price_Matloob", SqlDbType.Float);
            param[5].Value = Price_Matloob;
            dal.Excutecommand("Add_BuyOrder", param);
            dal.close();
        }

        public void Add_Buyorder_details(string ID_PRODUCT, int ID_ORDER, int QTY, string PRICE_UNIT, double DISCOUNT, string TOTAL_PRICE, string AMOUNT_PRICE)
        {

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            param[0].Value = ID_PRODUCT;
            param[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[1].Value = ID_ORDER;
            param[2] = new SqlParameter("@QTY", SqlDbType.Int);
            param[2].Value = QTY;
            param[3] = new SqlParameter("@PRICE_UNIT", SqlDbType.VarChar, 50);
            param[3].Value = PRICE_UNIT;
            param[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            param[4].Value = DISCOUNT;
            param[5] = new SqlParameter("@TOTAL_PRICE", SqlDbType.VarChar, 50);
            param[5].Value = TOTAL_PRICE;
            param[6] = new SqlParameter("@AMOUNT_PRICE", SqlDbType.VarChar, 50);
            param[6].Value = AMOUNT_PRICE;
            dal.Excutecommand("Add_Buyorder_details", param);
            dal.close();
        }

        public void ADD_SupPayHistory(int ID_ORDER, int Sup_ID, decimal paidValue,string dateOfPayment )
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


            public void ADD_Supplier_Money(int ID_ORDER, int Sup_ID, decimal Demand_Money, string dateOfPayment, string Reminder_Date)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ID_ORDER;
            param[1] = new SqlParameter("@Sup_ID ", SqlDbType.Int);
            param[1].Value = Sup_ID;
            param[2] = new SqlParameter("@Demand_Money", SqlDbType.Real);
            param[2].Value = Demand_Money;
            param[3] = new SqlParameter("@dateOfPayment", SqlDbType.NVarChar, 50);
            param[3].Value = dateOfPayment;
            param[3] = new SqlParameter("@Reminder_Date", SqlDbType.NVarChar, 50);
            param[3].Value = Reminder_Date;
            dal.Excutecommand("ADD_Supplier_Money", param);
            dal.close();
        }
        public DataTable verify_qty_in_stock(String ID_PRODUCT, int QTY)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            Param[0].Value = ID_PRODUCT;
            Param[1] = new SqlParameter("@QTY", SqlDbType.Int);
            Param[1].Value = QTY;
            DataTable dt = new DataTable();
            dt = dal.selectData("verify_qty_in_stock", Param);
            dal.close();
            return dt;
        }
        public DataTable get_order_details(int ID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID", SqlDbType.Int);
            Param[0].Value = ID;
            DataTable dt = new DataTable();
            dt = dal.selectData("get_order_details", Param);
            dal.close();
            return dt;
        }
        public DataTable get_NummOFlastInvoice()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.selectData("get_NummOFlastInvoice", null);
            dal.close();
            return dt;
        }
        public DataTable search_Order_List(string certerion)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@certerion ", SqlDbType.VarChar, 50);
            Param[0].Value = certerion;
            DataTable dt = new DataTable();
            dt = dal.selectData("search_Order_List", Param);
            dal.close();
            return dt;
        }
    }
}
