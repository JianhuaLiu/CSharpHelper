using Ninesky.IDAL;

namespace Ninesky.DAL
{
    /// <summary>
    /// 简单工厂用来返回公共方法
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// 用户
        /// </summary>
        public static InterfaceUserRepository UserPrository { get { return new UserRepository(); } }
    }
}