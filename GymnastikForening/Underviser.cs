using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Underviser : Ansat
    {
        private string _uddannelse;

        public string Uddannelse
        {
            get { return _uddannelse; }
            set { _uddannelse = value; }
        }

        private bool _børneAttest;

        public bool BørneAttest
        {
            get { return _børneAttest; }
            set { _børneAttest = value; }
        }

        public Underviser(string navn, string adresse, string mobilNr, string stilling, string uddannelse, bool børneAttest) : base(navn, adresse, mobilNr, stilling)
        {
            _uddannelse = uddannelse; 
            _børneAttest = børneAttest;

        }

        public override string ToString()
        {
            return base.ToString() + $" Uddannelse {_uddannelse} Børneattest { ( _børneAttest? "haves":"haves ikke")} Løn {beregnLøn()} ";
        }

        public override double beregnLøn()
        {
            return base.beregnLøn() + (Stilling.Contains("Instruktør") ? 10000 : 5000);
        }
    }
}
