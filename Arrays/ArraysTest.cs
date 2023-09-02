using System.Numerics;
using System.Text;

namespace Arrays
{
    internal class ArraysTest
    {
        private int[] arr;
        private int[] arr2;
        private bool Instance = false;

        bool IsntInstance(bool print = true)
        {
            if (!Instance)
                return true;
            if (print)
            {
                Ex1(); 
                Console.WriteLine();
            }
            return false;
        }

        public ArraysTest(int[] arr, int[] arr2)
        {
            this.arr = arr;
            this.arr2 = arr2;
            this.Instance = true;
        }

        public void TestAll()
        {
            Console.WriteLine("Ex1");
            ContinueOrSkip(Ex1);
            Console.WriteLine("Ex2");
            ContinueOrSkip(Ex2);
            Console.WriteLine("Ex3");
            ContinueOrSkip(Ex3);
            Console.WriteLine("Ex4");
            ContinueOrSkip(Ex4);
            Console.WriteLine("Ex5");
            ContinueOrSkip(Ex5);
            Console.WriteLine("Ex6");
            ContinueOrSkip(Ex6);
            Console.WriteLine("Ex7");
            ContinueOrSkip(Ex7);
            Console.WriteLine("Ex 8 & 12");
            ContinueOrSkip(Ex8_Ex12);
            Console.WriteLine("Ex 9 & 10");
            ContinueOrSkip(Ex9_Ex10);
            Console.WriteLine("Ex 11 & 10");
            ContinueOrSkip(Ex11_Ex10);
        }
        
        void ContinueOrSkip(Action action)
        {
            TimeSpan time = new TimeSpan(0, 0, 0, 0, 40);
            int outcome = GetYesNoOrSkip("Continue\n y == yes | n == no | s == skip");
            while (outcome == 0)
            {
                Thread.Sleep(time);
                outcome = GetYesNoOrSkip("");
            }
            Console.Clear();
            if (outcome == 1)
                action();
        }

        public void Ex1()
        {
            if (IsntInstance(false)) return;
            arr.Print();
            arr2.Print();
        }
        public void Ex2()
        {
            if (IsntInstance()) return;
            Console.WriteLine($"Array1: Avarage:{arr.AvarageValue()}");
            Console.WriteLine($"Array2: Avarage:{arr2.AvarageValue()}");
        }

        public void Ex3()
        {
            if (IsntInstance()) return;
            Console.WriteLine($"Array1: Sum: {arr.SumOfArray()}");
            Console.WriteLine($"Array2: Sum: {arr2.SumOfArray()}");
        }

        public void Ex4()
        {
            if (IsntInstance()) return;
            Console.WriteLine("After multiplying numbers that were not zogi");
            int[] arr = this.arr.Copy().MultiplyNonMod2NumsToBeMod2();
            int[] arr2 = this.arr2.Copy().MultiplyNonMod2NumsToBeMod2();
            arr.Print();
            arr2.Print();
        }

        public void Ex5()
        {
            int divide = GetInput("Input a number to divide by");
            if (IsntInstance()) return;
            Console.WriteLine($"all numbers that could be divided by {divide} without a remainder");
            arr.Print(divide);
            arr2.Print(divide);
        }

        public void Ex6()
        {
            if (IsntInstance()) return;
            
            Console.WriteLine("Maximum values and indexs of Arrays:");
            Console.WriteLine($"Array[{arr.MaxValueIndex()}] = {arr[arr.MaxValueIndex()]}");
            Console.WriteLine($"Array2[{arr2.MaxValueIndex()}] = {arr2[arr2.MaxValueIndex()]}");
        }

        public void Ex7()
        {
            if (IsntInstance()) return;
            
            Console.WriteLine($"Minimum value of Array: {arr.MinValue()}");
            Console.WriteLine($"Minimum value of Array2: {arr2.MinValue()}");
        }

        public void Ex8_Ex12()
        {
            if (IsntInstance()) return;

            Console.WriteLine($"Is Array Sorted? {arr.IsSorted()}");
            Console.WriteLine($"Is Array2 Sorted? {arr2.IsSorted()}");

            Console.WriteLine("Merging Arrays ([Sorted == Min To Max])");
            int[] combinedArray = arr.SortedCombine(arr2);
            combinedArray.Print();
        }

        public void Ex9_Ex10()
        {
            if (IsntInstance()) return;

            int num = GetInput("Input a number to count");
            while (!arr.ContainsNum(num) && !arr2.ContainsNum(num))
            {
                Console.WriteLine($"{num} is not contained in both arrays please choose a diffrent num");
                num = GetInput("Input a diffrent number to count");
            }
            int numCount = arr.CountNumber(num);
            int numCount2 = arr2.CountNumber(num);
            Console.WriteLine($"Array1 counted: {numCount} instances of {num}");
            Console.WriteLine($"Array2 counted: {numCount2} instances of {num}");
        }

        public void Ex11_Ex10()
        {
            if (IsntInstance()) return;
            int digit = GetDigit("Input a digit to count");
            while (!arr.ContainsNum(digit) && !arr2.ContainsNum(digit))
            {
                Console.WriteLine($"{digit} is not contained in both arrays please choose a diffrent digit");
                digit = GetInput("Input a diffrent digit to count");
            }
            int numCount = arr.CountDigit(digit);
            int numCount2 = arr2.CountDigit(digit);
            Console.WriteLine($"Array1 counted: {numCount} instances of {digit}");
            Console.WriteLine($"Array2 counted: {numCount2} instances of {digit}");
        }

        public static char GetKey(string userPrompt)
        {
            char Input = ' ';
            while (!char.IsWhiteSpace(Input))
            {
                Input = Console.ReadKey(true).KeyChar;
            }
            return Input;
        }
        
        public static bool GetYesOrNo(string userPrompt)
        {
            Console.WriteLine(userPrompt);
            char Input = char.ToLower(Console.ReadKey(true).KeyChar);
            while (Input != 'y' || Input != 'n')
            {
                Input = char.ToLower(Console.ReadKey(true).KeyChar);
                if (Input == 'y') { return true; }
                if (Input == 'n') { return false; }
            }
            return false;
        }

        public static int GetYesNoOrSkip(string userPrompt)
        {
            Console.WriteLine(userPrompt);
            char Input = ' ';
            while (Input != 'y' || Input != 'n' || Input != 's')
            {
                Input = char.ToLower(Console.ReadKey(true).KeyChar);
                if (Input == 'y') { return 1; }
                if (Input == 'n') { return 0; }
                if (Input == 's') { return 2; }
            }
            return 0;
        }
        public static int GetDigit(string userPrompt)
        {
            Console.WriteLine(userPrompt);
            string Input = $"{Console.ReadKey(true).KeyChar}";
            while (!char.IsDigit(Input[0]))
            {
                Input = $"{Console.ReadKey(true).KeyChar}";
            }
            return int.Parse(Input);
        }
        public static int GetInput(string userPrompt)
        {
            Console.WriteLine(userPrompt);
            string Input = "";
            while (string.IsNullOrEmpty(Input))
            {
                Input = Console.ReadLine();
            }
            Console.Clear();

            char[] sanitize = Input.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0, j = 0; i < sanitize.Length; i++)
            {
                if (char.IsDigit(sanitize[i]))
                {
                    builder.Insert(j, sanitize[i]);
                    j++;
                }
            }

            if (builder.Length < 1 || string.IsNullOrEmpty(builder.ToString())) 
            { 
                return GetInput(userPrompt); 
            }
            
            return int.Parse(builder.ToString());
        }
    }
}
