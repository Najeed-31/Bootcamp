namespace BootCamp_Assignment_02
{
    internal class Program
    {

        public class Node
        {
            public int x;
            public Node next;

            public Node(int a) 
            {
                this.x = a;
                this.next = null;
            }
        }



        


        public static void Main(string[] args)
        {
            bool running = true;
            while (running==true) 
            {
                int taskNum;
                Console.WriteLine("Enter the subtask number you want performed(1-4):");
                Console.WriteLine("Enter 0 to exit:");
                taskNum = Convert.ToInt32(Console.ReadLine());
                switch (taskNum)
                {
                    case 0:
                        Console.WriteLine("Exiting");
                        running = false;
                        break;
                    case 1:
                        Console.Write("Enter a bracketed expression: ");
                        string expression = Console.ReadLine();
                        bool value = IsBalanced(expression);
                        Console.WriteLine(value);
                        break;
                    case 2:
                        Queue<int> q = new Queue<int>();
                        Console.WriteLine("Enter 5 elements to populate a queue:");
                        for (int i = 1; i <= 5; i++)
                        {
                            q.Enqueue(Convert.ToInt32(Console.ReadLine()));
                        }
                        Console.WriteLine("Original Queue:");
                        foreach (var item in q)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        q = ReverseQueue(q);
                        Console.WriteLine("Reversed Queue:");
                        foreach (int item in q)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Node head = new Node(10);
                        head.next = new Node(20);
                        head.next.next = new Node(30);

                        Node temp = head;
                        int index = 1;
                        while (temp != null)
                        {
                            Console.Write("Node:" + index + " " + temp.x +" -> ");
                            temp = temp.next;
                            index++;
                        }
                        Console.Write("null");
                        Console.WriteLine();
                        break;
                    case 4:
                        int[] arr = new int[5];
                        Console.WriteLine("Original Array:");
                        for (int i = 0; i < 5; i++)
                        {
                            arr[i] = i + 1;
                            Console.Write(arr[i]+" ");
                        }
                        Console.WriteLine("\nEnter a value of k (the array will rotate left by k positions):");
                        int k = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Rotated Array:");
                        arr = RotateLeft(arr, k);
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(arr[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            
        }



        static bool IsBalanced(string expression)
        {
            bool er = false;
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    st.Push(expression[i]);
                }
                if (expression[i] == ')')
                {
                    if (st.Count != 0)
                    {
                        st.Pop();
                    }
                    else
                    {
                        er = true;
                    }
                }
            }
            if (st.Count == 0 && er == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static Queue<int> ReverseQueue(Queue<int> queue)
        {
            Stack<int> st = new Stack<int>();
            int count = queue.Count;
            for (int i = 0; i < count; i++) 
            {
                st.Push(queue.Dequeue());
            }
            for (int j = 0; j < count; j++)
            {
                queue.Enqueue(st.Pop());
            }
            return queue;
        }


        public static int[] RotateLeft(int[] arr, int k)
        {
            Stack<int> st = new Stack<int>();

            for (int i = k; i < arr.Length; i++)
            {
                st.Push(arr[i]);
            }
            for (int j=0;j<k;j++)
            {
                st.Push(arr[j]);
            }
            for(int l=arr.Length-1;l>=0;l--)
            {
                arr[l]= st.Pop();
            }
            return arr;
        }


    }
}