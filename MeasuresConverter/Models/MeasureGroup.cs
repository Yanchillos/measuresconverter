using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuresConverter.Models
{
    public class MeasureGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Models.Measure> Measures { get; set; }

        public List<Models.Conversion> Conversions { get; set; }

        public MeasureGroup()
        {

        }

        public MeasureGroup(XMLEntities.MeasureGroup measureGroup)
        {
            if (measureGroup == null)
                return;

            if (measureGroup.Measures == null || measureGroup.Conversions == null)
                return;

            this.Id = measureGroup.Id;
            this.Name = measureGroup.Name;

            this.Measures = new ObservableCollection<Measure>();
            foreach (var measure in measureGroup.Measures)
                this.Measures.Add(new Measure(measure));

            this.Conversions = new List<Conversion>();
            foreach (var conversion in measureGroup.Conversions)
                this.Conversions.Add(new Conversion(conversion));
        }
    }
}
