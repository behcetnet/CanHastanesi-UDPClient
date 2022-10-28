using System;
using System.Threading;

namespace udpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "27000";

            Console.WriteLine("Ekran IP'sini yazın: ");
            string ipAdres = "192.168.131.101"; //Console.ReadLine();
            try
            {
                for (int i = 0; i < 1000; i++)
                {

                    UDPSocket c = new UDPSocket();
                    c.Client(ipAdres, 4445);
                    c.Send($"B;;FİZİK TEDAVİ POL 2;;UZM. DR. AHMET CAMCI;;ZEYNEL DENİZ CAN;;SIRA NO: {i};;E");

                    Thread.Sleep(5000);
                }
            }
            catch
            {
                Console.WriteLine("Bağlantı kurulamadı.");
            }


            key = Console.ReadLine();
        }
    }
}
