using Akka.Actor;

namespace AkkaNet.Actors
{
    public class AkkaConfig
    {
        public static ActorSystem InspectorActorSystem;

        public static void RegisterActors()
        {
            InspectorActorSystem = ActorSystem.Create("InspectorActorSystem");
        }
    }
}
