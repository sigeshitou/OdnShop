using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using MySql.Data.MySqlClient;

using OdnShop.Core.Model;
namespace OdnShop.Core.Factory
{
    public class AdminFactory
    {
        public static void Add(AdminModel model)
        {
            string sql = "INSERT INTO odnshop_admin(username,userpwd,email,tel,usertype,lastlogindate,createdate,lastloginip,logincount,adminqx) VALUES(?username,?userpwd,?email,?tel,?usertype,?lastlogindate,?createdate,?lastloginip,?logincount,?adminqx)";
            MySqlParameter[] parameters = {
					new MySqlParameter("?username", MySqlDbType.VarChar,45),
					new MySqlParameter("?userpwd", MySqlDbType.VarChar,45),
					new MySqlParameter("?email", MySqlDbType.VarChar,45),
					new MySqlParameter("?tel", MySqlDbType.VarChar,45),
					new MySqlParameter("?usertype", MySqlDbType.Int16,4),
					new MySqlParameter("?lastlogindate", MySqlDbType.Datetime),
					new MySqlParameter("?createdate", MySqlDbType.Datetime),
					new MySqlParameter("?lastloginip", MySqlDbType.VarChar,45),
					new MySqlParameter("?logincount", MySqlDbType.Int32,11),
                    new MySqlParameter("?adminqx", MySqlDbType.MediumText)
            };

            parameters[0].Value = model.username;
            parameters[1].Value = model.userpwd;
            parameters[2].Value = model.email;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.usertype;
            parameters[5].Value = model.lastlogindate;
            parameters[6].Value = model.createdate;
            parameters[7].Value = model.lastloginip;
            parameters[8].Value = model.logincount;
            parameters[9].Value = model.adminqx;

            MySqlDbHelper.Query(sql, parameters);
        }

        public static void Delete(int adminid)
        {
            string sql = "delete from odnshop_admin where adminid=" + adminid.ToString();

            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void Update(AdminModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update odnshop_admin set ");
            strSql.Append("username=?username,");
            strSql.Append("userpwd=?userpwd,");
            strSql.Append("email=?email,");
            strSql.Append("tel=?tel,");
            strSql.Append("usertype=?usertype,");
            strSql.Append("lastlogindate=?lastlogindate,");
            strSql.Append("createdate=?createdate,");
            strSql.Append("lastloginip=?lastloginip,");
            strSql.Append("logincount=?logincount,");
            strSql.Append("adminqx=?adminqx");
            strSql.Append(" where adminid=?adminid ");

            MySqlParameter[] parameters = {
					new MySqlParameter("?username", MySqlDbType.VarChar,45),
					new MySqlParameter("?userpwd", MySqlDbType.VarChar,45),
					new MySqlParameter("?email", MySqlDbType.VarChar,45),
					new MySqlParameter("?tel", MySqlDbType.VarChar,45),
					new MySqlParameter("?usertype", MySqlDbType.Int16,4),
					new MySqlParameter("?lastlogindate", MySqlDbType.Datetime),
					new MySqlParameter("?createdate", MySqlDbType.Datetime),
					new MySqlParameter("?lastloginip", MySqlDbType.VarChar,45),
					new MySqlParameter("?logincount", MySqlDbType.Int32,11),
                    new MySqlParameter("?adminqx", MySqlDbType.MediumText),
                    new MySqlParameter("?adminid", MySqlDbType.Int32,11)};

            parameters[0].Value = model.username;
            parameters[1].Value = model.userpwd;
            parameters[2].Value = model.email;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.usertype;
            parameters[5].Value = model.lastlogindate;
            parameters[6].Value = model.createdate;
            parameters[7].Value = model.lastloginip;
            parameters[8].Value = model.logincount;
            parameters[9].Value = model.adminqx;
            parameters[10].Value = model.adminid;


            MySqlDbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public static AdminModel Get(int adminid)
        {
            string sql = "select * from odnshop_admin where adminid=" + adminid.ToString();
            DataSet ds = MySqlDbHelper.Query(sql);

            AdminModel info = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                info = PopulateModel(dr, new AdminModel());
            }

            return info;
        }

        public static AdminModel Get(string username)
        {
            string sql = "select * from odnshop_admin where username='" + username + "'";

            DataSet ds = MySqlDbHelper.Query(sql);

            AdminModel info = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                info = PopulateModel(dr, new AdminModel());
            }

            return info;
        }

        public static List<AdminModel> GetAll()
        {
            string sql = "select * from odnshop_admin";

            DataSet ds = MySqlDbHelper.Query(sql);
            DataTable dt = ds.Tables[0];

            List<AdminModel> list = new List<AdminModel>();
            AdminModel info = null;
            foreach (DataRow dr in dt.Rows)
            {
                info = PopulateModel(dr, new AdminModel());
                if (info != null)
                    list.Add(info);
            }

            return list;
        }

        private static AdminModel PopulateModel(DataRow dr, AdminModel entity)
        {
            if (dr == null)
                return null;

            AdminModel baseEntity = (AdminModel)Activator.CreateInstance(entity.GetType());
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
