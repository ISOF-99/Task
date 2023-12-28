
using Newtonsoft.Json;
/// Hanterar filoperationer för att ladda och spara kontakter samt prenumerera på avslutningshändelse.
public class FileService
{
    private const string JsonFilePath = "contacts.json";

    /// Laddar kontakter från en JSON-fil om filen finns.
    public List<Contact> LoadContacts()
    {
        List<Contact> contacts = new List<Contact>();

        if (File.Exists(JsonFilePath))
        {
            string json = File.ReadAllText(JsonFilePath);
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json)!;
            
        }
        else
        {
            Console.WriteLine("Ingen befintlig fil med kontakter hittades.\n");
        }

        return contacts;
    }

    /// Sparar kontakter till en JSON-fil.
    public void SaveContacts(List<Contact> contacts)
    {
        string json = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(JsonFilePath, json);
       
    }
    ///Lyssnar på avslutningshändelser och genomför en specificerad åtgärd när programmet avslutas.
    public void SubscribeToExitEvent(Action exitAction)
    {
        AppDomain.CurrentDomain.ProcessExit += (sender, args) => exitAction();
    }
    
}