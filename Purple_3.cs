using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Purple_3
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
                    _places.CopyTo(copy, 0);
                    return copy;
                }

            }
            public double[] Marks
            {
                get
                {
                    double[] copy = new double[7];
                    _marks.CopyTo(copy, 0);
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
            Purple_3.Participant[] sorted = array.OrderBy(p => p.Score).ThenByDescending(p => p.TotalMark).ToArray();
            Array.Copy(sorted, array, array.Length);
        }

        }
    }
}
