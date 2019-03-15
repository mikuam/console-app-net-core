namespace MichalBialecki.com.TicketStore.Console.App_Start
{
    using System.Linq;

    using SimpleInjector;

    public static class ContainerConfig
    {
        private static Container Container;

        public static void Init()
        {
            Container = new Container();

            RegisterAllTypesWithConvention();

            Container.Verify();
        }

        public static TService GetInstance<TService>() where TService : class
        {
            return Container.GetInstance<TService>();
        }

        private static void RegisterAllTypesWithConvention()
        {
            var typesWithInterfaces = typeof(Program).Assembly.GetExportedTypes()
                .Where(t => t.Namespace.StartsWith("MichalBialecki.com.TicketStore"))
                .Where(ts => ts.GetInterfaces().Any() && ts.IsClass).ToList();
            var registrations = typesWithInterfaces.Select(ti => new { Service = ti.GetInterfaces().Single(), Implementation = ti });

            foreach (var reg in registrations)
            {
                Container.Register(reg.Service, reg.Implementation, Lifestyle.Singleton);
            }
        }
    }
}
