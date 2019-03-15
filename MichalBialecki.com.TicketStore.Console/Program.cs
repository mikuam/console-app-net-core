namespace MichalBialecki.com.TicketStore.Console
{
    using System;

    using MichalBialecki.com.TicketStore.Console.App_Start;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContainerConfig.Init();
                var runner = ContainerConfig.GetInstance<IRunner>();

                runner.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
