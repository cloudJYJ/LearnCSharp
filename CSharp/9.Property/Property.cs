using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _9.Property
{
    class Program
    {
        static void Main()
        {
            WriteLine("[ 1 ] 프로퍼티");
            WriteLine("[ 2 ] 자동 구현 프로퍼티");
            WriteLine("[ 3 ] 생성자와 프로퍼티");
            WriteLine("[ 4 ] 익명 타입");
            WriteLine("[ 5 ] 프로퍼티 인터페이스 상속");
            WriteLine("[ 6 ] 추상 프로퍼티");
            string choice = ReadLine();
            if(choice == "1") { Property Property = new Property(); }
            if(choice == "2") { AutoImplementedProperty autoimplemendtedproperty = new AutoImplementedProperty(); }
            if(choice == "3") { ConstructorWithProperty constructorwithproperty = new ConstructorWithProperty(); }
            if(choice == "4") { AnonymusType anonymustype = new AnonymusType(); }
            if(choice == "5") { PropertiesInInterface propertiesininterface = new PropertiesInInterface(); }
            if(choice == "6") { PropertiesInAbstractClass propertiesInabstractclass = new PropertiesInAbstractClass(); } 
            WriteLine("이 창을 닫으려면 아무 키나 누르세요...");
            ReadKey();
        }
        
    }
    class Property
    {
        public Property()
        {
            BirthdayInfo birth = new BirthdayInfo();
            birth.Name = "서현";
            birth.BirthDay = new DateTime(1991, 6, 28);
            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.BirthDay.ToShortDateString()}");
            WriteLine($"Age : {birth.Age}");
        }
        class BirthdayInfo
        {
            private string name;
            private DateTime birthday;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public DateTime BirthDay
            {
                get { return birthday; }
                set { birthday = value; }
            }

            public int Age
            {
                get { return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year; }
            }
        }
    }                      // 1. 프로퍼티
    class AutoImplementedProperty
    {
        public AutoImplementedProperty()
        {
            BirthdayInfo birth = new BirthdayInfo();
            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
            WriteLine($"Age : {birth.Age}");

            birth.Name = "서현";
            birth.Birthday = new DateTime(1991, 6, 28);

            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
            WriteLine($"Age : {birth.Age}");
        }

        class BirthdayInfo
        {
            public string Name { get; set; } = "UnKnown";
            public DateTime Birthday { get; set; } = new DateTime(1, 1, 1);
            public int Age { get { return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year; } }
        }
    }       // 2. 자동 구현 프로퍼티
    class ConstructorWithProperty
    {
        public ConstructorWithProperty()
        {
            BirthdayInfo birth = new BirthdayInfo()
            {
                Name = "서현",
                Birthday = new DateTime(1991, 6, 28)
            };

            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
            WriteLine($"Age : {birth.Age}");
        }
        class BirthdayInfo
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
            public int Age { get { return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year; } }
        }
    }       // 3. 프로퍼티와 생성자
    class AnonymusType
    {
        public AnonymusType()
        {
            var a = new { Name = "박상현", Age = 123 };
            WriteLine($"Name : {a.Name}, Age : {a.Age}");

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } };
            Write($"Subject : {b.Subject}, Scores : ");
            foreach (var score in b.Scores)
                Write($"score");

            WriteLine();
        }
    }                  // 4. 익명 타입
    class PropertiesInInterface
    {
        public PropertiesInInterface()
        {
            NamedValue name = new NamedValue()
            { Name = "이름", Value = "박상현" };
            NamedValue height = new NamedValue()
            { Name = "키", Value = "177cm" };
            NamedValue weight = new NamedValue()
            { Name = "몸무게", Value = "90KG" };

            WriteLine($"{name.Name} : {name.Value}");
            WriteLine($"{height.Name} : {height.Value}");
            WriteLine($"{weight.Name} : {weight.Value}");
        }
        interface INamedValue
        {
            string Name
            {
                get;
                set;
            }
            string Value
            {
                get;
                set;
            }
        }

        class NamedValue : INamedValue
        {
            public string Name
            {
                get;
                set;
            }
            public string Value
            {
                get;
                set;
            }
        }

    }         // 5. 프로퍼티 인터페이스 상속
    class PropertiesInAbstractClass
    {
        public PropertiesInAbstractClass()
        {
            Product product_1 = new MyProduct()
            { ProductDate = new DateTime(2018, 1, 10) };

            WriteLine("Product:{0}, Product Date : {1}", product_1.SerialID, product_1.ProductDate);

            Product product_2 = new MyProduct()
            { ProductDate = new DateTime(2018, 1, 10) };

            WriteLine("Product:{0}, Product Date : {1}", product_2.SerialID, product_2.ProductDate);
        }
        abstract class Product
        {
            private static int serial = 0;
            public string SerialID { get { return String.Format("{0:d5}", serial++); } }
            abstract public DateTime ProductDate { get; set; }
        }

        class MyProduct : Product
        {
            public override DateTime ProductDate { get; set; }
        }
    }     // 6. 추상 프로퍼티
}
