using MichalBialecki.com.TicketStore.Console.Helpers;
using MichalBialecki.com.TicketStore.Console.Logic;

namespace MichalBialecki.com.TicketStore.Console
{
    using System;

    public class Runner : IRunner
    {
        private readonly ICommandValidator _commandValidator;
        private readonly ITicketService _ticketService;

        public Runner(ICommandValidator commandValidator, ITicketService ticketService)
        {
            _commandValidator = commandValidator;
            _ticketService = ticketService;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Ticket Store! Cinema hall has rows A..H and seats 1..15. " +
                              "Type number of seat to book it, for examli C4.");
            var command = string.Empty;
            do
            {
                command = Console.ReadLine();
                if (!_commandValidator.IsValid(command))
                {
                    Console.WriteLine($"Sorry, command: '{command}' not recognized.");
                }
                else
                {
                    var reservationSuccessful = _ticketService.Reserve(command);
                    if (reservationSuccessful)
                    {
                        Console.WriteLine("Successfuly reserved seat " + command);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, seat {command} is already reserved.");
                    }
                }
            }
            while (!command.Equals("exit", StringComparison.InvariantCultureIgnoreCase));

            Console.ReadKey();
        }
    }
}
