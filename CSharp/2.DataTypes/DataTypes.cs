using System;
using System.Collections.Generic;
using static System.Console;

namespace DataTypes
{
    class DataTypes
    {
        static void Main() // 프로그램의 시작 지점
        {
            WriteLine("[ 1 ] 정수 형식");
            WriteLine("[ 2 ] 정수 리터럴");
            WriteLine("[ 3 ] 오버플로우");
            WriteLine("[ 4 ] 부동 소수점 형식");
            WriteLine("[ 5 ] 10진수 형식");
            WriteLine("[ 6 ] 문자 형식");
            WriteLine("[ 7 ] 문자열 형식");
            WriteLine("[ 8 ] 논리 형식");
            WriteLine("[ 9 ] 오브젝트 형식");
            WriteLine("[10 ] 박싱과 언박싱");
            WriteLine("[11 ] 정수 형식 변환");
            WriteLine("[12 ] 부동 소수점 형식 변환");
            WriteLine("[13 ] 부호 있는 정수와 부호 없는 정수 사이 형식 변환");
            WriteLine("[14 ] 부동 소수점 형식과 정수 형식 사이 형식 변환");
            WriteLine("[15 ] 숫자 형식과 문자 형식 사이 형식 변환");
            string choice = ReadLine();
            if (choice == "1") { IntegralTypes integraltypes = new IntegralTypes(); }
            if (choice == "2") { SignedUnsigned signednsigned = new SignedUnsigned(); }
            if (choice == "3") { OverFlow overflow = new OverFlow(); }
            if (choice == "4") { FloatingPoint floatingpoint = new FloatingPoint(); }
            if (choice == "5") { Decimal Decimal = new Decimal(); }
            if (choice == "6") { Char Char =new Char(); }
            if (choice == "7") { String String = new String(); }
            if (choice == "8") { Bool Bool = new Bool(); }
            if (choice == "9") { Object Object = new Object(); }
            if (choice == "10") { BoxingUnboxing boxingunboxing = new BoxingUnboxing(); }
            if (choice == "11") { IntegralConversion integralconversion = new IntegralConversion(); }
            if (choice == "12") { FloatConversion floatconversion = new FloatConversion(); }
            if (choice == "13") { SignedUnsignedConversion signedunsignedconversion = new SignedUnsignedConversion(); }
            if (choice == "14") { FloatToIntegral floattointegral = new FloatToIntegral(); }
            if (choice == "15") { StringNumberConversion stringnumberconversion = new StringNumberConversion(); }
        }
    }

