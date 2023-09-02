using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    //wow so cool
    internal static class ArraysExtenstions
    {
        //Reusable code
        private static bool InvalidArray(int[] array)
        {
            if (array.Length <= 0 || array is null)
            {
                Console.WriteLine("Invalid Array");
                return true;
            }
            return false;
        }
        //Ex1
        public static void Print(this int[] array)
        {
            if (InvalidArray(array)) return;
            string toPrint = "[ ";
            foreach (int num in array) {
                toPrint += $"{num}, ";
            }
            toPrint = toPrint.Remove(toPrint.Length - 2) + " ]";
            Console.WriteLine(toPrint);
        }
        //Ex2
        public static double AvarageValue(this int[] array)
        {
            if (InvalidArray(array)) return 0.0;
            return array.SumOfArray() / array.Length;
        }
        //Ex3
        public static int SumOfArray(this int[] array)
        {
            if (InvalidArray(array)) return 0;
            int sum = 0;
            foreach (int num in array)
                sum += num;
            return sum;
        }
        //Ex4
        public static int[] MultiplyNonMod2NumsToBeMod2(this int[] array)
        {
            if (InvalidArray(array)) return Array.Empty<int>();

            for (int i = 0; i < array.Length; i++)
                array[i] = array[i] % 2 == 0 ? array[i] : array[i] * 2;
            return array;
        }
        //Ex.5
        public static void Print(this int[] array, int divide)
        {
            if (InvalidArray(array)) return;
            string toPrint = "[ ";
            foreach (int num in array)
                toPrint += num % divide == 0 ? $"{num}, " : "";
            toPrint = toPrint.Remove(toPrint.Length - 2) + " ]";
            Console.WriteLine(toPrint);
        }
        //Ex6
        public static int MaxValueIndex(this int[] array)
        {
            if (InvalidArray(array)) return -1;

            int max = array[0];
            int index = -1;
            for (int i = 0; i < array.Length; i++) 
            {
                if (max < array[i]) 
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
        //Ex7
        public static int MinValue(this int[] array)
        {
            if (InvalidArray(array)) return 0;

            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }
            return min;
        }
        //Ex8
        public static bool IsSorted(this int[] array) =>
            InvalidArray(array) ? false : IsSorted(array, 1);
        private static bool IsSorted(this int[] array, int i)
        {
            if (i < array.Length)
                return array[i - 1] <= array[i] && IsSorted(array, i + 1);
            i -= 1;
            return array[i - 1] <= array[i];
        }
        //Ex9
        public static int CountNumber(this int[] array, int number)
        {
            if (InvalidArray(array)) return 0;
            int count = 0;
            foreach (int num in array)
                count += num == number ? 1 : 0;
            
            return count;
        }
        //Ex10
        public static bool ContainsNum(this int[] array, int number)
        {
            if (InvalidArray(array)) return false;
            foreach (int num in array) { if (num == number) return true; }
            return false;
        }
        //Ex11
        public static int CountDigit(this int[] array, int digit)
        {
            if (InvalidArray(array)) return 0;
            int count = 0;
            foreach (int num in array)
            {
                string digits = num.ToString();
                for (int i = 0; i < digits.Length; i++) {
                    if (int.Parse($"{digits[i]}") == digit) { count++; } 
                }
            }
            return count;
        }
        //Ex12
        public static int[] SortedCombine(this int[] array, int[] arr)
        {
            int[] combine = new int[arr.Length + array.Length];
            if (arr.Length < array.Length)//arr -> array
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    combine[i] = arr[i];
                }
                for (int i = arr.Length, j = 0; i < combine.Length && j < array.Length; i++, j++)
                {
                    combine[i] = array[j];
                }
            }
            else if (arr.Length == array.Length)// 50/50
            {
                for (int i = array.Length, j = 0; i < combine.Length && j < arr.Length; i++, j++)
                {
                    combine[i] = arr[j];
                    combine[j] = array[j];
                }
            }
            else//array -> arr
            {
                for (int i = 0; i < array.Length; i++)
                {
                    combine[i] = array[i];
                }
                for (int i = array.Length, j = 0; i < combine.Length && j < arr.Length; i++, j++)
                {
                    combine[i] = arr[j];
                }
            }
            return BubbleSort(combine);
        }
        static int[] BubbleSort(int[] bubble)
        {
            int TempSort;
            int tempIndx;
            for (int i = 0; i < bubble.Length - 1; i++)
            {
                for (int j = 0; j < bubble.Length - 1; j++)
                {//brute force go brrrrrrrrrrr
                    tempIndx = j + 1;
                    TempSort = bubble[j];
                    if (bubble[tempIndx] < bubble[j])
                    {
                        bubble[j] = bubble[tempIndx];
                        bubble[tempIndx] = TempSort;
                    }
                }
            }
            return bubble;
        }
        //Utills
        public static int[] Copy(this int[] array)
        {
            int[] copy = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }
    }
}
