using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            // 7.2.3 (Countの呼び出し)
            // 上のAddメソッドで、２つのオブジェクトを追加しているので、読み込んだ単語数+2が、Countの値になる。
            Console.WriteLine(abbrs.Count);
            Console.WriteLine();

            // 7.2.3 (Removeの呼び出し)
            if (abbrs.Remove("NPT"))
                Console.WriteLine(abbrs.Count);

            if (abbrs.Remove("NPT"))
                Console.WriteLine(abbrs.Count);
            else
                Console.WriteLine("削除できません");

            Console.WriteLine();
            // 7.2.4
            // IEnumerable<> を実装したので、LINQが使える。
            foreach (var abbr in abbrs.Where(x => x.Key.Length == 3)) {
                Console.WriteLine("{0}={1}", abbr.Key, abbr.Value);
            }
        }
    }
}
