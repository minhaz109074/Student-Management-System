using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Course: PolymorphismUtils
    {
        private string? courseID;
        private string? courseName;
        private string? instructorName;
        private int numberOfCredits;

        // Properties
        public string CourseID
        {
            get
            {
                return courseID ?? string.Empty;
            }
            set
            {
                var splitCourseId = value.Split(' ');
                if (splitCourseId.IsValidCourseID()) //ExtensionMethod
                {
                    courseID = value;
                }
                else
                {
                    courseID = default;
                    Console.WriteLine("Incorrect course ID. Please input ID in the format (XXX YYY). EX: CSC 101.");
                }
            }
        }

        public string CourseName
        {
            get
            {
                return courseName ?? string.Empty;
            }
            set
            {
                courseName = value;
            }
        }

        public string InstructorName
        {
            get
            {
                return instructorName ?? string.Empty;
            }
            set
            {
                instructorName = value;
            }
        }

        public int NumberOfCredits
        {
            get
            {
                return numberOfCredits;
            }
            set
            {
                if (value.GetType() == typeof(int))
                {
                    numberOfCredits = value;
                }
                else
                {
                    numberOfCredits = default;
                    Console.WriteLine("Number of credits should be integer type.");
                }
            }
        }

        
        // Constructors
        public Course()
        {
            courseID = default;
            courseName = default;
            instructorName = default;
            numberOfCredits = default;
        }

        public Course(string id, string _courseName, string _instructorName, int credits)
        {
            CourseID = id;
            CourseName = _courseName;
            InstructorName = _instructorName;
            NumberOfCredits = credits;
        }

        public override void ShowFormattedOutput()
        {
            Console.WriteLine($"Course ID : {CourseID}");
            Console.WriteLine($"Course Name : {CourseName}");
            Console.WriteLine($"Instructor Name : {InstructorName}");
            Console.WriteLine($"Number of Credits : {NumberOfCredits}");
            Console.WriteLine();
        }

        
    }

}
