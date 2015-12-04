namespace MethodView
{
    public class OperatorDemo
    {
        private int nums = 0;

        public OperatorDemo(int num)
        {
            nums = num;
        }

        public static int operator +(OperatorDemo o1, OperatorDemo o2)
        {
            return o1.nums + o2.nums;
        }
    }
}