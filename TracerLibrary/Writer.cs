using System;
using System.IO;

namespace TracerLibrary
{
    public class Writer
    {
        private string path;
        public Writer(string path)
        {
            this.path = path;
        }
        public void writeResult(MemoryStream memoryStream)
        {
            StreamReader streamReader = new StreamReader(memoryStream);
            Console.WriteLine(streamReader.ReadToEnd());
            using (FileStream fileStream = new FileStream(path,FileMode.Append))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}