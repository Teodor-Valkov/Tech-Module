namespace _10.StudentGroup
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }

    class StudentGroups
    {
        static void Main()
        {
            List<Town> towns = ReadTownsAndStudents();
            List<Group> groups = DistributeStudentsIntoGroups(towns);

            PrintTheGroupsOnTheConsole(towns, groups);
        }

        private static List<Town> ReadTownsAndStudents()
        {
            List<Town> towns = new List<Town>();
            int counter = -1;

            string inputLine = Console.ReadLine();

            while (inputLine != null && inputLine.ToLower() != "end")
            {
                if (inputLine.Contains("=>"))
                {
                    string[] townParameters = inputLine.Split(new [] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] seats = townParameters[1].Trim().Split();

                    string townName = townParameters[0].Trim();
                    int seatsCount = int.Parse(seats[0].Trim());

                    Town town = new Town()
                    {
                        Name = townName,
                        SeatsCount = seatsCount,
                        Students = new List<Student>(),
                    };

                    towns.Add(town);
                    counter++;
                }

                else
                {
                    string[] parsedStudentInput = inputLine.Split(new [] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    Student currentStudent = new Student()
                    {
                        Name = parsedStudentInput[0].Trim(),
                        Email = parsedStudentInput[1].Trim(),
                        RegistrationDate = DateTime.ParseExact(parsedStudentInput[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture)
                    };

                    towns[counter].Students.Add(currentStudent);
                }

                inputLine = Console.ReadLine();
            }

            return towns;
        }

        private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();

            foreach (Town town in towns)
            {
                List<Student> students = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();

                while (students.Any())
                {
                    Group currentGroup = new Group
                    {
                        Town = town
                    };

                    currentGroup.Students = students.Take(currentGroup.Town.SeatsCount).ToList();
                    students = students.Skip(currentGroup.Town.SeatsCount).ToList();

                    groups.Add(currentGroup);
                }
            }

            return groups;
        }

        private static void PrintTheGroupsOnTheConsole(List<Town> towns, List<Group> groups)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

            foreach (Group group in groups.OrderBy(x => x.Town.Name))
            {
                Console.Write($"{group.Town.Name} => ");

                for (int i = 0; i < group.Students.Count(); i++)
                {
                    if (i == group.Students.Count - 1)
                    {
                        Console.WriteLine($"{group.Students[i].Email}");
                    }
                    else
                    {
                        Console.Write($"{group.Students[i].Email}, ");
                    }
                }
            }
        }
    }
}
