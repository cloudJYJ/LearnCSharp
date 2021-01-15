using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5.NameCard
{
    class Program
    {
        /* 다음 코드에서 NameCard 클래스의 메소드들을 프로퍼티로 변경해 작성하세요.
        class NameCard
        {
            private int age;
            private string name;

            public int GetAge()
            { return age; }

            public void SetAge(int value)
            { age = value; }

            public string GetName()
            { return name; }

            public void SetName(string value)
            { name = value; }
        }

        static void Main(string[] args)
        {
            NameCard MyCard = new NameCard();

            MyCard.SetAge(24);
            MyCard.SetName("상현");

            Console.WriteLine("나이 : {0}", MyCard.GetAge());
            Console.WriteLine("이름 : {0}", MyCard.GetName());

        }
        */
        class NameCard
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            NameCard MyCard = new NameCard();

            MyCard.Age = 24;
            MyCard.Name = "상현";

            Console.WriteLine("나이 : {0}",MyCard.Age);
            Console.WriteLine("이름 : {0}", MyCard.Name);

            Console.WriteLine("이 창을 닫으시려면 아무키나 누르세요...");
            Console.ReadKey();
        }
    }
}
