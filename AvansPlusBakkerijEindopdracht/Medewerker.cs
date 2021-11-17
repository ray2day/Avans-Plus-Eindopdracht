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
    public class Medewerker : Persoon                                                                               // de klasse Medewerker is een childklasse van de parentklasse Persoon
    {
        private int _Medewerkersnummer;                                                                             // properties
        private string _Functie;
        private DateTime _DatumInDienst;
        private string _Gebruikersnaam;
        private string _Wachtwoord;

        public int Medewerkersnummer { set { _Medewerkersnummer = value; } get { return _Medewerkersnummer; } }
        public string Functie { set { _Functie = value; } get { return _Functie; } }
        public DateTime DatumInDienst { set { _DatumInDienst = value; } get { return _DatumInDienst; } }
        public string Gebruikersnaam { set { _Gebruikersnaam = value; } get { return _Gebruikersnaam; } }
        public string Wachtwoord { set { _Wachtwoord = value; } get { return _Wachtwoord; } }

        public Medewerker(bool listGevuld, int medewerkersnummer) : base(listGevuld)
        {
            if (listGevuld == true)                                                                                 // indien 'start'data aanwezig; wordt deze (overloaded) constructor uitgevoerd
            {
                Medewerkersnummer = medewerkersnummer;

                do
                { Console.Write("\nGeef functie: "); Functie = Console.ReadLine(); }
                while (string.IsNullOrEmpty(Functie));

                string datumInvoer = "";
                DateTime datumindienst;
                do
                {
                    Console.Write("\nGeef datum in dienst (dag-maand-jaar): ");
                    datumInvoer = Console.ReadLine();
                }
                while (!DateTime.TryParseExact(datumInvoer, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out datumindienst));
                DatumInDienst = datumindienst;

                do
                {
                    Console.Write("\nGeef gewenste gebruikersnaam voor deze gebruiker/medewerker voor dit Bakkerij systeem: ");
                    Gebruikersnaam = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(Gebruikersnaam));

                do
                {
                    Console.Write("\nGeef gewenst bijbehorend wachtwoord: ");
                    Wachtwoord = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(Wachtwoord));

                Console.WriteLine("\n- Medewerker is toegevoegd. -");
            }
            else { }                                                                                                // indien geen 'start'data aanwezig
        }
    }
}