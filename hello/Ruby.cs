using System;
using System.Runtime.InteropServices;
using System.Text;
using VALUE = System.UInt32;

namespace ConsoleApplication
{
    static class Ruby
    {
        const string LIBRUBY = "lib/libruby";

        [DllImport(LIBRUBY)]
        public static extern void ruby_init();

        [DllImport(LIBRUBY)]
        private static extern VALUE rb_eval_string(byte[] script);

        [DllImport(LIBRUBY)]
        private static extern VALUE rb_eval_string_protect(byte[] script, ref int state);


        public static VALUE Eval(string script)
        {
            byte[] buf = Encoding.UTF8.GetBytes(script + '\0');
            return rb_eval_string(buf);
        }

        public static VALUE Eval(string script, ref int state)
        {
            byte[] buf = Encoding.UTF8.GetBytes(script + '\0');
            return rb_eval_string_protect(buf, ref state);
        }
    }
}
