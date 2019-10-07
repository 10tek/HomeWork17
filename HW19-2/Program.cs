using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace HW19_2
{
    class Program
    {
        static void Main(string[] args)
        {

            // С помощью класса XmlDocument создать класс который будет описывать студента и вывести его на консоль или сохранить в текстовый файл
            var students = new List<Student>()
            {
                new Student()
                {
                    FullName = "Male",
                    Age = 19,
                    AvgGrade = 89.5,
                    Course = Course.First
                },
                new Student()
                {
                    FullName = "Azat",
                    Age = 29,
                    AvgGrade = 65.4,
                    Course = Course.Fourth
                }
            };

            var path = @"C:\new\Xml.txt";
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Student>));
            TextWriter fileStream = new StreamWriter(path);
            serialiser.Serialize(fileStream, students);
            fileStream.Close();



        }
    }
}
