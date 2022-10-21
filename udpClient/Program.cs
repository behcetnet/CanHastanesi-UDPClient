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

                UDPSocket c = new UDPSocket();
                c.Client("127.0.0.1", Convert.ToInt32(key));
                c.Send("TEST!");


                key = Console.ReadLine();
            }
        }
    }
}
