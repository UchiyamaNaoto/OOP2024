﻿using SampleApp;
using System;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(223, "大福", 250);
            Product dorayaki = new Product(98, "どら焼き", 210);

            int price = karinto.Price;  //税抜きの金額
            int taxIncluded = karinto.GetPriceIncludingTax();//税込みの金額

            int daifukuPrice = daifuku.Price;
            int daifukuTaxIncluded = daifuku.GetPriceIncludingTax();

            int dorayakiTax = dorayaki.GetTax();


            Console.WriteLine(karinto.Name + "の税込金額" 
                                        + taxIncluded + "円【税抜き" + price + "円】");

            Console.WriteLine(daifuku.Name + "の税込金額"
                                        + daifukuTaxIncluded + "円【税抜き" + daifukuPrice + "円】");

            Console.WriteLine($"{dorayakiTax}円");


        }
    }
}
