using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Distance { get { return _distance; } }
            public int[] Marks 
            { 
                get 
                {
                    int[] copy = new int[5];
                    _marks.CopyTo(copy, 0);
                    return copy;
                } 
            }
            public int Result
            {
                get 
                {
                    int rez = 0;
                    int mi = int.MaxValue;
                    int ma = int.MinValue;

                    for (int i=0; i<Marks.Length; i++)
                    {
                        if (Marks[i]>ma) ma= Marks[i];
                        if (Marks[i]< mi) mi= Marks[i];
                        rez += Marks[i];
                    }
                    rez -= ma;
                    rez -=mi;
                    if (Distance == 120) rez += 60;
                    else if (Distance>120)
                    {
                        rez += 60;
                        rez += (Distance - 120) * 2;
                    }
                    else
                    {
                        rez += (60 - (120 - Distance) * 2);
                    }
                    return rez;
                }
            }

            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }
            public void Jump (int distance, int[] marks)
            {
                if (distance < 0) return;
                if (marks == null || marks.Length!=5) return;
                _distance= distance;
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[i]= marks[i];
                }
            }
            public static void Sort(List<Participant> array)
            {
                if (array == null || array.Count == 0) return;
                List<Participant> array1 = array.OrderByDescending(x => x.Result).ToList();
                for (int i = 0; i < array1.Count; i++)
                {
                    array1[i].Print();
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                array = array.OrderByDescending(x => x.Result).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].Print();
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {Name}. Фамилия: {Surname}. Результат: {Result}");
            }
        }
    }
}
