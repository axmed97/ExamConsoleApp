using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamConsoleApp
{
    class Group
    {
        public string GroupName { get; set; }
        public List<Student> Students { get; set; }
        private static int GroupId = 1;
        public int groupId { get; }
        public Group(string groupName)
        {
            GroupName = groupName;
            Students = new List<Student>();
            groupId = GroupId;
            GroupId++;
            
        }
        public static void AddGroup()
        {
            Console.Write("Please, enter group name: ");
            string groupName = Console.ReadLine();
            Group group = new Group(groupName);
            Console.WriteLine($"Group {groupName} created successfully!");
            AllList.Groups.Add(group);
            foreach (var item in AllList.Groups)
            {
                Console.WriteLine($"Group Id: {item.groupId}; Group Name: {item.GroupName}");
            }
        }
        public static void ShowExam(Student student)
        {
            Exam selectedExam = null;
            bool corretName = false;
            Exam:
            Console.Write("Please, enter Exam name: ");
            string examName = Console.ReadLine();
            foreach (var item in AllList.Exams)
            {
                if (item.ExamName == examName)
                {
                    selectedExam = item;
                    corretName = true;
                    break;
                }
            }
            if (corretName)
            {
                selectedExam.Students.Add(student);
                student.Exams.Add(selectedExam);
                foreach (var item in selectedExam.Students)
                {
                    Console.WriteLine($"Exam {selectedExam.ExamName} added {item.Name}!");
                }
            }
            else
            {
                Console.WriteLine("Exam name is not correct!");
                goto Exam;
            }
        }
        public static void SelectedStudentAddExam()
        {
            foreach (var item in AllList.Students)
            {
                Console.WriteLine($"Stundet id: {item.studentId}; Student Name: {item.Name}");
            }
            StartExam:
            Console.Write("Select Student Id: ");
            string selectedtId = Console.ReadLine();
            bool correctId = false;
            Student selectedStudent = null;
            if (Utilities.IsNumber(selectedtId))
            {
                int studentIdInt = Convert.ToInt32(selectedtId);
                foreach (var item in AllList.Students)
                {
                    if (item.studentId == studentIdInt)
                    {
                        selectedStudent = item;
                        correctId = true;
                        break;
                    }
                }
                if (correctId)
                {
                    foreach (var item in AllList.Exams)
                    {
                        Console.WriteLine($"Exam Name: {item.ExamName}; Exam Date: {item.ExamDate.ToString("dddd, dd MMMM yy")}");
                    }
                    ShowExam(selectedStudent);
                }
                else
                {
                    Console.WriteLine("Warning, Student id does not exit!");
                    goto StartExam;  
                }
            }
        }
    }
}
