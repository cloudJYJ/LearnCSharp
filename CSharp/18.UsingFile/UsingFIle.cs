using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Runtime.Serialization.Formatters.Binary;


namespace _18.UsingFile
{
    class UsingFIle
    {
        static void Main()
        {
            WriteLine("[ 1 ] 디렉토리/파일 정보 조회");
            WriteLine("[ 2 ] 디렉토리/파일 생성");
            WriteLine("[ 3 ] Stream");
            WriteLine("[ 4 ] 접근 방식");
            WriteLine("[ 5 ] 이진 데이터 처리");
            WriteLine("[ 6 ] 텍스트 파일 처리");
            WriteLine("[ 7 ] 직렬화");
            WriteLine("[ 8 ] 컬렉션 직렬화");
            string choice = ReadLine();
            if (choice == "1") { string[] args = { "C:Users" }; Dir dir = new Dir(args); }
            if (choice == "2") { string[] args = { "a.dat" }; Touch touch = new Touch(args); }
            if (choice == "3") { BasicIO basicio = new BasicIO(); }
            if (choice == "4") { SeqRand seqrand = new SeqRand(); }
            if (choice == "5") { BinaryFile binaryfile = new BinaryFile(); }
            if (choice == "6") { TextFile textfile = new TextFile(); }
            if (choice == "7") { Serialization serialization = new Serialization(); }
            WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            ReadKey();
        }
        class Dir
        {
            public Dir(string[] args)
            {
                string directory;
                if (args.Length < 1)
                    directory = ".";
                else
                    directory = args[0];

                WriteLine($"{directory} directory info");
                WriteLine("- Directories : ");
                var directories = (from dir in Directory.GetDirectories(directory)
                                   let info = new DirectoryInfo(dir)
                                   select new
                                   {
                                       Name = info.Name,
                                       Attributes = info.Attributes
                                   }).ToList();

                foreach (var d in directories)
                    WriteLine($"{d.Name} : {d.Attributes}");

                WriteLine("- Files : ");
                var files = (from file in Directory.GetFiles(directory)
                             let info = new FileInfo(file)
                             select new
                             {
                                 Name = info.Name,
                                 FileSize = info.Length,
                                 Attributes = info.Attributes
                             }).ToList();

                foreach (var f in files)
                    WriteLine($"{f.Name} : {f.FileSize} , {f.Attributes}");
            }
        }                   // 1. 디렉토리/파일 정보 조회
        class Touch
        {
            static void OnWrongPathType(string type)
            {
                WriteLine($"{type} is wrong type");
                return;
            }

            public Touch(string[] args)
            {
                if (args.Length == 0)
                {
                    WriteLine("Usage : Touch.exe <Path> [Type:File/Directory]");
                    return;
                }

                string path = args[0];
                string type = "File";
                if (args.Length > 1)
                    type = args[1];

                if (File.Exists(path) || Directory.Exists(path))
                {
                    if (type == "File")
                        File.SetLastWriteTime(path, DateTime.Now);
                    else if (type == "Directory")
                        Directory.SetLastWriteTime(path, DateTime.Now);
                    else
                    {
                        OnWrongPathType(path);
                        return;
                    }
                    WriteLine($"Updated {path} {type}");
                }
                else
                {
                    if (type == "File")
                        File.Create(path).Close();
                    else if (type == "Directory")
                        Directory.CreateDirectory(path);
                    else
                    {
                        OnWrongPathType(path);
                        return;
                    }

                    WriteLine($"Created {path} {type}");
                }
            }
        }                 // 2. 디렉토리/파일 생성
        class BasicIO
        {
            public BasicIO()
            {
                long someValue = 0x123456789ABCDEF0;
                WriteLine("{0,-1} : 0x{1:X16}", "Original Data", someValue);

                Stream outStream = new FileStream("a.dat", FileMode.Create);
                byte[] wBytes = BitConverter.GetBytes(someValue);

                Write("{0,-13} : ", "Byte array");
                foreach (byte b in wBytes)
                    Write("{0:X2} ", b);
                WriteLine();

                outStream.Write(wBytes, 0, wBytes.Length);
                outStream.Close();

                Stream inStream = new FileStream("a.dat", FileMode.Open);
                byte[] rbytes = new byte[8];

                int i = 0;
                while (inStream.Position < inStream.Length)
                    rbytes[i++] = (byte)inStream.ReadByte();

                long readValue = BitConverter.ToInt64(rbytes, 0);

                WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue);
                inStream.Close();
            }
        }               // 3. Stream
        class SeqRand
        {
            public SeqRand()
            {
                Stream OutStream = new FileStream("a.day", FileMode.Create);
                WriteLine($"Position : {OutStream.Position}");

                OutStream.WriteByte(0x01);
                WriteLine($"Position : {OutStream.Position}");

                OutStream.WriteByte(0x02);
                WriteLine($"Position : {OutStream.Position}");

                OutStream.WriteByte(0x03);
                WriteLine($"Position : {OutStream.Position}");

                OutStream.Seek(5, SeekOrigin.Current);
                WriteLine($"Position : {OutStream.Position}");

                OutStream.WriteByte(0x04);
                WriteLine($"Position : {OutStream.Position}");

                OutStream.Close();
            }
        }               // 4. 접근 방식
        class BinaryFile
        {
            public BinaryFile()
            {
                BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));

