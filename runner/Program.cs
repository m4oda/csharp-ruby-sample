using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileStream fs = new FileStream("script.rb", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using(StreamReader sr = new StreamReader(fs))
            {
                string buf = sr.ReadToEnd();

                Ruby.ruby_init();
                Ruby.Eval(buf);
            }
        }
    }
}
