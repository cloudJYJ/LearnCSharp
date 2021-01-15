using System;
using static System.Console;
using System.Collections.Generic;


namespace _7.Class
{
    class Class
    {
        static void Main()
        {
            WriteLine("[ 1 ] 클래스 선언과 객체 선언");
            WriteLine("[ 2 ] 생성자");
            WriteLine("[ 3 ] 정적 필드");
            WriteLine("[ 4 ] 깊은 복사");
            WriteLine("[ 5 ] this 키워드");
            WriteLine("[ 6 ] this 생성자");
            WriteLine("[ 7 ] 접근 한정자");
            WriteLine("[ 8 ] 상속");
            WriteLine("[ 9 ] 클래스 사이 형식 변환과 is, as");
            WriteLine("[10 ] 오버라이딩과 다형성");
            WriteLine("[11 ] 메소드 숨기기");
            WriteLine("[12 ] 오버라이딩 봉인");
            WriteLine("[13 ] 중첩 클래스");
            WriteLine("[14 ] 분할 클래스");
            WriteLine("[15 ] 확장 메소드");
            WriteLine("[16 ] 구조체");
            string choice = ReadLine();
            if(choice == "1") { BasicClass basicclass = new BasicClass(); }
            if(choice == "2") { Constructor constructor = new Constructor(); }
            if(choice == "3") { StaticField staticfield = new StaticField(); }
            if(choice == "4") { DeepCopy deepcopy = new DeepCopy(); }
            if(choice == "5") { This This = new This(); }
            if(choice == "6") { ThisConstructor thisconstructor = new ThisConstructor(); }
            if(choice == "7") { AccessModifier accessmodifier = new AccessModifier(); }
            if(choice == "8") { Inheritance inheritance = new Inheritance(); }
            if(choice == "9") { TypeCasting typecasting = new TypeCasting(); }
            if(choice == "10") { Overriding overriding = new Overriding(); }
            if(choice == "11") { MethodHiding methodhiding = new MethodHiding(); }
            if(choice == "12") { WriteLine("실행 결과가 없는 코드입니다. 직접 코드를 확인"); }
            if(choice == "13") { NestedClass nestedclass = new NestedClass(); }
            if(choice == "14") { PartialClass partialclass = new PartialClass(); }
            if(choice == "15") { ExtensionMethod extensionmethod = new ExtensionMethod(); }
            if(choice == "16") { Structure structure = new Structure(); } 
        }
    }
    class BasicClass
    {
        public BasicClass()
        {
            Cat kitty = new Cat();
            kitty.Color = "하얀색";
            kitty.Name = "키티";
            kitty.Meow();
            WriteLine($"{kitty.Name} : {kitty.Color}");

            Cat nero = new Cat();
            nero.Color = "검은색";
            nero.Name = "네로";
            nero.Meow();
            WriteLine($"{nero.Name} : {nero.Color}");
        }
        class Cat
        {
            public string Name;
            public string Color;

            public void Meow()
            {
                WriteLine($"{Name} : 야옹");
            }
        }
    }               // 1. 클래스 선언과 객체 생성
    class Constructor
    {
        public Constructor()
        {
            Cat Kitty = new Cat("키티", "하얀색");
            Kitty.Meow();
            WriteLine($"{Kitty.Name} : {Kitty.Color}");

            Cat nero = new Cat("네로", "검은색");
            nero.Meow();
            WriteLine($"{nero.Name} : {nero.Color}");
        }
        class Cat
        {
            public string Name;
            public string Color;

            public Cat()
            {
                Name = "";
                Color = "";
            }

            public Cat(string _Name, string _Color)
            {
                Name = _Name;
                Color = _Color;
            }

            ~Cat()
            {
                WriteLine($"{Name} : 잘가");
            }
            
            public void Meow()
            {
                WriteLine($"{Name} : 야옹");
            }
        }
    }              // 2. 생성자
    class StaticField
    {
        public StaticField()
        {
            WriteLine($"Global.Count : {Global.Count}");

            new ClassA();
            new ClassA();
            new ClassB();
            new ClassB();

            WriteLine($"Global.Count : {Global.Count}");
        }
        class Global
        {
            public static int Count = 0;
        }

        class ClassA
        {
            public ClassA()
            {
                Global.Count++;
            }
        }

        class ClassB
        {
            public ClassB()
            {
                Global.Count++;
            }
        }
    }              // 3. 정적 필드
    class DeepCopy
    {
        public DeepCopy()
        {
            WriteLine("Shallow Copy");
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClass target = source;
                target.MyField2 = 30;

                WriteLine($"{source.MyField1} {source.MyField2}");
                WriteLine($"{target.MyField1} {target.MyField2}");
            }

            WriteLine("Deep Copy");
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClass target = source.DeepCopy();
                target.MyField2 = 30;

