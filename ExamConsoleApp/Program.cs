using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AllList.Exams.Add(new Exam("HTML", new DateTime()));
            AllList.Exams.Add(new Exam("CSS", new DateTime()));
            AllList.Exams.Add(new Exam("JS", new DateTime()));

            string keyCode;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Select one of the below!");
                Console.WriteLine("1. Create Group and Group List");
                Console.WriteLine("2. Select Group Id and Add Student");
                Console.WriteLine("3. Select Student Id and Add Exam");
                Console.WriteLine("4. Exit");
                Console.Write(">>>>");
                keyCode = Console.ReadLine();
                if (Utilities.IsNumber(keyCode))
                {
                    switch (keyCode)
                    {
                        case "1":
                            Group.AddGroup();
                            break;
                        case "2":
                            Student.AddStudent();
                            break;
                        case "3":
                            Group.SelectedStudentAddExam();
                            break; 
                        case "4":
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("Please, enter between 1 and 4!");
                            break;
                    }
                }
            } while (keyCode != "4");

        }
    }
}
