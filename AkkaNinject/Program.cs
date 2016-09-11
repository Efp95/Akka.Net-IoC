using Akka.Actor;
using AkkaNinject.Actors;
using AkkaNinject.Services;
using System;

namespace AkkaNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("MyActorSystem");

            var wordInspectorActor = actorSystem.ActorOf(Props.Create(() => new WordInspectorActor(new PrinterService())));

            Console.WriteLine("Welcome!! Please enter a word to validate it.");
            Console.WriteLine("Enter 'exit' to close the program.");

            wordInspectorActor.Tell(WordInspectorActor.SystemCommands.Start);

            actorSystem.WhenTerminated.Wait();
        }
    }
}
