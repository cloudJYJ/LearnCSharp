using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace _16.Reflection_Attribute
{
    class Program
    {
        static void Main()
        {
            WriteLine("[ 1 ] GetType");
            WriteLine("[ 2 ] 동적 인스턴스");
            WriteLine("[ 3 ] 형식 내보내기");
            WriteLine("[ 4 ] 애트리뷰트");
            WriteLine("[ 5 ] Caller애트리뷰트");
            WriteLine("[ 6 ] 사용자 정의 애트리뷰트");
            string choice = ReadLine();
            if(choice == "1") { GetType gettype = new GetType(); }
            if(choice == "2") { DynamicInstance dynamicInstance = new DynamicInstance(); }
            if(choice == "3") { EmitTest emittest = new EmitTest(); }
            if(choice == "4") { BasicAttribute basicattribute = new BasicAttribute(); }
            if(choice == "5") { CallerInfo callerinfo = new CallerInfo(); }
            if(choice == "6") { HistoryAttribute historyattribute = new HistoryAttribute(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요.");
            ReadKey();
        }
    }
    
    class GetType
    {
        static void PrintInterfaces(Type type)
        {
            WriteLine("--------------- Interfaces ---------------");

            Type[] interfaces = type.GetInterfaces();
            foreach (Type i in interfaces)
                WriteLine("Name:{0}", i.Name);

            WriteLine();
        }

        static void PrintField(Type type)
        {
            WriteLine("--------------- Fields ---------------");

            FieldInfo[] fields = type.GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static |
                    BindingFlags.Instance );

            foreach(FieldInfo field in fields)
            {
                string accesssLevel = "protected";
                if (field.IsPublic) accesssLevel = "public";
                else if (field.IsPrivate) accesssLevel = "private";

                WriteLine("Access{0}, Type:{1}, Name:{2}",accesssLevel, field.FieldType.Name, field.Name);
            }
        }

        static void PrintMethod(Type type)
        {
            WriteLine("--------------- Method ---------------");

            MethodInfo[] methods = type.GetMethods();
            foreach( MethodInfo method in methods)
            {
                Write("Type:{0}, Name:{1}, Parameter:", method.ReturnType.Name, method.Name);

                ParameterInfo[] args = method.GetParameters();
                for(int i = 0; i > args.Length; i++)
                {
                    Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                        WriteLine(", ");
                }
                WriteLine();
            }
            WriteLine();
        }

        static void PrintProperties(Type type)
        {
            WriteLine("--------------- Properties ---------------");

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
                WriteLine("Type:{0}, Name:{1}", property.PropertyType.Name, property.Name);

            WriteLine();
        }

        public GetType()
        {
            int a = 0;
            Type type = a.GetType();
            PrintInterfaces(type);
            PrintField(type);
            PrintProperties(type);
            PrintMethod(type);
        }
    }                   // 1. GetType
    class DynamicInstance
    {
        class Profile
        {
            private string name;
            private string phone;

            public Profile()
            {
                name = ""; phone = "";
            }
            
            public Profile(string name, string phone)
            {
                this.name = name;
                this.phone = phone;
            }

            public void print()
            {
                WriteLine($"{name}, {phone}");
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Phone
            {
                get { return phone; }
                set { phone = value; }
            }
        }

        public DynamicInstance()
        {
            Type type = Type.GetType("DynamicInstance.Profile");
            MethodInfo methodinfo = type.GetMethod("Print");
            PropertyInfo nameproperty = type.GetProperty("Name");
            PropertyInfo phoneproperty = type.GetProperty("Phone");

            object profile = Activator.CreateInstance(type, "박상현", "512-1234");

            methodinfo.Invoke(profile, null);

            profile = Activator.CreateInstance(type);
            nameproperty.SetValue(profile, "박찬호", null);
            phoneproperty.SetValue(profile, "997-5511", null);

            WriteLine("{0}, {1}",
                nameproperty.GetValue(profile, null),
                phoneproperty.GetValue(profile, null)
                );
        }
    }           // 2. 동적 인스턴스
    class EmitTest
    {
        public EmitTest()
        {
            AssemblyBuilder newAssembly =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    new AssemblyName("CalculatorAssembly"),
                    AssemblyBuilderAccess.Run);

            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");
            TypeBuilder newType = newModule.DefineType("Sum1To100");

            MethodBuilder newMethod = newType.DefineMethod(
                "Calculator",
                MethodAttributes.Public,
                typeof(int),   // 반환 형식
                new Type[0]);  // 매개 변수

            ILGenerator generator = newMethod.GetILGenerator();

            generator.Emit(OpCodes.Ldc_I4, 1);

            for(int i = 2; i <= 100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }

            generator.Emit(OpCodes.Ret);
            newType.CreateType();

            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            WriteLine(Calculate.Invoke(sum1To100, null));
        }
    }                  // 3. 형식 내보내기
    class BasicAttribute
    {
        class MyClass
        {
            [Obsolete("OldMethod는 폐기되었습니다. NewMethod()를 이용하세요. ")]
            public void OldMethod()
            {
                WriteLine("I'm old");
            }

            public void NewMethod()
            {
                WriteLine("I'm new");
            }
        }

        public BasicAttribute()
        {
            MyClass obj = new MyClass();
            obj.OldMethod();
            obj.NewMethod();
        }
    }            // 4. 애트리뷰트
    class CallerInfo
    {
        public static class Trace
        {
            public static void WriteLine(string message,
                [CallerFilePath] string file = "",
                [CallerLineNumber] int Line = 0,
                [CallerMemberName] string member = "")
            {
                WriteLine($"{file}(Line:{Line}) {member}: {message}");
            }
        }

        public CallerInfo()
        {
            Trace.WriteLine("즐거운 프로그래밍!");
        }
    }                // 5. Caller애트리뷰트
    class HistoryAttribute
    {
        [System.AttributeUsage(System.AttributeTargets.Class,AllowMultiple = true)]
        class History : System.Attribute
        {
            private string programmer;
            public double version;
            public string changes;

            public History(string programmer)
            {
                this.programmer = programmer;
                version = 1.0;
                changes = "First release";
            }

            public string GetProgrammer()
            {
                return programmer;
            }
        }

        [History("Sean", version = 0.1, changes = "2021-01-20 Created class stub")]
        [History("Bob", version = 0.2, changes = "2021-01-21 Added Func() Method")]
        class MyClass
        {
            public void Func()
            {
                WriteLine("Func()");
            }
        }
        public HistoryAttribute()
        {
            Type type = typeof(MyClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);
        }
    }          // 6. 사용자 정의 애트리뷰트
}
