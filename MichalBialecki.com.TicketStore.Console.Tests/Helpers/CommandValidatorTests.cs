namespace MichalBialecki.com.TicketStore.Console.Tests.Helpers
{
    using MichalBialecki.com.TicketStore.Console.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class CommandValidatorTests
    {
        private CommandValidator _commandValidator;

        [SetUp]
        public void SetUp()
        {
            _commandValidator = new CommandValidator();
        }

        [TestCase("A1", true)]
        [TestCase("A15", true)]
        [TestCase("A11", true)]
        [TestCase("H15", true)]
        [TestCase("H16", false)]
        [TestCase("K15", false)]
        [TestCase("I4", false)]
        [TestCase("K.", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void IsValid_GivenCommand_ReturnsExpectedResult(string command, bool expectedResult)
        {
            // Arrange & Act
            var result = _commandValidator.IsValid(command);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
