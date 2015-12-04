using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]

namespace CSharpHelper
{
    /// <summary>
    /// 需要在根目录添加Log4Net.config配置文件，文件可从开源的Github上进行下载
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// 异常情况记录
        /// 级别：Error
        /// </summary>
        /// <param name="msg">错误信息</param>
        public static void ErrorWriteLog(string msg)
        {
            ILog log = LogManager.GetLogger("logerror");
            log.Error(msg);
        }

        /// <summary>
        /// 信息记录
        /// 级别：Info
        /// </summary>
        /// <param name="msg">记录信息</param>
        public static void InfoWriteLog(string msg)
        {
            ILog log = LogManager.GetLogger("loginfo");
            log.Info(msg);
        }
    }
}