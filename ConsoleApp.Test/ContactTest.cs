
using Xunit;

namespace Ahmad
/// En samling av enhetstester för ContactService-klassen.
{
    public class ContactServiceTests
    {
        /// Testar om ListContacts-metoden korrekt skriver ut kontaktinformation till konsolen.
        [Fact]
        public void ListContacts_ShouldPrintContacts()
        {
            /// Arrange
            var contactsList = new List<Contact> { new Contact { FirstName = "ahmad", LastName = "altmymy", PhoneNumber = "123456", EmailAddress = "ahmad.aden@example.com", Address = "mammamia" } };
            var contactService = new ContactService(contactsList);

            /// Simulate console output
            var simulatedConsoleOutput = new StringWriter();
            Console.SetOut(simulatedConsoleOutput);

            /// Act
            contactService.ListContacts();

            /// Assert
            Assert.Contains("ahmad altmymy", simulatedConsoleOutput.ToString());
        }

        
    }
}
