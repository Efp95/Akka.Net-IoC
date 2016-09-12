using Akka.Actor;
using Akka.DI.Core;
using AkkaNet.Actors;
using System;

namespace AkkaNet.Ninject
{
    class Program
    {
        static void Main(string[] args)
        {
            AkkaConfig.RegisterActors();
            NinjectConfig.RegisterBindings();

            var actorSystem = AkkaConfig.InspectorActorSystem;
            var wordInspectorActor = actorSystem.ActorOf(
                                        actorSystem.DI().Props<WordInspectorActor>(), "WordInspectorActor");

            wordInspectorActor.Tell(Messages.SystemCommands.Start);


            Console.WriteLine("Welcome from Akka.Ninject!! Please enter a word to validate it.");
            Console.WriteLine("Enter 'exit' to close the program.");

            actorSystem.WhenTerminated.Wait();
        }
    }
}
