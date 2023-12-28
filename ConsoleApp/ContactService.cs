/// Hanterar sånt som är relaterade till kontakter, såsom att lägga till, lista, visa detaljer och ta bort kontakter.

public class ContactService
{
    private List<Contact> contacts;

    public ContactService(List<Contact> contacts)
    {
        this.contacts = contacts;
    }

    /// Lägger till en ny kontakt i listan.
    public void AddContact()
    {
        Console.WriteLine("Lägg till en ny kontakt:");
        Contact newContact = new Contact();

        Console.Write("Förnamn: ");
        newContact.FirstName = Console.ReadLine()!;

        Console.Write("Efternamn: ");
        newContact.LastName = Console.ReadLine()!;

        Console.Write("Telefonnummer: ");
        newContact.PhoneNumber = Console.ReadLine()!;

        Console.Write("E-postadress: ");
        newContact.EmailAddress = Console.ReadLine()!;

        Console.Write("Adress: ");
        newContact.Address = Console.ReadLine()!;

        contacts.Add(newContact);

        Console.WriteLine("Kontakt tillagd!\n");
    }

    /// Visar en lista över alla kontakter med deras namn, telefonnummer, e-postadress och adress.
    public void ListContacts()
    {
        Console.WriteLine("Lista över alla kontakter:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Namn: {contact.FullName}, Telefon: {contact.PhoneNumber}, E-post: {contact.EmailAddress}, Adress: {contact.Address}");
        }
        Console.WriteLine();
    }
    /// Visar detaljerad information om en kontakt baserat på den angivna e-postadressen.
    public void ShowContactDetails()
    {
        Console.Write("Ange e-postadress för kontakten du vill visa detaljer för: ");
        string emailAddress = Console.ReadLine()!;

        Contact contact = contacts.Find(c => c.EmailAddress == emailAddress)!;

        Console.WriteLine($"Sökt e-postadress: {emailAddress}");

        if (contact != null)
        {
            Console.WriteLine($"Detaljer för kontakt '{contact.FullName}':");
            Console.WriteLine($"Telefon: {contact.PhoneNumber}");
            Console.WriteLine($"E-post: {contact.EmailAddress}");
            Console.WriteLine($"Adress: {contact.Address}\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }
    }
    /// Tar bort en kontakt baserat på den angivna e-postadressen.
    public void RemoveContact()
    {
        Console.Write("Ange e-postadress för kontakten du vill ta bort: ");
        string emailAddress = Console.ReadLine()!;

        Contact contactToRemove = contacts.Find(c => c.EmailAddress == emailAddress)!;

        Console.WriteLine($"E-postadress att ta bort: {emailAddress}");

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            Console.WriteLine($"Kontakt '{contactToRemove.FullName}' har tagits bort.\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }
    }
}