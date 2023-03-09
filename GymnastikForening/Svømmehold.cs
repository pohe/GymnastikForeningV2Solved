using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Svømmehold : Hold
    {
        private string _svømmehal;

        public string Svømmehal
        {
            get { return _svømmehal; }
            set { _svømmehal = value; }
        }

        public Svømmehold(string svømmehal, string holdId, int år, string holdNavn, double prisPrDeltager, int maxAntalBørn) : base(holdId, år, holdNavn, prisPrDeltager, maxAntalBørn)
        {
            _svømmehal = Svømmehal;
        }

        public override string ToString()
        {
            return $"Svømmehal {_svømmehal} " + base.ToString();
        }
    }
}
