﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NETlab1
{
    public class PersonalInfo
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string middle { get; set; }
        public DateTime birthday { get; }
        public string education { get; set; }
        public int personalID { get; set; }
        public PersonalInfo(string surname, string name, string middle, DateTime birthday, string education, int personalID)
        {
            this.surname = surname;
            this.name = name;
            this.middle = middle;
            this.birthday = birthday;
            this.education = education;
            this.personalID = personalID;
        }
        public override string ToString()
        {
            return string.Format($"{personalID}. {surname} {name} {middle} - B-day:{birthday.ToString("dd/MM/yyyy")}, education: {education}");
        }
        public void XMLWritePerson(XmlWriter writer)
        {
            writer.WriteStartElement("person");
            writer.WriteElementString("surname", surname);
            writer.WriteElementString("name", name);
            writer.WriteElementString("middle", middle);
            writer.WriteElementString("birthday", birthday.ToString("dd/MM/yyyy"));
            writer.WriteElementString("education", education);
            writer.WriteElementString("personalID", personalID.ToString());
            writer.WriteEndElement();
        }
    }
  

    /*public class DataEqualityComparer : IEqualityComparer<PersonalInfo>
    {
        public bool Equals(PersonalInfo x, PersonalInfo y)
        {
            bool Result = false;
            if (x.personalID == y.personalID)
                Result = true;
            return Result;
        }
        public int GetHashCode(PersonalInfo obj)
        {
            return obj.personalID;
        }
    }*/
}
