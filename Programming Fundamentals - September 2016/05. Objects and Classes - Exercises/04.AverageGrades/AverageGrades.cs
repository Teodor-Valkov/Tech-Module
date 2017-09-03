namespace _04.AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        //public double AverageGrade => Grades.Average();
        public double AverageGrade
        {
            get { return Grades.Average(); }
        }
    }

    internal class AverageGrades
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> studentsAndGrades = new List<string>();
            List<Student> allStudentsWithHighGrades = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                studentsAndGrades.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                Student currentStudent = new Student();
                string[] nameAndGrades = studentsAndGrades[i].Split(' ');

                currentStudent.Name = nameAndGrades[0];
                currentStudent.Grades = new List<double>();

                for (int j = 1; j < nameAndGrades.Length; j++)
                {
                    double currentGrade = double.Parse(nameAndGrades[j]);
                    currentStudent.Grades.Add(currentGrade);
                }

                if (currentStudent.AverageGrade >= 5.00)
                {
                    allStudentsWithHighGrades.Add(currentStudent);
                }
            }

            allStudentsWithHighGrades = allStudentsWithHighGrades.OrderBy(x => x.Name).ThenByDescending(s => s.AverageGrade).ToList();

            foreach (Student student in allStudentsWithHighGrades)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
            }
        }
    }
}