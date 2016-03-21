using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MeasuresConverter.Managers
{
    public class XMLManager
    {
        public static T GetXMLFromFile<T>(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var data = streamReader.ReadToEnd();
                return XMLManager.ParseXML<T>(data);
            }
        }

        private static T ParseXML<T>(string data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(data))
            {
                var result = (T)serializer.Deserialize(reader);
                return result;
            }
        }
    }
}
