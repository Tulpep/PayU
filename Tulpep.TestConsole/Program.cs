using System;
using Tulpep.PayU.Library.Services;

namespace Tulpep.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            QueriesService ping = new QueriesService();
            Console.WriteLine(ping.pingPayU());
            PaymentsService pay = new PaymentsService();
            Console.WriteLine(pay.MakeAPayment());
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
