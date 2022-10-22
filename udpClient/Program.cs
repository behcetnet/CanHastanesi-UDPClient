using System;

namespace udpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "27000";
            while (key != "!")
            {

                try
                {
                    UDPSocket c = new UDPSocket();
                    c.Client("192.168.50.57", 4445);
                    c.Send(key);
                }
                catch
                {
                    Console.WriteLine("Bağlantı kurulamadı.");
                }

                key = Console.ReadLine();
            }
        }
    }
}
