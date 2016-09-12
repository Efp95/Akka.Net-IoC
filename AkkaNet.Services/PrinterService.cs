using AkkaNet.Services.Interfaces;
using System;

namespace AkkaNet.Services
{
    public class PrinterService : IPrinterService
    {
        public void Run(string message)
        {
            Console.WriteLine(message);
        }
    }
}
