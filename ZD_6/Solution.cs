using System;

namespace ZD_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //int[] numbers2 = null;
            int number = 5;

            Console.WriteLine(SeachIndexElementInArray(numbers, number));
        }

        public static int SeachIndexElementInArray(int[] array, int element)
        {
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                    if (array[i] == element)
                        return i;

                return -1;
            }
            else
            {
                throw new ArgumentException("не инициализирован массив", nameof(array));
            }
        }
    }
}
