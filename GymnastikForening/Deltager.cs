using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Deltager
    {   //Der skal kun registreres et forældre navn og desuden antallet af børn
        public string ForælderNavn { get; set; }
        public string Adresse { get; set; }

        public int AntalBørn { get; set; }

        public Deltager(string forælderNavn, string adresse, int antalBørn)
        {
            ForælderNavn = forælderNavn;
            Adresse = adresse;
            AntalBørn = antalBørn;
        }

        public override string ToString()
        {
            return $"Forældre navn {ForælderNavn} adresse {Adresse} antal børn {AntalBørn}";
        }
    }
}
