using System;
using System.IO;
using VALUE = System.UInt32;
using ID = System.UInt32;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Ruby.ruby_init();
            Ruby.Require("./script.rb");

            VALUE fooClass = Ruby.GetConst("Foo");
            VALUE foo = Ruby.rb_class_new_instance(0, null, fooClass);
            ID fooMethod = Ruby.GetIntern("str");
            VALUE ret = Ruby.CallFunction(foo, fooMethod);
            string val = Ruby.GetStringValue(ret);
            Console.WriteLine(val);
        }
    }
}
