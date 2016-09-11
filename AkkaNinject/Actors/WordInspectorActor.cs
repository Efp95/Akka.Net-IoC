using Akka.Actor;
using AkkaNinject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaNinject.Actors
{
    class WordInspectorActor : ReceiveActor
    {
        private readonly IPrinterService _printerService;

        public WordInspectorActor(IPrinterService printerService)
        {
            _printerService = printerService;

            Receive<string>(word =>
            {
                Inspect(word);
            });
        }

        private void Inspect(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _printerService.Run(ValidationMessages.EmptyInput);

                Self.Tell(Console.ReadLine());
            }
            else
            {
                if (message.Length % 2 == 0)
                {
                    _printerService.Run(ValidationMessages.ValidInput);
                }
                else
                {
                    _printerService.Run(ValidationMessages.InvalidInput);
                }
            }
        }

        struct ValidationMessages
        {
            public const string EmptyInput = "You must send a word";

            public const string ValidInput = "You sent a valid input";
            public const string InvalidInput = "You sent an invalid input";
        }
    }
}
