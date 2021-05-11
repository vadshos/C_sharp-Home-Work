using System;

namespace HomeC_sharp_14_Dispose_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileWorker file = new FileWorker())
            {
                file.mode = FileWorker.Mode.Read;
                file.Read(("path.txt"));
            }
            FileWorker file2 = new FileWorker();
            file2.mode = FileWorker.Mode.Write;
            file2.Write("path.txt", "text");
        }
    }
}
