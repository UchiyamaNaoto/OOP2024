﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //非同期メソッド
        private async void bt_16_6_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await Task.Run(() => DoSomething());
            //DoSomething();
            toolStripStatusLabel1.Text = "終了";
        }

        private void DoSomething() {
            Thread.Sleep(5000);
        }

        //非同期メソッド（イベントハンドラ）
        private async void bt_16_7_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoSomething2());
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        private long DoSomething2() {
            var sw = Stopwatch.StartNew();
            Thread.Sleep(5000);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private async void bt_16_8_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await DoSomethingAsync();
            toolStripStatusLabel1.Text = "終了";
        }

        //非同期メソッド
        private async Task DoSomethingAsync() {
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
        }

        private async void bt_16_9_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoSomethingAsync2();
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }
        
        //非同期メソッド
        private async Task<long> DoSomethingAsync2() {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
