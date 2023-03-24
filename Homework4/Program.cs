using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Encodings;
using System.Globalization;

namespace Homework4
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Здравствуйте, если вы запустили эту программу,видимо вы хотите сыграть в игру,\nкоторая проверит выши знания в разных областях.");
            Console.WriteLine("Перед началом игры стоит огласить правила.\nВам предстоит ответить на 12 вопросов, ответ на каждый из которых вы узнаете в конце игры.\nВарианты ответов на вопросы будут пронумерованы цифрой от 1 до 4.\nЛюбой неверный ввод автоматически засчитывается как неверный ответ.\nНа этом правила кончаются и начинается игра. \nУдачи!:)\n");
            var lines = File.ReadAllLines("bank.txt");
            string[] question = new string[lines.Length];
            string[][] ans = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
                ans[i] = new string[4];
            int[] rightansind = new int[lines.Length];
            ReadConditionFile("bank.txt", ref question, ref ans, ref rightansind);
            int[] userans = new int[lines.Length];
            int rightanscount = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"Вопрос №{i + 1} \n{question[i]}\n");
                Console.Write("Варианты ответа: ");
                for (int j = 0; j < 4; j++)
                    Console.Write($"{j + 1}.{ans[i][j]} ");
                Console.WriteLine("\nВведите номер ответа, показавшийся вам верным");
                string taskans = Console.ReadLine();
                switch (taskans)
                {
                    case "1":
                        userans[i] = Convert.ToInt32(taskans);
                        break;
                    case "2":
                        userans[i] = Convert.ToInt32(taskans);
                        break;
                    case "3":
                        userans[i] = Convert.ToInt32(taskans);
                        break;
                    case "4":
                        userans[i] = Convert.ToInt32(taskans);
                        break;
                    default:
                        userans[i] = Convert.ToInt32("10");
                        break;
                }
            }
            for (int a = 0; a < lines.Length; a++)
                if (rightansind[a] == userans[a] - 1)
                    rightanscount++;
            rightanscount.ToString();
            Console.WriteLine($"\nПоздравляю, вы завершили свою игровую сессию ответив верно при этом на {rightanscount} вопросов");
            Console.WriteLine("\nА теперь,если желаете, можете ввести своё имя и ваш результат будет занесён в таблицу лидеров.\nХотите вексти своё имя?(введите да или нет)");
            string username = "Анонимус";
            string unconfirm = Console.ReadLine();
            unconfirm = unconfirm.ToLower();
            if (unconfirm == "да")
            {
                Console.WriteLine("Введите ваше имя");
                username = Console.ReadLine()+$" кол-во правильных ответов {rightanscount}";
                Leaderbord(username);
            }
            else if (unconfirm == "нет")
                Console.WriteLine("На нет и суда нет");
            else
                Console.WriteLine("Сочту это за нет");
        }
            
            

            
    

        static void ReadConditionFile(string path, ref string [] question, ref string[][] ans, ref int[] rightansind)
        {
            
            var lines = File.ReadAllLines(path);
            string [][] temp = new string[12] [] { new string [4], new string[4], new string[4], new string[4], new string[4], new string[4], new string [4], new string[4], new string[4], new string[4], new string[4], new string[4] };
            for (int i= 0; i<lines.Length; i++)
            {
                string line = lines[i];
                question[i] = Regex.Match(line , @".*?\?").ToString();
                ans[i] = Regex.Matches(line, @"(?<=\|\|)[\w\s\-]+(?=\=)").Select(x => x.ToString()).ToArray();
                temp[i] = Regex.Matches(line, @"(?<=\=\>)(True|False)").Select(x => x.ToString()).ToArray(); ;
                for (int j = 0; j < 4; j++)
                    if (temp[i][j] =="True")
                        rightansind[i] = j;

                
                    

                


            }

        }
        static void Leaderbord(string username)
        {
            using (var sr = new StreamWriter("leaderbord.txt", true, Encoding.Default))
            {
                sr.WriteLine(username);
            }
        }
    }
}