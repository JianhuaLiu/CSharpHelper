namespace MethodView
{
    using Newtonsoft.Json.Linq;
    using System;
    using static Color;
    using static System.Math;

    internal class CSharp6
    {
        public CSharp6()
        {
            //Getter专属自动属性
            Point po = new Point(1, 2);
            //po.x = 3; //无法赋值，因为是只读。但构造函数可以赋值

            //自动属性初始值
            int result = po.y; //1

            //使用静态成员
            //using static System.Math;
            double doub = po.Dist;
            //定义枚举同理
            var co = yello.ToString();

            //字符串插入法。定义$代表可以插入
            po.ToString();

            //表达式体方法。使用箭头函数
            po.ToString1();

            //索引初始值设定。
            po.ToJson();

            //?.运算符，如果左边为null，那么全部都是null。如果不是null，则可以执行.
            Point.FromJson(po.ToJson());

            //Nameof运算符。重载修改方法的时候也会修改
            po.Add(po);
        }
    }

    public class Point
    {
        public int x { get; }
        public int y { get; } = 1;

        public Point(int X, int Y)
        {
            x = X; y = Y;
        }

        public double Dist
        {
            get { return Sqrt(x * y); }
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public string ToString1() => $"({x},{y})";

        public JObject ToJson() => new JObject() {["x"] = x,["y"] = y };

        public static Point FromJson(JObject json)
        {
            if (json?["x"]?.Type == JTokenType.Integer)
            {
                return new Point((int)json["x"], (int)json["y"]);
            }
            return null;
        }

        public Point Add(Point point)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));
            return null;
        }
    }

    public enum Color
    {
        yello,
        black
    }
}