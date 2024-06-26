using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("生年月日を入力");
            Console.Write("年：");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int day = int.Parse(Console.ReadLine());

            var birthday = new DateTime(year, month, day);

            //あなたは平成〇〇年〇月〇日〇曜日に生まれました
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日dddd", culture);

            Console.WriteLine("あなたは" + str + "に生まれました");


            //あなたは生まれてから今日で〇〇〇〇日目です
            var today = DateTime.Today;

            TimeSpan diff = today - birthday;
            Console.WriteLine("あなたは生まれてから今日で{0}日目です", diff.Days + 1);


        }
    }
}
