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
            private int _k;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }

            }
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                    
                }
            }

            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    return Places.Sum();
                }
            }
            private int TopPlace
            {
                get
                {
                    if (_places == null) return 0;
                    return Places.Min();
                }
            }
            private double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;
                    return Marks.Sum();
                }
            }
            

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _k = 0;
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
                if (_marks == null || _k >= _marks.Length) return;
                _marks[_k] = result;
                _k++;
            }

            public void SetPlace(int judge, int place)
            {
                if (_places == null || judge < 0 || judge > _places.Length) return;
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
                    Array.Sort(participants, (x, y) =>
                    {
                        double a = 0, b = 0;

                        if (x.Marks == null)
                            a = 0;
                        else
                            a = x.Marks[j];
                        if (y.Marks == null)
                            b = 0;
                        else
                            b = y.Marks[j];
                        double raz = a - b;
                        if (raz < 0)
                            return 1;
                        else if (raz > 0)
                            return -1;
                        else
                            return 0;
                    });

                    for (int i = 0; i < participants.Length; i++)
                        participants[i].SetPlace(j, i + 1);
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

