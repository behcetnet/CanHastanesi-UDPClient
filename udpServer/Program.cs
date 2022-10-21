using System;
using System.Threading;

namespace udpServer
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread[] array = new Thread[20];

            for (int i = 0; i < array.Length; i++)
            {
                ParameterizedThreadStart start = new ParameterizedThreadStart(Start);
                array[i] = new Thread(start);
                array[i].Start(i);

            }

            // Join all the threads.
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Join();
            }

            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }

        static void Start(object i)
        {
            UDPSocket s;

            s = new UDPSocket(i);
            s.Server("127.0.0.1", 27000 + Convert.ToInt32(i));

            Console.WriteLine($"{i} kimlik nolu ekran başlatıldı.");
        }
    }
}
