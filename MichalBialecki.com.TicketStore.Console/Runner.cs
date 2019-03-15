namespace MichalBialecki.com.TicketStore.Console
{
    using System;

    public class Runner : IRunner
    {
        public Runner()
        {

        }

        public void Run()
        {
            var command = string.Empty;
            do
            {
                command = Console.ReadLine();
            }
            while (!command.Equals("exit", StringComparison.InvariantCultureIgnoreCase));

            Console.ReadKey();
        }
    }
}
