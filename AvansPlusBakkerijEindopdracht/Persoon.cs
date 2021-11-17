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
    public class Persoon
    {
        private string _Voornaam;                                                                                   // properties
        private string _Achternaam;
        private string _StraatEnHuisnummer;
        private string _Postcode;
        private string _Plaats;
        private string _Telefoonnummer;
        private string _Email;

        public string Voornaam { set { _Voornaam = value; } get { return _Voornaam; } }
        public string Achternaam { set { _Achternaam = value; } get { return _Achternaam; } }
        public string StraatEnHuisnummer { set { _StraatEnHuisnummer = value; } get { return _StraatEnHuisnummer; } }
        public string Postcode { set { _Postcode = value; } get { return _Postcode; } }
        public string Plaats { set { _Plaats = value; } get { return _Plaats; } }
        public string Telefoonnummer { set { _Telefoonnummer = value; } get { return _Telefoonnummer; } }
        public string Email { set { _Email = value; } get { return _Email; } }

        public Persoon(bool listGevuld)
        {
            if (listGevuld == true)                                                                                 // indien 'start'data aanwezig; wordt deze (overloaded) constructor uitgevoerd
            {
                do
                { Console.Write("\nGeef voornaam: "); Voornaam = Console.ReadLine(); }
                while (string.IsNullOrEmpty(Voornaam));

                do
                { Console.Write("\nGeef achternaam: "); Achternaam = Console.ReadLine(); }
                while (string.IsNullOrEmpty(Achternaam));

                do
                { Console.Write("\nGeef straat en huisnummer: "); StraatEnHuisnummer = Console.ReadLine(); }
                while (string.IsNullOrEmpty(StraatEnHuisnummer));

                do
                { Console.Write("\nGeef postcode: "); Postcode = Console.ReadLine(); }
                while (string.IsNullOrEmpty(Postcode));

                do
                { Console.Write("\nGeef plaats: "); Plaats = Console.ReadLine(); }
                while (string.IsNullOrEmpty(Plaats));

                bool geldigNedTel = true;                                                                           // (check of telefoonnummer ingave klopt)
                do
                {
                    Console.Write("\nGeef telefoonnummer: "); Telefoonnummer = Console.ReadLine();
                    geldigNedTel = (Regex.IsMatch(Telefoonnummer, @"(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)"));
                }
                while (!geldigNedTel);

                bool GeldigEmailAdres(string email)                                                                 // (check of e-mail ingave klopt)
                {
                    if (email.Trim().EndsWith(".")) { return false; }
                    try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email; }
                    catch { return false; }
                }
                do { Console.Write("\nGeef e-mail adres: "); Email = Console.ReadLine(); }
                while (!GeldigEmailAdres(Email));
            }
            else { }                                                                                                // indien geen 'start'data aanwezig
        }
    }
}

