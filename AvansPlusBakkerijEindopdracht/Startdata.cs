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
    public class Startdata
    {
        public static List<Medewerker> LaadMedewerkerData()
        {
            bool listGevuld = false;
            List<Medewerker> output = new List<Medewerker>();                                                       // new List object Medewerker wordt aangemaakt en gevuld met medewerker(start-)data

            output.Add(new Medewerker(listGevuld, 3) { Medewerkersnummer = 3, Voornaam = "Kees", Achternaam = "Boerboom", StraatEnHuisnummer = "Molenstraat 13", Postcode = "5344 BA", Plaats = "Heesch", Telefoonnummer = "0412-634002", Email = "kboerboom@bakkerij.nl", Functie = "verkoper", DatumInDienst = new DateTime(2002, 04, 21), Gebruikersnaam = "Security3", Wachtwoord = "Security4" });
            output.Add(new Medewerker(listGevuld, 1) { Medewerkersnummer = 1, Voornaam = "Raymond", Achternaam = "van Hoorn", StraatEnHuisnummer = "Tulpenstraat 52", Postcode = "5346 DD", Plaats = "Oss", Telefoonnummer = "0412-660543", Email = "rvanhoorn@bakkerij.nl", Functie = "manager", DatumInDienst = new DateTime(2010, 06, 01), Gebruikersnaam = "ray2day", Wachtwoord = "123456ab" });
            output.Add(new Medewerker(listGevuld, 6) { Medewerkersnummer = 6, Voornaam = "Sylvia", Achternaam = "Zwartvoort", StraatEnHuisnummer = "Musketier 17", Postcode = "8301 EJ", Plaats = "Raalte", Functie = "verkoper", Telefoonnummer = "0572-234102", Email = "szwartvoort@bakkerij.nl", DatumInDienst = new DateTime(2018, 12, 14), Gebruikersnaam = "Security6", Wachtwoord = "Security7" });
            output.Add(new Medewerker(listGevuld, 4) { Medewerkersnummer = 4, Voornaam = "Arnold", Achternaam = "Zus", StraatEnHuisnummer = "De Waring 10", Postcode = "6801 LE", Plaats = "Hoogeveen", Functie = "verkoper", Telefoonnummer = "0528-634002", Email = "azus@bakkerij.nl", DatumInDienst = new DateTime(2012, 04, 01), Gebruikersnaam = "Security4", Wachtwoord = "Security5" });
            output.Add(new Medewerker(listGevuld, 2) { Medewerkersnummer = 2, Voornaam = "Maartje", Achternaam = "Huijink", StraatEnHuisnummer = "Hyacintenstraat 12", Postcode = "5342 BW", Plaats = "Oss", Telefoonnummer = "0412-667211", Email = "mhuijink@bakkerij.nl", Functie = "inkoper", DatumInDienst = new DateTime(2010, 06, 01), Gebruikersnaam = "Martha", Wachtwoord = "Poesjes666" });
            output.Add(new Medewerker(listGevuld, 5) { Medewerkersnummer = 5, Voornaam = "Peter", Achternaam = "Roelofs", StraatEnHuisnummer = "Barneveldseweg 6a", Postcode = "7162 AG", Plaats = "Terborg", Telefoonnummer = "0315-456423", Email = "proelofs@bakkerij.nl", Functie = "inkoper", DatumInDienst = new DateTime(2016, 08, 01), Gebruikersnaam = "Security5", Wachtwoord = "Security6" });

            return output;
        }


        public static List<Klant> LaadKlantData()
        {
            bool listGevuld = false;
            List<Klant> output = new List<Klant>();                                                                 // new List object Klant wordt aangemaakt en gevuld met klant(start-)data

            output.Add(new Klant(listGevuld, 3) { Klantnummer = 3, Voornaam = "Richard", Achternaam = "van Kranenburg", StraatEnHuisnummer = "Luide Steeg Oost 11", Postcode = "3283 HJ", Plaats = "Amersfoort", Telefoonnummer = "033-5624022", Email = "rkranenburg@gmail.com" });
            output.Add(new Klant(listGevuld, 1) { Klantnummer = 1, Voornaam = "Angela", Achternaam = "van Dam", StraatEnHuisnummer = "Waterstraat 72", Postcode = "7102 ET", Plaats = "Doetinchem", Telefoonnummer = "0314-634122", Email = "ajmvandam@kpnmail.nl" });
            output.Add(new Klant(listGevuld, 6) { Klantnummer = 6, Voornaam = "Fred", Achternaam = "Jovink", StraatEnHuisnummer = "Blauwestraat 195", Postcode = "6578 MB", Plaats = "Oosterhout", Telefoonnummer = "0162-634562", Email = "fredjovink@hotmail.com" });
            output.Add(new Klant(listGevuld, 9) { Klantnummer = 9, Voornaam = "Joseph", Achternaam = "Kuipers", StraatEnHuisnummer = "Willaertstraat 18a", Postcode = "5344 AB", Plaats = "Oss", Telefoonnummer = "0412-634002", Email = "jkuipers1@hotmail.com" });
            output.Add(new Klant(listGevuld, 7) { Klantnummer = 7, Voornaam = "Anton", Achternaam = "Schaapsma", StraatEnHuisnummer = "Beethovenlaan 156", Postcode = "7442 HG", Plaats = "Nijverdal", Telefoonnummer = "0548-334652", Email = "aschaapsma@tele2.nl" });
            output.Add(new Klant(listGevuld, 5) { Klantnummer = 5, Voornaam = "Leon", Achternaam = "van de Bakker", StraatEnHuisnummer = "Zevenbergseweg 2", Postcode = "5351 PH", Plaats = "Berghem", Telefoonnummer = "0413-926383", Email = "bakkerl@gmail.com" });
            output.Add(new Klant(listGevuld, 8) { Klantnummer = 8, Voornaam = "Rudolph", Achternaam = "Hefkens", StraatEnHuisnummer = "Oranjestraat 4", Postcode = "7902 CB", Plaats = "Hoogeveen", Telefoonnummer = "0528-554002", Email = "rhefkens@home.nl" });
            output.Add(new Klant(listGevuld, 10) { Klantnummer = 10, Voornaam = "Kees", Achternaam = "van Megen", StraatEnHuisnummer = "Scheltemaweg 22", Postcode = "5652 XE", Plaats = "Eindhoven", Telefoonnummer = "040-6340302", Email = "kvanmegen@kpnmail.com" });
            output.Add(new Klant(listGevuld, 4) { Klantnummer = 4, Voornaam = "Claire", Achternaam = "Reuvers", StraatEnHuisnummer = "Perikplein 91", Postcode = "7512 JB", Plaats = "Enschede", Telefoonnummer = "0412-634002", Email = "clairereuvers@icloud.com" });
            output.Add(new Klant(listGevuld, 2) { Klantnummer = 2, Voornaam = "Henk", Achternaam = "Wagemakers", StraatEnHuisnummer = "Inlaat 2", Postcode = "5345 RB", Plaats = "Oss", Telefoonnummer = "0412-641120", Email = "hwagemakers@gmail.com" });

            return output;
        }


        public static List<Product> LaadProductData()
        {
            bool listGevuld = false;
            List<Product> output = new List<Product>();                                                             // new List object Product wordt aangemaakt en gevuld met product(start-)data

            output.Add(new Product(listGevuld, 4) { Productnummer = 4, Productnaam = "Kersenvlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 2 });
            output.Add(new Product(listGevuld, 3) { Productnummer = 3, Productnaam = "Appelvlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 3 });
            output.Add(new Product(listGevuld, 1) { Productnummer = 1, Productnaam = "Abrikozenvlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 2 });
            output.Add(new Product(listGevuld, 6) { Productnummer = 6, Productnaam = "Kruisbessenvlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 6 });
            output.Add(new Product(listGevuld, 7) { Productnummer = 7, Productnaam = "Kruisbessen-schuimvlaai", Inkoopprijs = 5.76, Verkoopprijs = 9.60, Voorraad = 1 });
            output.Add(new Product(listGevuld, 9) { Productnummer = 9, Productnaam = "Rijstevlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 2 });
            output.Add(new Product(listGevuld, 10) { Productnummer = 10, Productnaam = "Rijstevlaai met slagroom", Inkoopprijs = 5.13, Verkoopprijs = 8.55, Voorraad = 4 });
            output.Add(new Product(listGevuld, 2) { Productnummer = 2, Productnaam = "Appel-krokantvlaai", Inkoopprijs = 4.56, Verkoopprijs = 7.60, Voorraad = 3 });
            output.Add(new Product(listGevuld, 5) { Productnummer = 5, Productnaam = "Kruimelvlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 4 });
            output.Add(new Product(listGevuld, 8) { Productnummer = 8, Productnaam = "Pruimenvlaai", Inkoopprijs = 4.11, Verkoopprijs = 6.85, Voorraad = 1 });

            return output;
        }
    }
}
