using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    internal class Program {
        static async Task Main(string[] args) {
            //var sw = Stopwatch.StartNew();
            //var prime1 = GetPrimeAt5000();
            //var prime2 = GetPrimeAt6000();
            //sw.Stop();
            //Console.WriteLine(prime1);
            //Console.WriteLine(prime2);
            //Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");

            var sw = Stopwatch.StartNew();
            var task1 = Task.Run(() => GetPrimeAt5000());
            var task2 = Task.Run(() => GetPrimeAt6000());
            var prime1 = await task1;
            var prime2 = await task2;
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");
        }
        // List 16-20

        // 5000番目の素数を求める
        private static int GetPrimeAt5000() {
            return GetPrimes().Skip(4999).First();
        }

        // 6000番目の素数を求める
        private static int GetPrimeAt6000() {
            return GetPrimes().Skip(5999).First();
        }

        // 上記2つのメソッドから呼び出される下位メソッド
        // あえて効率の悪いアルゴリズムで記述しています。
        static IEnumerable<int> GetPrimes() {
            for (int i = 2; i < int.MaxValue; i++) {
                bool isPrime = true;
                for (int j = 2; j < i; j++) {
                    if (i % j == 0) {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    yield return i;
            }
        }
    }
}
