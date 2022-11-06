using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public static class ExtensionMethods
    {
        public static bool AreDigitsOnly(this string value)
        {
            return value.All(char.IsDigit);
        }
        public static bool IsValidSemesterYear(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length == 4 && value.AreDigitsOnly();
        }

        public static bool IsValidSemesterCode(this string value)
        {
            return value.ToLower() == "summer" || value.ToLower() == "fall" || value.ToLower() == "spring";
        }
        public static bool IsValidCourseID(this string[] value)
        {
            return value.Length == 2 && value[0].All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) && value[1].AreDigitsOnly();
        }

        
    }
}
