using System;

namespace CSharpHelper
{
    /// <summary>
    /// 时间方面帮助类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// DateTime转换，时间戳格式
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>Unix时间戳格式</returns>
        public static long ToUnix(this DateTime dt)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (dt.Ticks - start.Ticks) / 10000;
        }

        /// <summary>
        /// 时间戳转换，DateTime
        /// </summary>
        /// <param name="l">时间戳</param>
        /// <returns>DateTime时间格式</returns>
        public static DateTime ToDateTime(this long l)
        {
            DateTime time = DateTime.MinValue;
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            time = start.AddMilliseconds(l);
            return time;
        }

        /// <summary>
        /// 时间差值
        /// </summary>
        /// <param name="dateTime1">比较时间1</param>
        /// <param name="dateTime2">比较时间2</param>
        /// <returns>返回相差天数、小时、分钟、秒</returns>
        public static string DateDiffToString(DateTime dateTime1, DateTime dateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(dateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }

        /// <summary>
        /// 时间差值
        /// </summary>
        /// <param name="dateTime1">比较时间1</param>
        /// <param name="dateTime2">比较时间2</param>
        /// <returns>返回相差的TimeSpan</returns>
        public static TimeSpan DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts1 = new TimeSpan(dateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
    }
}