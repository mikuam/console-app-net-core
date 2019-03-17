namespace MichalBialecki.com.TicketStore.Console.Helpers
{
    using System.Text.RegularExpressions;

    public class CommandValidator : ICommandValidator
    {
        private string ShootRegexp = "[A-H]\\d\\d?";

        /// <summary>
        /// Checks if command is valid: columns are between A and H and rows between 1 and 15
        /// </summary>
        /// <param name="command">Command as string, for example C4</param>
        /// <returns>Boolean value indicating if command is valid</returns>
        public bool IsValid(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return false;
            }

            if (Regex.IsMatch(command, ShootRegexp))
            {
                var numberPart = command.Substring(1);
                if (int.TryParse(numberPart, out int number))
                {
                    return number >= 1 && number <= 15;
                }
            }

            return false;
        }
    }
}
