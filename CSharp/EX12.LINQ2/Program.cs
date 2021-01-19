using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX12.LINQ2
{
    class Program
    {
        class Car
        {
            public int Cost { get; set; }
            public int MaxSpeed { get; set; }
        }
        static void Main()
        {
            Car[] cars =
            {
                new Car(){Cost= 56,MaxSpeed= 120},
                new Car(){Cost= 70,MaxSpeed= 150},
                new Car(){Cost= 45,MaxSpeed= 180},
                new Car(){Cost= 32,MaxSpeed= 200},
                new Car(){Cost= 86,MaxSpeed= 280},
            };

            // 아래 코드와 동일한 결과를 반환하는 LINQ를 작성
            //var selected = cars.Where(c => c.Cost < 60).OrderBy(c => c.Cost);

            var selected = from car in cars
                           where car.Cost < 60
                           orderby car.Cost
                           select new { Cost = car.Cost, MaxSpeed = car.MaxSpeed };
                        
            foreach (var car in selected)
                Console.WriteLine($"비용 : {car.Cost}, 최대속도 : {car.MaxSpeed}");

            Console.WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}
