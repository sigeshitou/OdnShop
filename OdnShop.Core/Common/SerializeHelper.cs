using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OdnShop.Core.Common
{
    public class SerializeHelper
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">XML文件路径</param>
        /// <returns></returns>
        public static object LoadFromFile(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                // open the stream
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="xml">XML文本</param>
        /// <returns></returns>
        public static object LoadFromXml(Type type, string xml)
        {
            StringReader sr = new StringReader(xml);

            XmlSerializer serializer = new XmlSerializer(type);
            return serializer.Deserialize(sr);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void SaveToFile(object obj, string filename)
        {
            FileStream fs = null;
            // serialize it
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }

        public static string SaveToString(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, obj);


            return System.Text.Encoding.UTF8.GetString(ms.GetBuffer());
        }
    }
}
