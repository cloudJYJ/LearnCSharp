using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace _19.Thread_Task
{
    class Program
    {
        static void Main()
        {
            WriteLine("[ 1 ] 스레드");
            WriteLine("[ 2 ] 스레드 취소");
            WriteLine("[ 3 ] 스레드 상태");
            WriteLine("[ 4 ] 스레드 취소 : 인터럽트");
            WriteLine("[ 5 ] 스레드 동기화");
            WriteLine("[ 6 ] 스레드 동기화 : 모니터");
            WriteLine("[ 7 ] 스레드 저수준 동기화");
            WriteLine("[ 8 ] Task");
            WriteLine("[ 9 ] TaskResult");
            WriteLine("[10 ] ParallelLoop");
            WriteLine("[11 ] async/await 비동기");
            WriteLine("[12 ] AsyncFileIO");
            string choice = ReadLine();
            if (choice == "1") { BasicThread basicthread = new BasicThread(); }
            if (choice == "2") { AbortingThread abortingthread = new AbortingThread(); }
            if (choice == "3") { UsingTheadState usingthreadstate = new UsingTheadState(); }
            if (choice == "4") { InterruptingThread interruptingthread = new InterruptingThread(); }
            if (choice == "5") { Synchronize synchronize = new Synchronize(); }
            if (choice == "6") { UsingMonitor usingmonitor = new UsingMonitor(); }
            if (choice == "7") { WaitPulse waitpulse = new WaitPulse(); }
            if (choice == "8") { string[] args = {ReadLine()}; UsingTask usingtask = new UsingTask(args); }
            if (choice == "9") { TaskResult taskresult = new TaskResult(); }
            if (choice == "10") { ParallelLoop parallelloop = new ParallelLoop(); }
            if (choice == "11") { Async async = new Async(); }
            if (choice == "12") { string a = "a.txt",b = "b.txt"; AsyncFileIO asyncfileio = new AsyncFileIO(a,b); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요");
            ReadKey();
        }
    }  
    class BasicThread
    {
        public BasicThread()
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething));

            WriteLine("Strating thread...");
            t1.Start();

            for(int i = 0; i < 5; i++)
            {
                WriteLine($"Main : {i}");
                Thread.Sleep(10);
            }

            WriteLine("Waiting until thread stops...");
            t1.Join();

            WriteLine("Finished");
        }
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                WriteLine($"DoSomething : {i}");
                Thread.Sleep(10);    // 해당 메소드는 다른 스레드도 CPU를 사용할 수 있도록 CPU점유를 내려놓음 매개변수는 밀리초 단위
            }
        }
    }               // 1. 스레드
    class AbortingThread
    {
        class SideTask
        {
            int count;
            
            public SideTask(int count)
            {
                this.count = count;
            }

            public void KeepAlive()
            {
                try
                {
                    while(count > 0)
                    {
                        WriteLine($"{count--} left");
                        Thread.Sleep(10);
                    }
                    WriteLine("Count : 0");
                }
                catch(ThreadAbortException e)  // 스레드 취소(종료)
                {
                    WriteLine(e);
                }
                finally
                {
                    WriteLine("Clearing resource...");
                }
            }
        }
        public AbortingThread()
        {
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            WriteLine("Aborting thread");
            t1.Abort();

            WriteLine("Wating until thread stops...");
            t1.Join();

            WriteLine("Finished");
        }
    }            // 2. 스레드 취소
    class UsingTheadState
    {
        private static void PrintThreadState(ThreadState state)
        {
            WriteLine("{0,-16} : {1}", state, (int)state);
        }
        public UsingTheadState()
        {
            PrintThreadState(ThreadState.Running);

            PrintThreadState(ThreadState.StopRequested);

            PrintThreadState(ThreadState.SuspendRequested);

            PrintThreadState(ThreadState.Background);

            PrintThreadState(ThreadState.Unstarted);

            PrintThreadState(ThreadState.Stopped);

            PrintThreadState(ThreadState.WaitSleepJoin);

            PrintThreadState(ThreadState.Suspended);

            PrintThreadState(ThreadState.AbortRequested);

            PrintThreadState(ThreadState.Aborted);

            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped);
        }
    }           // 3. 스레드 상태
    class InterruptingThread
    {
        public InterruptingThread()
        {
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            WriteLine("Interrupting Thread...");
            t1.Interrupt();

            WriteLine("Wating until thread stops...");
            t1.Join();

            WriteLine("Finished");
        }
        class SideTask
        {
            int count;

            public SideTask(int count)
            {
                this.count = count;
            }

            public void KeepAlive()
            {
                try
                {
                    WriteLine("Running thread isn't gonna be interrupted");
                    Thread.SpinWait(1000000000);

                    while(count > 0)
                    {
                        WriteLine($"{count--} left");

                        WriteLine("Entering into WaitJoinSleep State...");
                        Thread.Sleep(10);
                    }
                    WriteLine("Count : 0");
                }
                catch (ThreadInterruptedException e)
                {
                    WriteLine(e);
                }
                finally
                {
                    WriteLine("Clearing resource...");
                }
            }
        }
    }        // 4. 스레드 취소:인터럽트
    class Synchronize
    {
        public Synchronize()
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        class Counter
        {
            const int LOOP_COUNT = 1000;

            readonly object thisLock;

            private int count;
            public int Count
            {
                get { return count; }
            }

            public Counter()
            {
                thisLock = new object();
                count = 0;
            }

            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while(loopCount-- > 0)
                {
                    lock (thisLock)
                    {
                        count++;
                    }
                    Thread.Sleep(1);
                }
            }

            public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while(loopCount-- > 0)
                {
                    lock (thisLock)
                    {
                        count--;
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }               // 5. 스레드 동기화
    class UsingMonitor
    {
        public UsingMonitor()
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        class Counter
        {
            const int LOOP_COUNT = 1000;

            readonly object thisLock;

            private int count;
            public int Count
            {
                get { return count; }
            }

            public Counter()
            {
                thisLock = new object();
                count = 0;
            }

            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    Monitor.Enter(thisLock);
                    try { count++; }
                    finally { Monitor.Exit(thisLock); }
                    Thread.Sleep(1);
                }
            }

            public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    Monitor.Enter(thisLock);
                    try { count--; }
                    finally { Monitor.Exit(thisLock); }
                    Thread.Sleep(1);
                }
            }
        }
    }              // 6. 스레드 동기화:모니터
    class WaitPulse
    {
        public WaitPulse()
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        class Counter
        {
            const int LOOP_COUNT = 1000;

            readonly object thisLock;
            bool lockedCount = false;

            private int count;
            public int Count
            {
                get { return count; }
            }

            public Counter()
            {
                thisLock = new object();
                count = 0;
            }

            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thisLock)
                    {
                        while (count > 0 || lockedCount == true)
                            Monitor.Wait(thisLock);

                        lockedCount = true;
                        count++;
                        lockedCount = false;

                        Monitor.Pulse(thisLock);
                    }
                }
            }

            public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thisLock)
                    {
                        while (count < 0 || lockedCount == true)
                            Monitor.Wait(thisLock);

                        lockedCount = true;
                        count--;
                        lockedCount = false;

                        Monitor.Pulse(thisLock);
                    }
                }
            }
        }
    }                 // 7. 스레드 저수준 동기화
    class UsingTask
    {
        public UsingTask(string[] args)
        {
            string srcFile = args[0];

            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state;
                File.Copy(paths[0], paths[1]);

                WriteLine("TaskID:{0}, ThreadID:{1}, {2} was copied to {3}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, paths[0], paths[1]);
            };

            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });

            Task t2 = Task.Run(()=> { FileCopyAction(new string[] { srcFile, srcFile + ".copy2" }); });

            t1.Start();

            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });

            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
    }                 // 8. Task
    class TaskResult
    {
        static bool IsPrime(long number)
        {
            if (number < 2)
                return false;

            if (number % 2 == 0 && number != 2)
                return false;

            for(long i = 2; i< number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return false;
        }

        public TaskResult()
        {
            long from = Convert.ToInt64(ReadLine());
            long to = Convert.ToInt64(ReadLine());
            int taskcount = Convert.ToInt32(ReadLine());

            Func<object, List<long>> FindPrimeFunc = (objRange) =>
            {
                long[] range = (long[])objRange;
                List<long> found = new List<long>();

                for (long i = range[0]; i < range[1]; i++)
                {
                    if (IsPrime(i))
                        found.Add(i);
                }
                return found;
            };

            Task<List<long>>[] tasks = new Task<List<long>>[taskcount];
            long currentFrom = from;
            long currentTo = to / tasks.Length;
            for(int i = 0; i< tasks.Length; i++)
            {
                WriteLine("Task[{0}] : {1} ~ {2}", i, currentFrom, currentTo);
                
                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] { currentFrom, currentTo });
                currentFrom = currentTo + 1;

                if (i == tasks.Length - 2)
                    currentTo = to;
                else
                    currentTo = currentTo + (to / tasks.Length);
            }

            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Started...");

            DateTime startTime = DateTime.Now;

            foreach (Task<List<long>> task in tasks)
                task.Start();

            List<long> total = new List<long>();

            foreach(Task<List<long>> task in tasks)
            {
                task.Wait();
                total.AddRange(task.Result.ToArray());
            }
            DateTime endTime = DateTime.Now;

            TimeSpan elapsed = endTime - startTime;

            WriteLine("Prime number count between {0} and {1} : {2}", from, to, total.Count);

            WriteLine("Elapsed time : {0}", elapsed);
        }
    }                // 9. TaskResult
    class ParallelLoop
    {
        static bool IsPrime(long number)
        {
            if (number < 2)
                return false;

            if (number % 2 == 0 && number != 2)
                return false;

            for(long i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public ParallelLoop()
        {
            long from = Convert.ToInt64(ReadLine());
            long to = Convert.ToInt64(ReadLine());

            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Strated...");

            DateTime startTime = DateTime.Now;
            List<long> total = new List<long>();

            Parallel.For(from, to, (long i) =>
            {
                if (IsPrime(i))
                    total.Add(i);
            });
            DateTime endTime = DateTime.Now;

            TimeSpan elapsed = endTime - startTime;

            WriteLine("Prime number count between {0} and {1} : {2}", from, to, total.Count);

            WriteLine("Elapsed time : {0}", elapsed);
        }
    }              // 10. ParallelLoop
    class Async
    {
        async static private void MyMethodAsync(int count)
        {
            WriteLine("C");
            WriteLine("D");

            await Task.Run(async () =>
            {
                for(int i = 1; i <= count; i++)
                {
                    WriteLine($"{i}/{count} ...");
                    await Task.Delay(100);
                }
            });

            WriteLine("G");
            WriteLine("H");
        }

        static void Caller()
        {
            WriteLine("A");
            WriteLine("B");

            MyMethodAsync(3);

            WriteLine("E");
            WriteLine("F");
        }

        public Async()
        {
            Caller();
        }
    }                     // 11. async/awiat 비동기
    class AsyncFileIO
    {
        static async Task<long> CopyAsync(string FromPath,string ToPath)
        {
            using(var fromStream = new FileStream(FromPath, FileMode.Open))
            {
                long totalCopied = 0;
                using (var toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int nRead = 0;
                    while((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;
                    }
                }
                return totalCopied;
            }
        }

        static async void DoCopy(string FromPath, string ToPath)
        {
            long totalCopied = await CopyAsync(FromPath, ToPath);
            WriteLine($"Copied Total {totalCopied} Bytes.");
        }

        public AsyncFileIO(string a, string b)
        {
            DoCopy(a, b);
        }
    }               // 12. AsyncFileIO
}
