using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public interface IAnsat
    {
        public int Id {  get; }
        string Navn { get; set; }
        string Adresse { get; set; }
        string MobilNr { get; set; }
        string Stilling { get; set; }
        DateTime  AnsættelsesDato { get;  }

    }
}
