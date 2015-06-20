using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

public class SerializerTools
{
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static T DeserializeItem<T>(string strXML)
                                where T : new()
        {
            T objItem;
            if (strXML.Trim().Length > 0)
            {
                StringReader rdr = new StringReader(strXML);
                XmlSerializer x = new XmlSerializer(typeof(T));
                objItem = (T)x.Deserialize(rdr);
                rdr.Close();
            }
            else
            {
                objItem = new T();
            }
            return objItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objItem"></param>
        /// <returns></returns>
        public static string SerializeItem<T>(T objItem)
        {
            string strRetVal = "";
            XmlSerializer s = new XmlSerializer(typeof(T));
            StringWriter sw = new StringWriter();
            s.Serialize(sw, objItem);
            strRetVal = sw.ToString();
            sw.Close();
            return strRetVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objItem"></param>
        /// <returns></returns>
        public static string SerializeItemUTF8<T>(T objItem)
        {
            string strRetVal = "";
            var serializer = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);
            serializer.Serialize(streamWriter, objItem);
            byte[] utf8EncodedXml = memoryStream.ToArray();
            //strRetVal = System.Text.Encoding.Default.GetString(utf8EncodedXml);
            strRetVal = System.Text.Encoding.UTF8.GetString(utf8EncodedXml);
            return strRetVal;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static List<T> DeserializeList<T>(string strXML)
        {
            StringReader rdr = new StringReader(strXML);
            XmlSerializer x = new XmlSerializer(typeof(List<T>));
            List<T> lstObjects = new List<T>();
            lstObjects = (List<T>)x.Deserialize(rdr);
            rdr.Close();

            return lstObjects;
        }


       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="lstObjects"></param>
       /// <returns></returns>
        public static string SerializeList<T>(List<T> lstObjects)
        {
            string strRetVal = "";
            XmlSerializer s = new XmlSerializer(typeof(List<T>));
            StringWriter sw = new StringWriter();
            s.Serialize(sw, lstObjects);
            strRetVal = sw.ToString();
            sw.Close();
            return strRetVal;
        }
    

}

