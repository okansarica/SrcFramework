using System.IO;

namespace SrcFramework.Utils
{
    public class FileOperations
    {
        public static void WriteToFile(string path, string name, string content, bool append = false)
        {
            string fullFileName = Path.Combine(path, name);
            if (append)
            {
                if (File.Exists(fullFileName))
                {
                    File.AppendAllText(fullFileName,content);
                }
                else
                {
                    File.WriteAllText(fullFileName,content);
                }
            }
            else
            {
                File.WriteAllText(fullFileName, content);
            }
            
        }


        public static string  ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
