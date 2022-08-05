using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class PathConstans
    {
        public static string LocalImagePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Pictures\";
    }
}
