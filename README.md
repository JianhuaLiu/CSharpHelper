# CSharpHelper
C#帮助类库，完善帮助方法。以便于后期使用

## C#帮助类库使用介绍

包含功能有：
* [Byte](#byte)
* [Cookie](#cookie)
* [Session](#session)
* [DataSet](#dataset)
* [DateTime](#datetime)
* [Http](#http)
* [Json](#json)
* [泛型](#list)
* [序列化](#serialize)
* [加密](#key)
* [日志](#log)
* [缓存](#Memory)

### <a name="byte">Byte包含功能
* ToStringByte() Byte数组转换字符串
* ToByte() 字符串转Byte

### <a name="cookie">Cookie包含功能
* SetCookie() 设置Cookie
* GetCookie() 获取Cookie
* ClearCookie() 清空Cookie
* IsCreate 是否存在

### <a name="session">Session包含功能
* SetCookie() 设置Cookie
* GetCookie() 获取Cookie
* ClearCookie() 清空Cookie
* IsCreate 是否存在

### <a name="dataset">DataSet包含功能
* ToList<T>(this DataSet,int) DataSet转换List泛型

### <a name="list">List包含功能
* ToDataSet<T>(this List<T>) List泛型转换DataSet

### <a name="datetime">DateTime包含功能
* ToUnix(this DateTime) 转换Unix时间戳
* ToDateTime(this long) 时间戳转换DateTime
* DateDiffToString() 获取时间差值字符串形式
* DateDiff() 获取时间差

### <a name="http">Http包含功能
* Request() 发送post请求、get请求

### <a name="json">Json包含功能
* ToJson() 序列化成Json对象
* JsonResult() 请求网址并返回实体

### <a name="serialize">序列化包含功能
* Serialize<T>() 序列化
* DeSerialize<T>() 反序列化

### <a name="key">加密帮助包含功能
* 哈希加密5种
* 对称加密4种
* 非对称加密3种

### <a name="log">日志包含功能
* ErrorWriteLog() 异常情况记录
* InfoWriteLog() 信息记录

### <a name="Memory">缓存包含功能
* GetCache() 获取缓存

方法具体文档，参看帮助类中，方法注释。在此不多描写
