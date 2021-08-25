using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Helpers.FileManage
{
    public static class FileManager
    {
        public static bool Save(Stream file,string path,string fileName)
        {
            try
            {
                using (FileStream fileToSave = new FileStream(path+fileName, FileMode.Create))
                {
                    file.CopyTo(fileToSave);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            
        }
    }
}
