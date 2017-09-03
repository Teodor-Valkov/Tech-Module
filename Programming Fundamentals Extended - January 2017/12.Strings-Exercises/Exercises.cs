namespace _12.Strings_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            Placeholders();

            // Task 2
            JsonStringify();

            // Task 3
            JsonParse();

            // Task 4
            SentenceSplit();

            //Task 5
            CapitalizeWords();
        }

        private static void Placeholders()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string sentenceToProcess = inputArgs[0];
                string[] placeholderWords = inputArgs[1].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < placeholderWords.Length; i++)
                {
                    string elements = "{" + i + "}";
                    sentenceToProcess = sentenceToProcess.Replace(elements, placeholderWords[i]);
                }

                Console.WriteLine(sentenceToProcess);
            }
        }

        private static void JsonStringify()
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "stringify")
                    break;

                string[] inputArgs = input.Split(new[] { " ", ":", "-", ">", "," }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                List<int> grades = new List<int>();

                for (int i = 2; i < inputArgs.Length; i++)
                {
                    grades.Add(int.Parse(inputArgs[i]));
                }

                Student student = new Student
                {
                    Name = name,
                    Age = age,
                    Grades = grades
                };

                students.Add(student);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < students.Count; i++)
            {
                sb.Append(i == students.Count - 1
                    ? $"{{name:\"{students[i].Name}\",age:{students[i].Age},grades:[{string.Join(", ", students[i].Grades)}]}}"
                    : $"{{name:\"{students[i].Name}\",age:{students[i].Age},grades:[{string.Join(", ", students[i].Grades)}]}},");
            }

            Console.WriteLine($"[{sb}]");
        }

        private static void JsonParse()
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();
            string[] inputArgs = input.Split(new[] { "},{" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string arg in inputArgs)
            {
                string[] argElements = arg.Split(new[] { " ", "{", "}", "[", "]", ":", "-", ">", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries);
                string name = argElements[1];
                int age = int.Parse(argElements[3]);
                List<int> grades = new List<int>();

                for (int i = 5; i < argElements.Length; i++)
                {
                    grades.Add(int.Parse(argElements[i]));
                }

                Student student = new Student
                {
                    Name = name,
                    Age = age,
                    Grades = grades
                };

                students.Add(student);
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student.Grades.Any()
                    ? $"{student.Name} : {student.Age} -> {string.Join(", ", student.Grades)}"
                    : $"{student.Name} : {student.Age} -> None");
            }
        }

        private static void SentenceSplit()
        {
            string input = Console.ReadLine();
            string separators = Console.ReadLine();

            string result = input.Replace(separators, ", ");
            Console.WriteLine($"[{result}]");
        }

        private static void CapitalizeWords()
        {
            string separators = " .,-_!?:;";

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] currentSentense = input.ToLower().Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                List<string> newSentence = new List<string>();

                foreach (string currentWord in currentSentense)
                {
                    string newWord = string.Empty; ;

                    for (int i = 0; i < currentWord.Length; i++)
                    {
                        char currentLetter = currentWord[i];

                        if (i == 0)
                        {
                            newWord = currentLetter.ToString().ToUpper();
                        }
                        else
                        {
                            newWord += currentLetter;
                        }
                    }

                    newSentence.Add(newWord);
                }

                Console.WriteLine(string.Join(", ", newSentence));
            }
        }
    }

    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }
    }
}