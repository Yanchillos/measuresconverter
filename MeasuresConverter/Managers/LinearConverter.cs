using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuresConverter.Managers
{
    public class LinearConverter
    {
        public double Factor { get; set; }

        public double Deltha { get; set; }

        public LinearConverter()
        {

        }

        public LinearConverter(double Factor, double Deltha)
        {
            this.Factor = (Factor != 0) ? Factor : 1;
            this.Deltha = Deltha;
        }

        public LinearConverter(double Factor)
            : this(Factor, 0) { }

        public double Convert(double source)
        {
            return (double)(source * Factor + Deltha);
        }

        public bool AllowInverse
        {
            get { return true; }
        }

        public LinearConverter Inverse
        {
            get { return new LinearConverter(1 / Factor, -Deltha / Factor); }
        }
    }
}
