using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using OdnShop.Core.Common;
using OdnShop.Core.Model;
namespace OdnShop.Core.Factory
{
    public class FavoriteFactory
    {
        public static void Add(FavoriteModel info)
        {
            string sql = @"INSERT INTO odnshop_favorite (uid,productid,createtime,productxml) VALUES (?uid,?productid,?createtime,?productxml)";

            MySqlParameter[] parameters = {
                MySqlDbHelper.MakeInParam("?uid" , MySqlDbType.Int32 , 4 ,info.uid),
                MySqlDbHelper.MakeInParam("?productid" , MySqlDbType.Int32 , 4 ,info.productid),
                MySqlDbHelper.MakeInParam("?createtime" , MySqlDbType.Datetime , 8 ,info.createtime),
                MySqlDbHelper.MakeInParam("?productxml" , MySqlDbType.VarChar , 0 ,SerializeHelper.SaveToString(info.product))
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void Delete(int fid)
        {
            string sql = "delete from odnshop_favorite where fid=" + fid;
            MySqlDbHelper.ExecuteSql(sql);
        }

        public static List<FavoriteModel> GetListByUid(int uid, int pageSize, int pageIndex, out int totalcount)
        {
            int start = (pageIndex - 1) * pageSize;
            string sql = string.Format("select * from odnshop_favorite where uid={0} order by fid desc limit {1},{2}", uid.ToString(), start, pageSize);

            List<FavoriteModel> list = new List<FavoriteModel>();

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            FavoriteModel info = null;
            foreach (DataRow dr in dt.Rows)
            {
                info = new FavoriteModel();
                info.product = (ProductModel)SerializeHelper.LoadFromXml(new ProductModel().GetType(), dr["productxml"].ToString());
                info.fid = Int32.Parse(dr["fid"].ToString());
                info.uid = Int32.Parse(dr["uid"].ToString());
                info.productid = Int32.Parse(dr["productid"].ToString());
                info.createtime = DateTime.Parse(dr["createtime"].ToString());

                list.Add(info);
            }

            totalcount = MySqlDbHelper.ExecuteScalar("select count(*) from odnshop_favorite where uid=" + uid);

            return list;
        }

        public static bool IsFavorite(int uid, int productid)
        {
            int favcount = MySqlDbHelper.ExecuteScalar( string.Format("select count(*) from odnshop_favorite where uid={0} and productid={1}", uid, productid));

            if (favcount > 0)
                return true;

            return false;
        }
    }
}