                WriteLine($"{source.MyField1} {source.MyField2}");
                WriteLine($"{target.MyField1} {target.MyField2}");
            }
        }
        class MyClass
        {
            public int MyField1;
            public int MyField2;

            public MyClass DeepCopy()
            {
                MyClass newCopy = new MyClass();
                newCopy.MyField1 = this.MyField1;
                newCopy.MyField2 = this.MyField2;

                return newCopy;
            }
        }
    }                 // 4. 깊은 복사
    class This
    {
        public This()
        {
            Employee pooh = new Employee();
            pooh.SetName("Pooh");
            pooh.SetPosition("Waiter");
            WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

            Employee tigger = new Employee();
            tigger.SetName("Tigger");
            tigger.SetPosition("Cleaner");
            WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");
        }
        class Employee
        {
            private string Name;
            private string Position;

            public void SetName(string Name)
            {
                this.Name = Name;
            }

            public string GetName()
            {
                return Name;
            }

            public void SetPosition(string Position)
            {
                this.Position = Position;
            }

            public string GetPosition()
            {
                return this.Position;
            }
        }
    }                     // 5. this 키워드
    class ThisConstructor
    {
        public ThisConstructor()
        {
            MyClass a = new MyClass();
            a.PrintFields();
            WriteLine();

            MyClass b = new MyClass(1);
            b.PrintFields();
            WriteLine();

            MyClass c = new MyClass(10, 20);
            c.PrintFields();
        }

        class MyClass
        {
            int a, b, c;

            public MyClass()
            {
                this.a = 5425;
                WriteLine("MyClass()");
            }

            public MyClass(int b) : this()
            {
                this.b = b;
                WriteLine($"MyClass({b})");
            }

            public MyClass(int b, int c) : this(b)
            {
                this.c = c;
                WriteLine($"MyClass({b},{c})");
            }

            public void PrintFields()
            {
                WriteLine($"a:{a}, b:{b}, c:{c}");
            }
        }
    }          // 6. this() 생성자
    class AccessModifier
    {
        public AccessModifier()
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TurnOnWater();

                heater.SetTemperature(-2);
                heater.TurnOnWater();

                heater.SetTemperature(50);
                heater.TurnOnWater();
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }
        }
        class WaterHeater
        {
            protected int temperature;

            public void SetTemperature(int temperature)
            {
                if(temperature <-5 || temperature > 42)
                {
                    throw new Exception("Out of temperature range");
                }

                this.temperature = temperature;
            }

            internal void TurnOnWater()
            {
                WriteLine($"Turn on water : {temperature}");
            }
        }
    }           // 7. 접근 한정자
    class Inheritance
    {
        public Inheritance()
        {
            Base a = new Base("a");
            a.BaseMethod();

            Derived b = new Derived("b");
            b.BaseMethod();
            b.DerivedMethod();
        }

        class Base
        {
            protected string Name;
            public Base(string Name)
            {
                this.Name = Name;
                WriteLine($"{this.Name}.Base()");
            }

            ~Base()
            {
                WriteLine($"{this.Name}.~Base()");
            }

            public void BaseMethod()
            {
                WriteLine($"{Name}.BaseMethod()");
            }
        }
        
        class Derived : Base
        {
            public Derived(string Name) : base(Name)
            {
                WriteLine($"{this.Name}.Derived()");
            }

            ~Derived()
            {
                WriteLine($"{this.Name}.~Derived()");
            }

            public void DerivedMethod()
            {
                WriteLine($"{Name}.DerivedMethod()");
            }
        }
    }              // 8. 상속
    class TypeCasting
    {
        public TypeCasting()
        {
            Mammal mammal = new Dog();
            Dog dog;

            if(mammal is Dog)
            {
                dog = (Dog)mammal;
                dog.Bark();
            }

            Mammal mammal2 = new Cat();

            Cat cat = mammal2 as Cat;
            if (cat != null)
                cat.Meow();

            Cat cat2 = mammal as Cat;
            if (cat2 != null)
                cat.Meow();
            else
                WriteLine("cat2 is not a Cat");
        }

        class Mammal
        {
            public void Nurse()
            {
                WriteLine("Nurse()");
            }
        }

        class Dog : Mammal
        {
            public void Bark()
            {
                WriteLine("Bark()");
            }
        }

        class Cat : Mammal
        {
            public void Meow()
            {
                WriteLine("Meow()");
            }
        }
    }              // 9. 클래스 사이 형식 변환과 is, as
    class Overriding
    {
        public Overriding()
        {
            WriteLine("Creating ArmorSuite...");

            ArmorSuite armorsuite = new ArmorSuite();
            armorsuite.Initialize();

            WriteLine("Creating Ironman...");
            ArmorSuite ironman = new IronMan();
            ironman.Initialize();

            WriteLine("Creating WarMachine...");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Initialize();
        }
        class ArmorSuite
        {
            public virtual void Initialize()
            {
                WriteLine("Armored");
            }
        }
        class IronMan : ArmorSuite
        {
            public override void Initialize()
            {
                base.Initialize();
                WriteLine("Repulsor Rays Armed");
            }
        }

        class WarMachine : ArmorSuite
        {
            public override void Initialize()
            {
                base.Initialize();
                WriteLine("Double-Barrel Cannons Armed");
                WriteLine("Micro-Rocekt Launcher Armed");
            }
        }
    }               // 10. 오버라이딩과 다형성
    class MethodHiding
    {
        public MethodHiding() 
        {
            Base baseObj = new Base();
            baseObj.MyMethod();

            Derived derivedObj = new Derived();
            derivedObj.MyMethod();

            Base baseOrDerived = new Derived();
            baseOrDerived.MyMethod();
        }
        
        class Base
        {
            public void MyMethod()
            {
                WriteLine("Base.MyMethod()");
            }
        }

        class Derived : Base
        {
            public new void MyMethod()
            {
                WriteLine("Derived.MyMethod()");
            }
        }
    }             // 11. 메소드 숨기기
    class SealedMethod
    {
        class Base
        {
            public virtual void SealMe()
            {
            }
        }

        class Derived : Base
        {
            public sealed override void SealMe()
            {
            }
        }
        /* sealed 된 메소드는 오버라이딩할 수 없기때문에 컴파일에러가난다.
        class WantToOverrider : Derived
        {
            public override void SealMe()
            {
            }
        }
        */
    }             // 12. 오버라이딩 봉인
    class NestedClass
    {
        public NestedClass()
        {
            Configuration config = new Configuration();
            config.SetConfig("Version", "V 5.0");
            config.SetConfig("Size", "655,324 KB");

            WriteLine(config.GetConfig("Version"));
            WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V5.0.1");
            WriteLine(config.GetConfig("Version"));
        }

       class Configuration
       {
            List<ItemValue> listConfig = new List<ItemValue>();
            public void SetConfig(string item, string value)
            {
                ItemValue iv = new ItemValue();
                iv.SetValue(this, item, value);
            }
            public string GetConfig(string item)
            {
                foreach(ItemValue iv in listConfig)
                {
                    if (iv.GetItem() == item)
                        return iv.GetValue();
                }
                return "";
            }
            private class ItemValue
            {
                private string item;
                private string value;

                public void SetValue(Configuration config, string item, string value)
                {
                    this.item = item;
                    this.value = value;

                    bool found = false;
                    for(int i = 0; i < config.listConfig.Count; i++)
                    {
                        if (config.listConfig[i].item == item)
                        {
                            config.listConfig[i] = this;
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                        config.listConfig.Add(this);
                }

                public string GetItem()
                {
                    return item;
                }
                public string GetValue()
                {
                    return value;
                }
            }
       }
    }              // 13. 중첩 클래스
    class PartialClass
    {
        public PartialClass()
        {
            MyClass obj = new MyClass();
            obj.method1();
            obj.method2();
            obj.method3();
            obj.method4();
        }
        partial class MyClass
        {
            public void method1()
            {
                WriteLine("Method1");
            }
            public void method2()
            {
                WriteLine("Method2");
            }
        }
        partial class MyClass
        {
            public void method3()
            {
                WriteLine("Method3");
            }
            public void method4()
            {
                WriteLine("Method4");
            }
        }
    }             // 14. 분할 클래스

    #region class ExtensionMethod             // 15. 확장 클래스
    class ExtensionMethod
    {
        
        public ExtensionMethod()
        {
            WriteLine($"3^2 : {3.Square()}");
            WriteLine($"3^4 : {3.Power(4)}");
            WriteLine($"2^10 : {2.Power(10)}");

            string hello = "Hello";
            WriteLine(hello.Append(", World!"));
        }    
    }
    public static class IntergerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }
        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int i = 1; i < exponent; i++)
                result *= myInt;

            return result;
        }
    }

    public static class StringExtension // 비타민 퀴즈 7-1 p275
    {
        public static string Append(this string myString, string AppendString)
        {
            return myString += AppendString;
        }
    }
    #endregion                             
    class Structure
    {
        public Structure()
        {
            Point3D p3d1;
            p3d1.X = 10;
            p3d1.Y = 20;
            p3d1.Z = 40;

            WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100, 200, 300);
            Point3D p3d3 = p3d2;
            p3d3.Z = 400;

            WriteLine(p3d2.ToString());
            WriteLine(p3d2.ToString());
        }

        struct Point3D
        {
            public int X;
            public int Y;
            public int Z;

            public Point3D(int X, int Y, int Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }

            public override string ToString()
            {
                return string.Format($"{X}, {Y}, {Z}");
            }
        }
    }                // 16. 구조체
}
