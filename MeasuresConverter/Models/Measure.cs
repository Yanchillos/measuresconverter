using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuresConverter.Models
{
    public class Measure
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Measure()
        {

        }

        public Measure(XMLEntities.Measure measure)
        {
            if (measure == null)
                return;

            this.Id = measure.Id;
            this.Name = measure.Name;
        }
    }
}
