using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04.ClassHelpers
{
    public class MultiplOrderClassHelper
    {       
        public int Index { get; set; }

        public int NumbOfMultipl {get; set;}

        public List<int> Priority { get; set; }

        public Matrix Intermediate { get; set; }

        public MultiplOrderClassHelper()
        {
            Priority = new List<int>();
        }

    }
}
