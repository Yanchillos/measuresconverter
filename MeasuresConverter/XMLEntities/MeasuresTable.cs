using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MeasuresConverter.XMLEntities
{
    [Serializable, XmlRoot(ElementName = "measuresTable")]
    public class MeasuresTable
    {
        [XmlArray("measureGroups")]
        [XmlArrayItem("measureGroup")]
        public MeasureGroup[] MeasureGroups { get; set; }
    }
}
