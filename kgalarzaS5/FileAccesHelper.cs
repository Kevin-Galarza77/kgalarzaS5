using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kgalarzaS5
{
    public class FileAccesHelper
    {
        public static string GetLocalFolderPath(string path)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, path);
        }
    }
}
