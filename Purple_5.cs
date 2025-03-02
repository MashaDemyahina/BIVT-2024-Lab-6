﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _charactertrait;
            private string _concept;

            public string Animal
            {
                get 
                { 
                    return _animal;
                }

            }
            public string CharacterTrait
            {
                get
                {
                    return _charactertrait;
                }
            }
            public string Concept
            {
                get
                {
                    return _concept;
                }
            }

            public Response(string animal, string charactertrair, string concept)
            {
                _animal = animal;
                _charactertrait = charactertrair;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (questionNumber < 1 || questionNumber > 3 || responses==null) return 0;
                int k = 0;
                for (int i=0; i<responses.Length; i++)
                {
                    if (questionNumber==1)
                    {
                        if (responses[i]._animal == _animal && responses[i]._animal!=null) k++;
                    }
                    else if (questionNumber == 2)
                    {
                        if (responses[i]._charactertrait == _charactertrait && responses[i]._charactertrait != null) k++;
                    }
                    else if (questionNumber == 3)
                    {
                        if (responses[i]._concept == _concept && responses[i]._concept != null) k++;
                    }
                    
                }

                return k;
            }
            public void Print()
            {
                Console.WriteLine($"Animal: {Animal}, CharacterTrait: {CharacterTrait}, Concept: {Concept}.");
            }
        }
        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public Response[] Responses
            {
                get
                {
                    if (_responses == null) return null;
                    return (Response[])_responses.Clone();
                }
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || _responses == null) return;
                string[] answer = new string[3];
                for (int i = 0; i < Math.Min(3, answers.Length); i++)
                {
                    answer[i]= answers[i];
                }
                var response1 = new Response[_responses.Length + 1];
                Array.Copy(_responses, response1, _responses.Length);
                response1[_responses.Length] = new Response(answer[0], answer[1], answer[2]);
                _responses = response1;
            }
            public string[] GetTopResponses(int question)
            {
                question--;
                if (_responses == null || question < 0 || question > 2) return null;
                int k = 0;
                string[]answer = new string[_responses.Length];
                for (int i = 0; i < _responses.Length; i++)
                {
                    int a = 1;
                    var array1 = new string[] { _responses[i].Animal, _responses[i].CharacterTrait, _responses[i].Concept };
                    for (int j = 0; j < i; j++)
                    {
                        var array2 = new string[] { _responses[j].Animal, _responses[j].CharacterTrait, _responses[j].Concept };
                        if (array1[question] == array2[question] && array1[question]!=null)
                        {
                            a++;
                            break;
                        }
                    }
                    if (a == 1 && array1[question] != null)
                    {
                        int n = 0;
                        for (int j = 0; j < k; j++)
                        {
                            if (answer[j] == array1[question] && array1[question] != null) n++;
                        }
                        if (n == 0 && array1[question] != null && array1[question] != "")
                        {
                            answer[k] = array1[question];
                            k++;
                        }
                    }
                }
                int[] counts = new int[answer.Length];
                for (int i = 0; i < answer.Length; i++)
                {
                    var array1 = new string[] { _responses[i].Animal, _responses[i].CharacterTrait, _responses[i].Concept };
                    for (int j = 0; j < answer.Length; j++)
                    {

                        if (answer[j] != null && array1[question] == answer[j])
                        {
                            counts[j]++;
                        }
                    }
                }
                Array.Sort(counts, answer);
                Array.Reverse(answer);
                string[] answer1 = new string[Math.Min(answer.Length, 5)];
                Array.Copy(answer, answer1, 5);
                return answer1;

            }

            public void Print()
            {
                Console.WriteLine(_name);
                if (_responses == null) return;
                foreach (var x in _responses) 
                { 
                    x.Print();
                }
            }
        }
    }
}
