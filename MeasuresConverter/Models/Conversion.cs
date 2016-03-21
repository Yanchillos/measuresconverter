using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuresConverter.Models
{
    public class Conversion
    {
        public int SourceId { get; set; }

        public int TargerId { get; set; }

        public double Factor { get; set; }

        public double Deltha { get; set; }

        public Conversion()
        {

        }

        public Conversion(XMLEntities.Conversion conversion)
        {
            this.SourceId = conversion.SourceId;
            this.TargerId = conversion.TargerId;
            this.Factor = conversion.Factor;
            this.Deltha = conversion.Deltha;
        }
    }
}
