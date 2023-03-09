using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Hold
    {
        private List<Deltager> deltagerListe; 

        public List<Deltager> DeltagerListe
        {
            get { return deltagerListe; }
        }

        public string HoldId { get; set; } //TumleE22
        public int År { get; set; } //Man tilmelder sig for et helt år adgang
        public string HoldNavn { get; set; }
        public double PrisPrDeltager { get; set; }
        public int MaxAntalBørn { get; set; }

        public Hold(string holdId, int år, string holdNavn, double prisPrDeltager, int maxAntalBørn)
        {
            HoldId = holdId;
            År = år;
            HoldNavn =holdNavn;
            PrisPrDeltager = prisPrDeltager;
            MaxAntalBørn = maxAntalBørn;
            deltagerListe = new List<Deltager>();
        }

        public void TilmeldDeltager(Deltager deltager)
        {
            if (deltager.AntalBørn < 0)
                throw new ArgumentException("Forkert argument - check input"); 
            if ( MaxAntalBørn >= ( AntalTilmeldte() + deltager.AntalBørn) )
            {
                deltagerListe.Add(deltager);
            }
            else
            {
                //Console.WriteLine("Der er ikke plads på holdet");
                throw new FuldtHoldException("Der er ikke plads på holdet"); 
            }
        }

        public int AntalTilmeldte()
        {
            //int antal = 0;
            //foreach(Deltager deltager in deltagerListe)
            //{
            //    antal = antal + deltager.AntalBørn;
            //}
            //return antal;

            return deltagerListe.Sum((d) => d.AntalBørn);
        }

        public Double BeregnTotalPris(int antalBørn) //Hvis Deltageren tilmelder en forælder og et barn, så er prisen holdprisen, men efterfølgende børn koster 50% af hold prisen
        {
            if (antalBørn >0)
            {
                if (antalBørn == 1)
                {
                    return PrisPrDeltager;
                }
                else
                {
                    return PrisPrDeltager + (antalBørn - 1) * PrisPrDeltager * 0.5;
                }
            }
            return 0;
        }


        public override string ToString()
        {
            return $"Hold id {HoldId} År {År} Holdnavn {HoldNavn} Pris pr deltager {PrisPrDeltager} Max antal børn {MaxAntalBørn} på holdet";
        }
    }
}
