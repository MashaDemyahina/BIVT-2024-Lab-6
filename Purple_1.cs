﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public double[] Coefs
            {
                get
                {
                    double[] copy = new double[4];
                    _coefs.CopyTo(copy, 0);
                    return copy;
                }
            }
            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[4, 7];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public double TotalScore
            {
                get
                {
                    double rez = 0;
                    for (int i=0; i<4; i++)//прыжки
                    {
                        int mi = int.MaxValue;
                        int ma = int.MinValue;
                        int sum = 0;//сумма всех оценок за прыжок
                        for (int j=0; j<7; j++)//оценки судей
                        {
                            int A = Marks[i, j];
                            if (A > ma) ma = A;
                            if (A < mi) mi = A;
                            sum += A;
                        }
                        sum -= ma;
                        sum -= mi;
                        rez += sum * Coefs[i];
                    }
                    return rez;
                }
            }
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[,] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
               
            }
            //методы
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length!=4) return;
                foreach (double x in coefs)
                {
                    if (x < 2.5 || x > 3.5) return;
                }
                Array.Copy(coefs, _coefs, 4);
            }
            
            public void Jump(int[] marks)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        int col = i % marks.Length;
                        int row = j % marks.Length;

                        _marks[col, row] = marks[i * 7 + j];
                    }
                }
            }
            public void Print()
            {
                
                Console.WriteLine($"Имя: {Name}. Фамилия: {Surname}. Результат: {TotalScore}");

            }
            public static void Sort(List<Participant> array)
            {
                if (array == null || array.Count == 0) return;
                List<Participant> array1 = array.OrderByDescending(x => x.TotalScore).ToList();
                for (int i = 0; i < array1.Count; i++)
                {
                    array1[i].Print();
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                array = array.OrderByDescending(x => x.TotalScore).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].Print();
                }
            }
        }
    }
}
