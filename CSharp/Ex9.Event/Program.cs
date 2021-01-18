using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex9.Event
{
    class Program
    {
        // 축하합니다! 30번째 고객 이벤트에 당첨되셨습니다. 와 같이 나오도록 이벤트 처리기를 추가하시오.
        delegate void MyDelegate(int a);
        static void Main()
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate(Market.MyHandler);

            for (int customerNo = 0; customerNo < 100; customerNo += 10)
                market.BuySomething(customerNo);

            Console.WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
        class Market
        {
            public event MyDelegate CustomerEvent;

            public void BuySomething(int CustomerNo)
            {
                if (CustomerNo == 30)
                    CustomerEvent(CustomerNo);
            }
            static public void MyHandler(int a)
            {
                Console.WriteLine($"{a}번째 고객 이벤트에 당첨되셨습니다.");
            }
        }
    }
}
