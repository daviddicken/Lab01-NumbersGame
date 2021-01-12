using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSequence();
        }

        //==============================
        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            int input = -1;
            try
            {
                bool toSml;
                do
                {
                    toSml = false;
                    Console.WriteLine("Please enter a number greater then zero.");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1)
                    {
                        Console.WriteLine("That numbet is less then 0 and will not work.");
                        toSml = true;
                    }
                    else
                    {
                        int[] arr = new int[input];
                        int[] filled = Populate(arr);
                        int sum = GetSum(filled);
                        int prod = GetProduct(filled, sum);
                        decimal q = GetQuotient(prod);
                        Console.WriteLine($"Your array is size {input}");
                        Console.Write("The numbers in the array are ");
                        for(int i = 0; i < filled.Length -1; i++)
                        {
                            Console.Write($"{filled[i]},");
                        }
                        Console.WriteLine(filled[filled.Length - 1]);
                        Console.WriteLine($"The sum of the array is {sum}");
                        Console.WriteLine($"{sum} * {prod / sum} = {prod}");
                        Console.WriteLine($"{prod} / {prod / q} = {q}");
                    }
                } while (toSml);
                
                
            }catch(FormatException fe)
            {
                Console.WriteLine($"That was not a number. Exception: {fe}");
            }catch(OverflowException oe)
            {
                Console.WriteLine($"Exception: {oe}");
                Console.WriteLine($"My head hurts today... Either your number was way to small or way to big");
            }catch(Exception e)
            {
                Console.WriteLine($"Not really sure what happened here. Exception: {e}");
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
        }

        //================================
        static int[] Populate(int[] arr)
        {
            string input;
     
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter a number: {i+1} of {arr.Length}");
                input = Console.ReadLine();
                arr[i] = Convert.ToInt32(input); 
            }

            return arr;
        }

        //===========================
        static int GetSum(int[] arr)
        {
            int sum = 0;
            foreach(int num in arr)
            {
                sum += num;
            }
            if (sum < 20) throw new Exception($"Value of {sum} is too low.");

            return sum;
        }

        static int GetProduct(int[] arr, int sum)
        {
            int product = -1;
            Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
            try
            {
                String input = Console.ReadLine();
                product = sum * arr[Convert.ToInt32(input)-1];
            }
            catch(IndexOutOfRangeException ie)
            {
                Console.WriteLine($"That wasn't between the numbers. Exception: {ie}");
            }

            return product;
        }

        //=====================================
        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by");
            String input = Console.ReadLine();
            
            if (Convert.ToDecimal(product) == 0 || Convert.ToDecimal(input) == 0)
            {
                Console.WriteLine("You divided by 0...");
            }
            return decimal.Divide(Convert.ToDecimal(product), Convert.ToDecimal(input));
        }
    }
}
