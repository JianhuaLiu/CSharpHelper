using Newtonsoft.Json;

namespace CSharpHelper
{
    /// <summary>
    /// Json相关帮助类
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 转换Json
        /// </summary>
        /// <param name="obj">待转换的对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Get方式请求URL
        /// </summary>
        /// <param name="url">请求网址</param>
        /// <param name="strContentType">响应头</param>
        /// <returns>解析的对象</returns>
        public static object JsonResult(string url, string strContentType = "application/json")
        {
            string content = HttpClientHelper.Response(url, strContentType);
            return JsonConvert.DeserializeObject(content);
        }

        /// <summary>
        /// Get方式请求URL
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="url">请求网址</param>
        /// <param name="strContentType">响应头</param>
        /// <returns>序列化的实体</returns>
        public static T JsonResult<T>(string url, string strContentType = "application/json")
        {
            string content = HttpClientHelper.Response(url, strContentType);
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Post方式请求URL
        /// </summary>
        /// <param name="url">请求网址</param>
        /// <param name="postData">请求数据</param>
        /// <param name="strContentType">响应头</param>
        /// <returns>解析的对象</returns>
        public static object JsonResult(string url, string postData, string strContentType = "application/json")
        {
            string content = HttpClientHelper.Response(url, postData, strContentType);
            return JsonConvert.DeserializeObject(content);
        }

        /// <summary>
        /// Post方式请求URL
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="url">请求网址</param>
        /// <param name="postData">请求数据</param>
        /// <param name="strContentType">响应头</param>
        /// <returns>序列化的实体</returns>
        public static T JsonResult<T>(string url, string postData, string strContentType = "application/json")
        {
            string content = HttpClientHelper.Response(url, postData, strContentType);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}