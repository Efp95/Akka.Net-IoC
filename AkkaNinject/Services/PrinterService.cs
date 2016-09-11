using System;

namespace AkkaNinject.Services
{
    class PrinterService : IPrinterService
    {
        public void Run(string message)
        {
            Console.WriteLine(message);
        }
    }
}
