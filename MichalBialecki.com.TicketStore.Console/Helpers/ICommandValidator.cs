namespace MichalBialecki.com.TicketStore.Console.Helpers
{
    public interface ICommandValidator
    {
        bool IsValid(string command);
    }
}
