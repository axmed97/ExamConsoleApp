using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamConsoleApp
{
    class Student
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int studentId { get; }
        private static int StudenId = 0;
        public List<Exam> Exams { get; set; }
        public Group Group;
        public Student(string name, string phone)
        {
            Exams = new List<Exam>();
            Name = name;
            Phone = phone;
            StudenId++;
            studentId = StudenId;
        }
        public static Student AddStudent()
        {
            if (AllList.Groups.Count > 0)
            {
                foreach (var item in AllList.Groups)
                {
                    Console.WriteLine($"Group Id: {item.groupId}; Group Name: {item.GroupName}");
                }
                StartGroup:
                Console.Write("Please, enter Group Id: ");
                string groupId = Console.ReadLine();
                Group selectedGroup = null;
                bool correctId = false;

                if (Utilities.IsNumber(groupId))
                {
                    int groupIdInt = Convert.ToInt32(groupId);
                    foreach (var item in AllList.Groups)
                    {
                        if (item.groupId == groupIdInt)
                        {
                            selectedGroup = item;
                            correctId = true;
                            break;
                        }
                    }
                    if (correctId)
                    {
                        Console.Write("Student Name: ");
                        string studentName = Console.ReadLine();
                        Console.Write("Student Phone: ");
                        string phone = Console.ReadLine();
                        Student student = new Student(studentName, phone);
                        student.Group = selectedGroup;
                        selectedGroup.Students.Add(student);
                        AllList.Students.Add(student);
                        return student;
                    }
                    else
                    {
                        Console.WriteLine("Group id is not correct");
                        goto StartGroup;
                    }
                    
                }
                else
                {
                    goto StartGroup;
                }
            }
            else
            {
                Console.WriteLine("Group was not fount!");
                Group.AddGroup();
                return null;
            }
            
        }
    }
}
