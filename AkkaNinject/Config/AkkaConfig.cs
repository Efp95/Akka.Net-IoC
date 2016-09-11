using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaNinject.Config
{
    class AkkaConfig
    {
        public static ActorSystem InspectorActorSystem;

        public static void RegisterActors()
        {
            InspectorActorSystem = ActorSystem.Create("InspectorActorSystem");
        }
    }
}
