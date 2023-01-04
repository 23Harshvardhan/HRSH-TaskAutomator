using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSH_TaskAutomator.Tools
{
    internal class Paths
    {
        public static string rootDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"/HRSH/TaskAutomator/";
        public static string tasksFile = rootDir + @"tasks.cfg";
        public static string tasksFolder = rootDir + @"Tasks/";
    }
}
