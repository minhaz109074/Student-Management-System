using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal interface IFileHandler
    {
        public dynamic ReadFiles(string fileName);
        public void WriteFiles(string fileName, List<dynamic> lines);
    }
}
