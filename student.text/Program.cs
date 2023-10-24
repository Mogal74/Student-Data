using System;
using System.IO;
using System.Collections.Generic;

class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
}

class Program
{
    static void Main()
    {
        // Collect student data
        List<Student> students = new List<Student>
        {
            new Student { StudentId = "474", Name = "Mogal", Age = 24 , Grade = "A+" },
            new Student { StudentId = "477", Name = "Harish", Age = 23, Grade = "A" },
            // Add more students if needed
        };

        // Write student data to a text file
        string filePath = "student_data.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Student student in students)
            {
                writer.WriteLine($"{student.StudentId},{student.Name},{student.Age},{student.Grade}");
            }
        }

        Console.WriteLine("Student data has been written to the file.");

        // Read and display student data from the file
        Console.WriteLine("\nRetrieving student data from the file:");
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                string studentId = data[0];
                string name = data[1];
                int age = int.Parse(data[2]);
                string grade = data[3];
                Console.WriteLine($"Student ID: {studentId}, Name: {name}, Age: {age}, Grade: {grade}");
            }
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
