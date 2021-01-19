using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _15.LINQ
{
    class LINQ
    {
        static void Main()
        {
            WriteLine("[ 1 ] FROM");
            WriteLine("[ 2 ] 간단한 LINQ");
            WriteLine("[ 3 ] 중첩 FROM");
            WriteLine("[ 4 ] GroupBy");
            WriteLine("[ 5 ] Join");
            WriteLine("[ 6 ] 간단한 LINQ");
            WriteLine("[ 7 ] LINQ 활용");
            string choice = ReadLine();
            if(choice == "1") { LinqFrom linqfrom = new LinqFrom(); }
            if(choice == "2") { SimpleLinq simplelinq = new SimpleLinq(); }
            if(choice == "3") { LinqFrom2 linqfrom2 = new LinqFrom2(); }
            if(choice == "4") { GroupBy groupBy = new GroupBy(); }
            if(choice == "5") { Join join = new Join(); }
            if(choice == "6") { SimpleLinq2 simplelinq12 = new SimpleLinq2(); }
            if(choice == "7") { UsingLinq usinglinq = new UsingLinq(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            ReadKey();
        }
    }

    class LinqFrom
    {
        public LinqFrom()
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;

            foreach (int n in result)
                WriteLine($"짝수 : {n}");
        }
    }               // 1. FROM
    class SimpleLinq
    {
        class Profile
        {
            public string Name { get; set; }
            public int    Height { get; set; }
        }

        public SimpleLinq()
        {
            Profile[] arrProfile =
            {
                new Profile() { Name = "정우성", Height = 186 },
                new Profile() { Name = "김태희", Height = 158 },
                new Profile() { Name = "고현정", Height = 172 },
                new Profile() { Name = "이문세", Height = 178 },
                new Profile() { Name = "하하", Height = 171 }
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height
                           select new { Name = profile.Name, InchHeight = profile.Height * 0.393 };

            foreach (var profile in profiles)
                WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }             // 2. 간단한 LINQ
    class LinqFrom2
    {
        class Class
        {
            public string Name { get; set; }
            public int[] Score { get; set; }
        }
        public LinqFrom2()
        {
            Class[] arrClass =
            {
                new Class(){ Name = "연두반", Score = new int[]{99,80,70,24}},
                new Class(){ Name = "분홍반", Score = new int[]{60,45,87,72}},
                new Class(){ Name = "파랑반", Score = new int[]{92,30,85,94}},
                new Class(){ Name = "노랑반", Score = new int[]{90,88,0,17}}
            };
            var classes = from c in arrClass
                          from s in c.Score
                          where s < 60
                          orderby s
                          select new { c.Name, Lowest = s, };

            foreach (var c in classes)
                WriteLine($"낙제 : {c.Name} ({c.Lowest})");
        }
    }              // 3. 중첩 FROM    
    class GroupBy
    {
        class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }

        public GroupBy()
        {
            Profile[] arrProfile =
            {
                new Profile(){ Name = "정우성", Height = 186},
                new Profile(){ Name = "김태희", Height = 158},
                new Profile(){ Name = "고현정", Height = 172},
                new Profile(){ Name = "이문세", Height = 178},
                new Profile(){ Name = "하하" , Height = 171}
            };

            var listProfile = from profile in arrProfile
                              orderby profile.Height
                              group profile by profile.Height < 175 into g
                              select new { GroupKey = g.Key, Profiles = g };

            foreach(var Group in listProfile)
            {
                WriteLine($"- 175cm 미만? : {Group.GroupKey}");
                foreach(var profile in Group.Profiles)
                {
                    WriteLine($"   {profile.Name}, {profile.Height}");
                }
            }
        }
    }                // 4. GroupBy
    class Join
    {
        class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
        class Product
        {
            public string Title { get; set; }
            public string Star { get; set; }
        }

        public Join()
        {
            Profile[] arrProfile =
            {
                new Profile(){ Name = "정우성", Height = 186},
                new Profile(){ Name = "김태희", Height = 158},
                new Profile(){ Name = "고현정", Height = 172},
                new Profile(){ Name = "이문세", Height = 178},
                new Profile(){ Name = "하하" , Height = 171}
            };

            Product[] arrProduct =
            {
                new Product(){Title = "비트", Star = "정우성"},
                new Product(){Title = "CF 다수", Star = "김태희"},
                new Product(){Title = "아이리스", Star="김태희"},
                new Product(){Title = "모래시계", Star = "고현정"},
                new Product(){Title = "Solo 예찬", Star = "이문세"}
            };

            var listProfile = 
                from profile in arrProfile
                join product in arrProduct on profile.Name equals product.Star
                select new
                {
                    Name = profile.Name,
                    Work = product.Title,
                    Height = profile.Height
                };

            WriteLine("--- 내부 조인 결과 ---");

            foreach(var profile in listProfile)
            {
                WriteLine("이름 : {0}, 작품 : {1}, 키 : {2}cm",profile.Name,profile.Work,profile.Height);
            }

            listProfile =
                from profile in arrProfile
                join product in arrProduct on profile.Name equals product.Star into ps
                from product in ps.DefaultIfEmpty(new Product() { Title = "그런거 없음" })
                select new
                {
                    Name = profile.Name,
                    Work = product.Title,
                    Height = profile.Height
                };

            WriteLine();
            WriteLine("--- 외부 조인 결과 ---");

            foreach( var profile in listProfile)
            {
                WriteLine("이름 : {0}, 작품 : {1}, 키 : {2}cm", profile.Name, profile.Work, profile.Height);
            }
        }
    }                   // 5. Join
    class SimpleLinq2
    {
        class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
        public SimpleLinq2()
        {
            Profile[] arrProfile =
            {
                new Profile(){ Name = "정우성", Height = 186},
                new Profile(){ Name = "김태희", Height = 158},
                new Profile(){ Name = "고현정", Height = 172},
                new Profile(){ Name = "이문세", Height = 178},
                new Profile(){ Name = "하하" , Height = 171}
            };

            var profiles = arrProfile.
                            Where(profile => profile.Height < 175).
                            OrderBy(profile => profile.Height).
                            Select(profile =>
                                    new
                                    {
                                        Name = profile.Name,
                                        InchHeight = profile.Height * 0.393
                                    });

            foreach (var profile in profiles)
                WriteLine($"{profile.Name},{profile.InchHeight}");
        }
    }            // 6. 간단한 LINQ2 = 간단한 LINQ의 기능과 같다.
    class UsingLinq
    {
        class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
        public UsingLinq()
        {
            Profile[] arrProfile =
           {
                new Profile(){ Name = "정우성", Height = 186},
                new Profile(){ Name = "김태희", Height = 158},
                new Profile(){ Name = "고현정", Height = 172},
                new Profile(){ Name = "이문세", Height = 178},
                new Profile(){ Name = "하하" , Height = 171}
            };

            var heightStat = from profile in arrProfile
                             group profile by profile.Height < 175 into g
                             select new
                             {
                                 Group = g.Key ==true?"175미만":"175이상",
                                 Count = g.Count(),
                                 Max   = g.Max(profile => profile.Height),
                                 Min   = g.Min(profile => profile.Height),
                                 Average = g.Average(profile => profile.Height)
                             };

            foreach (var stat in heightStat)
            {
                Write("{0} - Count:{1}, Max:{2}, ", stat.Group, stat.Count, stat.Max);
                WriteLine("Min:{0}, Average:{1}");
            }
        }
    }              // 7. LINQ 활용
}
