using System;
using System.Data;
using System.Text;
using System.Reflection;
using MySql.Data.MySqlClient;

using OdnShop.Core.Model;
namespace OdnShop.Core.Factory
{
    public class LinkFactory
    {
        public static void Add(LinkModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into odnshop_link(");
            strSql.Append("linkname,linkurl,includepic,possymbol,createtime,orderno)");
            strSql.Append(" values (");
            strSql.Append("?linkname,?linkurl,?includepic,?possymbol,?createtime,?orderno)");

            MySqlParameter[] parameters = {
					new MySqlParameter("?linkname", MySqlDbType.VarChar,45),
					new MySqlParameter("?linkurl", MySqlDbType.VarChar,200),
					new MySqlParameter("?includepic", MySqlDbType.VarChar,200),
					new MySqlParameter("?possymbol", MySqlDbType.VarChar,45),
					new MySqlParameter("?createtime", MySqlDbType.Datetime),
					new MySqlParameter("?orderno", MySqlDbType.Int32,11)};

            parameters[0].Value = model.linkname;
            parameters[1].Value = model.linkurl;
            parameters[2].Value = model.includepic;
            parameters[3].Value = model.possymbol;
            parameters[4].Value = model.createtime;
            parameters[5].Value = model.orderno;

            MySqlDbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public static void Delete(int linkid)
        {
            string sql = "delete from odnshop_link where linkid=" + linkid;
            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void Update(LinkModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update odnshop_link set ");
            strSql.Append("linkname=?linkname,");
            strSql.Append("linkurl=?linkurl,");
            strSql.Append("includepic=?includepic,");
            strSql.Append("possymbol=?possymbol,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("orderno=?orderno");
            strSql.Append(" where linkid=?linkid");

            MySqlParameter[] parameters = {
					new MySqlParameter("?linkname", MySqlDbType.VarChar,45),
					new MySqlParameter("?linkurl", MySqlDbType.VarChar,200),
					new MySqlParameter("?includepic", MySqlDbType.VarChar,200),
					new MySqlParameter("?possymbol", MySqlDbType.VarChar,45),
					new MySqlParameter("?createtime", MySqlDbType.Datetime),
					new MySqlParameter("?orderno", MySqlDbType.Int32,11),
					new MySqlParameter("?linkid", MySqlDbType.Int32,11)};

            parameters[0].Value = model.linkname;
            parameters[1].Value = model.linkurl;
            parameters[2].Value = model.includepic;
            parameters[3].Value = model.possymbol;
            parameters[4].Value = model.createtime;
            parameters[5].Value = model.orderno;
            parameters[6].Value = model.linkid;

            MySqlDbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public static LinkModel Get(int linkid)
        {
            string sql = "select * from odnshop_link where linkid = " + linkid;

            LinkModel info = null;

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                info = PopulateModel(dr, new LinkModel());
            }

            return info;
        }

        public static DataTable GetList(string possymbol)
        {
            string sql1 = "select * from odnshop_link order by orderno asc";
            string sql2 = "select * from odnshop_link where possymbol='" + possymbol + "' order by orderno asc";

            if (string.IsNullOrEmpty(possymbol))
            {
                return MySqlDbHelper.Query(sql1).Tables[0];
            }
            else
            {
                return MySqlDbHelper.Query(sql2).Tables[0];
            }
        }

        private static LinkModel PopulateModel(DataRow dr, LinkModel entity)
        {
            if (dr == null)
                return null;

            LinkModel baseEntity = (LinkModel)Activator.CreateInstance(entity.GetType());
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
