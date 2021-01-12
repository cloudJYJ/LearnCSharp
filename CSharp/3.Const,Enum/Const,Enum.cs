using System;
using static System.Console;

namespace _3.Const_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            try
            {
                WriteLine("[ 1 ] 상수 형식");
                WriteLine("[ 2 ] 열거 형식");
                WriteLine("[ 3 ] 열거 형식 변수");
                WriteLine("[ 4 ] 열거 형식 할당");
                WriteLine("[ 5 ] Nullable 형식");
                WriteLine("[ 6 ] 암시적 형식");
                WriteLine("[ 7 ] CTS");
                choice = int.Parse(ReadLine());
                if (choice == 1) { Constant Const = new Constant(); }
                if (choice == 2) { Enum Enum = new Enum(); }
                if (choice == 3) { Enum2 Enum2 = new Enum2(); }
                if (choice == 4) { Enum3 Enum3 = new Enum3(); }
                if (choice == 5) { Nullable Null = new Nullable(); }
                if (choice == 6) { UsingVar Var = new UsingVar(); }
                if (choice == 7) { CTS Cts = new CTS(); }
                else { WriteLine("목록외의 입력으로 종료됨;"); }
            }
            catch
            {
                WriteLine("목록외의 입력으로 종료됨");
            }
        }
    }
    class Constant              // 1. 상수 형식
    {
        public Constant()
        {
            const int MAX_INT = 2147483647;
            const int MIN_INT = -2147483648;

            WriteLine(MAX_INT);
            WriteLine(MIN_INT);
        }
    }
    class Enum                  // 2. 열거 형식
    {
        enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }
        public Enum()
        {
            WriteLine((int)DialogResult.YES);
            WriteLine((int)DialogResult.NO);
            WriteLine((int)DialogResult.CANCEL);
            WriteLine((int)DialogResult.CONFIRM);
            WriteLine((int)DialogResult.OK);
        }
    }
    class Enum2                 // 3. 열거 형식 변수
    {
        enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }
        public Enum2()
        {
            DialogResult result = DialogResult.YES;

            WriteLine(result == DialogResult.YES);
            WriteLine(result == DialogResult.NO);
            WriteLine(result == DialogResult.CANCEL);
            WriteLine(result == DialogResult.CONFIRM);
            WriteLine(result == DialogResult.OK);
        }
    }
    class Enum3                 // 4. 열거 형식 할당
    {
        enum DialogResult { YES = 10, NO, CANCEL, CONFIRM = 50, OK }
        public Enum3()
        {
            WriteLine((int)DialogResult.YES);
            WriteLine((int)DialogResult.NO);
            WriteLine((int)DialogResult.CANCEL);
            WriteLine((int)DialogResult.CONFIRM);
            WriteLine((int)DialogResult.OK);
        }
    }
    class Nullable              // 5. Nullable 형식
    {
        public Nullable()
        {
            int? a = null;

            WriteLine(a.HasValue);
            WriteLine(a != null);

            a = 3;
            WriteLine(a.HasValue);
            WriteLine(a != null);
            WriteLine(a.Value);
        }
    }
    class UsingVar              // 6. 암시적 형식
    {
        public UsingVar()
        {
            var a = 20;
            WriteLine("Type: {0}, Value: {1}", a.GetType(), a);

            var b = 3.1414213;
            WriteLine("Type: {0}, Value: {1}", b.GetType(), b);

            var c = "Hello, World!";
            WriteLine("Type: {0}, Value: {1}", c.GetType(), c);

            var d = new int[] { 10, 20, 30 };
            Write("Type: {0}, Value: ",d.GetType());
            foreach (var e in d)
                Write("{0} ", e);

            WriteLine();
        }
    }
    class CTS                   // 7. CTS
    {
        public CTS()
        {
            Int32 a = 123;
            int b = 456;

            WriteLine("a type:{0}, value{1}", a.GetType().ToString(), a);
            WriteLine("b type:{0}, value{1}", b.GetType().ToString(), b);

            String c = "abc";
            string d = "def";

            WriteLine("a type:{0}, value{1}", c.GetType().ToString(), c);
            WriteLine("b type:{0}, value{1}", d.GetType().ToString(), d);
        }
    }
}
