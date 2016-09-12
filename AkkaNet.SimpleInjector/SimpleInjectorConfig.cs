using Akka.DI.Core;
using Akka.DI.SimpleInjector;
using AkkaNet.Actors;
using AkkaNet.Services;
using AkkaNet.Services.Interfaces;
using SimpleInjector;

namespace AkkaNet.SimpleInjector
{
    class SimpleInjectorConfig
    {
        private static readonly Container _container;
        private static IDependencyResolver _resolver;

        static SimpleInjectorConfig()
        {
            _container = new Container();
        }

        public static IDependencyResolver Resolver
        {
            get
            {
                if (_resolver == null)
                {
                    var actorSystem = AkkaConfig.InspectorActorSystem;
                    _resolver = new SimpleInjectorDependencyResolver(_container, actorSystem);
                }

                return _resolver;
            }
        }

        public static void RegisterInjections()
        {
            _container.Register<IPrinterService, PrinterService>(Lifestyle.Singleton);
        }
    }
}
