/// Hanterar menyn för kontaktlistan genom att visa alternativ och hämta användarens val.
public static class MenuService
/// Visar huvudmenyn för kontaktlistan och returnerar användarens val.

{
    public static int ShowMenuAndGetChoice()
    {
       
        Console.WriteLine("Välkommen till kontaktlistan!");
        Console.WriteLine("1. Lägg till kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa detaljerad information om en kontakt");
        Console.WriteLine("4. Ta bort kontakt");
        Console.WriteLine("5. Avsluta");
       
        return GetMenuChoice();
        

    }
    /// Hämtar användarens val från konsolen och ser till att det är en giltig siffra mellan 1-5.

    public static int GetMenuChoice()
    {
        Console.Write("Ange ditt val: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Ange en siffra mellan 1-5. Försök igen.");
            Console.Write("Ange ditt val: ");
        }
        return choice;
    }
}

