namespace _08.EmployeeData
{
    using System;

    class EmployeeData
    {
        static void Main()
        {
            string firstName = "Amanda";
            string secondName = "Jonson";
            byte age = 27;
            char gender = 'f';
            long personalNumber = 8306112507;
            int uniqueEmployeeNumber = 27563571;

            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {secondName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {personalNumber}");
            Console.WriteLine($"Unique Employee number: {uniqueEmployeeNumber}");
        }
    }
}
