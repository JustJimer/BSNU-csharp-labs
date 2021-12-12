using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace TA_5
{

    public static class SortingAlgorithms
    {

        public static ulong compareCount = 0;
        public static ulong swapCount = 0;


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

        static public void MainMergeAlphabetical(IComparable[] values, int left, int mid, int right, int n)
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
                        Swap(a, i, j);
                    }
                }

                Swap(a, start, j);
                QuickSortAlphabetical(a, start, j - 1);
                QuickSortAlphabetical(a, j + 1, end);
            }
        }

        private static void Swap(string[] a, int i, int j)
        {
            string temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            ++swapCount;
        }

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

        static public void MainMergeQuantitative(string[] values, int left, int mid, int right, int n)
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

        static public void MainMergeLetters(string[] values, int left, int mid, int right, int n, char key)
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

            File.WriteAllText(Path.Combine(docPath, "output.csv"), "");
            for (int i = 0; i < res.Length; i++)
            {
                File.AppendAllText(Path.Combine(docPath, "output.csv"), res[i] + "\n");
            }


            Console.WriteLine($"array of {n} lines was sorted successfully");
            Console.WriteLine($"{type} {name} sort time {time}");

            Console.WriteLine("swaps " + SortingAlgorithms.swapCount);
            Console.WriteLine("compares " + SortingAlgorithms.compareCount);
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
                    Console.WriteLine("Enter number of lines: ");
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
                }
            }
            else if (PromptConfirmation("Use radix sort?"))
            {
                File.WriteAllText(Path.Combine(docPath, "input.csv"), "");
                Console.WriteLine("Enter number of lines: ");
                n = Int32.Parse(Console.ReadLine());
                int[] array = new int[n];
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(1, 99999);
                    File.AppendAllText(Path.Combine(docPath, "input.csv"), array[i] + "\n");
                }
                Console.WriteLine($"A new array of {n} numbers has been created.");
                stopWatch.Start();
                SortingAlgorithms.RadixSort(array);
                stopWatch.Stop();
                ResultFileOutput<int>(array, "radix", "", n, stopWatch.Elapsed.TotalMilliseconds);
            }

            bool PromptConfirmation(string confirmText)
            {
                Console.Write(confirmText + " [y/n] : ");
                ConsoleKey response = Console.ReadKey(false).Key;
                Console.WriteLine();
                return (response == ConsoleKey.Y);
            }
            Console.Read();
        }
    }
}
