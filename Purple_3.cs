using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _places;
            private double[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Places
            {
                get
                {
                    int[] copy = new int[7];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }

            }
            public double[] Marks
            {
                get
                {
                    double[] copy = new double[7];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                    
                }
            }

            public int Score => Places.Sum();
            public int TopPlace => Places.Min();
            public double TotalMark => Marks.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _places = new int[7];
                _marks = new double[7];
            }

            public void Evaluate(double result)
            {
                if (result < 0.0 || result > 6.0)
                {
                    Console.WriteLine("Оценка может быть только от 0 до 6");
                    return;
                }

                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] != 0)
                    {
                        continue;
                    }

                    _marks[i] = result;
                    return;
                }
            }

            public void SetPlace(int judge, int place)
            {
                _places[judge] = place;
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}. Surname: {Surname}. TotalScore: { Score}. TopPlace: { TopPlace}. TotalMark: { TotalMark}");
            }
            public static void SetPlaces(Participant[] participants)
        {
            if (participants == null) return;
            for (int j = 0; j < 7; j++)
            {
                Purple_3.Participant[] sorted = participants.OrderByDescending(p => p.Marks[j]).ToArray();

                for (int i = 0; i < sorted.Length; i++)
                {
                    int index = Array.IndexOf(participants, sorted[i]);
                    participants[index].SetPlace(j, i + 1);
                }
            }
        }

        public static void Sort(Participant[] array)
        {
            
                if (array == null) return;
                foreach (var x in array)
                {
                    if (x.Places == null) return;
                }
                Array.Sort(array, (x, y) =>
                {
                    if (x.Score == y.Score)
                    {
                        if (x.TopPlace == y.TopPlace)
                        {
                            double z = x.TotalMark - y.TotalMark;
                            if (z < 0) return 1;
                            else if (z > 0) return -1;
                            else return 0;
                        }
                        return x.TopPlace - y.TopPlace;
                    }
                    return x.Score - y.Score;
                });
            }

        }
    }
}
