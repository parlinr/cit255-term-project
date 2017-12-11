using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class PasserOperationData
    {
        //I will likely use this class for all three types as I will be using the same data with each type, even if I don't change the class's name.
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public int MinYards { get; set; }
        public int MaxYards { get; set; }
        public int MinTouchdowns { get; set; }
        public int MaxTouchdowns { get; set; }
    }
}
