using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_13._6._2
{
    public static class Program
    {
        public static List<string> textLinkedList = new List<string>();
        public static void Main(string[] args)
        {
            string filePath = @"C:\Users\Егор\Downloads\Text1.txt";

            //Чтение файла
            string text = "";
            using (StreamReader sr = File.OpenText(filePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                    text += str;
            }

            string noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] wordsArray = noPunctuationText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // Подсчет встречаемости слов
            foreach (string word in wordsArray)
            {
                if (wordCount.ContainsKey(word))
                {
                    // Увеличение счетчика для уже встречавшегося слова
                    wordCount[word]++;
                }
                else
                {
                    // Добавление нового слова в словарь с начальным счетчиком 1
                    wordCount[word] = 1;
                }
            }

            // Вывод результатов подсчета
            foreach (var pair in wordCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            // Сортировка словаря по значению в убывающем порядке
            var sortedWordCount = wordCount.OrderByDescending(pair => pair.Value);

            Console.WriteLine();

            // Вывод 10 самых встречаемых слов
            int count = 0;
            foreach (var pair in sortedWordCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
                count++;
                if (count == 10)
                    break;
            }
        }
    }
}

