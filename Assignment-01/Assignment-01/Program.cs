// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
public class PatientVisit
{
    public string Name { get; set; }
    public string VisitDate { get; set; }
    public string Reason { get; set; }
}
public class HelloWorld
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
                case 8:
                    Task8();
                    break;
                case 9:
                    Task9();
                    break;
                case 10:
                    Task10();
                    break;
                case 11:
                    Task11();
                    break;
                case 12:
                    Task12();
                    break;
                case 13:
                    Task13();
                    break;
                case 14:
                    Task14();
                    break;
                case 15:
                    Task15();
                    break;
                case 16:
                    Task16();
                    break;
                case 17:
                    Task17();
                    break;
                case 18:
                    Task18();
                    break;
                case 19:
                    Task19();
                    break;
                case 20:
                    Task20();
                    break;
                case 21:
                    Task21();
                    break;
                case 22:
                    Task22();
                    break;
                case 23:
                    Task23();
                    break;
                case 24:
                    Task24();
                    break;
                case 25:
                    Task25();
                    break;
                case 26:
                    Task26();
                    break;
                case 27:
                    Task27();
                    break;
                case 28:
                    Task28();
                    break;
                case 29:
                    Task29();
                    break;
                case 30:
                    Task30();
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
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
                Console.WriteLine(num+" is even.");
            }
            else
            {
                Console.WriteLine(num+" is odd.");
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
            int first = 0, second = 1, temp=0;
            Console.WriteLine("first N numbers of the Fibonacci series:");
            Console.Write(first + ", ");
            Console.Write(second + ", ");            
            for (int i = 2; i < num; i++)
            {
                Console.Write((first+second) + ", ");
                temp = first;
                first = second;
                second = temp + second;
            }
        }

        static void Task9()
        {
            int num;
            bool isPrime=true;
            Console.WriteLine("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            for(int i=2;i<=num/2;i++)
            {
                if (num%i==0)
                {
                    isPrime = false;
                    break;
                }
            }
            if(isPrime==false)
            {
                Console.WriteLine(num + " is not a prime number.");
            }
            else
            {
                Console.WriteLine(num + " is a prime number");
            }
        
        }
        
        static void Task10()
        {
        	int num1, num2, gcd=1;
            Console.WriteLine("Enter a number:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number:");
            num2 = Convert.ToInt32(Console.ReadLine());
            int minimum=(num1<num2)?num1:num2;
            for(int i=1;i<=minimum;i++)
            {
            	if(num1%i==0 && num2%i==0)
                {
                	gcd=i;
                }
            }
            Console.WriteLine("GCD of "+num1+" and "+num2+" is: "+gcd);
        }
    static void Task11()
    {
        int num1, num2;
        char choice;
        Console.WriteLine("Enter a number:");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter another number:");
        num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the operation you want to perform(+, -, *, /, %):");
        choice = Convert.ToChar(Console.ReadLine());
        switch(choice)
        {
            case '+':
                Console.WriteLine(num1+" + "+num2+" = "+(num1+num2));
                break;
            case '-':
                Console.WriteLine(num1+" - "+num2+" = "+(num1-num2));
                break;
            case '*':
                Console.WriteLine(num1+" x "+num2+" = "+(num1*num2));
                break;
            case '/':
                Console.WriteLine(num1+" / "+num2+" = "+(num1/num2));
                break;
            case '%':
                Console.WriteLine(num1+" % "+num2+" = "+(num1%num2));
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
        
    }
    
    static void Task12()
        {
            int num, count=0;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write(num + " has ");
            string newNum = "";
            while (num != 0)
            {
                num = num / 10;
                count++;
            }
            Console.Write(count+" digits");
        }
        
    static void Task13()
    {
        int num, temp;
        Console.WriteLine("Enter a number:");
        num = Convert.ToInt32(Console.ReadLine());
        int originalNum=num;
        string newNum = "";
        while (num != 0)
        {
            temp = num % 10;
            num = num / 10;
            newNum += Convert.ToString(temp);
        }
        num= Convert.ToInt32(newNum);
        if(originalNum==num)
        {
            Console.WriteLine(num+" is a palindrome");
        }
        else
        {
            Console.WriteLine(num+" is not a palindrome");
        }
    }
    
    static void Task14()
    {
        int num, temp,sum=0;
        Console.WriteLine("Enter a number:");
        num = Convert.ToInt32(Console.ReadLine());
        Console.Write("The sum of the digits of "+num);
        while (num != 0)
        {
            temp = num % 10;
            sum+=temp;
            num = num / 10;
        }
        Console.Write(" is: "+sum);
    }
    
    static void Task15()
    {
        int num, temp;
        double sum=0;
        Console.WriteLine("Enter a 3-digit number:");
        num = Convert.ToInt32(Console.ReadLine());
        int originalNum=num;
        string tempString =Convert.ToString(num);
        int length = tempString.Length;
        Console.Write(num);
        while (num != 0)
        {
            temp = num % 10;
            sum+=Math.Pow(temp,length);
            num = num / 10;
        }
        if(sum==originalNum)
        {
            Console.Write(" is an armstrong number.");
        }
        else
        {
            Console.Write(" is not an armstrong number.");
        }
        
    }
    
    static void Task16()
    {
        int[] numbers = new int[5];
        Console.WriteLine("Enter 5 numbers for an array of length 5:");
        for (int i=0;i<5;i++)
        {
            Console.Write("Enter element"+(i+1)+": ");
            numbers[i]=Convert.ToInt32(Console.ReadLine());
        }
        int min=numbers[0],max=numbers[0];
        for (int i=1;i<numbers.Length;i++)
        {
            if(numbers[i]<min)
                min=numbers[i];

            if(numbers[i]>max)
                max=numbers[i];
        }
        Console.WriteLine("Minimum: "+min);
        Console.WriteLine("Maximum: "+max);
    }
    
    static void Task17()
    {
        int[] numbers={58,2,13,124,78};
        Console.Write("The array is: { ");
        for(int i=0;i<numbers.Length;i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine("}");
        int num;
        bool found=false;
        Console.WriteLine("Enter a number you want to find in the array:");
        num = Convert.ToInt32(Console.ReadLine());
        for(int i=0;i<numbers.Length;i++)
        {
            if(numbers[i]==num)
            {
                Console.WriteLine(num+" found at array index: "+i);
                found=true;
            }
        }
        if (found==false)
        {
            Console.WriteLine(num+" does not exist in the array");
        }
    }
    
    static void Task18()
    {
        int[] numbers={58,2,13,124,78};
        Console.Write("The array is: { ");
        for(int i=0;i<numbers.Length;i++)
        {
            Console.Write(numbers[i]+" ");
        }
        Console.WriteLine("} before sorting");
        for(int i=0;i<numbers.Length-1;i++)
        {
            for(int j=0;j<numbers.Length-i-1;j++)
            {
                if(numbers[j]>numbers[j+1])
                {
                    int temp=numbers[j];
                    numbers[j]=numbers[j+1];
                    numbers[j+1]=temp;
                }
            }
        }
        Console.Write("Sorted array using bubble sort: { ");
        for(int i=0;i<numbers.Length;i++)
        {
            Console.Write(numbers[i]+" ");
        }
        Console.WriteLine("}");
    }
    
    
    static void Task19()
    {
        int[] numbers={58,2,13,123,78};
        int evenCount=0,oddCount=0;
        Console.Write("The array: { ");
        for(int i=0;i<numbers.Length;i++)
        {
            Console.Write(numbers[i]+" ");
            if(numbers[i]%2==0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }
        Console.WriteLine("} contains "+evenCount+" even numbers and "+oddCount+" odd numbers");
    }
    
    static void Task20()
    {
        List<string> names=new List<string>();
        Console.WriteLine("Enter the 4 names: ");
        for (int i=0;i<4;i++)
        {
            Console.Write("Enter name "+(i+1)+": ");
            string name=Console.ReadLine();
            names.Add(name);
        }
        names.Sort();
        Console.WriteLine("\nSorted names alphabetically:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
    
    
    static void Task21()
    {
        int[] numbers = new int[5];
        Console.WriteLine("Enter 5 numbers for an array of length 5:");
        for (int i=0;i<5;i++)
        {
            Console.Write("Enter element"+(i+1)+": ");
            numbers[i]=Convert.ToInt32(Console.ReadLine());
        }
        Dictionary<int,int> frequency=new Dictionary<int,int>();
        foreach(int num in numbers)
        {
            if(frequency.ContainsKey(num))
            {
                frequency[num]++;
            }
            else
            {
                frequency[num]=1;
            }
        }
        Console.WriteLine("\nFrequency of each number:");
        foreach(var pair in frequency)
        {
            Console.WriteLine("Number"+pair.Key+" appears "+pair.Value+" time(s)");
        }
    }
    
    static void Task22()
    {
        int[,]matrix1 = new int[2,2];
        int[,]matrix2 = new int[2,2];
        int[,]sumMatrix = new int[2,2];
        Console.WriteLine("\nEnter elements for Matrix 1:");
        for (int i=0;i<2;i++)
        {
            for (int j=0;j<2;j++)
            {
                Console.Write("Element ["+(i+1)+","+(j+1)+"]: ");
                matrix1[i,j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        Console.WriteLine("\nEnter elements for Matrix 2:");
        for (int i=0;i<2;i++)
        {
            for (int j=0;j<2;j++)
            {
                Console.Write("Element ["+(i+1)+","+(j+1)+"]: ");
                matrix2[i,j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        for (int i=0;i<2;i++)
        {
            for (int j=0;j<2;j++)
            {
                sumMatrix[i,j]=matrix1[i,j]+matrix2[i,j];
            }
        }
        Console.WriteLine("\nSum of the two matrices:");
        for (int i=0;i<2;i++)
        {
            for (int j=0;j<2;j++)
            {
                Console.Write(sumMatrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }
    
    static void Task23()
    {
        Console.Write("Enter a sentence: ");
        string sentence=Console.ReadLine();
        sentence=sentence.ToLower();
        int vowelCount= 0;
        for (int i=0;i<sentence.Length;i++)
        {
            char ch =sentence[i];
            if (ch == 'a'|| ch == 'e'||ch == 'i' ||ch == 'o'||ch == 'u')
            {
                vowelCount++;
            }
        }
        Console.WriteLine("The sentence '"+sentence+"' has "+vowelCount+" vowels");
    }
    
    static void Task24()
    {
        Console.Write("Enter a word or sentence: ");
        string sample=Console.ReadLine();
        string newSample=sample.ToLower().Replace(" ", "");
        string reversed ="";
        for (int i=newSample.Length-1; i>=0;i--)
        {
            reversed+=newSample[i];
        }
        if (newSample==reversed)
        {
            Console.WriteLine("'"+sample+"' is a palindrome.");
        }
        else
        {
            Console.WriteLine("'"+sample+"' is not a palindrome.");
        }
    }
    
    static void Task25()
    {
        Console.Write("Enter a sentence: ");
        string sentence=Console.ReadLine();
        string[]words=sentence.Split(' ');
        Array.Reverse(words);
        string reversedSentence=string.Join(" ",words);
        Console.WriteLine("Reversed sentence: "+reversedSentence);
    }
    
    
    static void Task26()
    {
        int[] numbers={58,2,2,124,58, 8};
        Console.Write("The array is: { ");
        for(int i=0;i<numbers.Length;i++)
        {
            Console.Write(numbers[i]+" ");
        }
        Console.WriteLine("}");
        HashSet<int>uniqueNumbers=new HashSet<int>();
        foreach(int num in numbers)
        {
            uniqueNumbers.Add(num);
        }
        Console.WriteLine("\nUnique values hash set:");
        foreach(int num in uniqueNumbers)
        {
            Console.Write(num+" ");
        }
    }
    
    static void Task27()
    {
        Dictionary<string, int> studentMarks = new Dictionary<string, int>()
        {
            { "Najeed", 85 },
            { "Shahmeer", 90 },
            { "Bukhari", 78 }
        };
        Console.WriteLine("Initial Record:");
        foreach (var record in studentMarks)
        {
            Console.WriteLine(record.Key+": "+record.Value+" marks");
        }
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Search Marks");
        Console.WriteLine("3. Update Marks");
        Console.Write("Choose an option (1-3): ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Enter student name: ");
                string nameToAdd=Console.ReadLine();
                Console.Write("Enter marks: ");
                int marksToAdd=Convert.ToInt32(Console.ReadLine());
                if (studentMarks.ContainsKey(nameToAdd))
                {
                    Console.WriteLine("Student already exists.");
                }
                else
                {
                    studentMarks[nameToAdd]=marksToAdd;
                    Console.WriteLine("Student added.");
                }
                break;
            case "2":
                Console.Write("Enter student name to search: ");
                string nameToSearch=Console.ReadLine();

                if (studentMarks.ContainsKey(nameToSearch))
                {
                    Console.WriteLine("Marks of"+nameToSearch+": "+studentMarks[nameToSearch]);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
                break;
            case "3":
                Console.Write("Enter student name to update their: ");
                string nameToUpdate=Console.ReadLine();

                if (studentMarks.ContainsKey(nameToUpdate))
                {
                    Console.Write("Enter new marks: ");
                    int newMarks=Convert.ToInt32(Console.ReadLine());
                    studentMarks[nameToUpdate]=newMarks;
                    Console.WriteLine("Marks updated.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
                break;
            default:
                Console.WriteLine("Invalid Input.");
                break;
        }
        Console.WriteLine("Final Record:");
        foreach (var record in studentMarks)
        {
            Console.WriteLine(record.Key+": "+record.Value+" marks");
        }
    }
    
    
    static void Task28()
    {
        List<PatientVisit> visits = new List<PatientVisit>
{
    new PatientVisit { Name = "Najeed", VisitDate = "2025-07-20", Reason = "Check-up" },
    new PatientVisit { Name = "Shahmeer", VisitDate = "2025-07-21", Reason = "Flu" },
    new PatientVisit { Name = "Bukhari", VisitDate = "2025-07-22", Reason = "Headache" }
};

        bool running=true;
        while (running)
        {
            Console.WriteLine("1. Add Visit");
            Console.WriteLine("2. Search Visit");
            Console.WriteLine("3. Update Visit");
            Console.WriteLine("4. Delete Visit");
            Console.Write("Choose an option (1–4): ");
            string choice=Console.ReadLine();
            bool found=false;
            switch (choice)
            {
                case "1":
                    PatientVisit newVisit=new PatientVisit();
                    Console.Write("Enter patient name: ");
                    newVisit.Name=Console.ReadLine();
                    Console.Write("Enter visit date: ");
                    newVisit.VisitDate=Console.ReadLine();
                    Console.Write("Enter reason for visit: ");
                    newVisit.Reason=Console.ReadLine();
                    visits.Add(newVisit);
                    Console.WriteLine("Visit added.");
                    break;

                case "2":
                    Console.Write("Enter patient name to search: ");
                    string searchName=Console.ReadLine();
                    
                    foreach(var visit in visits)
                    {
                        if (visit.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Name: {visit.Name}, Date: {visit.VisitDate}, Reason: {visit.Reason}");
                            found=true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("No visit found.");
                    break;

                case "3": 
                    Console.Write("Enter patient name to update: ");
                    string updateName=Console.ReadLine();
                    foreach(var visit in visits)
                    {
                        if (visit.Name.Equals(updateName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter new visit date: ");
                            visit.VisitDate=Console.ReadLine();
                            Console.Write("Enter new reason: ");
                            visit.Reason=Console.ReadLine();
                            Console.WriteLine("Visit updated.");
                            found=true;
                            break;
                        }
                    }
                    if (!found)
                        Console.WriteLine("No visit found.");
                    break;

                case "4":
                    Console.Write("Enter patient name to delete: ");
                    string deleteName=Console.ReadLine();
                    int removed=visits.RemoveAll(v=>v.Name.Equals(deleteName,StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(removed>0?"Visit deleted.": "No visit found.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
    
    
    static void Task29()
    {
        Console.WriteLine("Enter a paragraph:");
        string paragraph=Console.ReadLine();
        string[] words= paragraph.ToLower().Split(' ');
        Dictionary<string,int> wordCount=new Dictionary<string,int>();
        foreach(string word in words)
        {
            if (word=="") continue;
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word]=1;
            }
        }
        Console.WriteLine("\nWord Frequencies:");
        foreach(var pair in wordCount)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }
    
    
    static void Task30()
    {
        Console.Write("Enter desired password length: ");
        int length=int.Parse(Console.ReadLine());

        string characters="abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random random=new Random();
        string password="";

        for(int i=0;i<length;i++)
        {
            int index=random.Next(characters.Length);
            password+=characters[index];
        }

        Console.WriteLine("Generated Password: " +password);
    }
        
}