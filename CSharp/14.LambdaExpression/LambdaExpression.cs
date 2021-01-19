using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using static System.Console;

namespace _14.LambdaExpression
{
    class LambdaExpression
    {
        static void Main()
        {
            WriteLine("[ 1 ] 람다식");
            WriteLine("[ 2 ] 문 형식의 람다식");
            WriteLine("[ 3 ] Func 대리자");
            WriteLine("[ 4 ] Action 대리자");
            WriteLine("[ 5 ] 식 트리");
            WriteLine("[ 6 ] 람다식 식 트리");
            WriteLine("[ 7 ] 멤버 구현 식");
            string choice = ReadLine();
            if(choice == "1") { Lambda lambda = new Lambda(); }
            if(choice == "2") {
                string[] args = { ReadLine() };
                StatementLambda statementlambda = new StatementLambda(args);
            }
            if(choice == "3") { FuncTest functest = new FuncTest(); }
            if(choice == "4") { ActionTest actiontest = new ActionTest(); }
            if(choice == "5") { UsingExpressionTree usingexpressiontree = new UsingExpressionTree(); }
            if(choice == "6") { ExpressionTreeViaLambda expressionTreeViaLambda = new ExpressionTreeViaLambda(); }
            if(choice == "7") { ExpressionBodiedMember expressionbodiedmember = new ExpressionBodiedMember(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            ReadKey();
        }
    }
    class Lambda
    {
        delegate int Calculate(int a, int b);
        public Lambda()
        {
            Calculate calc = (a, b) => a + b;

            WriteLine($"{3} + {4} : {calc(3, 4)}");
        }
    }                   // 1. 람다식
    class StatementLambda
    {
        delegate string Concatenate(string[] args);
        public StatementLambda(string[] args)
        {
            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;

                return result;
            };
            WriteLine(concat(args));
        }
    }          // 2. 문형식의 람다식
    class FuncTest
    {
        public FuncTest()
        {
            Func<int> func1 = () => 10;
            WriteLine($"func1() : {func1()}");

            Func<int, int> func2 = (x) => x * 2;
            WriteLine($"func2(4) : {func2(4)}");

            Func<double, double, double> func3 = (x, y) => x / y;
            WriteLine($"func3(22,7) : {func3(22, 7)}");
        }
    }                 // 3. Func 대리자
    class ActionTest
    {
        public ActionTest()
        {
            Action act1 = () => WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;

            act2(3);
            WriteLine($"result : {result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                WriteLine($"Action<T1, T2>({x}, {y}) : {pi}");
            };
            act3(22.0, 7.0);
        }
    }               // 4. Action 대리자
    class UsingExpressionTree
    {
        public UsingExpressionTree()
        {
            // 1*2+(x-y)
            Expression const1 = Expression.Constant(1);
            WriteLine(const1);

            Expression const2 = Expression.Constant(2);
            WriteLine(const2);

            Expression leftExp = Expression.Multiply(const1, const2); // 1*2
            WriteLine(leftExp);

            Expression param1 = Expression.Parameter(typeof(int));
            WriteLine(param1);
            
            Expression param2 = Expression.Parameter(typeof(int));
            WriteLine(param2);

            Expression rightExp = Expression.Subtract(param1, param2); // x - y;
            WriteLine(rightExp);

            Expression exp = Expression.Add(leftExp, rightExp);
            WriteLine(exp);

            Expression<Func<int, int, int>> expression =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>> (
                    exp, new ParameterExpression[]
                    {
                        (ParameterExpression)param1,
                        (ParameterExpression)param2
                    }
                );
            WriteLine(expression);

            Func<int, int, int> func = expression.Compile();

            WriteLine(func);
            // x = 7, y = 8
            WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
        }
    }      // 5. 식 트리
    class ExpressionTreeViaLambda
    {
        public ExpressionTreeViaLambda()
        {
            Expression<Func<int, int, int>> expression =
                (a, b) => 1 * 2 + (a - b);
            Func<int, int, int> Func = expression.Compile();

            // x = 7, y = 8
            WriteLine($"1*2+({7}-{8}) = {Func(7, 8)}");
        }
    }  // 6. 람다식 식 트리
    class ExpressionBodiedMember
    {
        public ExpressionBodiedMember()
        {
            FriendList obj = new FriendList();
            obj.Add("Eeny");
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny");
            obj.PrintAll();

            WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            WriteLine($"{obj.Capacity}");

            WriteLine($"{obj[0]}");
            obj[0] = "Moe";
            obj.PrintAll();
        }
        class FriendList
        {
            private List<string> list = new List<string>();

            public void Add(string name) => list.Add(name);
            public void Remove(string name) => list.Remove(name);
            public void PrintAll()
            {
                foreach (var s in list)
                    WriteLine(s);
            }

            public FriendList() => WriteLine("FriendList()");
            ~FriendList() => WriteLine("~FriendList()");

            // public int capacity => list.Capacity; 읽기 전용

            public int Capacity // 속성
            {
                get => list.Capacity;
                set => list.Capacity = value;
            }

            // public string this[int index] => list[index]; 읽기 전용
            public string this[int index]
            {
                get => list[index];
                set => list[index] = value;
            }
        }
    }   // 7. 멤버 구현 식
}
