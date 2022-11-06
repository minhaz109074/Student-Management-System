using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudentManagementSystem
{
    internal class FileHandler: IFileHandler
    {
        //Generic methods
        public T ConvertJson<T>(string line)
        {
            T obj = JsonConvert.DeserializeObject<T>(line);
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public dynamic ReadFiles(string fileName)
        {
            string path = @"..\..\..\files\" + fileName;
            string type = fileName.Split(".")[0];
            List<string> fileLines = new List<string>();
            try
            {
                using StreamReader reader = new StreamReader(path);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
               

            }
            catch
            {
                Console.WriteLine("The file could not be read.");
                
                return false;
            }

            List<dynamic> listOfObject = new List<dynamic>();

            foreach(var line in fileLines)
            {
                if (type == "students")
                {
                    Student obj = ConvertJson<Student>(line); //calling generic methods
                    
                    listOfObject.Add(obj);
                }
                
                else
                {
                    Course obj = ConvertJson<Course>(line); //calling generic methods
                    listOfObject.Add(obj);
                }
            }

            return listOfObject;
        }
        public void WriteFiles(string fileName, List<dynamic> lines)
        {
            string filePath = @"..\..\..\files\" + fileName;

            List<string> listOfObject = new List<string>();
            foreach (var line in lines)
            {
                string obj = JsonConvert.SerializeObject(line);
                listOfObject.Add(obj);
            }

            using StreamWriter file = new StreamWriter(filePath);
            foreach (string list in listOfObject)
            {
                file.WriteLine(list);
            }
        }
    }
}
