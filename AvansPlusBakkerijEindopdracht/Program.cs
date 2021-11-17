using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AvansPlusBakkerijEindopdracht
{
    enum Hoofdmenu { Medewerkergegevens = 1, Klantgegevens, Productgegevens, Bestellingen, Stoppen }
    enum SubmmenuMedewerkergegevens { MedewerkersWeergeven = 1, MedewerkerToevoegen, MedewerkerWissen }
    enum SubmmenuKlantgegevens { KlantenWeergeven = 1, KlantToevoegen, KlantWissen }
    enum SubmmenuProductgegevens { ProductenWeergeven = 1, ProductToevoegen, ProductWissen }
    enum SubmmenuBestellingen { BestellingenWeergeven = 1, BestellingToevoegen, BestellingWissen }

    class Program
    {
        // * * *   I N I T I A L I S A T I E   * * *

        static List<Medewerker> medewerkers = Startdata.LaadMedewerkerData();                                       // initialisatie van de lijsten
        static List<Klant> klanten = Startdata.LaadKlantData();
        static List<Product> producten = Startdata.LaadProductData();

        static void Main(string[] args)
        {
            try
            {
                bool listGevuld = true;

                // * * *   I N T R O S C H E R M   * * *

                string gebruikersnaam = "";                                                                         // programma begin variabelen
                string wachtwoord = "";
                string gebruiker = "";
                bool kloptGebruikersnaamMetWW = false;
                string toegangsniveau = "restricties";
                int i = 0;

                TitelWeergave("Avans Plus Bakkerij informatiesysteem");

                Console.WriteLine("Welkom bij het Avans Plus Bakkerij informatiesysteem.");
                Console.WriteLine("Met dit programma kunt u eenvoudig medewerker-, klant- en productgegevens opzoeken.\n");
                Console.WriteLine("Dit programma is alleen toegankelijk voor medewerkers van de Bakkerij.\n");
                Console.WriteLine("Voer uw gebruikersnaam en wachtwoord in.");

                do                                                                                                  // gebruikersnaam- / en wachtwoordcontrole
                {
                    Console.Write("\nGebruikersnaam: ");
                    gebruikersnaam = Console.ReadLine();

                    Console.Write("Wachtwoord: ");
                    wachtwoord = AfgeschermdeWachtwoordInvoer();

                    foreach (var medewerker in medewerkers)
                    {
                        if (!kloptGebruikersnaamMetWW && medewerker.Wachtwoord == wachtwoord && medewerker.Gebruikersnaam == gebruikersnaam)
                        {
                            kloptGebruikersnaamMetWW = true;
                            gebruiker = medewerker.Voornaam;

                            if (medewerker.Functie == "manager")
                            {
                                toegangsniveau = "geen restricties";
                            }
                        }
                    }

                    i++;
                    if (i != 3 && !kloptGebruikersnaamMetWW)
                    {
                        Console.WriteLine("\n- U heeft ongeldige combinatie van gebruikersnaam en/of wachtwoord ingevoerd. Probeer het nogmaals. -");
                    }
                    if (i == 3 && !kloptGebruikersnaamMetWW)
                    {
                        Console.WriteLine("\nU heeft 3x een ongeldige combinatie van gebruikersnaam en/of wachtwoord ingevoerd.\n");
                        ProgrammaBeeindigen();
                    }
                }
                while (!kloptGebruikersnaamMetWW);

                Console.WriteLine($"\nWelkom {gebruiker}!");
                System.Threading.Thread.Sleep(2000);

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

                // * * *   H O O F D M E N U -   E N   P R O G R A M M A   * * *


                string menuLoop = "hoofdmenu";
                while (menuLoop == "hoofdmenu")
                {
                    string invoer = "";
                    uint uitvoer = 0;

                    do                                                                                              // hoofdmenu
                    {
                        TitelWeergave("Hoofdmenu");

                        Console.WriteLine("1) Medewerkergegevens\n");
                        Console.WriteLine("2) Klantgegevens\n");
                        Console.WriteLine("3) Productgegevens\n");
                        Console.WriteLine("4) Bestellingen\n");
                        Console.WriteLine("5) Stoppen\n");

                        Console.Write("Uw keuze: ");
                        invoer = Console.ReadLine();
                    }
                    while (!uint.TryParse(invoer, out uitvoer));

                    Hoofdmenu keuze = (Hoofdmenu)uitvoer;

                    switch (keuze)
                    {
                        case Hoofdmenu.Medewerkergegevens:
                            menuLoop = "submenu";
                            while (menuLoop == "submenu")
                            {
                                // * * *   S U B M E N U :   M E D E W E R K E R S G E G E V E N S   * * *

                                invoer = "";
                                uitvoer = 0;

                                do
                                {
                                    medewerkers = medewerkers.OrderBy(x => x.Medewerkersnummer).ToList();           // medewerkers sorteren

                                    TitelWeergave("Medewerkergegevensmenu");

                                    Console.WriteLine("1) Medewerkers weergeven\n");
                                    Console.WriteLine("2) Medewerker toevoegen\n");
                                    Console.WriteLine("3) Medewerker wissen\n");
                                    Console.WriteLine("4) Terug naar hoofdmenu\n");

                                    Console.Write("Uw keuze: ");
                                    invoer = Console.ReadLine();
                                }
                                while (!uint.TryParse(invoer, out uitvoer));

                                SubmmenuMedewerkergegevens keuze1 = (SubmmenuMedewerkergegevens)uitvoer;

                                switch (keuze1)
                                {
                                    case SubmmenuMedewerkergegevens.MedewerkersWeergeven:                           // medewerkers weergeven
                                        TitelWeergave("Medewerkers weergeven");
                                        MedewerkersWeergeven();
                                        DrukEenToets();
                                        break;

                                    case SubmmenuMedewerkergegevens.MedewerkerToevoegen:                            // medewerker toevoegen
                                        TitelWeergave("Medewerker toevoegen");
                                        if (toegangsniveau == "restricties") { Console.WriteLine($"- U heeft geen bevoegdheid voor het toevoegen van medewerkers. -"); }
                                        if (toegangsniveau == "geen restricties") { var medewerker = new Medewerker(listGevuld, MedewerkersnummerGenereren()); medewerkers.Add(medewerker); }
                                        DrukEenToets();
                                        break;

                                    case SubmmenuMedewerkergegevens.MedewerkerWissen:                               // medewerker wissen
                                        TitelWeergave("Medewerker wissen");
                                        if (toegangsniveau == "restricties") { Console.WriteLine($"- U heeft geen bevoegdheid voor het wissen van medewerkers. -"); }
                                        if (toegangsniveau == "geen restricties") { MedewerkerWissen(); }
                                        DrukEenToets();
                                        break;

                                    default:                                                                        
                                        if (uitvoer < 5)
                                        {
                                            menuLoop = "hoofdmenu";                                                 // terug naar hoofdmenu
                                        }
                                        break;
                                }
                            }
                            break;

                        // ---------------------------------------------------------------------------------------------------------------

                        case Hoofdmenu.Klantgegevens:
                            menuLoop = "submenu";
                            while (menuLoop == "submenu")
                            {
                                // * * *   S U B M E N U :   K L A N T G E G E V E N S   * * *

                                invoer = "";
                                uitvoer = 0;

                                do
                                {
                                    klanten = klanten.OrderBy(x => x.Klantnummer).ToList();                         // klanten sorteren             

                                    TitelWeergave("Klantgegevensmenu");

                                    Console.WriteLine("1) Klanten weergeven\n");
                                    Console.WriteLine("2) Klant toevoegen\n");
                                    Console.WriteLine("3) Klant wissen\n");
                                    Console.WriteLine("4) Terug naar hoofdmenu\n");

                                    Console.Write("Uw keuze: ");
                                    invoer = Console.ReadLine();
                                }
                                while (!uint.TryParse(invoer, out uitvoer));

                                SubmmenuKlantgegevens keuze2 = (SubmmenuKlantgegevens)uitvoer;

                                switch (keuze2)
                                {
                                    case SubmmenuKlantgegevens.KlantenWeergeven:                                    // klanten weergeven
                                        TitelWeergave("Klanten weergeven");
                                        KlantenWeergeven();
                                        DrukEenToets();
                                        break;

                                    case SubmmenuKlantgegevens.KlantToevoegen:                                      // klant toevoegen
                                        TitelWeergave("Klant toevoegen");

                                        var klant = new Klant(listGevuld, KlantnummerGenereren());
                                        klanten.Add(klant);

                                        DrukEenToets();
                                        break;

                                    case SubmmenuKlantgegevens.KlantWissen:                                         // klant wissen
                                        TitelWeergave("Klant wissen");
                                        KlantWissen();
                                        DrukEenToets();
                                        break;

                                    default:
                                        if (uitvoer < 5)
                                        {
                                            menuLoop = "hoofdmenu";                                                 // terug naar hoofdmenu
                                        }
                                        break;
                                }
                            }
                            break;

                        // ---------------------------------------------------------------------------------------------------------------    

                        case Hoofdmenu.Productgegevens:
                            menuLoop = "submenu";
                            while (menuLoop == "submenu")
                            {
                                // * * *   S U B M E N U :  P R O D U C T G E G E V E N S   * * *

                                invoer = "";
                                uitvoer = 0;

                                do
                                {
                                    producten = producten.OrderBy(x => x.Productnummer).ToList();                   // producten sorteren

                                    TitelWeergave("Productgegevensmenu");

                                    Console.WriteLine("1) Producten weergeven\n");
                                    Console.WriteLine("2) Product toevoegen\n");
                                    Console.WriteLine("3) Product wissen\n");
                                    Console.WriteLine("4) Terug naar hoofdmenu\n");

                                    Console.Write("Uw keuze: ");
                                    invoer = Console.ReadLine();
                                }
                                while (!uint.TryParse(invoer, out uitvoer));

                                SubmmenuProductgegevens keuze3 = (SubmmenuProductgegevens)uitvoer;

                                switch (keuze3)
                                {
                                    case SubmmenuProductgegevens.ProductenWeergeven:                                // producten weergeven
                                        TitelWeergave("Producten weergeven");
                                        ProductenWeergeven();
                                        DrukEenToets();
                                        break;

                                    case SubmmenuProductgegevens.ProductToevoegen:                                  // product toevoegen
                                        TitelWeergave("Product toevoegen");

                                        var product = new Product(listGevuld, ProductnummerGenereren());
                                        producten.Add(product);

                                        DrukEenToets();
                                        break;

                                    case SubmmenuProductgegevens.ProductWissen:                                     // product wissen
                                        TitelWeergave("Product wissen");
                                        ProductWissen();
                                        DrukEenToets();
                                        break;

                                    default:                                                                        
                                        if (uitvoer < 5)
                                        {
                                            menuLoop = "hoofdmenu";                                                 // terug naar hoofdmenu
                                        }
                                        break;
                                }
                            }
                            break;

                        // ---------------------------------------------------------------------------------------------------------------

                        case Hoofdmenu.Bestellingen:

                            // * * *   S U B M E N U :   B E S T E L L I N G E N   * * *

                            TitelWeergave("Bestellingen");                                                          
                            Console.WriteLine("- Onderdeel nog niet beschikbaar. Excuses voor het ongemak. -");
                            DrukEenToets();

                            break;

                        // --------------------------------------------------------------------------------------------------------------- 

                        case Hoofdmenu.Stoppen:                                                                     

                            // * * *   S U B M E N U :   S T O P P E N   * * *

                            Console.WriteLine("\nBedankt voor het gebruik van het Bakkerij informatiesysteem.\n");
                            ProgrammaBeeindigen();
                            break;

                        default:
                            break;
                    }
                }

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -










                // * * *   M E T H O D E N :   A L G E M E E N   P R O G R A M M A   * * *

                // -- Afgeschermde Wachtwoord Invoer --

                static string AfgeschermdeWachtwoordInvoer()                                                        // methode voor afgeschermde wachtwoordinvoer
                {
                    StringBuilder input = new StringBuilder();
                    while (true)
                    {
                        int x = Console.CursorLeft;
                        int y = Console.CursorTop;
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                        if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                        {
                            input.Remove(input.Length - 1, 1);
                            Console.SetCursorPosition(x - 1, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x - 1, y);
                        }
                        else if (key.KeyChar < 32 || key.KeyChar > 126)
                        {
                            Trace.WriteLine("- Ongeldige invoer: dit is geen leesteken! -");
                        }
                        else if (key.Key != ConsoleKey.Backspace)
                        {
                            input.Append(key.KeyChar);
                            Console.OutputEncoding = System.Text.Encoding.UTF8;
                            Console.Write("\u2022");
                        }
                    }
                    return input.ToString();
                }


                // -- Titel Weergave --

                static void TitelWeergave(string titel)                                                             // methode voor het weergeven van de titel
                {
                    Console.Clear();
                    char[] balk = new char[titel.Length];
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    for (int i = 0; i < titel.Length; i++) { balk[i] = '\u0336'; }
                    string titelbalk = new string(balk);
                    Console.WriteLine($"{titelbalk}\n{titel}\n{titelbalk}\n");
                }


                // -- Druk een toets --

                static void DrukEenToets()                                                                          // methode voor druk een toets ingave
                {
                    Console.WriteLine("\nDruk een toets.");
                    Console.ReadKey();
                }


                // -- Programma beeindigen --                                                                       // methode voor het beeindigen van het programma

                static void ProgrammaBeeindigen()
                {
                    Console.WriteLine("- Het programma wordt beeindigd. -");
                    Environment.Exit(0);
                }






                // * * *   M E T H O D E N :   M E D E W E R K E R   * * *

                // -- Medewerkersnummer Genereren --                                                                

                static int MedewerkersnummerGenereren()                                                             // methode voor het genereren van een nieuw medewerkersnummer
                {                                                                                                   // (op basis van het hoogste medewerkersnummer te achterhalen)
                    int hoogsteMedewerkersnummer = 0;                                                               // [let op! lijst dienst vooraf gesorteerd te zijn!!]

                    foreach (var medewerker in medewerkers)
                    {
                        if (medewerker.Medewerkersnummer > hoogsteMedewerkersnummer)                                // (check wat het hoogste medewerkersnummer is)
                        {
                            hoogsteMedewerkersnummer = medewerker.Medewerkersnummer;
                        }
                    }

                    int medewerkersnummer = ++hoogsteMedewerkersnummer;

                    Console.WriteLine($"Nieuw (gegenereerd) medewerkersnummer: {medewerkersnummer}");

                    return medewerkersnummer;
                }


                // -- Medewerkers Weergeven --

                static void MedewerkersWeergeven()                                                                  // methode voor het weergeven van de lijst medewerkers                                                
                {
                    if (medewerkers.Count == 0)
                    {
                        Console.WriteLine("- De lijst met medewerkers is leeg! Voeg eerst medewerkers toe via het 'Medewerker toevoegen'-menu. -");
                    }
                    else
                    {
                        foreach (var medewerker in medewerkers)
                        {
                            Console.WriteLine($"{ medewerker.Medewerkersnummer }. { medewerker.Voornaam } { medewerker.Achternaam } ({ medewerker.Functie }) | { medewerker.StraatEnHuisnummer }, { medewerker.Postcode }, { medewerker.Plaats } | Tel. { medewerker.Telefoonnummer } | E-mail: { medewerker.Email } | Datum in dienst: { medewerker.DatumInDienst.ToString("dd-MM-yyyy") }");
                        }
                    }
                }


                // -- Medewerker Wissen --

                static void MedewerkerWissen()                                                                      // methode voor het wissen van een werknemer
                {
                    if (medewerkers.Count > 0)
                    {
                        MedewerkersWeergeven();

                        int teWissenNummer = 0;
                        int counter = 0;
                        bool medewerkersnummerAanwezig = (false);
                        string invoer = "";
                        do
                        {
                            Console.Write("\nWelk medewerkersnummer wilt u wissen? ");
                            invoer = Console.ReadLine();
                        }
                        while (!int.TryParse(invoer, out teWissenNummer));

                        foreach (var medewerker in medewerkers)                                                     // (check of medewerker uberhaupt in lijst aanwezig is)
                        {
                            if (medewerkersnummerAanwezig == false)
                            {
                                counter++;
                            }
                            if (medewerker.Medewerkersnummer == teWissenNummer)
                            {
                                medewerkersnummerAanwezig = (true);
                            }
                        }

                        if (medewerkersnummerAanwezig)
                        {

                            medewerkers.RemoveAt(--counter);                                                        // (het daadwerkelijke wissen van de medewerker)
                            Console.WriteLine("\n- Medewerker is gewist. -");
                        }
                        else
                        {
                            Console.WriteLine("- Medewerkersnummer niet aanwezig! -");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- De lijst met medewerkers is leeg! Voeg eerst medewerker toe via het 'Medewerkers toevoegen'-menu. -");
                    }
                }


                // * * *   M E T H O D E N :   K L A N T   * * *

                // -- Klantnummer Genereren --

                static int KlantnummerGenereren()                                                                   // methode voor het genereren van een nieuw klantnummer
                {                                                                                                   // (op basis van eerst mogelijke optie)
                    bool flag = true;                                                                               // [let op! lijst dienst vooraf gesorteerd te zijn!!]
                    int counter = 0;
                    int klantnummer = 0;

                    foreach (var klant in klanten)                                                                  // (check wat eerst mogelijke optie is)                                
                    {
                        counter = ++counter;

                        if (klant.Klantnummer != counter)
                        {
                            while (flag)
                            {
                                klantnummer = counter;
                                flag = false;
                            }

                        }
                    }

                    if (klantnummer == 0)                                                                           // (indien geen plaats, genereer a.h.v. hoogste klantnummer)
                    {
                        foreach (var klant in klanten)
                        {
                            if (klant.Klantnummer > klantnummer)
                            {
                                klantnummer = klant.Klantnummer;
                            }
                        }
                        klantnummer = ++klantnummer;
                    }

                    Console.WriteLine($"Nieuw (gegenereerd) klantnummer: {klantnummer}");
                    return klantnummer;
                }


                // -- Klanten Weergeven --

                static void KlantenWeergeven()                                                                      // methode voor het weergeven van de lijst klanten
                {
                    if (klanten.Count == 0)
                    {
                        Console.WriteLine("- De lijst met klanten is leeg! Voeg eerst klanten toe via het 'Klant toevoegen'-menu. -");
                    }
                    else
                    {
                        foreach (var klant in klanten)
                        {
                            Console.WriteLine($"{ klant.Klantnummer }. { klant.Voornaam } { klant.Achternaam } | { klant.StraatEnHuisnummer }, { klant.Postcode }, { klant.Plaats } | Tel. { klant.Telefoonnummer } | E-mail { klant.Email }");
                        }
                    }
                }


                // -- Klant Wissen --

                static void KlantWissen()                                                                           // methode voor het wissen van een klant
                {
                    if (klanten.Count > 0)
                    {
                        KlantenWeergeven();

                        int teWissenNummer = 0;
                        int counter = 0;
                        bool klantnummerAanwezig = (false);
                        string invoer = "";
                        do
                        {
                            Console.Write("\nWelk klantnummer wilt u wissen? ");
                            invoer = Console.ReadLine();
                        }
                        while (!int.TryParse(invoer, out teWissenNummer));

                        foreach (var klant in klanten)                                                              // (check of klant uberhaupt in lijst aanwezig is)
                        {
                            if (klantnummerAanwezig == false)
                            {
                                counter++;
                            }
                            if (klant.Klantnummer == teWissenNummer)
                            {
                                klantnummerAanwezig = (true);
                            }
                        }

                        if (klantnummerAanwezig)
                        {

                            klanten.RemoveAt(--counter);                                                            // (het daadwerkelijke wissen van de klant)
                            Console.WriteLine("\n- Klant is gewist. -");
                        }
                        else
                        {
                            Console.WriteLine("- Klantnummer niet aanwezig! -");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- De lijst met klanten is leeg! Voeg eerst producten toe via het 'Klant toevoegen'-menu. -");
                    }

                }


                // * * *   M E T H O D E N :   P R O D U C T   * * *

                // -- Productnummer Genereren --

                static int ProductnummerGenereren()                                                                 // methode voor het genereren van een nieuw productnummer
                {                                                                                                   // (op basis van eerst mogelijke optie)
                    bool flag = true;                                                                               // [let op! lijst dienst vooraf gesorteerd te zijn!!]
                    int counter = 0;
                    int productnummer = 0;

                    foreach (var product in producten)                                                              // (check wat eerst mogelijke optie is)                                
                    {
                        counter = ++counter;

                        if (product.Productnummer != counter)
                        {
                            while (flag)
                            {
                                productnummer = counter;
                                flag = false;
                            }

                        }
                    }

                    if (productnummer == 0)                                                                         // (indien geen plaats, genereer a.h.v. hoogste productnummer)
                    {
                        foreach (var product in producten)
                        {
                            if (product.Productnummer > productnummer)
                            {
                                productnummer = product.Productnummer;
                            }
                        }
                        productnummer = ++productnummer;
                    }

                    Console.WriteLine($"Nieuw (gegenereerd) productnummer: {productnummer}");
                    return productnummer;
                }


                // -- Producten Weergeven --

                static void ProductenWeergeven()                                                                    // methode voor het weergeven van de lijst producten
                {
                    if (producten.Count == 0)
                    {
                        Console.WriteLine("- De lijst met producten is leeg! Voeg eerst producten toe via het 'Product toevoegen'-menu. -");
                    }
                    else
                    {
                        foreach (var product in producten)
                        {
                            Console.OutputEncoding = System.Text.Encoding.UTF8;
                            Console.WriteLine($"{ product.Productnummer }. { product.Productnaam } | Inkoopprijs: \u20AC {String.Format("{0:0.00}", product.Inkoopprijs)} | Verkoopprijs: \u20AC {String.Format("{0:0.00}", product.Verkoopprijs)} | Aantal op voorraad: { product.Voorraad } ");
                        }
                    }
                }


                // -- Product Wissen --

                static void ProductWissen()                                                                         // methode voor het wissen van een product
                {
                    if (producten.Count > 0)
                    {
                        ProductenWeergeven();

                        int teWissenNummer = 0;
                        int counter = 0;
                        bool productnummerAanwezig = (false);
                        string invoer = "";
                        do
                        {
                            Console.Write("\nWelk productnummer wilt u wissen? ");
                            invoer = Console.ReadLine();
                        }
                        while (!int.TryParse(invoer, out teWissenNummer));

                        foreach (var product in producten)                                                          // (check of product uberhaupt in lijst aanwezig is)
                        {
                            if (productnummerAanwezig == false)
                            {
                                counter++;
                            }
                            if (product.Productnummer == teWissenNummer)
                            {
                                productnummerAanwezig = (true);
                            }
                        }

                        if (productnummerAanwezig)
                        {

                            producten.RemoveAt(--counter);                                                          // (het daadwerkelijke wissen van het product)
                            Console.WriteLine("\n- Product is gewist. -");
                        }
                        else
                        {
                            Console.WriteLine("- Productnummer niet aanwezig! -");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- De lijst met producten is leeg! Voeg eerst producten toe via het 'Product toevoegen'-menu. -");
                    }
                }
            }






            catch (Exception)                                                                                       // en mocht er onverhoopt toch nog een foutje in het programma zitten...
            {
                Console.WriteLine("\n- Er heeft zich een ernstige fout voorgedaan. Het programma wordt afgesloten. -");
                Environment.Exit(0);
            }
        }
    }
}