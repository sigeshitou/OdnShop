using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using OdnShop.Core.Common;
using OdnShop.Core.Model;
namespace OdnShop.Core.Factory
{
    public class OrderFactory
    {
        public static void Add(OrderModel info)
        {
            string sql = @"INSERT INTO odnshop_order (orderno,uid,customername,tel,address,orderstatus,deliverstatus,createtime,orderxml) VALUES (?orderno,?uid,?customername,?tel,?address,?orderstatus,?deliverstatus,?createtime,?orderxml)";

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?orderno" , MySqlDbType.VarChar , 32 ,info.orderno) ,
                MySqlDbHelper.MakeInParam("?uid" , MySqlDbType.Int32 , 4 ,info.uid),
                MySqlDbHelper.MakeInParam("?customername" , MySqlDbType.VarChar , 50 ,info.customername) ,
                MySqlDbHelper.MakeInParam("?tel" , MySqlDbType.VarChar , 50 ,info.tel) ,
                MySqlDbHelper.MakeInParam("?address" , MySqlDbType.VarChar , 100 ,info.address) ,
                MySqlDbHelper.MakeInParam("?orderstatus" , MySqlDbType.Int32 , 4 ,info.orderstatus),
                MySqlDbHelper.MakeInParam("?deliverstatus" , MySqlDbType.Int32 , 4 ,info.deliverstatus),
                MySqlDbHelper.MakeInParam("?createtime" , MySqlDbType.Datetime , 8 ,info.createtime),
                MySqlDbHelper.MakeInParam("?orderxml" , MySqlDbType.VarChar , 0 ,SerializeHelper.SaveToString(info))
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void Update(OrderModel info)
        {
            string sql = "UPDATE odnshop_order set customername=?customername,tel=?tel,address=?address,orderstatus=?orderstatus,deliverstatus=?deliverstatus,createtime=?createtime,orderxml=?orderxml where orderid=?orderid";
            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?customername" , MySqlDbType.VarChar , 50 ,info.customername) ,
                MySqlDbHelper.MakeInParam("?tel" , MySqlDbType.VarChar , 50 ,info.tel) ,
                MySqlDbHelper.MakeInParam("?address" , MySqlDbType.VarChar , 100 ,info.address) ,
                MySqlDbHelper.MakeInParam("?orderstatus" , MySqlDbType.Int32 , 4 ,info.orderstatus),
                MySqlDbHelper.MakeInParam("?deliverstatus" , MySqlDbType.Int32 , 4 ,info.deliverstatus),
                MySqlDbHelper.MakeInParam("?createtime" , MySqlDbType.Date , 8 ,info.createtime),
                MySqlDbHelper.MakeInParam("?orderxml" , MySqlDbType.VarChar , 0 ,SerializeHelper.SaveToString(info)),
                MySqlDbHelper.MakeInParam("?orderid" , MySqlDbType.Int32 , 4 ,info.orderid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void UpdateStatus(int orderstatus,int orderid)
        {
            string sql = "UPDATE odnshop_order set orderstatus=?orderstatus where orderid=?orderid";
            MySqlParameter[] parameters = {
                MySqlDbHelper.MakeInParam("?orderstatus" , MySqlDbType.Int32 , 4 ,orderstatus),
                MySqlDbHelper.MakeInParam("?orderid" , MySqlDbType.Int32 , 4 ,orderid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void UpdateDeliverstatus(string orderno, int deliverstatus)
        {
            string sql = "UPDATE odnshop_order set deliverstatus=?deliverstatus where orderno=@orderno";
            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?deliverstatus" , MySqlDbType.Int32 , 4 ,deliverstatus),
                MySqlDbHelper.MakeInParam("?orderno" , MySqlDbType.VarChar , 32 ,orderno)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void UpdateOrderStatus(string orderno, int orderstatus)
        {
            string sql = "UPDATE odnshop_order set orderstatus=?orderstatus where orderno=?orderno";
            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?orderstatus" , MySqlDbType.Int32 , 4 ,orderstatus),
                MySqlDbHelper.MakeInParam("?orderno" , MySqlDbType.VarChar , 32 ,orderno)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static OrderModel Get(int orderid)
        {
            string sql = "select * from odnshop_order where orderid=" + orderid;

            OrderModel info = null;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());
            }

            return info;
        }

        public static List<OrderModel> GetByUid(int uid)
        {
            string sql = "select top 5 * from odnshop_order where orderstatus=5 and uid=" + uid + " order by orderid desc";

            List<OrderModel> list = new List<OrderModel>();
            
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            OrderModel info = null;
            foreach(DataRow dr in dt.Rows)
            {
                info = new OrderModel();
                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());

                list.Add(info);
            }

            return list;
        }

        public static OrderModel Get(string orderno)
        {
            string sql = string.Format("select * from odnshop_order where orderno='{0}'", orderno);

            OrderModel info = null;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());
            }

            return info;
        }


        //我的购物车
        public static OrderModel GetCartOrder(int uid)
        {
            string sql = "select * from odnshop_order where orderstatus=1 and uid=" + uid;

            OrderModel info = null;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                
                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());
            }

            return info;
        }

        //我的订单，只显示最近10条订单信息
        public static List<OrderModel> GetMyOrders(int uid)
        {
            string sql = "select * from odnshop_order where orderstatus=5 and uid=" + uid + " order by orderid desc limit 5"; ;

            List<OrderModel> list = new List<OrderModel>();
            OrderModel info = null;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            foreach(DataRow dr in dt.Rows)
            {
                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());
                list.Add(info);
            }

            return list ;
        }

