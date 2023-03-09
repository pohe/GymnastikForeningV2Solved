using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class HoldKatalog
    {
        private List<Hold> holdListe;

        public HoldKatalog()
        {
            holdListe = new List<Hold>();
        }

        public void TilføjHold(Hold hold) // der må ikke være dubletter
        {
            if (FindHold(hold.HoldId) != null)
            {
                throw new ArgumentException($"Der findes allerede et hold med hold id {hold.HoldId} ");
            }
            else
            {
                holdListe.Add(hold);
            }
        }

        public Hold FindHold(string holdId)
        {
            //foreach (Hold hold in holdListe)
            //{
            //    if (hold.HoldId == holdId)
            //        return hold;
            //}

            int i = 0;
            while (i < holdListe.Count)
            {
                if (holdListe[i].HoldId == holdId)
                    return holdListe[i];
                i++;
            }
            return null;
        }

        public Hold FindHoldLinq(string holdId)
        {
            return holdListe.Find(h => h.HoldId == holdId);
        }

        public void PrintHoldListe()
        {
            foreach (Hold hold in holdListe)
            {
                Console.WriteLine(hold);
            }
        }

        public int FindAntalHold(string holdNavn)
        {
            int antal = 0;
            foreach (Hold hold in holdListe)
            {
                if (hold.HoldNavn == holdNavn)
                {
                    antal++;
                }
            }
            return antal;
            //return HentHoldListe(holdNavn).Count;

        }
        public int FindAntalHoldLinq(string holdNavn)
        {
            return holdListe.FindAll(h => h.HoldNavn == holdNavn).Count;
        }

        public List<Hold> HentHoldListe(string holdNavn)
        {
            List<Hold> liste = new List<Hold>();
            foreach (Hold hold in holdListe)
            {
                if (hold.HoldNavn == holdNavn)
                {
                    liste.Add(hold);
                }
            }
            return liste;
        }

        public List<Hold> HentHoldListeLinq(string holdNavn)
        {
            //List<Hold> liste = new List<Hold>();
            //foreach (Hold hold in holdListe)
            //{
            //    if (hold.HoldNavn == holdNavn)
            //    {
            //        liste.Add(hold);
            //    }
            //}
            //return liste; 
            return holdListe.FindAll(h => h.HoldNavn == holdNavn);
        }

        public override string ToString()
        {
            string returString = "";
            foreach (Hold hold in holdListe)
            {
                returString = returString + hold.ToString() + " \n";
            }
            return returString;
        }

        public int SamletAntalDeltagerePåAlleHold()
        {
            int sum = 0;
            foreach (Hold hold in holdListe)
            {
                sum += hold.AntalTilmeldte();
            }
            return sum;
        }

        public int SamletAntalDeltagerePåAlleHoldLinq()
        {
            return holdListe.Sum(h => h.AntalTilmeldte());
        }

        public int GennemsnitligeDeltagerePrHold()
        {
            int antal = 0;
            foreach (Hold hold in holdListe)
            {
                antal += hold.AntalTilmeldte();
            }
            if (holdListe.Count > 0)
                return antal / holdListe.Count;
            else
                return 0;
        }

        public int GennemsnitligeDeltagerePrHoldLinq()
        {
            return (int)holdListe.Average(h => h.AntalTilmeldte());
        }

        public int FlestDeltagerePåHold()
        {
            int højestAntalDeltagere = 0;
            foreach(Hold hold in holdListe)
            {
                if (hold.AntalTilmeldte() > højestAntalDeltagere)
                    højestAntalDeltagere = hold.AntalTilmeldte();
            }
            return højestAntalDeltagere; 
        }

        public int FlestDeltagerePåHoldLinq()
        {
            return holdListe.Select( h=>h.AntalTilmeldte() ).Max();
        }


        public Hold HoldMedFlestDeltagere()
        {
            if (holdListe== null || holdListe.Count == 0)
                return null;
            else
            {
                Hold holdMedFlestDeltagere = holdListe[0];
                for (int i = 1; i < holdListe.Count; i++)
                {
                    if (holdListe[i].AntalTilmeldte() > holdMedFlestDeltagere.AntalTilmeldte() )
                        holdMedFlestDeltagere = holdListe[i];
                }
                return holdMedFlestDeltagere;
            }
        }

        public Hold HoldMedFlestDeltagereLinq()
        {
            return holdListe.Where(h =>  h.AntalTilmeldte() == holdListe.Select(h => h.AntalTilmeldte()).Max()).First();
        }


        public double MaxIndtjenningpåHold(Hold hold)
        {
            double totalPrHold = 0; 
            foreach(Deltager deltager in hold.DeltagerListe)
            {
                totalPrHold += hold.BeregnTotalPris(deltager.AntalBørn);
            }
            return totalPrHold;
        }

        public Hold HoldMedHøjstIndtjenning()
        {
            if (holdListe == null || holdListe.Count == 0)
                return null;
            else
            {
                Hold holdMedHøjestIndtjenning = holdListe[0];
                for (int i = 1; i < holdListe.Count; i++)
                {
                    if (MaxIndtjenningpåHold(holdListe[i]) > MaxIndtjenningpåHold(holdMedHøjestIndtjenning) )
                        holdMedHøjestIndtjenning = holdListe[i];
                }
                return holdMedHøjestIndtjenning;
            }
            return null;
        }

    }
}
