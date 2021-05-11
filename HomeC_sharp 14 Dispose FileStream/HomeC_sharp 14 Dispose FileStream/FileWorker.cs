using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace HomeC_sharp_14_Dispose_FileStream
{
    class FileWorker : IDisposable
    {
        public enum Mode { Read, Write, ReadWrite }
        public Mode mode { get; set; }
        public void Write(string path, string text)
        {
            if(mode == Mode.Write|| mode == Mode.ReadWrite)
                Console.WriteLine("Writing text");
            else
                Console.WriteLine("Bad mode work");
        }
        public string Read(string path)
        {

            if (mode == Mode.Read || mode == Mode.ReadWrite)
                return "Text from file";
            else
                throw new FileLoadException();
        }

        public void Dispose()
        {
            Console.WriteLine("End work with file");
        }
        ~FileWorker()
        {
            Dispose();
        }
    }
}
