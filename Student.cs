using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public enum DepartmentName
    {
        None,
        ComputerScience,
        BBA,
        ENGLISH
    }

    public enum DegreeName
    {
        None,
        BSC,
        BBA,
        BA,
        MSC,
        MBA,
        MA
    }
    internal class Student: PolymorphismUtils
    {
        private string? firstName;
        private string? middleName;
        private string? lastName;
        private string? studentID;
        private Semester? joiningBatch;
        private DepartmentName department;
        private DegreeName degree;
        private List<Semester>? attendedSemester;
        private List<List<Course>>? coursesInEachSemester;

        //Properties
        public string FirstName
        {
            get
            {
                return firstName ?? "None";
            }
            set
            {
                if(value != null && value != String.Empty)
                {
                    firstName = value;
                }
                else
                {
                    firstName = default;
                    Console.WriteLine("Please enter your firstname...");
                }
            }
        } 

        public string MiddleName
        {
            get
            {
                return middleName ?? "None";
            } 
            set
            {
                middleName = value;
            }
        }

        public String LastName
        {
            get { return lastName ?? "None"; }
            set
            {
                lastName = value;
            }
        } 

        public string StudentID
        {
            get
            {
                return studentID ?? "None";
            }
            set
            {
                var splitStduentId = value.Split('-');
                if (splitStduentId.Length == 3)
                {
                    bool flag = false;
                    for(var i = 0; i < splitStduentId.Length; i++)
                    {
                        if (!(splitStduentId[i].Length == 3))
                        {
                            flag = true;
                            break;
                        }
                        
                    }
                    if (!flag)
                    {
                        studentID = value;
                    }
                    if (flag)
                    {
                        studentID = default;
                        Console.WriteLine("Student ID should be in the format XXX-XXX-XXX.");

                    }
                }
                else
                {
                    studentID = default;
                    Console.WriteLine("Student ID should be in the format XXX-XXX-XXX.");

                }
            }
        }
        public Semester? JoiningBatch
        {
            get
            {
                return joiningBatch;
            }
            set
            {
                joiningBatch = value;
            }
        }

        public dynamic Department
        {
            get { return department; }
            set {
                department = (DepartmentName)value;
            }
        }
        public dynamic Degree
        {
            get { return degree; }
            set
            {
                degree = (DegreeName)value;

            }
        }
        public List<Semester>? AttendedSemester
        {
            get
            {
                return attendedSemester;
            }
            set
            {
                attendedSemester = value;
            }
        }
        public List<List<Course>>? CoursesInEachSemester
        {
            get
            {
                return coursesInEachSemester;
            }
            set
            {
                coursesInEachSemester = value;
            }
        }

        //Constructors
        public Student()
        {
            firstName = default;
            middleName = default;
            lastName = default;
            studentID = default;
            joiningBatch = default;
            department = DepartmentName.None;
            degree = DegreeName.None;
            attendedSemester = new List<Semester>();
            coursesInEachSemester = new List<List<Course>>();


        }
        public Student(string _firstName, string _middleName, string _lastName, string id, Semester _joiningBatch,  int _department, int _degree, List<Semester> _attendedSemester, List<List<Course>> courses)
        {
            FirstName = _firstName;
            MiddleName = _middleName;
            LastName = _lastName;
            StudentID = id;
            JoiningBatch = _joiningBatch;
            Department = _department;
            Degree = _degree;
            AttendedSemester = _attendedSemester;
            CoursesInEachSemester= courses;
        }
        public override void ShowFormattedOutput()
        {
            
            Console.WriteLine($"\nSTUDENT NAME : {FirstName} {MiddleName} {LastName}\n");
            Console.WriteLine($"STUDENT ID : {StudentID}\n");
            Console.Write("JOINING BATCH :  ");
            JoiningBatch.ShowFormattedOutput();
            Console.WriteLine();
            Console.WriteLine($"DEPARTMENT: {Department}\n");
            Console.WriteLine($"DEGREE: {Degree}\n");

            Console.WriteLine("COMPLETED SEMESTERS ARE :- ");
            foreach (var semester in AttendedSemester)
            {
                semester.ShowFormattedOutput();
            }
            Console.WriteLine();
            Console.WriteLine("COURSES IN EACH SEMESTERS ARE :- ");
            for (int i = 0; i < AttendedSemester.Count; i++)
            {
                Console.WriteLine($"{AttendedSemester[i].SemesterCode} : {AttendedSemester[i].Year}");
                foreach (var course in CoursesInEachSemester[i])
                {
                    course.ShowFormattedOutput();
                }
            }
            Console.WriteLine();
        }

    }
}
