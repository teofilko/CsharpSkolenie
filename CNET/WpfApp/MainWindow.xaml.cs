﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            txbInfo.Text = "Načítám súbory..\n";
            var files = Directory.EnumerateFiles(@"C:\Users\StudentEN\Documents\words");
            foreach (var file in files)
            {
                var result = Data.FreqAnalysis.FreqAnalysisFromFile(file);
                txbInfo.Text += result.Source + '\n';
                foreach(var word in result.GetTopTen())
                {
                    txbInfo.Text += $"{word.Key} : {word.Value}\n";
                }
            }
            sw.Stop();
            txbInfo.Text += $"elapsed millisecounds: {sw.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }
    }
}