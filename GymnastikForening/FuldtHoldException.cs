using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikForening
{
    public class FuldtHoldException:Exception
    {
        public FuldtHoldException(string message): base(message)
        {
        }
    }
}
