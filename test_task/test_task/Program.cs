using System;

namespace test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Количество стульев 

            Console.Write("Сколько стульев за покерным столом?:\t");
            int elementsCount = int.Parse(Console.ReadLine());

            // Количество фишек

            int[] nums = new int[elementsCount];
            Console.WriteLine("Введите количество фишек за каждым из мест");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("Количество фишек за {0} местом:\t", i + 1);
                nums[i] = Int32.Parse(Console.ReadLine());
            }

            // Сумма массива и должное число фишек

            static int Sum(int[] nums, int i = 0)
            {
                if (i >= nums.Length)
                    return 0;

                int result = Sum(nums, i + 1);

                return nums[i] + result;
            }

            int result = Sum(nums);
            int chips_avg = result / elementsCount;

            Console.WriteLine(chips_avg);
            Console.ReadLine();

            // Сортировка массива

            
            int moves = 0;
            bool condition;
            do
            {
                condition = false;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > chips_avg)
                    {
                        Console.WriteLine("Раскидываем {0}-й стек", i + 1);
                        condition = true;
                        Console.WriteLine(condition);
                        if (i < nums.Length - i + 1)
                        {
                            int chips_excess_backward = (nums[i] - chips_avg);
                            moves = moves + chips_excess_backward;
                            try
                            {
                                nums[i - 1] = nums[i - 1] + chips_excess_backward;
                                nums[i] = nums[i] - chips_excess_backward;
                            }
                            catch(IndexOutOfRangeException)
                            {
                                nums[elementsCount - 1] = nums[elementsCount - 1] + chips_excess_backward;
                                nums[i] = nums[i] - chips_excess_backward;

                            }
                        }
                        else
                        {
                            int chips_excess_forward = (nums[i] - chips_avg);
                            moves = moves + chips_excess_forward;
                            try
                            {
                                nums[i + 1] = nums[i + 1] + chips_excess_forward;
                                nums[i] = nums[i] - chips_excess_forward;

                            }
                            catch(IndexOutOfRangeException)
                            {
                                nums[0] = nums[0] + chips_excess_forward;
                                nums[i] = nums[i] - chips_excess_forward;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                    Console.WriteLine(nums[i]);
                }
            }
            while (condition);



            // Результат сортировки 

            Console.WriteLine("Вывод отсортированного массива");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            Console.WriteLine("Количество необходимых ходов:");
            Console.WriteLine(moves);
            Console.ReadLine();

        }   
    }
}
