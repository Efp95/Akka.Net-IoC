using Akka.DI.Ninject;
using AkkaNet.Actors;
using AkkaNet.Services;
using AkkaNet.Services.Interfaces;
using Ninject;

namespace AkkaNet.Ninject
{
    class NinjectConfig
    {
        public static void RegisterBindings()
        {
            var container = new StandardKernel();
            container.Bind<IPrinterService>().To<PrinterService>();

            SetResolver(container);
        }

        private static void SetResolver(IKernel kernel)
        {
            var actorSystem = AkkaConfig.InspectorActorSystem;
            var resolver = new NinjectDependencyResolver(kernel, actorSystem);
        }
    }
}
