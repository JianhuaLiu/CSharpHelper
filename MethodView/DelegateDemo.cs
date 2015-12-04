using System;

namespace MethodView
{
    public class DelegateDemo
    {
        public DelegateDemo()
        {
            Car car = new Car();
            car.NoCallback += Method1;
            AsyncCallback asy = new AsyncCallback(CallBa);
            car.Go(asy);
        }

        public string Method1(string msg)
        {
            Console.WriteLine(msg);
            return "123";
        }

        public void CallBa(IAsyncResult iar)
        {
            Car.CarHandler carH = (Car.CarHandler)iar.AsyncState;
            string str = carH.EndInvoke(iar);
            Console.WriteLine(string.Format("测试回掉函数，传递值为：{0}", str));
        }
    }

    public class Car
    {
        public delegate string CarHandler(string msg);

        public event CarHandler NoCallback;

        public void Go(AsyncCallback ar)
        {
            NoCallback.BeginInvoke("测试调用", ar, NoCallback);
        }
    }
}