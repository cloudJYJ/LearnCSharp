using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _17.Dynamic
{
    class Dynamic
    {
        static void Main()
        {
            WriteLine("[ 1 ] 오리 타이핑");
            string choice = ReadLine();
            if(choice == "1") { DuckTyping ducktyping = new DuckTyping(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            ReadKey();
        }
    }
    class DuckTyping
    {
        class Duck
        {
            public void Walk()
            { WriteLine(this.GetType() + ".Walk"); }
            public void Swim()
            { WriteLine(this.GetType() + ".Swim"); }
            public void Quack()
            { WriteLine(this.GetType() + ".Quack"); }
        }
        class Mallard : Duck
        { }

        class Robot
        {
            public void Walk()
            { WriteLine("Robot.Walk"); }
            public void Swim()
            { WriteLine("Robot.Swim"); }
            public void Quack()
            { WriteLine("Robot.Quack"); }
        }
        public DuckTyping()
        {
            dynamic[] arr = new dynamic[] { new Duck(), new Mallard(), new Robot() };
            //Duck[] arr = new Duck[] { new Duck(), new Mallard(), new Robot() };   // Robot은 Duck을 상속받지 않아서 Duck형식이 아니라 에러를 일으킴

            foreach(dynamic duck in arr)
            {
                WriteLine(duck.GetType());
                duck.Walk();
                duck.Swim();
                duck.Quack();

                WriteLine();
            }
        }
    }                   // 1. 오리 타이핑
}
