using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Ansat : IAnsat, IComparable<Ansat>
    {
        protected const double _basisLøn = 5000; 

        private static int _counter = 0;

        private int _id;

        public int Id
        {
            get { return _id; }
        }

        private string _navn;

        public string Navn
        {
            get { return _navn; }
            set { _navn=value; }
        }

        private string _adresse;

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        private string _mobilNr;

        public string MobilNr
        {
            get { return _mobilNr; }
            set { _mobilNr = value; }
        }

        private string _stilling;

        public string Stilling
        {
            get { return _stilling; }
            set { _stilling = value; }
        }

        private DateTime _ansættelsesDato;

        public DateTime AnsættelsesDato
        {
            get { return _ansættelsesDato; }
            
        }

        public Ansat(string navn,   string adresse,  string mobilNr, string stilling)
        {
            _counter++;
            _id = _counter;
            _navn = navn;
            _adresse = adresse;
            _mobilNr = mobilNr;
            _stilling = stilling;
            _ansættelsesDato =  DateTime.Now;
        }

        public override string ToString()
        {
            return $" ID {_id} Navn {_navn} Adresse {_adresse} Mobil {_mobilNr} Stilling {_stilling} Ansat {_ansættelsesDato.ToString("MM/dd/yyyy")} Løn { beregnLøn() }";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Ansat)) return false;
            if (this.Navn == ((Ansat)obj).Navn && this.MobilNr == ((Ansat)obj).MobilNr || this.Id == ((Ansat)obj).Id)
                return true;
            else
                return false;
        }
        public virtual double beregnLøn()
        {
            return _basisLøn;
        }

        public int CompareTo(Ansat? other)
        {
            return Navn.CompareTo(other.Navn);
        }
    }
}
