using System;
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

        private async void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            txbInfo.Text = "Načítám súbory..\n";
            var files = Directory.EnumerateFiles(@"C:\Users\StudentEN\Documents\words");
            IProgress<string> progress = new Progress<string>(message =>
            {
                txbInfo.Text += message;
            });
                string message = "";
            await Task.Run(() =>
            {
                foreach (var file in files)
                {
                    var result = Data.FreqAnalysis.FreqAnalysisFromFile(file);
                    message += result.Source + '\n';
                    foreach (var word in result.GetTopTen())
                    {
                        message += $"{word.Key} : {word.Value}\n";
                    }
             progress.Report(message);
               }
            });
            sw.Stop();
            progress.Report($"elapsed millisecounds: {sw.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null;
        }

        private void btnLoadParallel_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            txbInfo.Text = "Načítám súbory..\n";
            var files = Directory.EnumerateFiles(@"C:\Users\StudentEN\Documents\words");

            IProgress<string> progress = new Progress<string>(message =>
            {
                txbInfo.Text += message;
            });
            string message = "";
            Parallel.ForEach(files, file =>
            {
                var result = Data.FreqAnalysis.FreqAnalysisFromFile(file);
                message += result.Source + '\n';
                foreach (var word in result.GetTopTen())
                {
                    message += $"{word.Key} : {word.Value}\n";
                }
                progress.Report(message);
            });

            sw.Stop();
            progress.Report($"elapsed millisecounds: {sw.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null;
        }

        private async void  btnLoadParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            txbInfo.Text = "Načítám súbory..\n";
            var files = Directory.EnumerateFiles(@"C:\Users\StudentEN\Documents\words");

            IProgress<string> progress = new Progress<string>(message =>
            {
                txbInfo.Text += message;
            });
            string message = "";
            await Parallel.ForEachAsync(files,async( file,cancelationToken) =>
            {
                var result = Data.FreqAnalysis.FreqAnalysisFromFile(file);
                message += result.Source + '\n';
                foreach (var word in result.GetTopTen())
                {
                    message += $"{word.Key} : {word.Value}\n";
                }
                progress.Report(message);
            });

            sw.Stop();
            progress.Report($"elapsed millisecounds: {sw.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null;
        }
    }
}
