using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NETlab1
{
    class Program
    {
        static List<PersonalInfo> personalData = new List<PersonalInfo>()
        {
            new PersonalInfo("Shynkarenko","Yevhen","Anatoliyovych",   DateTime.Parse("1985-12-30"), "bachelor", 1),
            new PersonalInfo("Brovarenko", "Adam", "Ivanovych",        DateTime.Parse("1963-03-28"), "bachelor", 2),
            new PersonalInfo("Kravchenko", "Lyubov", "Valentynivna",   DateTime.Parse("1981-12-06"), "Ph.D",     3),
            new PersonalInfo("Mel'nychenko", "Olena", "Andriyovych",   DateTime.Parse("1985-10-14"), "master",   4),
            new PersonalInfo("Pavlyuk", "Tamara", "Serhiyivna",        DateTime.Parse("2000-01-25"), "bachelor", 5),
            new PersonalInfo("Dmytrenko", "Danylo", "Mykolayovych",    DateTime.Parse("1963-05-02"), "master",   6),
            new PersonalInfo("Ponomarenko", "Andriy", "Yosypovych",    DateTime.Parse("1991-01-20"), "master",   7),
            new PersonalInfo("Shevchenko", "Vsevolod", "Oleksiyovych", DateTime.Parse("1987-05-27"), "bachelor", 8),
            new PersonalInfo("Ponomarchuk", "Valentyna", "Romanivna",  DateTime.Parse("1969-08-17"), "Ph.D",     9)
        };
        static List<WorkerInfo> workerData = new List<WorkerInfo>()
        {
            new WorkerInfo(1, "6011780282043117", "narrow", DateTime.Parse("2020-08-11")),
            new WorkerInfo(2, "4916686643712357", "broad",  DateTime.Parse("2020-02-26")),
            new WorkerInfo(3, "5379940837068906", "broad",  DateTime.Parse("2021-04-12")),
            new WorkerInfo(4, "5128346448421811", "narrow", DateTime.Parse("2020-10-30")),
            new WorkerInfo(5, "5476029642508538", "broad",  DateTime.Parse("2021-10-19")),
            new WorkerInfo(6, "4856489104225234", "broad",  DateTime.Parse("2021-03-22")),
            new WorkerInfo(7, "3479960571264937", "narrow", DateTime.Parse("2021-08-21")),
            new WorkerInfo(8, "4916826615417733", "narrow", DateTime.Parse("2020-07-05")),
            new WorkerInfo(9, "6011937586586205", "broad",  DateTime.Parse("2021-11-03"))
        };
        static List<MonthlySalary> salaries = new List<MonthlySalary>()
        {
            new MonthlySalary("6011780282043117", DateTime.Parse("2021-09-01"), 16000),
            new MonthlySalary("6011780282043117", DateTime.Parse("2021-10-01"), 15500),
            new MonthlySalary("6011780282043117", DateTime.Parse("2021-11-01"), 15300),

            new MonthlySalary("4916686643712357", DateTime.Parse("2021-09-01"), 18000),
            new MonthlySalary("4916686643712357", DateTime.Parse("2021-10-01"), 18000),
            new MonthlySalary("4916686643712357", DateTime.Parse("2021-11-01"), 17800),

            new MonthlySalary("5379940837068906", DateTime.Parse("2021-09-01"), 18500),
            new MonthlySalary("5379940837068906", DateTime.Parse("2021-10-01"), 18500),
            new MonthlySalary("5379940837068906", DateTime.Parse("2021-11-01"), 18500),

            new MonthlySalary("5128346448421811", DateTime.Parse("2021-09-01"), 16200),
            new MonthlySalary("5128346448421811", DateTime.Parse("2021-10-01"), 16000),
            new MonthlySalary("5128346448421811", DateTime.Parse("2021-11-01"), 16000),

            new MonthlySalary("5476029642508538", DateTime.Parse("2021-11-01"), 17500),

            new MonthlySalary("4856489104225234", DateTime.Parse("2021-09-01"), 17800),
            new MonthlySalary("4856489104225234", DateTime.Parse("2021-10-01"), 17800),
            new MonthlySalary("4856489104225234", DateTime.Parse("2021-11-01"), 17800),

            new MonthlySalary("3479960571264937", DateTime.Parse("2021-10-01"), 16000),
            new MonthlySalary("3479960571264937", DateTime.Parse("2021-11-01"), 16000),

            new MonthlySalary("4916826615417733", DateTime.Parse("2021-09-01"), 16500),
            new MonthlySalary("4916826615417733", DateTime.Parse("2021-10-01"), 16500),
            new MonthlySalary("4916826615417733", DateTime.Parse("2021-11-01"), 16200),
        };
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("personalData.xml", settings))
            {
                writer.WriteStartElement("personalData");
                foreach (var person in personalData)
                {
                    person.XMLWritePerson(writer);
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("workerData.xml", settings))
            {
                writer.WriteStartElement("workerData");
                foreach (var person in workerData)
                {
                    person.XMLWriteWorker(writer);
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("monthlySalary.xml", settings))
            {
                writer.WriteStartElement("monthlySalaries");
                foreach (var person in salaries)
                {
                    person.XMLWriteSalary(writer);
                }
                writer.WriteEndElement();
            }

            XDocument personalDataDoc = XDocument.Load("personalData.xml");
            XDocument workerDataDoc = XDocument.Load("workerData.xml");
            XDocument salariesDoc = XDocument.Load("monthlySalary.xml");

            XmlDocument personalDataDocX = new XmlDocument();
            personalDataDocX.Load("personalData.xml");

            Console.WriteLine("1. Outputing file with XML\n");
            foreach (XmlNode node in personalDataDocX.DocumentElement)
            {
                string surname = node["surname"].InnerText;
                string name = node["name"].InnerText;
                string middle = node["middle"].InnerText;
                string birthday = node["birthday"].InnerText;
                string education = node["education"].InnerText;
                int personalID = Int32.Parse(node["personalID"].InnerText);
                Console.WriteLine($"{personalID}. {surname} {name} {middle}\t- B-day: {birthday}, education: {education}");
            }

            Console.WriteLine("\n2. Outputing file with LINQ to XML\n");
            foreach (XElement worker in workerDataDoc.Element("workerData").Elements("worker"))
            {
                XElement personalID = worker.Element("personalID");
                XElement specialization = worker.Element("specialization");
                XElement hiredDate = worker.Element("hiredDate");
                XElement taxpayerCardID = worker.Element("taxpayerCardID");
                if (personalID != null && specialization != null && hiredDate != null && taxpayerCardID != null)
                    Console.WriteLine("{0}. specialization: {1}, hired: {2} - taxpayer Card ID {3}", personalID.Value, specialization.Value, hiredDate.Value, taxpayerCardID.Value);
            }

            Console.WriteLine("\n3. Sorting\n");
            var sorted = salariesDoc.Descendants("monthlySalary").OrderByDescending(s => s.Element("salary").Value);
            foreach (var salary in sorted)
                Console.WriteLine($"Date: {salary.Element("monthYear").Value} - {salary.Element("salary").Value} UAH Tax Payers Card ID:{salary.Element("taxpayerCardID").Value}"); 

            Console.WriteLine("\n4. Conditions\n");
            var condition = workerDataDoc.Descendants("worker").Where(w => DateTime.Parse(w.Element("hiredDate").Value) < DateTime.Parse("2021-01-01"));
            foreach (var worker in condition)
                Console.WriteLine($"{worker.Element("personalID").Value}. specialization: {worker.Element("specialization").Value}, hired: {worker.Element("hiredDate").Value} - taxpayer Card ID {worker.Element("taxpayerCardID").Value}");

            Console.WriteLine("\n5. JOIN\n");
            var join = from persone in personalDataDoc.Descendants("person")
                       join workers in workerDataDoc.Descendants("worker")
                       on persone.Element("personalID").Value equals workers.Element("personalID").Value
                       select new { personalID = persone.Element("personalID").Value, surname = persone.Element("surname").Value, name = persone.Element("name").Value, middle = persone.Element("middle").Value, taxpayerCardID = workers.Element("taxpayerCardID").Value };
            foreach(var joined in join)
                Console.WriteLine($"{joined.personalID}. {joined.surname} {joined.name} {joined.middle} - {joined.taxpayerCardID}");

            Console.WriteLine("\n6. JOIN\n");
            var join2 = from workers in workerDataDoc.Descendants("worker")
                       join salaries in salariesDoc.Descendants("monthlySalary")
                       on workers.Element("taxpayerCardID").Value equals salaries.Element("taxpayerCardID").Value
                       select new { personalID = workers.Element("personalID").Value, hired = workers.Element("hiredDate").Value, specialization = workers.Element("specialization").Value, salary = salaries.Element("salary").Value };
            foreach (var leftJoined in join2)
                Console.WriteLine($"{leftJoined.personalID}. Hired: {leftJoined.hired}, spec: {leftJoined.specialization}\t- {leftJoined.salary}");

            Console.WriteLine("\n7. Grouping\n");
            var groups = personalDataDoc.Descendants("person").GroupBy(p => p.Element("education").Value);
            foreach (var group in groups)
            {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var person in group)
                    Console.WriteLine($"{person.Element("personalID").Value}. {person.Element("surname").Value} {person.Element("name").Value} {person.Element("middle").Value}\t- education: {person.Element("education").Value}");
            }

            Console.WriteLine("\n8. Grouping with Count\n");
            var countGroup = workerDataDoc.Descendants("worker").GroupBy(w=>w.Element("specialization").Value);
            foreach (var group in countGroup)
            {
                Console.Write($"Group: {group.Key} - ");
                Console.WriteLine(group.Count());
            }

            Console.WriteLine("\n9. Grouping with Avarage\n");
            var avarageGroup = from worker in workerDataDoc.Descendants("worker")
                               join salary in salariesDoc.Descendants("monthlySalary")
                               on worker.Element("taxpayerCardID").Value equals salary.Element("taxpayerCardID").Value
                               group new { spec = worker.Element("specialization").Value, money = Int32.Parse(salary.Element("salary").Value) } by worker.Element("specialization").Value into grouped
                               select new { specialization = grouped.Key, moneyAverage = grouped.Average(x => x.money) };
            foreach (var row in avarageGroup)
                Console.WriteLine($"{row.specialization} - {row.moneyAverage} UAH");

            Console.WriteLine("\n10. Deleting a Node\n");
            personalDataDoc.Descendants("person").Where(p=>p.Element("personalID").Value == "5").Remove();
            Console.WriteLine("Deleted");

            Console.WriteLine("\n11. Adding an element\n");
            personalDataDoc.Root.Add(new XElement("person", 
                new XElement("surname", "Brand"), 
                new XElement("name", "New"), 
                new XElement("middle", "Person"),
                new XElement("birthday", "10.10.1990"), 
                new XElement("education", "bachelor"), 
                new XElement("personalID", "10")));
            Console.WriteLine("Added");

            Console.WriteLine("\n12. Changing existing one\n");
            foreach(var element in personalDataDoc.Descendants("person"))
                if (element.Element("personalID").Value == "1")
                    element.SetAttributeValue("status", "boss");
                else
                    element.SetAttributeValue("status", "worker");
            Console.WriteLine("Changed");

            personalDataDoc.Save("personalDataUpdated.xml");

            Console.ReadKey(); 
        }
    }
}
