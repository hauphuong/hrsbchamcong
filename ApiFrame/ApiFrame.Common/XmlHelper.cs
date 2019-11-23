using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace ApiFrame.Common
{
    public static class XmlHelper
    {
        public static IEnumerable<T> Deserialize<T>(IEnumerable<XElement> elements) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            XElement item = elements.First();
            var z = (T)ser.Deserialize(item.CreateReader());
            return elements.Select(x =>
            {
                using (var render = x.CreateReader())
                    return (T)ser.Deserialize(render);
            });
        }

        public static T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
            using (StringWriter textWriter = new UTF8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize, ns);
                return textWriter.ToString();
            }
        }

        public class UTF8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.UTF8;
                }
            }
            //public override Encoding Encoding = Encoding.UTF8;
        }
    }
}
