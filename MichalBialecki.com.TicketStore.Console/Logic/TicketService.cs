using System;

namespace MichalBialecki.com.TicketStore.Console.Logic
{
    public class TicketService : ITicketService
    {
        private readonly Random _random;
    
        public TicketService()
        {
            _random = new Random();
        }

        public bool Reserve(string place)
        {
            // respons is just random - no need to creat advanced logic here
            return _random.NextDouble() >= 0.5;
        }
    }
}
