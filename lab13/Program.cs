using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace lab13
{
    [Serializable]
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public Country() { }

        public Country(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public override string ToString()
        {
            return $"Name - {Name} | Population - {Population}";
        }
    }

    [DataContract]
    public class Path
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public float Time { get; set; }
        [DataMember]
        public float Distance { get; set; }

        public float speed;

        [OnSerializing]
        void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine("[DataContractJson] path serializing has been started");
        }

        [OnSerialized]
        void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("[DataContractJson] path was serialized successfully");
        }

        [OnDeserializing]
        void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine("[DataContractJson] path deserializing has been started");
        }

        [OnDeserialized]
        void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine(ToString());
            speed = Distance / Time;
            Console.WriteLine("[DataContractJson] path was deserialized successfully");
        }

        public Path()
        {
            speed = Distance / Time;
        }

        public Path(string name, float time, float distance)
        {
            Name = name;
            Time = time;
            Distance = distance;
            speed = distance / time;
        }

        public override string ToString()
        {
            return $"Name - {Name} | Time - {Time} | Distance - {Distance} | Speed - {speed}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1 - SOAP
            Console.WriteLine("\tTASK 1");
            Country country1 = new Country("Ukraine", 44130000);
            Country country2 = new Country("Poland", 37950000);
            Country country3 = new Country("Turkey", 84340000);
            Country[] countries = new Country[] { country1, country2, country3 };

            foreach (var item in countries)
                Console.WriteLine(item);

            SoapFormatter soapFormatter = new SoapFormatter();

            using (FileStream fileStream = new FileStream("countriesSOAP.dat", FileMode.OpenOrCreate))
                soapFormatter.Serialize(fileStream, countries);
            Console.WriteLine("[SOAP] countries were serialized successfully");

            using (FileStream fileStream = new FileStream("countriesSOAP.dat", FileMode.Open))
            {
                Country[] countriesDeserialized = (Country[])soapFormatter.Deserialize(fileStream);
                foreach (var item in countriesDeserialized)
                    Console.WriteLine(item);
                Console.WriteLine("[SOAP] countries were deserialized successfully");
            }

            //2 - DataContractJsonSerializer
            Console.WriteLine("\n\n\tTASK 2");
            Path pathA = new Path("Path A", 3, 120);
            Console.WriteLine(pathA);

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Path));

            using (FileStream fileStream = new FileStream("path.json", FileMode.OpenOrCreate))
                jsonSerializer.WriteObject(fileStream, pathA);

            using (FileStream fileStream = new FileStream("path.json", FileMode.Open))
            {
                Path pathDeserialized = (Path)jsonSerializer.ReadObject(fileStream);
                Console.WriteLine(pathDeserialized);
            }

            //3 - XML
            Console.WriteLine("\n\n\tTASK 3");
            Country country4 = new Country("Germany", 83240000);
            Console.WriteLine(country4);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Country));

            using (FileStream fileStream = new FileStream("country.xml", FileMode.OpenOrCreate))
                xmlSerializer.Serialize(fileStream, country4);
            Console.WriteLine("[XML] country was serialized successfully");

            using (FileStream fileStream = new FileStream("country.xml", FileMode.Open))
            {
                Country countryDeserialized = (Country)xmlSerializer.Deserialize(fileStream);
                Console.WriteLine(countryDeserialized);
                Console.WriteLine("[XML] country was deserialized successfully");
            }

            Console.Read();
        }
    }
}