                bw.Write(int.MaxValue);
                bw.Write("Good Morning!");
                bw.Write(uint.MaxValue);
                bw.Write("안녕하세요!");
                bw.Write(double.MaxValue);

                bw.Close();

                BinaryReader br = new BinaryReader(new FileStream("a.day", FileMode.Open));

                WriteLine($"File Size : {br.BaseStream.Length} bytes");
                WriteLine($"{br.ReadInt32()}");
                WriteLine($"{br.ReadString()}");
                WriteLine($"{br.ReadUInt32()}");
                WriteLine($"{br.ReadString()}");
                WriteLine($"{br.ReadDouble()}");

                br.Close();
            }
        }            // 5. 이진 데이터 처리
        class TextFile
        {
            public TextFile()
            {
                StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create));
                sw.WriteLine(int.MaxValue);
                sw.WriteLine("Good morning!");
                sw.WriteLine(uint.MaxValue);
                sw.WriteLine("안녕하세요!");
                sw.WriteLine(double.MaxValue);

                sw.Close();

                StreamReader sr = new StreamReader(new FileStream("a.txt", FileMode.Open));

                WriteLine($"File size : {sr.BaseStream.Length} bytes");

                while(sr.EndOfStream == false)
                {
                    WriteLine(sr.ReadLine());
                }

                sr.Close();
            }
        }              // 6. 텍스트 파일 처리
        class Serialization
        {
            [Serializable]
            class NameCard
            {
                public string Name;
                public string Phone;
                public int Age;
            }
            public Serialization()
            {
                Stream ws = new FileStream("a.dat", FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();

                NameCard nc = new NameCard();
                nc.Name = "정용준";
                nc.Phone = "010-7707-0985";
                nc.Age = 20;

                serializer.Serialize(ws, nc);
                ws.Close();

                Stream rs = new FileStream("a.dat", FileMode.Open);
                BinaryFormatter desirializer = new BinaryFormatter();

                NameCard nc2;
                nc2 = (NameCard)desirializer.Deserialize(rs);
                rs.Close();

                WriteLine($"Name : {nc2.Name}");
                WriteLine($"Phone : {nc2.Phone}");
                WriteLine($"Age : {nc2.Age}");
            }
        }         // 7. 직렬화
        class SerializingCollection
        {
            public SerializingCollection()
            {
                Stream ws = new FileStream("a.day", FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();

                List<NameCard> list = new List<NameCard>();
                list.Add(new NameCard("박상현", "010-123-4567", 33));
                list.Add(new NameCard("정용준", "010-7707-0985", 20));
                list.Add(new NameCard("장미란", "010-555-5555", 20));

                serializer.Serialize(ws, list);
                ws.Close();

                Stream rs = new FileStream("a.dat", FileMode.Open);
                BinaryFormatter desirializer = new BinaryFormatter();

                List<NameCard> list2;
                list2 = (List<NameCard>)desirializer.Deserialize(rs);
                rs.Close();

                foreach(NameCard nc in list2)
                {
                    WriteLine($"Name: {nc.Name}, Phone: {nc.Phone}, Age: {nc.Age}");
                }
            }
            [Serializable]
            class NameCard
            {
                public NameCard(string Name, string Phone, int Age)
                {
                    this.Name = Name;
                    this.Phone = Phone;
                    this.Age = Age;
                }
                public string Name;
                public string Phone;
                public int Age;
            }
        } // 8. 컬렉션 직렬화
    }
}
