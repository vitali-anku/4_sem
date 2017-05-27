using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_7
{
    [Serializable]
    public class Student
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Age")]
        public int Age { get; set; }
        [XmlElement("Spec")]
        public string Spec { get; set; }
        [XmlElement("BirthDay")]
        public string BirthDay { get; set; }
        [XmlElement("k")]
        public string k { get; set; }
        [XmlElement("group")]
        public string group { get; set; }
        [XmlElement("gender")]
        public string gender { get; set; }
        [XmlElement("sr")]
        public string sr { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("Zip")]
        public int Zip { get; set; }
        [XmlElement("street")]
        public string street { get; set; }
        [XmlElement("house")]
        public string house { get; set; }
        [XmlElement("apartament")]
        public string apartament { get; set; }

        public Student()
        {

        }

        public Student(string name, int age,string spec, string birthday,string k, string group,string gender, string sr,AddressWithCity add)
        {
            Name = name;
            Age = age;
            Spec = spec;
            BirthDay = birthday;
            this.k = k;
            this.group = group;
            this.gender = gender;
            this.sr = sr;
            AddressWithCity address = add;
            City = add._city.city;
            Zip = add._city.zip;
            street = add._address.street;
            house = add._address.house;
            apartament = add._address.apartament;
        }

    }
    public class AddressWithCity
    {
        public City _city;
        public Address _address;

        public AddressWithCity(City c , Address a)
        {
            _city = c;
            _address = a;
        }

    }
    public class City
    {
       public string city { get; set; }
       public int zip { get; set; }
    }
   public class Address
    {
        public string street { get; set; }
        public string house { get; set; }
        public string apartament { get; set; }
    }
}
