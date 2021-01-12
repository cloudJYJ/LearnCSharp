using System;
using static System.Console;
using System.Globalization;
namespace Appendix
{
    class Appendix
    {
        static void Main()
        {
            WriteLine("[ 1 ] 문자열 안에서 찾기");
            WriteLine("[ 2 ] 문자열 변형하기");
            WriteLine("[ 3 ] 문자열 분할하기");
            WriteLine("[ 4 ] 왼쪽/오른쪽 맞춤");
            WriteLine("[ 5 ] 숫자 서식화");
            WriteLine("[ 6 ] 날짜 및 시간 서식화");
            WriteLine("[ 7 ] 문자열 보간");
            string choice = ReadLine();
            if (choice == "1") { StringSearch StringSearch = new StringSearch(); }
            if (choice == "2") { StringModify StringModify = new StringModify(); }
            if (choice == "3") { StringSlice StringSlice = new StringSlice(); }
            if (choice == "4") { StringFormatBasic StringFormatBasic = new StringFormatBasic(); }
            if (choice == "5") { StringFormatNumber StringFormatNumber = new StringFormatNumber(); }
            if (choice == "6") { StringFormatDataTime StringFormatDataTime = new StringFormatDataTime(); }
            if (choice == "7") { StringInterpolation StringInterpolation = new StringInterpolation(); }
        }
    }
    class StringSearch
    {
        public StringSearch()
        {
            string greeting = "Good Morning";

            WriteLine(greeting);
            WriteLine();

            // IndexOf()
            WriteLine("IndexOf 'Good' : {0}", greeting.IndexOf("Good"));
            WriteLine("IndexOf 'o' : {0}", greeting.IndexOf("o"));

            // LastIndexOf()
            WriteLine("LastIndexOf 'Good' : {0}", greeting.LastIndexOf("Good"));
            WriteLine("LastIndexOf 'o' : {0}", greeting.LastIndexOf("o"));

            // StartsWith()
            WriteLine("StartsWith 'Good' : {0}", greeting.StartsWith("Good"));
            WriteLine("StartsWith 'Morning' : {0}", greeting.StartsWith("Morning"));

            // EndsWith()
            WriteLine("EndsWith 'Good' : {0}", greeting.EndsWith("Good"));
            WriteLine("EndsWith 'Morning' : {0}", greeting.EndsWith("Morning"));

            // Contains()
            WriteLine("Contains 'Evening' : {0}", greeting.Contains("Evening"));
            WriteLine("Contains 'Morning' : {0}", greeting.Contains("Morning"));

            //Replace()
            WriteLine("Replaced 'Morning' with 'Evening': {0}", greeting.Replace("Morning", "Evening"));            
        }
    }             // 1. 문자열 안에서 찾기
    class StringModify
    {
        public StringModify()
        {
            WriteLine("ToLower() : '{0}'", "ABC".ToLower());
            WriteLine("ToUpper() : '{0}'", "abc".ToUpper());

            WriteLine("Insert() : '{0}'", "Happy Friday!".Insert(5, "Sunny"));
            WriteLine("Remove() : '{0}'", "I Don't Love You".Remove(2, 6));

            WriteLine("Trim() : '{0}'", " No Spaces ".Trim());
            WriteLine("TrimStart() : '{0}'", " No Spaces ".TrimStart());
            WriteLine("TrimEnd() : '{0}'", " No Spaces ".TrimEnd());
        }
    }             // 2. 문자열 변형하기
    class StringSlice
    {
        public StringSlice()
        {
            string greeting = "Good morning.";

            WriteLine(greeting.Substring(0, 5)); // "Good"
            WriteLine(greeting.Substring(5)); // "Morning"
            WriteLine();

            string[] arr = greeting.Split(
                    new string[] { " " }, StringSplitOptions.None);
            WriteLine("Word Count : {0}", arr.Length);

            foreach (string element in arr)
                WriteLine("{0}", element);
        }
    }              // 3. 문자열 분할하기
    class StringFormatBasic
    {
        public StringFormatBasic()
        {
            string fmt = "{0,-20}{1,-15}{2,30}";

            WriteLine(fmt, "Publisher", "Author", "Title");
            WriteLine(fmt, "Marvel", "Stan Lee", "Iron Man");
            WriteLine(fmt, "Hanbit", "Sanghyun Park", "C# 7.0 Programming");
            WriteLine(fmt, "Prentice Hall", "K&R", "The C Programming Language");
        }
    }        // 4. 오른쪽/왼쪽 맞춤
    class StringFormatNumber
    {
        public StringFormatNumber()
        {
            // D : 10진수
            WriteLine("10진수: {0:D}", 123);
            WriteLine("10진수: {0:D5}", 123);

            // X : 16진수
            WriteLine("16진수: 0x{0:X}", 0xFF1234);
            WriteLine("16진수: 0x{0:X8}", 0xFF1234);

            // N : 숫자
            WriteLine("숫자: {0:N}", 123456789);
            WriteLine("숫자: {0:N0}", 123456789);

            // F : 고정소수점
            WriteLine("고정소수점: {0:F}", 123.45);
            WriteLine("고정소수점: {0:F5}", 123.456);

            // E : 공학용
            WriteLine("공학: {0:E}", 123.456789);
        }
    }       // 5. 숫자 서식화
    class StringFormatDataTime
    {
        public StringFormatDataTime()
        {
            DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22);

            WriteLine("12시간 형식: {0:yyyy-MM-dd tt hh:mm:ss (ddd)}", dt);
            WriteLine("24시간 형식: {0:yyyy-MM-dd tt HH:mms:ss (dddd)}", dt);

            CultureInfo ciKo = new CultureInfo("ko-KR");
            WriteLine();
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciKo));
            WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciKo));

            CultureInfo ciEn = new CultureInfo("en-US");
            WriteLine();
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciEn));
            WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciEn));
            WriteLine(dt.ToString(ciEn));
        }
    }     // 6. 날짜 및 시간 서식화
    class StringInterpolation
    {
        public StringInterpolation()
        {
            string name = "김튼튼";
            int age = 23;
            WriteLine($"{name,-10},{age:D3}");

            name = "박날씬";
            age = 30;
            WriteLine($"{name},{age,-10:D3}");

            name = "이비실";
            age = 17;
            WriteLine($"{name},{(age > 20 ? "성인" : "미성년자")}");
        }
    }      // 7. 문자열 보간
}
