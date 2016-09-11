using Akka.Actor;
using Akka.DI.Core;
using AkkaNinject.Actors;
using AkkaNinject.Config;
using System;

namespace AkkaNinject
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

            wordInspectorActor.Tell(WordInspectorActor.SystemCommands.Start);


            Console.WriteLine("Welcome!! Please enter a word to validate it.");
            Console.WriteLine("Enter 'exit' to close the program.");

            actorSystem.WhenTerminated.Wait();
        }
    }
}
