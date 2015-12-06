using System.ServiceModel;

namespace WcfServiceDemo
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUser”。
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string ShowName(string name);
    }
}