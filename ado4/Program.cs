using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ado4.mcs;
using System.Collections;
using System.Xml.Linq;
using System.Xml;

namespace ado4
{
    class Program
    {     
        private static mcs.mcs db = new mcs.mcs();
        static void Main(string[] args)
        {
            //Exm1();
            //Exm2();
            //Exm3();
            //Exm4();
            //Exm5();
            //Exm6();
            //Exm7();
            //Exm8();
            //Exm9();
            //Exm10();

            //LINQ  TO  XML
            //Exm14();
            //Exm15();
            //Exm16();
            //Exm17();
            Exm18();
            Console.ReadKey();
        }
        //where
        public static void Exm1()
        {
            var query = db.AccessTab.ToList();
            foreach (var item in query.TakeWhile(w=>w.strTabUrl!=null))
            {
                Console.WriteLine(item.strTabName);
            }
        }
        //синтаксис облегченного восприятия
        public static void Exm2()
        {
            var query = from e in db.newEquipment
                        select e;
            foreach (var item in query)
            {
                Console.WriteLine(item.CreateDate);
            }
        }
        //select many
        public static void Exm3()
        {
            List<string> fullName = new List<string> { "Evgeniy Gertsen", "Alex Dean", "Shaun Livingstone" };
            var query = fullName.SelectMany(name => name.Split());
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            var sQuery = from name in fullName
                         from n in name.Split()
                         select n;

            foreach (var item in sQuery)
            {
                Console.WriteLine(item);
            }
        }
        //Join, GroupJoin
        public static void Exm4()
        {
            var query = db.TablesModel.ToList();
            var jQuery = query.Join(db.TablesSNPrefix,
                                    m => m.intModelID,
                                    p => p.intModelID,
                                    (m, p) =>
                                    new { m.strName, p.strPrefix });
            foreach (var item in jQuery)
            {
                Console.WriteLine(item);
            }
        }
        public static void Exm5()
        {
            var query = db.TablesSNPrefix.GroupBy(g=> new { ModelID = g.intModelID })
                .Select(s=> new { s.Key.ModelID, ModelCount = s.Count() })
                .Where(w=>w.ModelCount>3);

            //Console.WriteLine(query.GetType().Name);
            foreach (var item in query)
            {
                Console.WriteLine(item.ModelID+" "+item.ModelCount);
            }
        }
        public static void Exm6()
        {
            var q = from au in db.AccessUser
                    join at in db.AccessTab on au.intAccessID equals at.intTabID
                    into obj
                    select obj;
        }
        //order by, then by, order by descending
        public static void Exm7()
        {
            var query = db.newEquipment
                .OrderBy(o => o.CreateDate)
                .ThenBy(t=>t.bitMeter).AsQueryable();


            foreach (var item in query)
            {
                Console.WriteLine(item.CreateDate+" " + item.bitMeter);
            }
        }
        public static void Exm8()
        {
            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };

            //concat
            IEnumerable<int> concatSeq = seq1.Concat(seq2);
            foreach (var item in concatSeq)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //union
            IEnumerable<int> union = seq1.Union(seq2);

            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            //intersect
            IEnumerable<int> inter = seq1.Intersect(seq2);

            foreach (var item in inter)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");

            IEnumerable<int> exept = seq1.Except(seq2);

            foreach (var item in exept)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");

        }
        //ofType,Cast,AsEnumerable,AsQuerable
        public static void Exm9()
        {
            ArrayList cll = new ArrayList();
            cll.AddRange(new int[] { 3, 4, 5 });
            IEnumerable<int> seq1 = cll.Cast<int>();// кастит только в заданный тип
            IEnumerable<int> seq2 = cll.OfType<int>();//выбирать только  заданный тип

        }
        //First, FirstOfDefault
        public static void Exm10()
        {
            newEquipment query = db.newEquipment.First();
            Console.WriteLine(query);
            newEquipment query2 = db.newEquipment.FirstOrDefault(f=>f.intEquipmentID==2352452);

            Console.WriteLine(query);
        }
        //ElementAt, ElementAtOrDefault
        public static void Exm11()
        {
            var q = db.newEquipment.ToList().ElementAtOrDefault(10);
        }
        //Count,LongCount,Min,Max,Sum,Average
        public static void Exm12()
        {
            int count = db.AccessUser.Count(c => c.intTabID == 1);
            int? d = db.AccessUser.Sum(s => s.intUserId);
        }
        public static void Exm13()
        {
            bool isTrue = new int[] { 2, 3, 4 }.Contains(3);

            IEnumerable<AccessUser> somesequence = db.AccessUser.Where(w => w.intAccessID == 1);
            var q6 = db.AccessUser.SequenceEqual(somesequence);
        }


        //linq to xml
        public static void Exm14()
        {
            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.CreateElement("customers");
            XmlAttribute atr = doc.CreateAttribute("id");

            atr.InnerText = "2";
            root.Attributes.Append(atr);

            XmlElement fname = doc.CreateElement("fName");
            fname.InnerText = "Chen";
            root.AppendChild(fname);
            doc.AppendChild(root);
            doc.Save("customer.xml");
        }
        public static void Exm15()
        {

            XElement el = new XElement("customers", new XAttribute("id","2"),new XElement("LastName","Ir"),new XElement("FirstName","Kin Chen"));
            el.Save("xdoc.xml");

            XDocument doc = XDocument.Load("https://www.habrahabr.ru/rss/main");
            //Console.WriteLine(doc);
            string news = @"<item><title><![CDATA[Google I/O 2018: руководство пользователя]]></title></item>";

            XElement e = XElement.Parse(news);
            Console.WriteLine(e);
            
        }

        public static void Exm16()
        {
            XElement query = new XElement("tabs",
                                         from a in db.AccessTab.ToList()
                                         select
                                         new XElement("AccessTab",
                                         new XElement("intTab", a.intTabID),
                                         new XElement("groupname",a.strTabGroupName)));
            Console.WriteLine(query);
        }


        public static XDocument GetNews()
        {
            return XDocument.Load("https://www.habrahabr.ru/rss/interesting");
        }
        public static void Exm17()
        {
            var query = GetNews().Element("rss").Element("channel").Elements().Where(w=>w.Name=="item").ToList();
            Console.OutputEncoding = Encoding.Unicode;
            foreach (var item in query)
            {
                Console.WriteLine(item.Element("title").Value);
            }
        }

        //parent,ancestors,IsBefore,IsAfter,PreviousNode,
        public static void Exm18()
        {
            var query = GetNews().Element("rss").Element("channel").Elements();
            var test = query.First().IsBefore(query.Last());
        }

        public static void EditElement()
        {
            var query = GetNews().Element("rss").Element("channel").Elements().Where(w => w.Name == "image").ToList();           
            XElement el = query.FirstOrDefault(f => f.Name == "title");
            el.SetValue(el.Value + "***");
            el.Save("el_edit.xml");
        }


    }
}
