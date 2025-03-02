using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _timeAlreadySet;
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
            public double Time
            {
                get
                {
                    
                    return _time;
                }
            }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
                _timeAlreadySet = false;
            }

            public void Run(double time)
            {
                if (_timeAlreadySet) return;
                _time = time;
                _timeAlreadySet = true;
            }
            public void Print()
            {
                Console.WriteLine($"Name: {Name}, Surname: {Surname}, Time: {Time}");
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    return (Sportsman[])_sportsmen.Clone();
                }
            }

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group)
            {
                _name = group.Name;
                if (group.Sportsmen != null)
                {
                    _sportsmen = new Sportsman[group.Sportsmen.Length];
                    Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);
                }
                else _sportsmen = new Sportsman[0];
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                _sportsmen=_sportsmen.Append(sportsman).ToArray();

            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null|| sportsmen==null) return;
                _sportsmen = _sportsmen.Concat(sportsmen).ToArray();

            }
            public void Add(Group group)
            {
                if (_sportsmen == null|| group.Sportsmen==null) return;
                Add(group.Sportsmen);
            }
            public void Sort()
            {
                if (_sportsmen == null) return;
                Array.Sort(_sportsmen, (x, y) =>{if (x.Time < y.Time) return -1;else if (x.Time > y.Time) return 1; else return 0;});

            }
            public static Group Merge(Group group1, Group group2)
            {
                Group finalGroup = new Group("Финалисты");

                finalGroup.Add(group1);
                finalGroup.Add(group2);

                finalGroup.Sort();

                return finalGroup;
                
            }
            public void Print()
            {
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i].Print();
                }

                Console.WriteLine($"Name: {Name}.");
            }
        } 
    }
}
