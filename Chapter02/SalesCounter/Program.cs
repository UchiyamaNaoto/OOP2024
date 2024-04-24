﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    internal class Program {
        static void Main(string[] args) {

            var sales = new SalesCounter(@"data\sales.csv");
            var amountPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string,int> obj in amountPerStore) {
                Console.WriteLine("{0} {1}",obj.Key,obj.Value);
            }
        }
    }
}
