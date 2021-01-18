using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _10.Array_Collection_Indexer
{
    class Program
    {
        static void Main()
        {
            WriteLine("[ 1 ] 샘플 배열");
            WriteLine("[ 2 ] 배열 초기화");
            WriteLine("[ 3 ] System.Array");
            WriteLine("[ 4 ] 배열 활용");
            WriteLine("[ 5 ] 2차원 배열");
            WriteLine("[ 6 ] 3차원 배열");
            WriteLine("[ 7 ] 가변 배열");
            WriteLine("[ 8 ] 리스트 사용");
            WriteLine("[ 9 ] 큐 사용");
            WriteLine("[10 ] 스택 사용");
            WriteLine("[11 ] 해쉬테이블 사용");
            WriteLine("[12 ] 컬렉션 초기화");
            WriteLine("[13 ] 인덱서");
            WriteLine("[14 ] Yield");
            WriteLine("[15 ] Enumerable");
            string choice = ReadLine();
            if (choice == "1") { ArraySample arraysample = new ArraySample(); }
            if (choice == "2") { InitializingArray initializingarray = new InitializingArray(); }
            if (choice == "3") { DerivedFromArray derivedfromarray = new DerivedFromArray(); }
            if (choice == "4") { MoreOnArray moreonarray = new MoreOnArray(); }
            if (choice == "5") { _2DArray _2darray = new _2DArray(); }
            if (choice == "6") { _3DArray _3darray = new _3DArray(); }
            if (choice == "7") { JaggedArray jaggedarray = new JaggedArray(); }
            if (choice == "8") { UsingList usinglist = new UsingList(); }
            if (choice == "9") { UsingQueue usingqueue = new UsingQueue(); }
            if (choice == "10") { UsingStack usingstack = new UsingStack(); }
            if (choice == "11") { UsingHashTable hashtable = new UsingHashTable(); }
            if (choice == "12") { InitializingCollections initialzingcollections = new InitializingCollections(); }
            if (choice == "13") { Indexer indexer = new Indexer(); }
            if (choice == "14") { Yield yield = new Yield(); }
            if (choice == "15") { Enumerable enumerable = new Enumerable(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            ReadKey();
        }
    }
    class ArraySample
    {
        public ArraySample()
        {
            int[] scores = new int[5];
            scores[0] = 80;
            scores[1] = 74;
            scores[2] = 81;
            scores[3] = 90;
            scores[4] = 34;

            foreach (int score in scores)
                WriteLine(score);

            int sum = 0;
            foreach (int score in scores)
                sum += score;

            int average = sum / scores.Length;

            WriteLine($"Average Score : {average}");
        }
    }               // 1. 샘플 배열
    class InitializingArray
    {
        public InitializingArray()
        {
            string[] array1 = new string[3] { "안녕", "Hello", "Halo" };

            WriteLine("Array1...");
            foreach (string greeting in array1)
                WriteLine($"{greeting}");

            string[] array2 = new string[] { "안녕", "Hello", "Halo" };

            WriteLine("Array2...");
            foreach (string greeting in array2)
                WriteLine($"{greeting}");

            string[] array3 = { "안녕", "Hello", "Halo" };

            WriteLine("Array3...");
            foreach (string greeting in array3)
                WriteLine($"{greeting}");
        }
    }         // 2. 배열 초기화
    class DerivedFromArray
    {
        public DerivedFromArray()
        {
            int[] array = new int[] { 10, 30, 20, 7, 1 };
            WriteLine($"Type Of array : {array.GetType()}");
            WriteLine($"Base type Of array : {array.GetType().BaseType}");
        }
    }          // 3. System.Array
    class MoreOnArray
    {
        public MoreOnArray()
        {
            int[] scores = new int[] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
                Write($"{score} ");
            WriteLine();

            // 배열 정렬
            Array.Sort(scores);
            // 배열에 모든 요소에대해 action을 수행함
            Array.ForEach<int>(scores, new Action<int>(print));

            WriteLine();
            // 배열의 차원을 반환
            WriteLine($"Number of dimensions : {scores.Rank}");

            // 이진 탐색 수행
            WriteLine("Binary Search : 81 is at {0}", Array.BinarySearch<int>(scores, 81));
            // 특정 데이터의 인덱스를 반환
            WriteLine("Linear Search : 90 is at {0}", Array.IndexOf(scores, 90));

            WriteLine("Everyone passed ? : {0}", Array.TrueForAll<int>(scores, CheckPassed));

            int index = Array.FindIndex<int>(scores,
                delegate (int score)
                {
                    if (score < 60)
                        return true;
                    else
                        return false;
                });

            scores[index] = 61;

            WriteLine("Everyone passed ? : {0}", Array.TrueForAll<int>(scores, CheckPassed));

            WriteLine($"Old length of scores : {scores.GetLength(0)}");

            // 배열의 크기를 재조정함
            Array.Resize<int>(ref scores, 10);

            WriteLine($"New length of scores : {scores.Length}");

            Array.ForEach<int>(scores, new Action<int>(print));
            WriteLine();

            Array.Clear(scores, 3, 7);

            Array.ForEach<int>(scores, new Action<int>(print));
            WriteLine();
        }
        private static bool CheckPassed(int score)
        {
            if (score >= 60)
                return true;
            else
                return false;
        }
        private static void print(int value)
        {
            Write($"{value} ");
        }
    }               // 4. 배열 활용
    class _2DArray
    {
        public _2DArray()
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Write($"[{i}, {j}] : {arr[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();

            int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Write($"[{i}, {j}] : {arr2[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();

            int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    Write($"[{i}, {j}] : {arr3[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();
        }
    }                  // 5. 2차원 배열
    class _3DArray
    {
        public _3DArray()
        {
            int[,,] array = new int[4, 3, 2]
            {
                { { 1,2 },{ 3,4 },{ 5,6 } },
                { { 1,4 },{ 2,5 },{ 3,6 } },
                { { 6,5 },{ 4,3 },{ 2,1 } },
                { { 6,3 },{ 5,2 },{ 4,1 } },
            };

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Write("{ ");
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Write($"{array[i, j, k]}");
                    }
                    Write(" }");
                }
                WriteLine();
            }
        }
    }                  // 6. 3차원 배열
    class JaggedArray
    {
        public JaggedArray()
        {
            int[][] jagged = new int[3][];
            jagged[0] = new int[5] { 1, 2, 3, 4, 5 };
            jagged[1] = new int[] { 10, 20, 30 };
            jagged[2] = new int[] { 100, 200 };

            foreach(int[] arr in jagged)
            {
                Write($"Length : {arr.Length}, ");
                foreach( int e in arr)
                {
                    Write($"{e} ");
                }
                WriteLine();
            }

            WriteLine();

            int[][] jagged2 = new int[2][]
            {
                new int[] {1000,2000},
                new int[4] {6,7,8,9}
            };

            foreach(int[] arr in jagged2)
            {
                Write($"Length : {arr.Length}, ");
                foreach(int e in arr)
                {
                    Write($"{e} ");
                }
                WriteLine();
            }
        }
    }               // 7. 가변 배열
    class UsingList
    {
        public UsingList()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.RemoveAt(2);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Insert(2, 2);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Add("adc");
            list.Add("def");

            for (int i = 0; i < list.Count; i++)
                Write($"{list[i]} ");
            WriteLine();
        }
    }                 // 8. 리스트 사용
    class UsingQueue
    {
        public UsingQueue()
        {
            Queue que = new Queue();
            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(5);

            while (que.Count > 0)
                WriteLine(que.Dequeue());
        }
    }                // 9. 큐 사용
    class UsingStack
    {
        public UsingStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(4);

            while (stack.Count > 0)
                WriteLine(stack.Pop());
        }
    }                // 10. 스택 사용
    class UsingHashTable
    {
        public UsingHashTable()
        {
            Hashtable ht = new Hashtable();
            ht["하나"] = "one";
            ht["둘"] = "two";
            ht["셋"] = "three";
            ht["넷"] = "four";
            ht["다섯"] = "five";

            WriteLine(ht["하나"]);
            WriteLine(ht["둘"]);
            WriteLine(ht["셋"]);
            WriteLine(ht["넷"]);
            WriteLine(ht["다섯"]);
        }
    }            // 11. 해쉬테이블 사용
    class InitializingCollections
    {
        public InitializingCollections()
        {
            int[] arr = { 123, 456, 789 };

            ArrayList list = new ArrayList(arr);
            foreach (object item in list)
                WriteLine($"ArrayList : {item}");
            WriteLine();

            Stack stack = new Stack(arr);
            foreach (object item in stack)
                WriteLine($"Stack : {item}");

            Queue queue = new Queue(arr);
            foreach (object item in queue)
                WriteLine($"Queue : {item}");

            ArrayList list2 = new ArrayList() { 11, 22, 33 };
            foreach (object item in list2)
                WriteLine($"ArrayList2 : {item}");
            WriteLine();
        }
    }   // 12. 컬렉션 초기화
    class Indexer{
        class MyList
        {
            private int[] array;

            public MyList()
            {
                array = new int[3];
            }

            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    if (index >= array.Length)
                    {
                        Array.Resize<int>(ref array, index + 1);
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
        public Indexer()
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            for (int i = 0; i < list.Length; i++)
                WriteLine(list[i]);
        }
    }                   // 13. 인덱서
    class Yield
    {
        public Yield()
        {
            var obj = new MyEnumrator();
            foreach (int i in obj)
                WriteLine(i);
        }
        class MyEnumrator
        {
            int[] numbers = { 1, 2, 3, 4 };
            public IEnumerator GetEnumerator()
            {
                yield return numbers[0];
                yield return numbers[1];
                yield return numbers[2];
                yield break;               
                yield return numbers[3];
            }
        }
    }                     // 14. Yield
    class Enumerable
    {
        public Enumerable()
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            foreach (int e in list)
                WriteLine(e);
        }
        class MyList : IEnumerable, IEnumerator
        {
            private int[] array;
            int position = -1;

            public MyList()
            {
                array = new int[3];
            }

            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    if(index >= array.Length)
                    {
                        Array.Resize<int>(ref array, index + 1);
                        WriteLine($"Array Resized : {array.Length}");
                    }

                    array[index] = value;
                }
            }
            
            // IEnumerator 멤버
            public object Current
            {
                get
                {
                    return array[position];
                }
            }

            // IEnumerator 멤버
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

            // IEnumerator 멤버
            public void Reset()
            {
                position = -1;
            }

            // IEnumerable 멤버
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < array.Length; i++)
                    yield return (array[i]);
            }
        }
    }                // 15. Enumrable
}
