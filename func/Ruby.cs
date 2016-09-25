using System;
using System.Runtime.InteropServices;
using System.Text;
using VALUE = System.UInt32;
using ID = System.UInt32;

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
        private static extern VALUE
            rb_eval_string_protect(byte[] script, ref int state);

        [DllImport(LIBRUBY)]
        private static extern VALUE rb_const_get(VALUE klass, ID name);

        [DllImport(LIBRUBY)]
        private static extern ID rb_intern(byte[] name);

        [DllImport(LIBRUBY)]
        public static extern VALUE
            rb_class_new_instance(int argc, VALUE[] argv, VALUE klass);

        [DllImport(LIBRUBY)]
        private static extern VALUE rb_funcall(VALUE recv, ID name, int argc);

        [DllImport(LIBRUBY)]
        private static extern IntPtr
            rb_string_value_cstr(ref IntPtr v_ptr);

        [DllImport(LIBRUBY)]
        private static extern VALUE rb_require(byte[] fname);


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

        public static VALUE Require(string fname)
        {
            byte[] buf = Encoding.UTF8.GetBytes(fname + '\0');
            return rb_require(buf);
        }

        public static VALUE GetConst(string name)
        {
            ID nameSymbol = GetIntern(name);
            return rb_const_get(Object, nameSymbol);
        }

        public static ID GetIntern(string name)
        {
            return rb_intern(Encoding.UTF8.GetBytes(name + '\0'));
        }

        public static VALUE CallFunction(VALUE recv, ID name)
        {
            return rb_funcall(recv, name, 0);
        }

        public static string GetStringValue(VALUE v)
        {
            IntPtr v_ptr = new IntPtr(v);
            IntPtr ptr = rb_string_value_cstr(ref v_ptr);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static VALUE Object
        {
            get
            {
                return Eval("Object");
            }
        }
    }
}
