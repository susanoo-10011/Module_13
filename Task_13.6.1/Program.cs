using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task_13._6._1
{
    public class Program
    {
        public static List<string> textList = new List<string>();
        public static LinkedList<string> textLinkedList = new LinkedList<string>();


        public static void Main(string[] args)
        {
            string filePath = @"C:\Users\Егор\Downloads\Text1.txt";

            var watch = Stopwatch.StartNew();

            using (StreamReader sr = File.OpenText(filePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                    textList.Add(str);

                watch.Stop();
            }
            Console.WriteLine($"Вставка в List: {watch.Elapsed.TotalMilliseconds}  мс");


            watch.Restart();
            watch.Start();

            using (StreamReader sr = File.OpenText(filePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                    textLinkedList.AddLast(str);

                watch.Stop();
            }
            Console.WriteLine($"Вставка в LinkedList: {watch.Elapsed.TotalMilliseconds}  мс");

            Console.ReadKey();
        }
    }
}
