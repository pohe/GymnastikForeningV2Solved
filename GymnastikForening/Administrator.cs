using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Administrator : Ansat
    {
        private string _ansvarsOmråde;

        public string Ansvarsområde
        {
            get { return _ansvarsOmråde; }
            set { _ansvarsOmråde = value; }
        }

        public Administrator(string navn, string adresse, string mobilNr, string stilling, string ansvarsområde) : base(navn, adresse, mobilNr, stilling)
        {
            _ansvarsOmråde = ansvarsområde;
        }

        public override string ToString()
        {
            return base.ToString() + $" Ansvarsområde {_ansvarsOmråde}  Løn {beregnLøn()}";
        }
        public override double beregnLøn()
        {
            return base.beregnLøn() + (Stilling.Contains("Direktør")? 15000 : 5000);
        }

    }
}
