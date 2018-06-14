using System;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

using OdnShop.Core.Model;
namespace OdnShop.Core.Factory
{
    /// <summary>
    /// 前台用户操作类
    /// </summary>
    public class UserFactory
    {
        public static void Add(UserModel info)
        {
            string sql = @"INSERT INTO odnshop_user(nickname,openid,fullname,sex,tel,address,headpicurl,jbnum,jfnum,createdate,fromuid,usertype) VALUES(?nickname,?openid,?fullname,?sex,?tel,?address,?headpicurl,?jbnum,?jfnum,?createdate,?fromuid,?usertype)";

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?nickname" , MySqlDbType.VarChar , 50,info.nickname) ,
                MySqlDbHelper.MakeInParam("?openid" , MySqlDbType.VarChar , 255,info.openid) ,
                MySqlDbHelper.MakeInParam("?fullname" , MySqlDbType.VarChar , 50,info.fullname) ,
                MySqlDbHelper.MakeInParam("?sex" , MySqlDbType.VarChar , 50,info.sex) ,
                MySqlDbHelper.MakeInParam("?tel" , MySqlDbType.VarChar , 50,info.tel) ,
                MySqlDbHelper.MakeInParam("?address" , MySqlDbType.VarChar , 50,info.address) ,
                MySqlDbHelper.MakeInParam("?headpicurl" , MySqlDbType.VarChar , 255,info.headpicurl) ,
                MySqlDbHelper.MakeInParam("?jbnum" , MySqlDbType.Int32 , 4 ,info.jbnum) ,
                MySqlDbHelper.MakeInParam("?jfnum" , MySqlDbType.Int32 , 4 ,info.jfnum) ,
                MySqlDbHelper.MakeInParam("?createdate" , MySqlDbType.Datetime ,8 ,info.createdate) ,
                MySqlDbHelper.MakeInParam("?fromuid" , MySqlDbType.Int32 , 4 ,info.fromuid),
                MySqlDbHelper.MakeInParam("?usertype" , MySqlDbType.Int32 , 4 ,info.usertype)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void Delete(int uid)
        {
            string sql = "delete from odnshop_user where uid=" + uid.ToString();

            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void Update(UserModel info)
        {
            string sql = @"update odnshop_user set 
                            nickname = ?nickname,
                            openid = ?openid,
                            fullname = ?fullname,
                            sex = ?sex,
                            tel = ?tel,
                            address = ?address,
                            headpicurl = ?headpicurl,
                            jbnum = ?jbnum,
                            jfnum = ?jfnum,
                            createdate = ?createdate,
                            fromuid = ?fromuid,
                            usertype = ?usertype where uid = ?uid";

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?nickname" , MySqlDbType.VarChar , 50 ,info.nickname) ,
                MySqlDbHelper.MakeInParam("?openid" , MySqlDbType.VarChar , 255 ,info.openid) ,
                MySqlDbHelper.MakeInParam("?fullname" , MySqlDbType.VarChar , 50 ,info.fullname) ,
                MySqlDbHelper.MakeInParam("?sex" , MySqlDbType.VarChar , 50 ,info.sex) ,
                MySqlDbHelper.MakeInParam("?tel" , MySqlDbType.VarChar , 50 ,info.tel) ,
                MySqlDbHelper.MakeInParam("?address" , MySqlDbType.VarChar , 50 ,info.address) ,
                MySqlDbHelper.MakeInParam("?headpicurl" , MySqlDbType.VarChar , 255 ,info.headpicurl) ,
                MySqlDbHelper.MakeInParam("?jbnum" , MySqlDbType.Int32 , 4 ,info.jbnum) ,
                MySqlDbHelper.MakeInParam("?jfnum" , MySqlDbType.Int32 , 4 ,info.jfnum) ,
                MySqlDbHelper.MakeInParam("?createdate" , MySqlDbType.Date ,8 ,info.createdate) ,
                MySqlDbHelper.MakeInParam("?fromuid" , MySqlDbType.Int32 , 4 ,info.fromuid),
                MySqlDbHelper.MakeInParam("?usertype" , MySqlDbType.Int32 , 4 ,info.usertype),
                MySqlDbHelper.MakeInParam("?uid" , MySqlDbType.Int32 , 4 ,info.uid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void UpdateUsertype(int uid, int usertype)
        {
            string sql = @"update odnshop_user set usertype=?usertype where uid = ?uid";
            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?usertype" , MySqlDbType.Int32 , 4 ,usertype) ,
                MySqlDbHelper.MakeInParam("?uid" , MySqlDbType.Int32 , 4 ,uid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void UpdateJb(int uid, int jb)
        {
            int jbnum = 0;
            string sql = string.Empty;

            if (jb >= 0)
            {
                jbnum = jb;
                sql = @"update odnshop_user set jbnum=jbnum+?jbnum where uid = ?uid";
            }
            else
            {
                jbnum = -jb;
                sql = @"update odnshop_user set jbnum=jbnum-?jbnum where uid = ?uid";
            }

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?jbnum" , MySqlDbType.Int32 , 4 ,jbnum) ,
                MySqlDbHelper.MakeInParam("?uid" , MySqlDbType.Int32 , 4 ,uid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void UpdateJf(int uid, int jf)
        {
            int jfnum = 0;
            string sql = string.Empty;

            if (jf >= 0)
            {
                jfnum = jf;
                sql = @"update odnshop_user set jfnum=jfnum+?jfnum where uid = ?uid";
            }
            else
            {
                jfnum = -jf;
                sql = @"update odnshop_user set jfnum=jfnum-?jfnum where uid = ?uid";
            }

            MySqlParameter[] parameters = { 
                MySqlDbHelper.MakeInParam("?jfnum" , MySqlDbType.Int32 , 4 ,jfnum) ,
                MySqlDbHelper.MakeInParam("?uid" , MySqlDbType.Int32 , 4 ,uid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static UserModel Get(int uid)
        {
            string sql = "select * from odnshop_user where uid=" + uid;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            UserModel info = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info = PopulateModel(dr, new UserModel());
            }

            return info;
        }

        public static UserModel GetFirst()
        {
            string sql = "select * from odnshop_user order by uid asc limit 1";
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            UserModel info = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info = PopulateModel(dr, new UserModel());
            }

            return info;
        }

        public static UserModel Get(string openid)
        {
            string sql = "select * from odnshop_user where openid='" + openid + "'";
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            UserModel info = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info = PopulateModel(dr, new UserModel());
            }

            return info;
        }

        public static DataTable GetList(int pageSize, int pageIndex, string whereSql, string orderBy, out int totalcount)
        {
            int start = (pageIndex - 1) * pageSize;

            string sql = string.Format("select * from odnshop_user {0}{1} limit {2},{3}", whereSql, orderBy, start, pageSize);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            totalcount = MySqlDbHelper.ExecuteScalar(string.Format("select count(*) from odnshop_user {0}", whereSql));

            return dt;
        }

        public static DataTable GetList(string whereSql)
        {
            string sql = string.Format("select * from odnshop_user {0} order by uid desc", whereSql);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            return dt;
        }

        public static int GetTotalCount()
        {
            int totalcount = MySqlDbHelper.ExecuteScalar("select count(*) from odnshop_user ");
            return totalcount;
        }

        private static UserModel PopulateModel(DataRow dr, UserModel entity)
        {
            if (dr == null)
                return null;

            UserModel baseEntity = (UserModel)Activator.CreateInstance(entity.GetType());
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
