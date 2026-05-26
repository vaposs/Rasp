using System;

namespace ZD_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Clamp(15, 10, 20));
            //Console.WriteLine(Clamp(15,10,2));
        }

        public static int Clamp(int value, int min, int max)
        {
            if (min < max)
            {
                if (value < min)
                    return min;
                else if (value > max)
                    return max;
                else
                    return value;
            }
            else
            {
                throw new ArgumentException($"некоректные входные данные (min={min}> max={max})");
            }
        }
    }
}
