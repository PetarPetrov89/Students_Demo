using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Students_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> commands = new Dictionary<int, string>()
            {
                { 1, "SHOW ALL"},
                { 2, "SEARCH IN"},
                { 3, "SEARCH SN"},
                { 4, "DELETE IN"},
                { 5, "ADD"},
                { 6, "SHOW AVGR"},
                { 0, "EXIT"},
            };

            Console.WriteLine("Welcome to Students App");

            ShowMenu(commands);

            while (true)
            {

                Console.WriteLine("Please enter a number:");
                try
                {
                    int command = int.Parse(Console.ReadLine());
                    if (!commands.ContainsKey(command))
                    {
                        Console.WriteLine("There is no such command");
                        continue;
                    }

                    switch (command)
                    {
                        case 1:
                            ShowAllStudents();
                            break;
                        case 2:
                            SearchByEGN();
                            break;
                        case 3:
                            SearchByFacNum();
                            break;
                        case 4:
                            DeleteByEGN();
                            break;
                        case 5:
                            AddStudents();
                            break;
                        case 6:
                            ShowAvarage();
                            break;
                        case 0:
                            Exit();
                            break;
                        default:
                            break;

                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Wrong format");
                    continue;
                }
            }
        }

        private static void ShowAvarage()
        {
            string[] students = File.ReadAllLines(@"C:\DemoFiles\Students.txt");

            foreach (string student in students)
            {
                string[] studentElements = student.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                double sumOfGrades = 0;

                for (int i = 5; i < 14; i++)
                {
                    sumOfGrades += double.Parse(studentElements[i]);
                }

                Console.WriteLine($"{studentElements[0]} {studentElements[2]} with Fac # {studentElements[4]} has average grade - {(sumOfGrades / 10).ToString("#.##")}");
            }
        }

        private static void AddStudents()
        {
            string studentInfo = Console.ReadLine().Trim();

            Regex regex = new Regex(@"([a-zA-Z]+\s){3}[0-9]{6} [0-9]{7} ([2-6].[0-9][0-9]+\s){10}");

            if (regex.IsMatch(studentInfo))
            {
                using (StreamWriter writer = new StreamWriter(@"C:\DemoFiles\Students.txt", true))
                {
                    writer.WriteLine(studentInfo);
                }
            }
            else
            {
                Console.WriteLine("Wrong format of input");
            }
        }

        private static void SearchByFacNum()
        {
            Console.WriteLine("Please enter Ident Num of Stuent");
            string facNum = Console.ReadLine();

            while (CheckIfFacNumIsValid(facNum))
            {
                Console.WriteLine("Wrong format of ident Num!");
                facNum = Console.ReadLine();
            }

            string[] students = File.ReadAllLines(@"D:\NetIt\txt_f\Students.txt");

            Dictionary<string, string> studentsDic = new Dictionary<string, string>();

            foreach (var student in students)
            {
                string[] studentElements = student.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                studentsDic.Add(studentElements[4], student);

            }

            if (studentsDic.ContainsKey(facNum))
            {
                Console.WriteLine(studentsDic[facNum]);
            }
            else
            {
                Console.WriteLine("Sorry there is no such student!");
            }
        }

        private static bool CheckIfFacNumIsValid(string facNum)
        {
            return true;
        }

        private static void DeleteByEGN()
        {
            Console.WriteLine("Please enter Ident Num of Stuent");
            string identNum = Console.ReadLine();

            while (!CheckIfEGNIsValid(identNum))
            {
                Console.WriteLine("Wrong format of ident Num!");
                identNum = Console.ReadLine();
            }

            string[] students = File.ReadAllLines(@"D:\NetIt\txt_f\Students.txt");

            Dictionary<string, string> studentsDic = new Dictionary<string, string>();

            foreach (string student in students)
            {
                string[] studentElements = student.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                studentsDic.Add(studentElements[3], student);

            }
            if (studentsDic.ContainsKey(identNum))
            {
                string studentToBeRemoved = studentsDic[identNum];

                studentsDic.Remove(identNum);

                using (StreamWriter writer = new StreamWriter(@"D:\NetIt\txt_f\Students.txt"))
                {
                    foreach (var kvp in studentsDic)
                    {
                        writer.WriteLine(kvp.Value);
                    }
                }
                Console.WriteLine($"Student removed: {studentToBeRemoved}");
            }
            else
            {
                Console.WriteLine("Sorry there is no such student!");
            }

        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void SearchByEGN()
        {
            Console.WriteLine("Please enter Ident Num of Stuent");
            string identNum = Console.ReadLine();

            while (CheckIfEGNIsValid(identNum))
            {
                Console.WriteLine("Wrong format of ident Num!");
                identNum = Console.ReadLine();
            }

            string[] students = File.ReadAllLines(@"D:\NetIt\txt_f\Students.txt");

            Dictionary<string, string> studentsDic = new Dictionary<string, string>();

            foreach (var student in students)
            {
                string[] studentElements = student.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                studentsDic.Add(studentElements[3], student);

            }

            if (studentsDic.ContainsKey(identNum))
            {
                Console.WriteLine(studentsDic[identNum]);
            }
            else
            {
                Console.WriteLine("Sorry there is no such student!");
            }
            //for (int i = 0; i < students.Length; i++)
            //{
            //    if (students[i].Contains(identNum))
            //    {
            //        Console.WriteLine("We found this guy!");
            //        Console.WriteLine(students[i]);
            //        return;
            //    }
            //}
        }

        private static bool CheckIfEGNIsValid(string identNum)
        {
            if (identNum.Length != 6 || identNum.Contains('a'))
            {
                return false;
            }
            return true;
        }

        private static void ShowAllStudents()
        {
            string[] students = File.ReadAllLines(@"D:\NetIt\txt_f\Students.txt");

            foreach (var student in students)
            {
                string[] studentElements = student.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentElements[0];
                string middleName = studentElements[1];
                string lastName = studentElements[2];
                string egn = studentElements[3];
                string facNum = studentElements[4];
                string grade1 = studentElements[5];
                string grade2 = studentElements[6];
                string grade3 = studentElements[7];
                string grade4 = studentElements[8];
                string grade5 = studentElements[9];
                string grade6 = studentElements[10];
                string grade7 = studentElements[11];
                string grade8 = studentElements[12];
                string grade9 = studentElements[13];
                string grade10 = studentElements[14];

                Console.WriteLine($"{firstName} {middleName} {lastName} {facNum} {grade1} {grade2} {grade3} {grade4} {grade5} {grade6} {grade7} {grade8} {grade9} {grade10}");
            }
        }

        private static void ShowMenu(Dictionary<int, string> commands)
        {
            foreach (var command in commands)
            {
                Console.WriteLine($"{command.Key}) {command.Value}");
            }
        }
        //private static void ShowMenu()
        //{
        //    Console.WriteLine("1) Show all Students");
        //    Console.WriteLine("2) Search by Ident Num");
        //    Console.WriteLine("3) Search by Student Num");
        //    Console.WriteLine("4) Delete by Ident Num");
        //    Console.WriteLine("5) Add Student");
        //    Console.WriteLine("6) Average grade for all students");
        //    Console.WriteLine("0) Exit");

        //}
    }
}
