using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Ruby.ruby_init();
            Ruby.Eval("puts 'Hello?'");
        }
    }
}