    class IntegralTypes
    {
        public IntegralTypes() // 생성자메소드로써 해당 클래스가 인스턴스화될때 호출되어 실행됨
        {
            sbyte a = -10;
            byte b = 40;

            WriteLine($"a={a}, b={b}");

            short c = -30000;
            ushort d = 60000;

            WriteLine($"c={c}, d={d}");

            int e = -1000_0000; // 0이 7개
            uint f = 3_0000_0000; // 0이 8개

            WriteLine($"e={e}, f={f}");

            long g = -5000_0000_0000; // 0이 11개
            ulong h = 200_0000_0000_0000_0000; // 0이 18개

            WriteLine($"g={g}, h={h}");

            IntegerLiterals();
        }
        public void IntegerLiterals()
        {
            byte a = 240;           // 10진수 리터럴
            WriteLine($"a={a}");

            byte b = 0b1111_0000;   // 2진수 리터럴
            WriteLine($"b={b}");

            byte c = 0XF0;          // 16진수 리터럴
            WriteLine($"c={c}");

            uint d = 0x1234_abcd;   // 16진수 리터럴
            WriteLine($"d={d}");
        }
    }             // 1. 정수 형식
    class SignedUnsigned
    {
        public SignedUnsigned()
        {
            byte a = 255;
            sbyte b = (sbyte)a;

            WriteLine(a);
            WriteLine(b);
        }
    }            // 2. 정수 리터럴
    class OverFlow
    {
        public OverFlow()
        {
            uint a = uint.MaxValue;

            WriteLine(a);

            a++;

            WriteLine(a);
        }
    }                  // 3. 오버플로우
    class FloatingPoint
    {
        public FloatingPoint()
        {
            float a = 3.1415_9265_3589_7932_3846f;
            WriteLine(a);

            double b = 3.1415_9265_3589_7932_3846f;
            WriteLine(b);
        }
    }             // 4. 부동 소수점 형식
    class Decimal
    {
        public Decimal()
        {
            float a = 3.1415_9265_3589_7932_3846_2643_3832_79f;
            double b = 3.1415_9265_3589_7932_3846_2643_3832_79;
            decimal c = 3.1415_9265_3589_7932_3846_2643_3832_79m;

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
        }
    }                   // 5. 10진수 형식
    class Char
    {
        public Char()
        {
            char a = '안';
            char b = '녕';
            char c = '하';
            char d = '세';
            char e = '요';

            Write(a);
            Write(b);
            Write(c);
            Write(d);
            Write(e);
            WriteLine();
        }
    }                      // 6. 문자 형식
    class String
    {
        public String()
        {
            string a = "안녕하세요?";
            string b = "정용준입니다.";

            WriteLine(a);
            WriteLine(b);
        }
    }                    // 7. 문자열 형식
    class Bool
    {
        public Bool()
        {
            bool a = true;
            bool b = false;

            WriteLine(a);
            WriteLine(b);
        }
    }                      // 8. 논리 형식
    class Object
    {
        public Object()
        {
            object a = 123;
            object b = 3.141592653589793238462643383279m;
            object c = true;
            object d = "안녕하세요";

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
            WriteLine(d);
        }
    }                    // 9. Object 형식
    class BoxingUnboxing
    {
        public BoxingUnboxing()
        {
            int a = 123;
            object b = (object)a;   // a에 담긴 값을 박싱해서 힙에 저장
            int c = (int)b;         // b에 담긴 값을 언박싱해서 스택에 저장

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
            double x = 3.1414213;
            object y = x;           // x에 담긴 값을 박싱해서 힙에 저장
            double z = (double)y;   // y에 담긴 값을 언박싱해서 스택에 저장

            WriteLine(x);
            WriteLine(y);
            WriteLine(z);

        }
    }            // 10. 박싱과 언박싱
    class IntegralConversion
    {
        public IntegralConversion()
        {
            sbyte a = 127;
            WriteLine(a);

            int b = (int)a;
            WriteLine(b);

            int x = 128; // sbyte의 최대값 127보다 1 큰 수
            WriteLine(x);

            sbyte y = (sbyte)x; // 여기서 오버플로우 발생
            WriteLine(y);
        }
    }        // 11. 정수 형식 변환
    class FloatConversion
    {
        public FloatConversion()
        {
            float a = 69.6875f;
            WriteLine("a : {0}", a);

            double b = (double)a;
            WriteLine("b : {0}", b);

            WriteLine("69.6875 == b : {0}", 69.6875 == b);

            float x = 0.1f;
            WriteLine("x : {0}", x);

            double y = (double)x;
            WriteLine("y : {0}", y);

            WriteLine("0.1 == y : {0}", 0.1 == y);
        }
    }           // 12. 부동 소수점 형식 변환
    class SignedUnsignedConversion
    {
        public SignedUnsignedConversion()
        {
            int a = 500;
            WriteLine(a);

            uint b = (uint)a;
            WriteLine(b);

            int x = -30;
            WriteLine(x);

            uint y = (uint)x; // 언더플로우 발생
            WriteLine(y);
        }
    }  // 13. 부호 있는 정수와 부호 없는 정수 사이 형식 변환
    class FloatToIntegral
    {
        public FloatToIntegral()
        {
            float a = 0.9f;
            int b = (int)a;
            WriteLine(b);

            float c = 1.1f;
            int d = (int)c;
            WriteLine(d);
        }
    }           // 14. 부동 소수점 형식과 정수 형식 사이 형식 변환
    class StringNumberConversion
    {
        public StringNumberConversion()
        {
            int a = 123;
            string b = a.ToString();
            WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            WriteLine(d);

            string e = "123456";
            int f = Convert.ToInt32(e);
            WriteLine(f);

            string g = "1.2345";
            float h = float.Parse(g);
            WriteLine(h);
        }
    }    // 15. 숫자형식과 문자형식 사이 형식 변환
}
