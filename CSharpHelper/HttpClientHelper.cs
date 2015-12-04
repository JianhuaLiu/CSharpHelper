using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CSharpHelper
{
    /// <summary>
    /// 网页请求调用帮助类，主要分为Get和Post请求
    /// </summary>
    public static class HttpClientHelper
    {
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url">请求网址</param>
        /// <param name="strContentType">设置响应头，默认application/json</param>
        /// <returns>请求返回信息</returns>
        public static string Response(string url, string strContentType = "application/json")
        {
            //设置对应的调用安全协议
            if (url.StartsWith("https"))
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                }
                catch (System.Exception ex)
                {
                    LogHelper.ErrorWriteLog(ex.Message);
                }
            }
            HttpClient httpClient = new HttpClient();
            //设置响应头为Json
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(strContentType));
            //异步请求
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            //是否成功
            if (response.IsSuccessStatusCode)
            {
                //返回内容序列化字符串，并返回
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return "";
        }

        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url">请求网址</param>
        /// <param name="postData">请求数据包</param>
        /// <param name="strContentType">设置响应头，默认application/json</param>
        /// <returns>请求返回信息</returns>
        public static string Response(string url, string postData, string strContentType = "application/json")
        {
            if (url.StartsWith("https"))
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                }
                catch (System.Exception ex)
                {
                    LogHelper.ErrorWriteLog(ex.Message);
                }
            }
            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(strContentType);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return "";
        }
    }
}