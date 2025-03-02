using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_1;
using static Lab_6.Purple_4;
using static Lab_6.Purple_5;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //A();
            //B();
            C();
            //D();
            //E();

        }
        static void A()
        {
            var names = "Дарья,Тихонова,Александр,Козлов,Никита,Павлов,Юрий,Луговой,Юрий,Степанов,Мария,Луговая,Виктор,Жарков,Марина,Иванова,Марина,Полевая,Максим,Тихонов".Split(',');
            var jumps = "3,4,1,2,1,3,1,5,3,4,3,3,3,3,2,4,1,5,6,1,2,6,4,3,2,2,1,1,3,5,4,4,5,1,4,1,6,5,2,1,4,1,6,2,4,1,2,6,5,6,5,2,2,4,3,4,1,1,3,5,5,5,2,4,1,1,2,2,2,5,5,2,3,3,2,2,3,3,1,3,4,2,4,5,3,3,5,2,1,2,4,5,5,4,2,3,2,2,6,3,1,2,2,6,6,5,1,6,6,3,2,5,4,3,5,4,5,1,1,5,3,4,2,1,1,2,2,2,4,2,6,3,4,3,2,1,3,5,1,5,6,5,5,4,2,6,4,5,4,3,2,4,6,1,1,1,3,4,4,1,6,3,1,5,1,4,3,1,4,6,1,4,5,3,4,1,2,3,1,5,4,3,3,6,2,3,1,6,3,3,3,6,6,3,6,6,6,5,3,2,6,5,3,5,4,4,2,1,2,4,4,2,2,5,1,3,1,6,5,6,1,6,3,3,3,6,3,5,4,2,3,4,6,1,4,2,1,5,1,1,3,1,3,2,6,1,4,4,6,6,2,5,3,3,1,4,5,6,2,6,4,5,4,2,3,1,3,3,4,2,2,3,6,5,1,5,5,1,3,4".Split(',');
            var crids = new double[] { 2.58, 2.90, 3.04, 3.43, 2.95, 2.63, 3.16, 2.89, 2.56, 3.40, 2.91, 2.69, 2.86, 2.90, 3.19, 3.14, 2.81, 2.64, 2.76, 3.20, 2.74, 3.30, 2.94, 3.27, 2.57, 2.79, 2.71, 3.46, 3.09, 2.67, 2.90, 3.50, 2.65, 3.47, 3.11, 3.39, 3.14, 3.46, 2.96, 2.76 };
            var part = new Purple_1.Participant[10];
            int ind = 0;
            for (int i = 0; i < 10; i++)
            {
                part[i] = new Purple_1.Participant(names[i * 2], names[i * 2 + 1]);
                var crid = new double[4];
                for (int j = 0; j < 4; j++)
                    crid[j] = crids[i * 4 + j];
                part[i].SetCriterias(crid);
                for (int j = 0; j < 4; j++)
                {
                    int[] arr = new int[7];
                    for (int k = 0; k < 7; k++)
                    {
                        arr[k] = int.Parse(jumps[ind]);
                        ind++;
                    }
                    part[i].Jump(arr);
                }
            }

            Purple_1.Participant.Sort(part);
            foreach (var p in part)
            {
                Console.WriteLine(p.Name + " " + p.Surname + " " + p.TotalScore);
            }
        }
        static void B()
        {
            var names = "оксана,сидорова,полина,полевая,дмитрий,полевой,евгения,распутина,савелий,луговой,евгения,павлова,егор,свиридов,степан,свиридов,анастасия,козлова,светлана,свиридова".Split(',');
            var distance = "135,191,147,115,112,151,186,166,112,197".Split(',');
            var marks = "15,1,3,9,15,19,14,9,11,4,20,9,1,13,6,5,20,17,9,16,19,8,1,6,17,16,12,5,20,4,5,20,3,19,18,16,12,5,4,15,7,4,19,11,12,14,3,6,17,1".Split(',');
            var part = new Purple_2.Participant[10];
            int ind = 0;
            for (int i = 0; i < 10; i++)
            {
                part[i] = new Purple_2.Participant(names[i * 2], names[i * 2 + 1]);
                var m = new int[5];
                for (int j = 0; j < 5; j++)
                    m[j] = int.Parse(marks[ind++]);
                part[i].Jump(int.Parse(distance[i]), m);
            }

            Purple_2.Participant.Sort(part);
            foreach (var p in part)
            {
                Console.WriteLine(p.Name + " " + p.Surname + " " + p.Result);
            }


        }

        static void C()
        {

            Purple_3.Participant[] participants =
            {
                new Purple_3.Participant("Виктор", "Полевой"),
                new Purple_3.Participant("Алиса", "Козлова"),
                new Purple_3.Participant("Ярослав", "Зайцев"),
                new Purple_3.Participant("Савелий", "Кристиан"),
                new Purple_3.Participant("Алиса", "Козлова"),
                new Purple_3.Participant("Алиса", "Луговая"),
                new Purple_3.Participant("Александр", "Петров"),
                new Purple_3.Participant("Мария", "Смирнова"),
                new Purple_3.Participant("Полина", "Сидорова"),
                new Purple_3.Participant("Татьяна", "Сидорова"),
            };

            double[,] scores =
            {
                { 5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89 },
                { 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79 },
                { 2.93, 3.10, 5.46, 4.88, 3.99, 4.79, 5.56 },
                { 4.20, 4.69, 3.90, 1.67, 1.13, 5.66, 5.40 },
                { 3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73 },
                { 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68 },
                { 3.78, 3.42, 3.84, 2.19, 1.20, 2.51, 3.51 },
                { 1.35, 3.40, 1.85, 2.02, 2.78, 3.23, 3.03 },
                { 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77 },
                { 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84 },
            };

            for (int i = 0; i < participants.Length; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    participants[i].Evaluate(scores[i, j]);
                }
            }

            Purple_3.Participant.SetPlaces(participants);
            Purple_3.Participant.Sort(participants);

            for (int i = 0; i < participants.Length; i++)
            {
                participants[i].Print();
            }
        }
        static void D()
        {
            Sportsman[] firstGroupSportmans =
            {
                new Sportsman("Полина", "Луговая"),
                new Sportsman("Савелий", "Козлов"),
                new Sportsman("Екатерина", "Жаркова"),
                new Sportsman("Дмитрий", "Иванов"),
                new Sportsman("Дмитрий", "Полевой"),
                new Sportsman("Савелий", "Петров"),
                new Sportsman("Евгения", "Распутина"),
                new Sportsman("Екатерина", "Луговая"),
                new Sportsman("Мария", "Иванова"),
                new Sportsman("Степан", "Павлов"),
                new Sportsman("Ольга", "Павлова"),
                new Sportsman("Ольга", "Полевая"),
                new Sportsman("Дарья", "Павлова"),
                new Sportsman("Дарья", "Свиридова"),
                new Sportsman("Евгения", "Свиридова"),
            };

            double[] firstGroupTimes =
            {
                422.64, 142.05, 185.23,
                294.32, 79.26, 230.63,
                35.16, 376.12, 279.20,
                292.38, 467.60, 473.82,
                290.14, 368.60, 212.67
            };

            Sportsman[] secondGroupSportmans =
            {
                new Sportsman("Анастасия", "Жаркова"),
                new Sportsman("Александр", "Павлов"),
                new Sportsman("Степан", "Свиридов"),
                new Sportsman("Игорь", "Сидоров"),
                new Sportsman("Евгения", "Сидорова"),
                new Sportsman("Мария", "Сидорова"),
                new Sportsman("Лев", "Петров"),
                new Sportsman("Савелий", "Козлов"),
                new Sportsman("Егор", "Свиридов"),
                new Sportsman("Оксана", "Жаркова"),
                new Sportsman("Светлана", "Петрова"),
                new Sportsman("Полина", "Петрова"),
                new Sportsman("Екатерина", "Павлова"),
                new Sportsman("Юлия", "Полевая"),
                new Sportsman("Евгения", "Павлова"),
            };

            double[] secondGroupTimes =
            {
                112.49, 472.11, 213.92,
                102.13, 263.21, 350.75,
                248.68, 325.28, 300.00,
                252.16, 402.20, 397.33,
                384.94, 8.09, 480.52
            };

            Group firstGroup = new Group("first");
            for (int i = 0; i < firstGroupSportmans.Length; i++)
            {
                firstGroupSportmans[i].Run(firstGroupTimes[i]);
            }
            firstGroup.Add(firstGroupSportmans);

            Group secondGroup = new Group("second");
            for (int i = 0; i < secondGroupSportmans.Length; i++)
            {
                secondGroupSportmans[i].Run(secondGroupTimes[i]);
            }
            secondGroup.Add(secondGroupSportmans);
            Group merged = Purple_4.Group.Merge(firstGroup, secondGroup);
            merged.Print();
        }
        static void E()
        {
            Response[] responses =
            {
                new Response("Макака","","Манга"),
                new Response("Тануки","Проницательность","Манга"),
                new Response("Тануки","Скромность","Кимоно"),
                new Response("Кошка","Внимательность","Суши"),
                new Response("Сима_энага","Дружелюбность","Кимоно"),
                new Response("Макака","Внимательность","Самурай"),
                new Response("Панда","Проницательность","Манга"),
                new Response("Сима_энага","Проницательность","Суши"),
                new Response("Серау","Внимательность","Сакура"),
                new Response("Панда","","Кимоно"),
                new Response("Сима_энага","Дружелюбность","Сакура"),
                new Response("Кошка","Внимательность","Кимоно"),
                new Response("Панда","","Сакура"),
                new Response("Кошка","Уважительность","Фудзияма"),
                new Response("Панда","Целеустремленность","Аниме"),
                new Response("Серау","Дружелюбность",""),
                new Response("Панда","","Манга"),
                new Response("Сима_энага","Скромность","Фудзияма"),
                new Response("Панда","Проницательность","Самурай"),
                new Response("Кошка","Внимательность","Сакура")
            };

            Research research = new Research("research");

            for (int i = 0; i < responses.Length; i++)
            {
                research.Add(new[] {
                    responses[i].Animal,
                    responses[i].CharacterTrait,
                    responses[i].Concept });
            }

            string[] firstTopAnswers = research.GetTopResponses(1);
            string[] doubleTopAnswers = research.GetTopResponses(2);
            string[] thirdTopAnswers = research.GetTopResponses(3);

            for (int i = 0; i < firstTopAnswers.Length; i++)
            {
                Console.WriteLine(firstTopAnswers[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < doubleTopAnswers.Length; i++)
            {
                Console.WriteLine(doubleTopAnswers[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < thirdTopAnswers.Length; i++)
            {
                Console.WriteLine(thirdTopAnswers[i]);
            }

        }
    }
        

    }
    

