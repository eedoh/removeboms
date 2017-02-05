using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveBoms
{
    class Program
    {
        private static void RemoveBoms(string directory)
        {
            foreach (string filename in Directory.GetFiles(directory))
            {
                var bytes = System.IO.File.ReadAllBytes(filename);
                if (bytes.Length > 2 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                {
                    System.IO.File.WriteAllBytes(filename, bytes.Skip(3).ToArray());
                    Console.WriteLine(filename);
                }
            }
            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                RemoveBoms(subDirectory);
            }
        }
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Remove Boms usage:");
                Console.WriteLine("RemoveBoms [directory enclosed in double quotations marks]");
            }
            else
            {
                RemoveBoms(args[0]);
            }
            
        }
    }
}
