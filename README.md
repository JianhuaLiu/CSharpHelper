# CSharpHelper
C#帮助类库，完善帮助方法。以便于后期使用

## C#帮助类库使用介绍

包含功能有：
* [Cookie](#cookie)
* [Session](#session)
* [DataSet](#dataset)
* [DateTime](#datetime)
* [泛型](#list)
* [序列化](#serialize)

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

### <a name="serialize">序列化包含功能
* Serialize<T>() 序列化
* DeSerialize<T>() 反序列化

方法具体文档，参看帮助类中，方法注释。在此不多描写