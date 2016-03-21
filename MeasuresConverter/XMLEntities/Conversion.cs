using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MeasuresConverter.XMLEntities
{
    public class Conversion
    {
        [XmlAttribute("sourceId")]
        public int SourceId { get; set; }

        [XmlAttribute("targetId")]
        public int TargerId { get; set; }

        [XmlAttribute("factor")]
        public double Factor { get; set; }

        [XmlAttribute("deltha")]
        public double Deltha { get; set; }
    }
}
