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
    public class Product
    {
        private int _Productnummer;                                                                                 // properties
        private string _Productnaam;
        private double _Verkoopprijs;
        private double _Inkoopprijs;
        private int _Voorraad;

        public int Productnummer { set { _Productnummer = value; } get { return _Productnummer; } }
        public string Productnaam { set { _Productnaam = value; } get { return _Productnaam; } }
        public double Verkoopprijs { set { _Verkoopprijs = value; } get { return _Verkoopprijs; } }
        public double Inkoopprijs { set { _Inkoopprijs = value; } get { return _Inkoopprijs; } }
        public int Voorraad { set { _Voorraad = value; } get { return _Voorraad; } }

        public Product(bool listGevuld, int productnummer)
        {
            if (listGevuld == true)                                                                                 // indien lijst gevuld; wordt deze overloaded constructor uitgevoerd
            {
                Productnummer = productnummer;

                do
                {
                    Console.Write("\nGeef productnaam: ");
                    Productnaam = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(Productnaam));

                string invoer = "";
                double inkoopprijs = 0;
                do
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.Write("\nGeef inkooprijs van product op: \u20AC ");
                    invoer = Console.ReadLine();
                }
                while (!double.TryParse(invoer.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out inkoopprijs));
                Inkoopprijs = inkoopprijs;

                do
                {
                    double verkoopprijs = 0;
                    invoer = "";
                    do
                    {
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.Write("\nGeef verkooprijs van product op: \u20AC ");
                        invoer = Console.ReadLine();
                    }
                    while (!double.TryParse(invoer.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out verkoopprijs));
                    Verkoopprijs = verkoopprijs;


                    if (Verkoopprijs < Inkoopprijs)
                    {
                        Console.WriteLine("\n- Verkoopprijs mag niet lager zijn dan inkoopprijs! -");
                    }
                }
                while (Verkoopprijs < Inkoopprijs);

                int voorraad = 0;
                invoer = "";
                do
                {
                    Console.Write("\nGeef aantal stuks op voorraad op: ");
                    invoer = Console.ReadLine();
                }
                while (!int.TryParse(invoer, out voorraad));
                Voorraad = voorraad;

                Console.WriteLine("\n- Product is toegevoegd. -");
            }
            else { }                                                                                                // indien lijst niet gevuld; wordt er niets uitgevoerd
        }
    }
}
