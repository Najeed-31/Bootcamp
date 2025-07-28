namespace Assignment_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int taskNum;
            Console.WriteLine("Enter the subtask number you want performed:");
            taskNum = Convert.ToInt32(Console.ReadLine());
            switch (taskNum)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
                case 7:
                    Task7();
                    break;
            }

        }

        static void Task1()
        {
            int num;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(num + " x " + i + " = " + (num * i));
            }
        }

        static void Task2()
        {
            int num;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine(num + " is even.");
            }
            else
            {
                Console.WriteLine(num + " is odd.");
            }

        }

        static void Task3()
        {
            int num1, num2, num3;
            Console.WriteLine("Enter 3 numbers:");
            Console.WriteLine("Number 1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number 2:");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number 3:");
            num3 = Convert.ToInt32(Console.ReadLine());
            if (Math.Max(num1, num2) == num1 && Math.Max(num1, num3) == num1)
            {
                Console.WriteLine(num1 + " is the maximum number");
            }
            else if (Math.Max(num1, num2) == num2 && Math.Max(num2, num3) == num2)
            {
                Console.WriteLine(num2 + " is the maximum number");
            }
            else
            {
                Console.WriteLine(num3 + " is the maximum number.");
            }

        }

        static void Task4()
        {
            int num;
            Console.WriteLine("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i < num + 1; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum from 1 to " + num + " is: " + sum);
        }

        static void Task5()
        {
            int num, temp;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write(num + " reversed is: ");
            string newNum = "";
            while (num != 0)
            {
                temp = num % 10;
                num = num / 10;
                newNum += Convert.ToString(temp);
            }
            Console.WriteLine(Convert.ToInt32(newNum));
        }

        static void Task6()
        {
            int num, fact = 1;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = num; i > 0; i--)
            {
                fact *= i;
            }
            Console.WriteLine("Factorial of " + num + " is: " + fact);
        }

        static void Task7()
        {
            int year;
            Console.WriteLine("Enter a year: ");
            year = Convert.ToInt32(Console.ReadLine());
            if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
            {
                Console.WriteLine(year + " is a leap year.");
            }
            else if (year % 4 == 0)
            {
                Console.WriteLine(year + " is a leap year.");
            }
            else
            {
                Console.WriteLine(year + " is not a leap year.");
            }
        }

        static void Task8()
        {
            int num;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());
            int first = 0, second = 1;
            Console.WriteLine("first N numbers of the Fibonacci series:");
            Console.Write(first);
            first = second;
            second = first + second;
            Console.Write(second);
            for (int i = 2; i < num; i++)
            {

            }
        }
    }
}
