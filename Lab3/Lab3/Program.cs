using System;

namespace Lab3
{
    public static class ArrayUtils
    {
        public static int[] MergeArrays(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result[arr1.Length + i] = arr2[i];
            }
            return result;
        }

        public static int[] InsertElement(int[] arr, int element, int index)
        {
            int[] result = new int[arr.Length + 1];
            for (int i = 0, j = 0; i < result.Length; i++)
            {
                if (i == index)
                {
                    result[i] = element;
                }
                else
                {
                    result[i] = arr[j++];
                }
            }

            return result;
        }

        public static int[] RemoveElement(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentOutOfRangeException("Index is out of range");

            int[] result = new int[arr.Length - 1];
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (i == index) continue;
                result[j++] = arr[i];
            }

            return result;
        }

        public static int[] InsertArray(int[] arr1, int index, int[] arr2)
        {
            if (index < 0 || index > arr1.Length)
                throw new ArgumentOutOfRangeException("Index is out of range");

            int[] result = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < index; i++)
                result[i] = arr1[i];

            for (int i = 0; i < arr2.Length; i++)
                result[index + i] = arr2[i];

            for (int i = index; i < arr1.Length; i++)
                result[arr2.Length + i] = arr1[i];

            return result;
        }

        public static int[] CopyWithReplacement(int[] arr1, int start1, int[] arr2, int start2, int count)
        {
            if (start1 < 0 || start1 + count > arr1.Length || start2 < 0 || start2 + count > arr2.Length)
                throw new ArgumentOutOfRangeException("Index or count out of range");

            int[] result = new int[arr2.Length];
            for (int i = 0; i < arr2.Length; i++)
            {
                result[i] = arr2[i];
            }

            for (int i = 0; i < count; i++)
            {
                result[start2 + i] = arr1[start1 + i];
            }

            return result;
        }
    }

    internal abstract class Program
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            int[] arr2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
            Console.WriteLine(string.Join(" ", ArrayUtils.MergeArrays(arr1, arr2)));
            Console.WriteLine(string.Join(" ", ArrayUtils.InsertElement(arr1, 88, 7)));
            Console.WriteLine(string.Join(" ", ArrayUtils.RemoveElement(arr1, 9)));
            Console.WriteLine(string.Join(" ", ArrayUtils.InsertArray(arr1, 5, arr2)));
            Console.WriteLine(string.Join(" ", ArrayUtils.CopyWithReplacement(arr1, 2, arr2, 1, arr1.Length - 4)));
        }
    }
}
