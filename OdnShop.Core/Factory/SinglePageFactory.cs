using System;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

using OdnShop.Core.Model;

namespace OdnShop.Core.Factory
{
    public class SinglePageFactory
    {
        public static void Add(SinglePageModel model)
        {
            string sql = @"INSERT INTO odnshop_singlepage(serialno ,title ,content) VALUES (?serialno,?title,?content)";

            MySqlParameter[] parameters = {
                    new MySqlParameter("?serialno", MySqlDbType.VarChar,45),
                    new MySqlParameter("?title", MySqlDbType.VarChar,200),
                    new MySqlParameter("?content", MySqlDbType.Text)};

            parameters[0].Value = model.serialno;
            parameters[1].Value = model.title;
            parameters[2].Value = model.content;

            MySqlDbHelper.ExecuteSql(sql, parameters);
        }

        public static void Delete(int pageid)
        {
            string sql = "delete from odnshop_singlepage where pageid=" + pageid;
            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void Update(SinglePageModel model)
        {
            string sql = @"update odnshop_singlepage set 
                            serialno = ?serialno,
                            title = ?title,
                            content = ?content where pageid = ?pageid";

            MySqlParameter[] parameters = {
                    new MySqlParameter("?serialno", MySqlDbType.VarChar,45),
                    new MySqlParameter("?title", MySqlDbType.VarChar,200),
                    new MySqlParameter("?content", MySqlDbType.Text),
                    new MySqlParameter("?pageid", MySqlDbType.Int32,11)};
            parameters[0].Value = model.serialno;
            parameters[1].Value = model.title;
            parameters[2].Value = model.content;
            parameters[3].Value = model.pageid;

            MySqlDbHelper.ExecuteSql(sql, parameters);
        }

        public static SinglePageModel Get(int pageid)
        {
            string sql = "select * from odnshop_singlepage where pageid = " + pageid;

            SinglePageModel info = null;

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info = PopulateModel(dr, new SinglePageModel());
            }

            return info;
        }

        public static SinglePageModel Get(string serialno)
        {
            string sql = "select * from odnshop_singlepage where serialno = '" + serialno + "'";

            SinglePageModel info = null;

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info = PopulateModel(dr, new SinglePageModel());
            }

            return info;
        }

        public static DataTable GetAll()
        {
            string sql = "select * from odnshop_singlepage  order by pageid asc";

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            return dt;
        }

        private static SinglePageModel PopulateModel(DataRow dr, SinglePageModel entity)
        {
            if (dr == null)
                return null;

            SinglePageModel baseEntity = (SinglePageModel)Activator.CreateInstance(entity.GetType());
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
