using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using MySql.Data.MySqlClient;

using OdnShop.Core.Common;
using OdnShop.Core.Model;

namespace OdnShop.Core.Factory
{
    public class UserGroupFactory
    {
        public static void Add(UserGroupModel model)
        {
            string sql = "INSERT INTO odnshop_usergroup(groupid,groupname,picurl,grouplevel,isdefalut,upgradejf,discount) VALUES(?groupid,?groupname,?picurl,?grouplevel,?isdefalut,?upgradejf,?discount)";

            MySqlParameter[] parameters = {
                    new MySqlParameter("?groupid", MySqlDbType.Int32,11),
                    new MySqlParameter("?groupname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?picurl", MySqlDbType.VarChar,50),
                    new MySqlParameter("?grouplevel", MySqlDbType.Int32,11),
                    new MySqlParameter("?isdefalut", MySqlDbType.Int32),
                    new MySqlParameter("?upgradejf", MySqlDbType.Int32,11),
                    new MySqlParameter("?discount", MySqlDbType.Int32,11)
             };

            parameters[0].Value = model.groupid;
            parameters[1].Value = model.groupname;
            parameters[2].Value = model.picurl;
            parameters[3].Value = model.grouplevel;
            parameters[4].Value = model.isdefalut?1:0;
            parameters[5].Value = model.upgradejf;
            parameters[5].Value = model.discount;

            MySqlDbHelper.ExecuteSql(sql, parameters);
        }

        public static void Delete(int groupid)
        {
            string sql = "delete from odnshop_usergroup where groupid=" + groupid.ToString();

            MySqlDbHelper.ExecuteSql(sql);
        }

        public static void Update(UserGroupModel info)
        {
            string sql = "UPDATE odnshop_usergroup set groupname=?groupname,picurl=?picurl,grouplevel=?grouplevel,isdefalut=?isdefalut,upgradejf=?upgradejf,discount=?discount where groupid=?groupid";
            MySqlParameter[] parameters = {
                MySqlDbHelper.MakeInParam("?groupname" , MySqlDbType.VarChar , 50 ,info.groupname) ,
                MySqlDbHelper.MakeInParam("?picurl" , MySqlDbType.VarChar , 50 ,info.picurl) ,
                MySqlDbHelper.MakeInParam("?grouplevel" , MySqlDbType.VarChar , 100 ,info.grouplevel) ,
                MySqlDbHelper.MakeInParam("?isdefalut" , MySqlDbType.Int32 , 4 ,info.isdefalut?1:0),
                MySqlDbHelper.MakeInParam("?upgradejf" , MySqlDbType.Int32 , 4 ,info.upgradejf),
                MySqlDbHelper.MakeInParam("?discount" , MySqlDbType.Date , 8 ,info.discount),
                MySqlDbHelper.MakeInParam("?groupid" , MySqlDbType.Int32 , 4 ,info.groupid)
            };

            MySqlDbHelper.Query(sql, parameters);
        }

        public static UserGroupModel Get(int groupid)
        {
            string sql = "select * from odnshop_usergroup where groupid=" + groupid;
            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            UserGroupModel info = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info = PopulateModel(dr, new UserGroupModel());
            }

            return info;
        }

        public static UserGroupModel GetDefault()
        {
            List<UserGroupModel> list = GetList("where isdefalut=1");
            if (list.Count > 0)
                return list[0];

            return null;
        }

        public static List<UserGroupModel> GetList(string whereSql)
        {
            string sql = string.Format("select * from odnshop_usergroup {0} order by grouplevel asc", whereSql);

            DataTable dt = MySqlDbHelper.Query(sql).Tables[0];

            List<UserGroupModel> list = new List<UserGroupModel>();
            UserGroupModel info = null;
            foreach (DataRow dr in dt.Rows)
            {
                info = PopulateModel(dr, new UserGroupModel());
                list.Add(info);
            }

            return list;
        }

        public static List<UserGroupModel> GetAll()
        {
            return GetList("");
        }

        private static UserGroupModel PopulateModel(DataRow dr, UserGroupModel entity)
        {
            if (dr == null)
                return null;

            UserGroupModel baseEntity = (UserGroupModel)Activator.CreateInstance(entity.GetType());
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
