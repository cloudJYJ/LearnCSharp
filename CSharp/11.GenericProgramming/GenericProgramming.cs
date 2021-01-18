using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _11.GenericProgramming
{
    class GenericProgramming
    {
        static void Main()
        {
            WriteLine("[ 1 ] 일반화 메소드");
            WriteLine("[ 2 ] 일반화 클래스");
            WriteLine("[ 3 ] 형식 매개 변수 제약");
            WriteLine("[ 4 ] 일반화 컬렉션 List<T>");
            WriteLine("[ 5 ] 일반화 컬렉션 Queue<T>");
            WriteLine("[ 6 ] 일반화 컬렉션 Stack<T>");
            WriteLine("[ 7 ] 일반화 컬렉션 Dictionary <T>");
            WriteLine("[ 8 ] Foreach를 사용할 수 있는 일반화 클래스");
            string choice = ReadLine();
            if (choice == "1") { GenericMethod genericmethod = new GenericMethod(); }
            if (choice == "2") { GenericClass genericclass = new GenericClass(); }
            if (choice == "3") { ConstraintsOnTypeParameters constraintsontypsparameters = new ConstraintsOnTypeParameters(); }
            if (choice == "4") { UsingGenericList usinggenericlist = new UsingGenericList(); }
            if (choice == "5") { UsingGenericQueue usinggenericqueue = new UsingGenericQueue(); }
            if (choice == "6") { UsingGenericStack usinggenericstack = new UsingGenericStack(); }
            if (choice == "7") { UsingDictionary usingdictionary = new UsingDictionary(); }
            if (choice == "8") { EnumerableGeneric enumerablegeneric = new EnumerableGeneric(); }
            WriteLine("이 창을 닫으시려면 아무키나 누르세요...");
            ReadKey();
        }
    }
    class GenericMethod
    {
        public GenericMethod()
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);

            foreach (int element in target)
                WriteLine(element);

            string[] source2 = {"하나","둘","셋","넷","다섯"};
            string[] target2 = new string[source2.Length];

            CopyArray<string>(source2, target2);

            foreach (string element in target2)
                WriteLine(element);
        }

        static void CopyArray<T>(T[] source, T[] target)
        {
            for (int i = 0; i < source.Length; i++)
                target[i] = source[i];
        }
    }                   // 1. 일반화 메소드
    class GenericClass
    {
        public GenericClass()
        {
            MyList<string> str_list = new MyList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            for (int i = 0; i < str_list.Length; i++)
                WriteLine(str_list[i]);

            WriteLine();

            MyList<int> int_list = new MyList<int>();
            int_list[0] = 0;
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3;
            int_list[4] = 4;

            for (int i = 0; i < int_list.Length; i++)
                WriteLine(int_list[i]);
        }

        class MyList<T>
        {
            private T[] array;

            public MyList()
            {
                array = new T[3];
            }

            public T this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    if(index >= array.Length)
                    {
                        Array.Resize<T>(ref array, index + 1);
                        WriteLine($"Array Resized : {array.Length}");
                    }
                    array[index] = value;
                }
            }

            public int Length
            {
                get { return array.Length; }
            }
        }
    }                    // 2. 일반화 클래스
    class ConstraintsOnTypeParameters
    {
        public ConstraintsOnTypeParameters()
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Dervied();
            c.Array[2] = CreateInstance<Base>();

            BaseArray<Dervied> d = new BaseArray<Dervied>(3);
            d.Array[0] = new Dervied();
            d.Array[1] = CreateInstance<Dervied>();
            d.Array[2] = CreateInstance<Dervied>();

            BaseArray<Dervied> e = new BaseArray<Dervied>(3);
            e.CopyArray<Dervied>(d.Array);
        }

        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        class StructArray<T> where T : struct
        {
            public T[] Array { get; set; }
            public StructArray(int size)
            {
                Array = new T[size];
            }
        }

        class RefArray<T> where T : class
        {
            public T[] Array { get; set; }
            public RefArray(int size)
            {
                Array = new T[size];
            }
        }

        class Base { }
        class Dervied : Base { }
        class BaseArray<U> where U : Base
        {
            public U[] Array { get; set; }
            public BaseArray(int size)
            {
                Array = new U[size];
            }

            public void CopyArray<T>(T[] Source) where T : U
            {
                Source.CopyTo(Array, 0);
            }
        }
    }     // 3. 형식 매개 변수 제약
    class UsingGenericList
    {
        public UsingGenericList()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (int element in list)
                Write($"{element} ");
            WriteLine();

            list.RemoveAt(2);

            foreach (int element in list)
                Write($"{element} ");
            WriteLine();

            list.Insert(2, 2);

            foreach (int element in list)
                Write($"{element} ");
            WriteLine();
        }
    }                // 4. 일반화 컬렉션 List<T>
    class UsingGenericQueue
    {
        public UsingGenericQueue() 
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            while (queue.Count > 0)
                WriteLine(queue.Dequeue());
        }
    }               // 5. 일반화 컬렉션 Queue<T>
    class UsingGenericStack
    {
        public UsingGenericStack()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while (stack.Count > 0)
                WriteLine(stack.Pop());
        } 
    }               // 6. 일반화 컬렉션 Stack<T>
    class UsingDictionary
    {
        public UsingDictionary()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic["하나"] = "one";
            dic["둘"] = "two";
            dic["셋"] = "three";
            dic["넷"] = "four";
            dic["다섯"] = "five";

            WriteLine(dic["하나"]);
            WriteLine(dic["둘"]);
            WriteLine(dic["셋"]);
            WriteLine(dic["넷"]);
            WriteLine(dic["다섯"]);
        }
    }                 // 7. 일반화 컬렉션 Dictionary<T>
    class EnumerableGeneric
    {
        public EnumerableGeneric()
        {
            MyList<string> str_list = new MyList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            foreach (string str in str_list)
                WriteLine(str);

            WriteLine();

            MyList<int> int_list = new MyList<int>();
            int_list[0] = 0;
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3;
            int_list[4] = 4;

            foreach (int no in int_list)
                WriteLine(no);
        }

        class MyList<T> : IEnumerable<T>, IEnumerator<T>
        {
            private T[] array;
            int position = -1;

            public MyList()
            {
                array = new T[3];
            }

            public T this[int index]
            {
                get
                {
                    return array[index];
                }

                set
                {
                    if(index >= array.Length)
                    {
                        Array.Resize<T>(ref array, index + 1);
                        WriteLine($"Array Resized : {array.Length}");
                    }

                    array[index] = value;
                }
            }

            public int Length
            {
                get { return array.Length; }
            }

            public IEnumerator<T> GetEnumerator()
            {
                for(int i = 0; i<array.Length; i++)
                {
                    yield return (array[i]);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                for(int i = 0; i < array.Length; i++)
                {
                    yield return (array[i]);
                }
            }

            public T Current
            {
                get { return array[position]; }
            }

            object IEnumerator.Current
            {
                get { return array[position]; }
            }

            public bool MoveNext()
            {
                if(position == array.Length - 1)
                {
                    Reset();
                    return false;
                }

                position++;
                return (position < array.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            public void Dispose()
            {

            }
        }
    }               // 8. Foreach를 사용할 수 있는 일반화 클래스
}
