using AkkaNet.Actors;
using System;

namespace AkkaNet.SimpleInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            AkkaConfig.RegisterActors();
            SimpleInjectorConfig.RegisterInjections();

            var actorSystem = AkkaConfig.InspectorActorSystem;
            var wordInspectorActor = actorSystem.ActorOf(
                                        SimpleInjectorConfig.Resolver.Create<WordInspectorActor>(), "WordInspectorActor");

            wordInspectorActor.Tell(Messages.SystemCommands.Start, null);


            Console.WriteLine("Welcome from AkkaNet.SimpleInjector!! Please enter a word to validate it.");
            Console.WriteLine("Enter 'exit' to close the program.");

            actorSystem.WhenTerminated.Wait();
        }
    }
}