        public static DataTable GetList(int pageSize, int pageIndex, string whereSql, string orderBy, out int totalcount)
        {
            int start = (pageIndex - 1) * pageSize;

            string sql = string.Format("select * from odnshop_order {0}{1} limit {2},{3}", whereSql, orderBy, start, pageSize);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            totalcount = MySqlDbHelper.ExecuteScalar(string.Format("select count(*) from odnshop_order {0}", whereSql));

            return dt;

        }

        public static DataTable GetList(int count, string whereSql)
        {
            string sql = string.Format("select * from odnshop_order {0} order by orderid desc limit {1}", whereSql,count);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            return dt;
        }

        public static DataTable GetList(string whereSql)
        {
            string sql = string.Format("select * from odnshop_order {0} order by orderid desc", whereSql);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            return dt;
        }

        public static List<OrderModel> GetOrderList(string whereSql)
        {
            string sql = string.Format("select * from odnshop_order {0} order by orderid desc", whereSql);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            List<OrderModel> list = new List<OrderModel>();
            OrderModel info = null;

            foreach (DataRow dr in dt.Rows)
            {
                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());
                list.Add(info);
            }

            return list;
        }

        public static List<OrderModel> GetOrderList(int pageSize, int pageIndex, string whereSql, string orderBy, out int totalcount)
        {
            int start = (pageIndex - 1) * pageSize;

            string sql = string.Format("select * from odnshop_order {0}{1} limit {2},{3}", whereSql, orderBy, start, pageSize);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            totalcount = MySqlDbHelper.ExecuteScalar(string.Format("select count(*) from odnshop_order {0}", whereSql));

            List<OrderModel> list = new List<OrderModel>();
            OrderModel info = null;

            foreach (DataRow dr in dt.Rows)
            {
                info = (OrderModel)SerializeHelper.LoadFromXml(new OrderModel().GetType(), dr["orderxml"].ToString());
                info.orderid = Int32.Parse(dr["orderid"].ToString());
                info.orderstatus = Int32.Parse(dr["orderstatus"].ToString());
                info.deliverstatus = Int32.Parse(dr["deliverstatus"].ToString());
                list.Add(info);
            }

            return list;

        }
    }
}
