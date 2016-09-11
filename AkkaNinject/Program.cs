using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Ninject;
using AkkaNinject.Actors;
using AkkaNinject.Services;
using Ninject;
using System;

namespace AkkaNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new StandardKernel();
            container.Bind<IPrinterService>().To<PrinterService>();

            var actorSystem = ActorSystem.Create("MyActorSystem");

            var resolver = new NinjectDependencyResolver(container, actorSystem);
            var wordInspectorActor = actorSystem.ActorOf(
                                        actorSystem.DI().Props<WordInspectorActor>(), "WordInspectorActor");

            Console.WriteLine("Welcome!! Please enter a word to validate it.");
            Console.WriteLine("Enter 'exit' to close the program.");

            wordInspectorActor.Tell(WordInspectorActor.SystemCommands.Start);

            actorSystem.WhenTerminated.Wait();
        }
    }
}
