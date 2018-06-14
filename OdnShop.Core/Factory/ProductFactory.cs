using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;
using OdnShop.Core.Model;

namespace OdnShop.Core.Factory
{
    public class ProductFactory
    {
        public static void Add(ProductModel info)
        {
            string sql = @"INSERT INTO odnshop_product( 
                            productname ,
                            includepicpath ,
                            productpics,
                            iscommend,
                            productcode ,
                            description ,
                            specification ,
                            salecount ,
                            hits ,productcount,
                            price,itemprice,categoryid,createtime) VALUES (?productname,?includepicpath,?productpics,?iscommend,?productcode,?description,?specification,?salecount,?hits,?productcount,?price,?itemprice,?categoryid,?createtime)";

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?productname" , MySqlDbType.VarChar , 50 ,info.productname) ,
                MySqlDbHelper.MakeInParam("?includepicpath" , MySqlDbType.VarChar , 50 ,info.includepicpath) ,
                MySqlDbHelper.MakeInParam("?productpics" , MySqlDbType.MediumText , 0 ,info.productpics) ,
                MySqlDbHelper.MakeInParam("?iscommend",MySqlDbType.Bit , 1 ,info.iscommend) ,
                MySqlDbHelper.MakeInParam("?productcode" , MySqlDbType.Int32 , 4 ,info.productcode) ,
                MySqlDbHelper.MakeInParam("?description" , MySqlDbType.VarChar , 0 ,info.description) ,
                MySqlDbHelper.MakeInParam("?specification" , MySqlDbType.VarChar , 0 ,info.specification) ,
                MySqlDbHelper.MakeInParam("?salecount" , MySqlDbType.Int32 , 4 ,info.salecount) ,
                MySqlDbHelper.MakeInParam("?hits" , MySqlDbType.Int32 , 4 ,info.hits),
                MySqlDbHelper.MakeInParam("?productcount" , MySqlDbType.Int32 , 4 ,info.productcount),
                MySqlDbHelper.MakeInParam("?price" , MySqlDbType.Decimal , 8 ,info.price),
                MySqlDbHelper.MakeInParam("?itemprice" , MySqlDbType.VarChar , 0 ,info.itemprice) ,
                MySqlDbHelper.MakeInParam("?categoryid" , MySqlDbType.Int32 , 4 ,info.categoryid),
                MySqlDbHelper.MakeInParam("?createtime" , MySqlDbType.Date , 8 ,info.createtime) 
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void Delete(int productid)
        {
            string sql = "delete from odnshop_product where productid=" + productid;
            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void UpdateHits(int productid)
        {
            string sql = "UPDATE odnshop_product set hits=hits+1 where productid=" + productid;
            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void Update(ProductModel info)
        {
            string sql = @"UPDATE odnshop_product set 
                            productname=?productname ,
                            includepicpath=?includepicpath ,
                            productpics=?productpics,
                            iscommend = ?iscommend ,
                            productcode=?productcode ,
                            description=?description ,
                            specification=?specification ,
                            salecount=?salecount ,
                            hits=?hits ,
                            productcount=?productcount,
                            price=?price,itemprice=?itemprice,categoryid=?categoryid,createtime=?createtime WHERE productid = ?productid";

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?productname" , MySqlDbType.VarChar , 50 ,info.productname) ,
                MySqlDbHelper.MakeInParam("?includepicpath" , MySqlDbType.VarChar , 50 ,info.includepicpath) ,
                MySqlDbHelper.MakeInParam("?productpics" , MySqlDbType.MediumText , 0 ,info.productpics) ,
                MySqlDbHelper.MakeInParam("?iscommend",MySqlDbType.Int16 , 1 ,info.iscommend) ,
                MySqlDbHelper.MakeInParam("?productcode" , MySqlDbType.Int32 , 4 ,info.productcode) ,
                MySqlDbHelper.MakeInParam("?description" , MySqlDbType.VarChar , 0 ,info.description) ,
                MySqlDbHelper.MakeInParam("?specification" , MySqlDbType.VarChar , 0 ,info.specification) ,
                MySqlDbHelper.MakeInParam("?salecount" , MySqlDbType.Int32 , 4 ,info.salecount) ,
                MySqlDbHelper.MakeInParam("?hits" , MySqlDbType.Int32 , 4 ,info.hits),
                MySqlDbHelper.MakeInParam("?productcount" , MySqlDbType.Int32 , 4 ,info.productcount),
                MySqlDbHelper.MakeInParam("?price" , MySqlDbType.Decimal , 8 ,info.price),
                MySqlDbHelper.MakeInParam("?itemprice" , MySqlDbType.VarChar , 0 ,info.itemprice) ,
                MySqlDbHelper.MakeInParam("?categoryid" , MySqlDbType.Int32 , 4 ,info.categoryid),
                MySqlDbHelper.MakeInParam("?createtime" , MySqlDbType.Datetime , 8 ,info.createtime) ,
                MySqlDbHelper.MakeInParam("?productid" , MySqlDbType.Int32 , 4 ,info.productid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        //salecount,增加的销量=减少的库存量
        public static void UpdateSalecount(int productid, int salecount)
        {
            string sql = @"UPDATE odnshop_product set 
                            salecount=salecount+?salecount ,
                            productcount=productcount-?salecount WHERE productid = ?productid";

            MySqlParameter[] parameters = {
                MySqlDbHelper.MakeInParam("?salecount" , MySqlDbType.Int32 , 4 ,salecount) ,
                MySqlDbHelper.MakeInParam("?productcount" , MySqlDbType.Int32 , 4 ,salecount),
                MySqlDbHelper.MakeInParam("?productid" , MySqlDbType.Int32 , 4 ,productid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static ProductModel Get(int productid) 
        {
            string sql = "select * from odnshop_product where productid=" + productid;

            ProductModel info = null;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                info = PopulateModel(dr, new ProductModel());
            }

            return info;
        }

        public static List<ProductModel> GetList(int pageSize, int pageIndex, string whereSql, string orderBy, out int totalcount)
        {
            int start = (pageIndex - 1) * pageSize;

            string sql = string.Format("select * from odnshop_product {0}{1} limit {2},{3}", whereSql, orderBy, start, pageSize);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            totalcount = MySqlDbHelper.ExecuteScalar(string.Format("select count(*) from odnshop_product {0}", whereSql));


            List<ProductModel> list = new List<ProductModel>();
            ProductModel info = null;
            foreach (DataRow dr in dt.Rows)
            {
                info = PopulateModel(dr, new ProductModel());

                list.Add(info);
            }

            return list;
        }

        public static List<ProductModel> GetList(int count, string whereSql)
        {
            string sql = string.Format("select * from odnshop_product {0} order by productid desc limit {1}", whereSql,count);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            List<ProductModel> list = new List<ProductModel>();
            ProductModel info = null;
            foreach (DataRow dr in dt.Rows)
            {
                info = PopulateModel(dr, new ProductModel());

                list.Add(info);
            }

            return  list ;
        }

        public static DataTable GetList(string whereSql)
        {
            string sql = string.Format("select * from odnshop_product {0} order by productid desc", whereSql);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            return dt;
        }

        private static ProductModel PopulateModel(DataRow dr, ProductModel entity)
        {
            if (dr == null)
                return null;

            ProductModel baseEntity = (ProductModel)Activator.CreateInstance(entity.GetType());
            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                try
                {
                    baseEntity.GetType().GetProperty(propertyInfo.Name).SetValue(baseEntity, dr[propertyInfo.Name], null);
                }
                catch { }
            }

            return baseEntity;
        }

    }
}
