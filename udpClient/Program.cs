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
            string ipAdres = Console.ReadLine();
            try
            {
                UDPSocket c = new UDPSocket();
                c.Client(ipAdres, 4445);
                c.Send("B;;FİZİK TEDAVİ POL 2;;UZM. DR. AHMET CAMCI;;ZEYNEL DENİZ CAN;;SIRA NO: 99;;E");
            }
            catch
            {
                Console.WriteLine("Bağlantı kurulamadı.");
            }


            key = Console.ReadLine();
        }
    }
}
