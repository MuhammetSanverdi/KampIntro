﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string Upload(IFormFile file, string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root+filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;

                }

            }
            return null;
        }

        public void Delete(string filepath, string root)
        {
            if (File.Exists(root+filepath))
            {
                File.Delete(root + filepath);

            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(root+filePath))
            {
                File.Delete(root + filePath);                
            }
            return Upload(file, root);
        }
    }
}
