using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpHelper
{
    /// <summary>
    /// XML帮助类
    /// </summary>
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化功能
        /// </summary>
        /// <typeparam name="T">需要序列化的实体类型</typeparam>
        /// <param name="model">实体类本身</param>
        /// <param name="type">序列化类型枚举。分为：BinaryFormatter，Soap，Xml</param>
        /// <param name="strUrl">序列化保存地址</param>
        /// <returns>序列化是否成功</returns>
        public static bool Serialize<T>(T model, SerializeType type, string strUrl) where T : class, new()
        {
            try
            {
                using (FileStream fs = new FileStream(strUrl, FileMode.Create))
                {
                    switch (type)
                    {
                        case SerializeType.BinaryFormatter:
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(fs, model);
                                break;
                            }
                        case SerializeType.Soap:
                            {
                                SoapFormatter formatter = new SoapFormatter();
                                formatter.Serialize(fs, model);
                                break;
                            }
                        case SerializeType.Xml:
                            {
                                XmlSerializer formatter = new XmlSerializer(typeof(T));
                                formatter.Serialize(fs, model);
                                break;
                            }
                        default:
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">需要序列化的实体类型</typeparam>
        /// <param name="type">序列化类型</param>
        /// <param name="strUrl">存储地址</param>
        /// <returns>返回实体</returns>
        public static T DeSerialize<T>(SerializeType type, string strUrl) where T : class, new()
        {
            using (FileStream fs = new FileStream(strUrl, FileMode.Open))
            {
                T model = new T();
                switch (type)
                {
                    case SerializeType.BinaryFormatter:
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            model = (T)formatter.Deserialize(fs);
                            break;
                        }
                    case SerializeType.Soap:
                        {
                            SoapFormatter formatter = new SoapFormatter();
                            model = (T)formatter.Deserialize(fs);
                            break;
                        }  
                    case SerializeType.Xml:
                        {
                            XmlSerializer formatter = new XmlSerializer(typeof(T));
                            model = (T)formatter.Deserialize(fs);
                            break;
                        }
                    default:
                        break;
                }
                return model;
            }
        }
    }

    /// <summary>
    /// 序列化选择类
    /// 三种不同的选择类型
    /// </summary>
    public enum SerializeType
    {
        /// <summary>
        /// 以缩略型二进制格式写到一个文件中去，速度比较快，而且写入后的文件已二进制保存有一定的保密效果。
        /// </summary>
        BinaryFormatter,
        /// <summary>
        /// 简单对象访问协议（SOAP），是一种轻量的、简单 的、基于XML的协议，它被设计成在WEB上交换结构化的和固化的信息。
        /// </summary>
        Soap,
        /// <summary>
        /// 一般Xml
        /// </summary>
        Xml
    }
}
