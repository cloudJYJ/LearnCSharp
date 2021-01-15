using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace _8.Interface_Abstract
{
    class Program
    {
        static void Main()
        {
            WriteLine("[ 1 ] 인터페이스");
            WriteLine("[ 2 ] 인터페이스간 상속");
            WriteLine("[ 3 ] 인터페이스 다중 상속");
            WriteLine("[ 4 ] 추상 클래스");
            string choice = ReadLine();
            if(choice == "1") { Interface Interface = new Interface(); }
            if(choice == "2") { DerivedInterface DerivedInterface = new DerivedInterface(); }
            if(choice == "3") { MultiInterfaceInheritance multiinterfaceinheritance = new MultiInterfaceInheritance(); }
            if(choice == "4") { AbstractClass abstractClass = new AbstractClass(); }
            WriteLine("이 창을 닫으려면 아무 키나 누르세요...");
            ReadKey();
        }
    }

    class Interface
    {
        public Interface()
        {
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));
            // 비타민 퀴즈 8-1 p293
            // ClimateMonitor의 logger가 FileLogger 대신 ConsoleLogger의 객체를 가리키도록 바꿔서 테스트 해보세요.
            // ClimateMonitor monitor = new ClimateMonitor(new FileLogger());

            monitor.start();
        }

        interface ILogger
        {
            void WriteLog(string message);
        }

        class ConsoleLogger : ILogger
        {
            public void WriteLog(string message)
            {
                WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
            }
        }

        class FileLogger : ILogger
        {
            private StreamWriter writer;
            public FileLogger(string path)
            {
                writer = File.CreateText(path);
                writer.AutoFlush = true;
            }
            public void WriteLog(string message)
            {
                WriteLine("{0} {1}",DateTime.Now.ToShortTimeString(),message);
            }
        }

        class ClimateMonitor
        {
            private ILogger logger;
            public ClimateMonitor(ILogger logger)
            {
                this.logger = logger;
            }

            public void start()
            {
                while (true)
                {
                    Write("온도를 입력해주시요 : ");
                    string temperature = ReadLine();
                    if (temperature == "")
                        break;

                    logger.WriteLog("현재 온도 : " + temperature);
                }
            }
        }
    }                   // 1. 인터페이스
    class DerivedInterface
    {
        public DerivedInterface()
        {
            IFormattableLogger logger = new ConsoleLogger2();
            logger.WriteLog("The world is not flat.");
            logger.WriteLog("{0} + {1} = {2}", 1, 1, 2);
        }
        interface ILogger
        {
            void WriteLog(string message);
        }

        interface IFormattableLogger : ILogger
        {
            void WriteLog(string format, params Object[] args);
        }

        class ConsoleLogger2 : IFormattableLogger
        {
            public void WriteLog(string message)
            {
                WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
            }

            public void WriteLog(string format, params Object[] args)
            {
                String message = String.Format(format, args);
                WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
            }
        }
    }            // 2. 인터페이스간 상속
    class MultiInterfaceInheritance
    {
        public MultiInterfaceInheritance()
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            IRunnable runnable = car as IRunnable;
            runnable.Run();

            IFlayable flyable = car as IFlayable;
            flyable.Fly();
        }

        interface IRunnable
        {
            void Run();
        }

        interface IFlayable
        {
            void Fly();
        }

        class FlyingCar : IRunnable, IFlayable
        {
            public void Run()
            {
                WriteLine("Run! Run!");
            }
            public void Fly()
            {
                WriteLine("Fly! Fly!");
            }
        }
        
    }   // 3. 인터페이스 다중 상속
    class AbstractClass
    {
        public AbstractClass()
        {
            AbstractBase obj = new Derived();
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }

        abstract class AbstractBase
        {
            protected void ProtectdMethodA()
            {
                WriteLine("AbstractBase.ProtectedMethodA()");
            }

            public void PublicMethodA()
            {
                WriteLine("AbstractBase.PublicMethodA()");
            }

            public abstract void AbstractMethodA();
        }

        class Derived : AbstractBase
        {
            public override void AbstractMethodA()
            {
                WriteLine("Derived.AbstractMethodA()");
                ProtectdMethodA();
            }
        }
    }               // 4. 추상 클래스
}
