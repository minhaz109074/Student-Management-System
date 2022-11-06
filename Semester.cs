using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Semester: PolymorphismUtils
    {
        private string? semesterCode;
        private string? year;

        // Properties
        public string SemesterCode
        {
            get
            {
                return semesterCode ?? "None";
            }
            set
            {
                if (value.IsValidSemesterCode()) //ExtensionMethod
                {
                    semesterCode = value;
                }
                else
                {
                    semesterCode = default;
                    Console.WriteLine("Summer, Spring, and Fall are the only valid semester codes. Select one of these.");
                }
            }
        }

        public string Year
        {
            get
            {
                return year ?? "None";
            }

            set
            {
                if (value.IsValidSemesterYear()) //ExtensionMethod
                {
                    year = value;
                }
                else
                {
                    year = default;
                    Console.WriteLine("Please provide a valid year in the format “YYYY”, e.g. “2022”...");
                }
            }
        }

        
        //Constructors
        public Semester()
        {
            semesterCode = default;
            year = default;
        }

        public Semester(string code, string _year)
        {
            SemesterCode = code;
            Year = _year;
        }

        public override void ShowFormattedOutput()
        {
            Console.Write($"Semester Code - {SemesterCode}, ");
            Console.Write($"Year - {Year}\n");
        }


    }
}
