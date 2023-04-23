using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text.Encodings;
using System.Text;




namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите кол-во чисел");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите минимальное рандомное число a");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите максимальное рандомное число b");
            //int b = Convert.ToInt32(Console.ReadLine());
            //RandomBinaryFile("task1.dat", n, a, b);
            Console.WriteLine(FindKPos("C:/Users/Тая/Desktop/Homework4/Homework5/bin/Debug/net7.0/inpur-files/task2.txt", 9));
            
        }
        /// <summary>
        /// Создаёт бинарный файл из N случайных вещественных чисел в диапазоне от a до b
        /// </summary>
        /// <param name="path"></param>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        static void RandomBinaryFile(string path, int n =20, int a=-50, int b= 50)
        {
            if (n < 0) throw new ArgumentException("Число чисел должно неотрицательным");
            if (a > b) throw new ArgumentException("a должно быть меньше чем b");
            if ( path == null || path == "") throw new ArgumentNullException("Укажите имя файла");    
            var r = new Random();
            using (var bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8, false))
            {
                for (int i = 0; i < n; i++)
                    bw.Write(r.Next(a, b+1)*r.NextDouble());
            }
        }

        static int FindKPos(string path, int k)
        {
            var NumArr = File.ReadAllText(path);
            var s = Regex.Split(NumArr, @"\s+").Select(x=> Convert.ToInt32(x)).ToArray();
            if ( k>=s.Length || k<1) return -1;
            else return s[k];
        }

    }
}