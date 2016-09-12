using Akka.DI.Ninject;
using AkkaNet.Services;
using AkkaNet.Services.Interfaces;
using Ninject;

namespace AkkaNinject.Config
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
