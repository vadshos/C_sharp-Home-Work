using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jugged_FileStream
{
    class JuggedFileWork
    {
        public static void Write(string path, byte[][] jug)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.WriteByte((byte)jug.Length);
                foreach (var item in jug)
                {
                    fs.WriteByte((byte)item.Length);
                    foreach (var elem in item)
                    {
                        fs.WriteByte(elem);
                    }
                }
            }
        }
        public static byte[][] Read (string path)
        {
            byte size = 1;

            byte[][] jug = new  byte[size][];
            for (int i = 0; i < size; i++)
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                  if(i == 0)
                  {
                     size = (byte)fs.ReadByte();
                     jug = new byte[size][];
                  }
                    byte length = (byte)fs.ReadByte();
                    jug[i] = new byte[length];
                    for (int j = 0; j < length; j++)
                    {
                       jug[i][j] =  (byte)fs.ReadByte();
                    }
                }
            }
            return jug;
        }
            

    }
}
