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
    public class Klant : Persoon                                                                                    // de klasse Klant is een childklasse van de parentklasse Persoon
    {
        private int _Klantnummer;                                                                                   // properties

        public int Klantnummer { set { _Klantnummer = value; } get { return _Klantnummer; } }

        public Klant(bool listGevuld, int klantnummer) : base(listGevuld)
        {
            if (listGevuld == true)                                                                                 // indien 'start'data aanwezig; wordt deze (overloaded) constructor uitgevoerd
            {
                Klantnummer = klantnummer;

                Console.WriteLine("\n- Klant is toegevoegd. -");
            }
            else { }                                                                                                // indien geen 'start'data aanwezig
        }
    }
}