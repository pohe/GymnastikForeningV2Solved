using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class Tilmelding
    {
		private Hold _holdTilmelding;

		public Hold HoldTilmelding
		{
			get { return _holdTilmelding; }
			set { _holdTilmelding = value; }
		}

		private Deltager _deltagerTilmelding;

		public Deltager DeltagerTilmelding
		{
			get { return _deltagerTilmelding; }
			set { _deltagerTilmelding = value; }
		}

		public DateTime DateTime { get; set; }

		public Tilmelding(Hold hold, Deltager deltager)
		{
			if (hold.MaxAntalBørn<deltager.AntalBørn)
			{
                DateTime = DateTime.Now;
                _deltagerTilmelding = deltager;
                _holdTilmelding = hold;
            }
			else
			{
				Console.WriteLine("Tilmelding ikke muligt. Der er ikke plads på holdet");
			}
		}

		public Double BeregnTotalPris() //Hvis Deltageren tilmelder en forælder og et barn, så er prisen holdprisen, men efterfølgende børn koster 50% af hold prisen
		{
			if (_deltagerTilmelding.AntalBørn == 1)
			{
				return _holdTilmelding.PrisPrDeltager;
			}
			else
			{
				return _holdTilmelding.PrisPrDeltager + (_deltagerTilmelding.AntalBørn - 1) * _holdTilmelding.PrisPrDeltager * 0.5;
            }
			return 0;
		}

		public override string ToString()
		{
			return $"Tilmelding til {_holdTilmelding} for {_deltagerTilmelding.ForælderNavn} der har tilmeldt {_deltagerTilmelding.AntalBørn} antal børn";
		}
	}
}
