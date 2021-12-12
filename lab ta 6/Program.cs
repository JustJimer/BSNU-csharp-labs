using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace TA_6
{

    public static class SortingAlgorithms
    {
        public static ulong compareCount = 0;
        public static ulong swapCount = 0;

        //Alphabetical Sorting
        public static void InsertSortAlphabetical(IComparable[] array)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                IComparable value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    ++compareCount;
                    ++swapCount;
                    array[j + 1] = array[j];
                    j--;
                }
                ++swapCount;
                array[j + 1] = value;
            }
        }

        public static void ShellSortAlphabetical(IComparable[] array)
        {
            int i, j, pos;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    IComparable value = array[i];

                    while ((j >= pos) && (array[j - pos].CompareTo(value) > 0))
                    {
                        ++compareCount;
                        ++swapCount;
                        array[j] = array[j - pos];
                        j = j - pos;
                    }
                    ++swapCount;
                    array[j] = value;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        static private void MainMergeAlphabetical(IComparable[] values, int left, int mid, int right, int n)
        {
            IComparable[] temp = new IComparable[n];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                ++compareCount;
                ++compareCount;
                ++swapCount;
                if (values[left].CompareTo(values[mid]) < 0)
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[left++];
            }

            while (mid <= right)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[mid++];
            }

            for (i = 0; i < num; i++)
            {
                ++swapCount;
                values[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortAlphabetical(IComparable[] values, int left, int right, int n)
        {
            int mid;
            ++compareCount;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortAlphabetical(values, left, mid, n);
                MergeSortAlphabetical(values, (mid + 1), right, n);

                MainMergeAlphabetical(values, left, (mid + 1), right, n);
            }
        }

        public static void QuickSortAlphabetical(string[] a, int start, int end)
        {
            int i = start;
            int j = end;

            if (j - i >= 1)
            {
                ++compareCount;
                string pivot = a[i];
                while (j > i)
                {
                    ++compareCount;
                    while (a[i].CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                        ++compareCount;
                    }
                    while (a[j].CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                        ++compareCount;
                    }
                    if (j > i)
                    {
                        ++compareCount;
                        Swap<string>(a, i, j);
                    }
                }

                Swap<string>(a, start, j);
                QuickSortAlphabetical(a, start, j - 1);
                QuickSortAlphabetical(a, j + 1, end);
            }
        }

        static public void HeapSortAlphabetical(string[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyNumbersAlphabetical(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap<string>(arr, 0, i);
                HeapifyNumbersAlphabetical(arr, i, 0);
            }
        }

        static private void HeapifyNumbersAlphabetical(string[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l].CompareTo(arr[largest]) > 0)
            {
                largest = l;
                ++compareCount;
            }

            if (r < n && arr[r].CompareTo(arr[largest]) > 0)
            {
                largest = r;
                ++compareCount;
            }

            if (largest != i)
            {
                Swap<string>(arr, i, largest);
                HeapifyNumbersAlphabetical(arr, n, largest);
                ++compareCount;
            }
        }

        //Quantitative Sorting
        public static void InsertSortQuantitative(string[] array)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                string value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].Length > value.Length))
                {
                    ++compareCount;
                    ++swapCount;
                    array[j + 1] = array[j];
                    j--;
                }
                ++swapCount;
                array[j + 1] = value;
            }
        }

        public static void ShellSortQuantitative(string[] array)
        {
            int i, j, pos;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    string value = array[i];
                    while ((j >= pos) && (array[j - pos].Length > value.Length))
                    {
                        ++compareCount;
                        ++swapCount;
                        array[j] = array[j - pos];
                        j = j - pos;
                    }
                    ++swapCount;
                    array[j] = value;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        static private void MainMergeQuantitative(string[] values, int left, int mid, int right, int n)
        {
            string[] temp = new string[n];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                ++compareCount;
                ++compareCount;
                ++swapCount;
                if (values[left].Length < values[mid].Length)
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[left++];
            }

            while (mid <= right)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[mid++];
            }

            for (i = 0; i < num; i++)
            {
                ++swapCount;
                values[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortQuantitative(string[] values, int left, int right, int n)
        {
            int mid;
            ++compareCount;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortQuantitative(values, left, mid, n);
                MergeSortQuantitative(values, (mid + 1), right, n);

                MainMergeQuantitative(values, left, (mid + 1), right, n);
            }
        }

        static public void HeapSortQuantitative(string[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyNumbersQuantitative(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap<string>(arr, 0, i);
                HeapifyNumbersQuantitative(arr, i, 0);
            }
        }

        static private void HeapifyNumbersQuantitative(string[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l].Length > arr[largest].Length)
            {
                largest = l;
                ++compareCount;
            }

            if (r < n && arr[r].Length > arr[largest].Length)
            {
                largest = r;
                ++compareCount;
            }

            if (largest != i)
            {
                Swap<string>(arr, i, largest);
                HeapifyNumbersQuantitative(arr, n, largest);
                ++compareCount;
            }
        }

        //Letters Sorting
        public static void InsertSortLetters(string[] array, char key)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                string value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].Count(x => x == key) > value.Count(x => x == key)))
                {
                    ++compareCount;
                    ++swapCount;
                    array[j + 1] = array[j];
                    j--;
                }
                ++swapCount;
                array[j + 1] = value;
            }
        }

        public static void ShellSortLetters(string[] array, char key)
        {
            int i, j, pos;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    string value = array[i];
                    while ((j >= pos) && (array[j - pos].Count(x => x == key) > value.Count(x => x == key)))
                    {
                        ++compareCount;
                        ++swapCount;
                        array[j] = array[j - pos];
                        j = j - pos;
                    }
                    ++swapCount;
                    array[j] = value;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        static private void MainMergeLetters(string[] values, int left, int mid, int right, int n, char key)
        {
            string[] temp = new string[n];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                ++compareCount;
                ++compareCount;
                ++swapCount;
                if (values[left].Count(x => x == key) < values[mid].Count(x => x == key))
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[left++];
            }

            while (mid <= right)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[mid++];
            }

            for (i = 0; i < num; i++)
            {
                ++swapCount;
                values[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortLetters(string[] values, int left, int right, int n, char key)
        {
            int mid;
            ++compareCount;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortLetters(values, left, mid, n, key);
                MergeSortLetters(values, (mid + 1), right, n, key);

                MainMergeLetters(values, left, (mid + 1), right, n, key);
            }
        }

        static public void HeapSortLetters(string[] arr, char key)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyNumbersLetters(arr, n, i, key);

            for (int i = n - 1; i > 0; i--)
            {
                Swap<string>(arr, 0, i);
                HeapifyNumbersLetters(arr, i, 0, key);
            }
        }

        static private void HeapifyNumbersLetters(string[] arr, int n, int i, char key)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && (arr[l].Count(x => x == key) > arr[largest].Count(x => x == key)))
            {
                largest = l;
                ++compareCount;
            }

            if (r < n && (arr[r].Count(x => x == key) > arr[largest].Count(x => x == key)))
            {
                largest = r;
                ++compareCount;
            }

            if (largest != i)
            {
                Swap<string>(arr, i, largest);
                HeapifyNumbersLetters(arr, n, largest, key);
                ++compareCount;
            }
        }

        //Numbers of Digits Sorting
        public static void InsertSortDigits(string[] array)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                string value = array[i];
                j = i - 1;

                while ((j >= 0) && (NumbersCounter(array[j]) > NumbersCounter(value)))
                {
                    ++compareCount;
                    ++swapCount;
                    array[j + 1] = array[j];
                    j--;
                }
                ++swapCount;
                array[j + 1] = value;
            }
        }

        public static void ShellSortDigits(string[] array)
        {
            int i, j, pos;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    string value = array[i];
                    while ((j >= pos) && (NumbersCounter(array[j - pos]) > NumbersCounter(value)))
                    {
                        ++compareCount;
                        ++swapCount;
                        array[j] = array[j - pos];
                        j = j - pos;
                    }
                    ++swapCount;
                    array[j] = value;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        static private void MainMergeDigits(string[] values, int left, int mid, int right, int n)
        {
            string[] temp = new string[n];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                ++compareCount;
                ++compareCount;
                ++swapCount;
                if (NumbersCounter(values[left]) > NumbersCounter(values[mid]))
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[left++];
            }

            while (mid <= right)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[mid++];
            }

            for (i = 0; i < num; i++)
            {
                ++swapCount;
                values[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortDigits(string[] values, int left, int right, int n)
        {
            int mid;
            ++compareCount;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortDigits(values, left, mid, n);
                MergeSortDigits(values, (mid + 1), right, n);

                MainMergeDigits(values, left, (mid + 1), right, n);
            }
        }

        static public void HeapSortDigits(string[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyNumbersDigits(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap<string>(arr, 0, i);
                HeapifyNumbersDigits(arr, i, 0);
            }
        }

        static private void HeapifyNumbersDigits(string[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && (NumbersCounter(arr[l]) > NumbersCounter(arr[largest])))
            {
                largest = l;
                ++compareCount;
            }

            if (r < n && (NumbersCounter(arr[r]) > NumbersCounter(arr[largest])))
            {
                largest = r;
                ++compareCount;
            }

            if (largest != i)
            {
                Swap<string>(arr, i, largest);
                HeapifyNumbersDigits(arr, n, largest);
                ++compareCount;
            }
        }

        static private int NumbersCounter(string str)
        {
            int counter = 0;
            foreach (char item in str)
                if (Char.IsDigit(item))
                    ++counter;
            return counter;
        }

        //Radix sort
        static public void RadixSort(int[] array)
        {
            int i, j;
            int[] tmp = new int[array.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < array.Length; ++i)
                {
                    ++swapCount;
                    ++compareCount;
                    ++compareCount;
                    bool move = (array[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        array[i - j] = array[i];
                    else
                        tmp[j++] = array[i];
                }
                Array.Copy(tmp, 0, array, array.Length - j, j);
                ++swapCount;
            }
        }

        //HeapSort
        static public void HeapSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyNumbers(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap<int>(arr, 0, i);
                HeapifyNumbers(arr, i, 0);
            }
        }

        static private void HeapifyNumbers(int[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l] > arr[largest])
            {
                largest = l;
                ++compareCount;
            }

            if (r < n && arr[r] > arr[largest])
            {
                largest = r;
                ++compareCount;
            }

            if (largest != i)
            {
                Swap<int>(arr, i, largest);
                HeapifyNumbers(arr, n, largest);
                ++compareCount;
            }
        }

        //Swap func
        private static void Swap<T>(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            ++swapCount;
        }
    }
    class Program
    {
        private static readonly string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static readonly Random random = new Random();

        public static void StringGen(int n)
        {
            int randomStrLength = 0;
            File.WriteAllText(Path.Combine(docPath, "input.csv"), "");
            for (int i = 0; i < n; i++)
            {
                randomStrLength = random.Next(2, 250);
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
                string RandomStr = new string(Enumerable.Repeat(chars, randomStrLength).Select(s => s[random.Next(s.Length)]).ToArray());
                File.AppendAllText(Path.Combine(docPath, "input.csv"), RandomStr + "\n");
            }
        }

        public static void ResultFileOutput<T>(T[] res, string name, string type, int n, double time)
        {
            Console.WriteLine("sort complete, creating result file...");
            Console.WriteLine("compares " + SortingAlgorithms.compareCount);
            Console.WriteLine("swaps " + SortingAlgorithms.swapCount);
            File.WriteAllText(Path.Combine(docPath, "output.csv"), "");
            for (int i = 0; i < res.Length; i++)
            {
                File.AppendAllText(Path.Combine(docPath, "output.csv"), res[i] + "\n");
            }
            Console.WriteLine($"array of {n} lines was sorted successfully");
            Console.WriteLine($"{type} {name} sort time {time}");
        }

        private static bool PromptConfirmation(string confirmText)
        {
            Console.Write(confirmText + " [y/n] : ");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            return (response == ConsoleKey.Y);
        }

        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            string sourceFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "input.csv");
            int n;
            File.AppendAllText(sourceFilePath, "");

            if (PromptConfirmation("Work with string array?"))
            {
                if (PromptConfirmation("Create array new sequence of lines?"))
                {
                    Console.Write("Enter number of lines: ");
                    n = Int32.Parse(Console.ReadLine());
                    StringGen(n);
                    Console.WriteLine($"A new sequence of {n} lines has been created.");
                }
                else
                    n = File.ReadLines(sourceFilePath).Count();
                string[] sourceFile = File.ReadAllLines(sourceFilePath);

                if (PromptConfirmation("Sort alphabetically?"))
                {
                    if (PromptConfirmation("Use insertion sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.InsertSortAlphabetical(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "insertion", "alphabetical", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use shell sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.ShellSortAlphabetical(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "shell", "alphabetical", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use merge sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.MergeSortAlphabetical(sourceFile, 0, n - 1, n);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "merge", "alphabetical", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use quick sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.QuickSortAlphabetical(sourceFile, 0, n - 1);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "quick", "alphabetical", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use heap sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.HeapSortAlphabetical(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "heap", "alphabetical", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                }

                else if (PromptConfirmation("Sort by number of characters?"))
                {
                    if (PromptConfirmation("Use insertion sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.InsertSortQuantitative(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "insertion", "quantitative", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use shell sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.ShellSortQuantitative(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "shell", "quantitative", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use merge sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.MergeSortQuantitative(sourceFile, 0, n - 1, n);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "merge", "quantitative", n, stopWatch.Elapsed.TotalMilliseconds);

                    }
                    else if (PromptConfirmation("Use heap sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.HeapSortQuantitative(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "heap", "quantitative", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                }

                else if (PromptConfirmation("Sort by number of specific letter?"))
                {
                    Console.WriteLine("Enter a character (from a to z):");
                    char key = Console.ReadLine()[0];

                    if (PromptConfirmation("Use insertion sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.InsertSortLetters(sourceFile, key);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "insertion", $"letter {key}", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use shell sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.ShellSortLetters(sourceFile, key);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "shell", $"letter {key}", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use merge sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.MergeSortLetters(sourceFile, 0, n - 1, n, key);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "merge", $"letter {key}", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use heap sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.HeapSortLetters(sourceFile, key);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "heap", $"letter {key}", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                }

                else if (PromptConfirmation("Sort by number of digits?"))
                {
                    if (PromptConfirmation("Use insertion sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.InsertSortDigits(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "insertion", $"number of digits", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use shell sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.ShellSortDigits(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "shell", $"number of digits", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use merge sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.MergeSortDigits(sourceFile, 0, n - 1, n);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "merge", $"number of digits", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                    else if (PromptConfirmation("Use heap sort?"))
                    {
                        stopWatch.Start();
                        SortingAlgorithms.HeapSortDigits(sourceFile);
                        stopWatch.Stop();
                        ResultFileOutput<string>(sourceFile, "heap", $"number of digits", n, stopWatch.Elapsed.TotalMilliseconds);
                    }
                }
            }
            else
            {
                Console.WriteLine("Using radix/heap sort");
                File.WriteAllText(Path.Combine(docPath, "input.csv"), "");
                Console.Write("Enter number of lines: ");
                n = Int32.Parse(Console.ReadLine());
                int[] array = new int[n];
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(1, 99999);
                    File.AppendAllText(Path.Combine(docPath, "input.csv"), array[i] + "\n");
                }
                Console.WriteLine($"A new array of {n} numbers has been created.");

                if (PromptConfirmation("Use radix sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.RadixSort(array);
                    stopWatch.Stop();
                    ResultFileOutput<int>(array, "radix", "", n, stopWatch.Elapsed.TotalMilliseconds);
                }
                else if (PromptConfirmation("Use heap sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.HeapSort(array);
                    stopWatch.Stop();
                    ResultFileOutput<int>(array, "heap", "", n, stopWatch.Elapsed.TotalMilliseconds);
                }
            }
            Console.Read();
        }
    }
}