using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MeasuresConverter.XMLEntities
{
    public class MeasureGroup
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("measures")]
        [XmlArrayItem("measure")]
        public Measure[] Measures { get; set; }

        [XmlArray("conversions")]
        [XmlArrayItem("conversion")]
        public Conversion[] Conversions { get; set; }
    }
}
