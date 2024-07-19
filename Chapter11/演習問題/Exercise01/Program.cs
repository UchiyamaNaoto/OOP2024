using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Value,
                                 Teammembers = x.Element("teammembers").Value
                             });
            foreach (var sport in sports) {
                Console.WriteLine("{0} {1}", sport.Name, sport.Teammembers);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                            .Select(x => new {
                                Name = x.Element("name").Attribute("kanji").Value,
                                Firstplayed = x.Element("firstplayed").Value,
                            }).OrderBy(x => x.Firstplayed);

            foreach (var sport in sports) {
                Console.WriteLine("{0}({1})", sport.Name, sport.Firstplayed);
            }

        }

        private static void Exercise1_3(string file) {
#if false 
            //解答例①
            var xdoc = XDocument.Load(file);
            var sport = xdoc.Root.Elements()
                            .OrderByDescending(x => x.Element("teammembers").Value)
                            .First();

            Console.WriteLine($"{sport.Element("name").Value}");
#else 
            //解答例②
            var xdoc = XDocument.Load(file);
            var sport = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Value,
                                 Teammembers = x.Element("teammembers").Value
                             })
                             .OrderByDescending(x => int.Parse(x.Teammembers))
                             .First();
            Console.WriteLine("{0}", sport.Name);
#endif

        }

        private static void Exercise1_4(string file, string newfile) {
            List<XElement> xElements = new List<XElement>();

            var xdoc = XDocument.Load(file);
            string name, kanji, teammembers, firstplayed;
            int nextFlag;
            while (true) {
                //入力処理
                Console.Write("名称：");   name = Console.ReadLine();
                Console.Write("漢字：");   kanji = Console.ReadLine();
                Console.Write("人数：");   teammembers = Console.ReadLine();
                Console.Write("起源：");   firstplayed = Console.ReadLine();
                //1件分の要素作成
                var element = new XElement("ballsport",
                     new XElement("name", name, new XAttribute("kanji", kanji)),
                     new XElement("teammembers", teammembers),
                     new XElement("firstplayed", firstplayed)
                );
                xElements.Add(element); //リストへ要素を追加

                Console.WriteLine();    //改行
                Console.Write("追加【1】保存【２】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if (nextFlag == 2)　break;  //無限ループを抜ける
                Console.WriteLine();    //改行
            }
            xdoc.Root.Add(xElements);
            xdoc.Save(newfile); //保存
        }
    }
}
