using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _13.Delegate_Event
{
    class Program
    {
        static void Main()
        {
            WriteLine("[ 1 ] 대리자");
            WriteLine("[ 2 ] 대리자 활용");
            WriteLine("[ 3 ] 일반화 대리자");
            WriteLine("[ 4 ] 대리자 체인");
            WriteLine("[ 5 ] 익명 메소드");
            WriteLine("[ 6 ] 이벤트 테스트");
            string choice = ReadLine();
            if(choice == "1") { Delegate0 Delegate = new Delegate0(); }
            if(choice == "2") { UsingDelegate usingdelegate = new UsingDelegate(); }
            if(choice == "3") { GenericDelegate genericdelegate = new GenericDelegate(); }
            if(choice == "4") { DelegateChains delegatechains = new DelegateChains(); }
            if(choice == "5") { AnonymousMethod anonymousmethod = new AnonymousMethod(); }
            if(choice == "6") { EventTest eventtest = new EventTest(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            ReadKey();
        }
    }

    class Delegate0
    {
        delegate int MyDelegate(int a, int b);
        public Delegate0()
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            WriteLine(Callback(3, 4));

            Callback = new MyDelegate(Calc.Minus);
            WriteLine(Callback(7, 5));
        }

        class Calculator
        {
            public int Plus(int a, int b)
            {
                return a + b;
            }
            public int Minus(int a, int b)
            {
                return a - b;
            }
        }
    }                  // 1. 대리자
    class UsingDelegate
    {
        delegate int Compare(int a, int b);

        public UsingDelegate()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting ascending...");
            BubbleSort(array, new Compare(AscendCompare));

            for (int i = 0; i < array.Length; i++)
                Write($"{array[i]} ");

            int[] array2 = { 7, 2, 8, 10, 11 };
            WriteLine("\nSorting descending...");
            BubbleSort(array2, new Compare(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
                Write($"{array2[i]} ");

            WriteLine();
        }
        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }
        static int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }
        static int DescendCompare(int a, int b)
        {
            if (a < b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }
    }              // 2. 대리자 활용
    class GenericDelegate
    {
        delegate int Compare<T>(T a, T b);
        public GenericDelegate()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting ascending...");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for (int i = 0; i < array.Length; i++)
                Write($"{array[i]} ");

            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };

            WriteLine("\nSorting Descending...");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
                Write($"{array2[i]} ");

            WriteLine();
        }

        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;
        }

        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0;
            int j = 0;
            T temp;

            for(i = 0; i<DataSet.Length-1; i++)
            {
                for(j = 0; j<DataSet.Length - (i+1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }
    }            // 3. 일반화 대리자
    class DelegateChains
    {
        public DelegateChains()
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            notifier.Event0ccured += listener1.SomethingHappend;
            notifier.Event0ccured += listener2.SomethingHappend;
            notifier.Event0ccured += listener3.SomethingHappend;
            notifier.Event0ccured("You've got mail");

            WriteLine();

            notifier.Event0ccured -= listener2.SomethingHappend;
            notifier.Event0ccured("Download complete.");

            WriteLine();

            notifier.Event0ccured = new Notify(listener2.SomethingHappend)
                                  + new Notify(listener3.SomethingHappend);
            notifier.Event0ccured("Nuclear launch detected.");

            WriteLine();

            Notify notify1 = new Notify(listener1.SomethingHappend);
            Notify notify2 = new Notify(listener2.SomethingHappend);

            notifier.Event0ccured = (Notify)Delegate.Combine(notify1, notify2);
            notifier.Event0ccured("Fire!!");

            WriteLine();

            notifier.Event0ccured = (Notify)Delegate.Remove(notifier.Event0ccured, notify2);

            notifier.Event0ccured("RPG!!");

        }

        delegate void Notify(string message);

        class Notifier
        {
            public Notify Event0ccured;
        }

        class EventListener
        {
            private string name;
            public EventListener(string name)
            {
                this.name = name;
            }

            public void SomethingHappend(string message)
            {
                WriteLine($"{name}.SomethingHappened : {message}");
            }
        }
    }             // 4. 대리자 체인
    class AnonymousMethod
    {
        delegate int Compare(int a, int b);
        public AnonymousMethod()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting Ascending...");
            BubbleSort(array, delegate (int a, int b)   // 익명 메소드
            {
                if (a > b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });

            for (int i = 0; i < array.Length; i++)
                Write($"{array[i]} ");

            int[] array2 = { 7, 2, 8, 10, 11 };
            WriteLine("\nSorting Descending...");
            BubbleSort(array2, delegate (int a, int b)
            {
                if (a < b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });

            for (int i = 0; i < array2.Length; i++)
                Write($"{array2[i]} ");

            WriteLine();
        }
        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for(i = 0; i < DataSet.Length-1; i++)
            {
                for(j = 0; j < DataSet.Length - (i+1); j++)
                {
                    if(Comparer(DataSet[j], DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }
    }            // 5. 익명 메소드
    class EventTest
    {
        delegate void EventHandler(string message);
        public EventTest()
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyNotifier.MyHandler);

            for(int i = 1; i<30; i++)
            {
                notifier.DoSomething(i);
            }
        }

        class MyNotifier
        {
            public event EventHandler SomethingHappened;
            public void DoSomething(int number)
            {
                int temp = number % 10;

                if(temp != 0 && temp % 3 == 0)
                {
                    SomethingHappened(String.Format("{0} : 짝",number));
                }
            }
            static public void MyHandler(string message)
            {
                WriteLine(message);
            }
        }
    }                  // 6. 이벤트 테스트
}
