/// Representerar en kontakt med egenskaper för förnamn, efternamn, telefonnummer, e-postadress och adress
public class Contact
{
    // Statiska medlemmar för hantering av kontakter och filoperationer
    private static List<Contact> kontakter = new List<Contact>();
    private static FileService fileService = new FileService();
    private static ContactService? contactService;

    static void Main()
    {
        kontakter = fileService.LoadContacts();
        contactService = new ContactService(kontakter);

        // Prenumererar på avslutningshändelse för att spara kontakter och avsluta på ett korrekt sätt
        fileService.SubscribeToExitEvent(() => SaveAndExit());
        
        while (true)
        {
            
            int val = MenuService.ShowMenuAndGetChoice();
            Console.Clear();
            switch (val)
            {
                case 1:
                    contactService.AddContact();
                    break;
                case 2:
                    contactService.ListContacts();
                    break;
                case 3:
                    contactService.ShowContactDetails();
                    break;
                case 4:
                    contactService.RemoveContact();
                    break;
                case 5:
                    SaveAndExit();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    /// Sparar kontakter till en fil och avslutar programmet.
    static void SaveAndExit()
    {

        fileService.SaveContacts(kontakter);
        Console.WriteLine("Programmet har avslutats");
        Environment.Exit(0);
    }
    /// Hämtar eller anger kontaktens förnamn,efternamn,mobilnummer osv....
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Address { get; set; }


    /// Hämtar kontaktpersonens fullständiga namn genom att kombinera förnamn och efternamn.
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }
}



