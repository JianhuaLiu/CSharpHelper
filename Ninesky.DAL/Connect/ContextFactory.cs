using System.Runtime.Remoting.Messaging;

namespace Ninesky.DAL
{
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static NineskDbContext GetCurrentContext()
        {
            //使用数据槽(CallContext)保证唯一性
            NineskDbContext _nContext = CallContext.GetData("NineskyContext") as NineskDbContext;
            if (_nContext == null)
            {
                _nContext = new NineskDbContext();
                CallContext.SetData("NineskyContext", _nContext);
            }
            return _nContext;
        }
    }
}