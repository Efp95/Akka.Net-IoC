using Akka.Actor;
using AkkaNet.Services.Interfaces;
using System;

namespace AkkaNet.Actors
{
    public class WordInspectorActor : ReceiveActor
    {
        private readonly IPrinterService _printerService;

        public WordInspectorActor(IPrinterService printerService)
        {
            _printerService = printerService;

            Receive<string>(word =>
            {
                bool shouldInspect = !(IsUsingCommands(word));

                if (shouldInspect)
                    Inspect(word);
            });
        }


        private bool IsUsingCommands(string message)
        {
            if (Messages.SystemCommands.Start.Equals(message))
            {
                ReCall();
                return true;
            }

            if (Messages.SystemCommands.Exit.Equals(message))
            {
                Context.System.Terminate();
                return true;
            }

            return false;
        }

        private void Inspect(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _printerService.Run(Messages.ValidationMessages.EmptyInput);
            }
            else
            {
                if (message.Length % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    _printerService.Run(Messages.ValidationMessages.ValidInput);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    _printerService.Run(Messages.ValidationMessages.InvalidInput);
                }
            }

            ReCall();
        }

        private void ReCall()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Self.Tell(Console.ReadLine());
        }

    }
}
