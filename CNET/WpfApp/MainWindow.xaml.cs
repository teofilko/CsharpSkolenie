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

        private void btnTaskFirst_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            string url = "https://seznam.cz";
            string url1 = "https://seznamzpravy.cz";
            string url2 = "https://www.ictpro.cz";

            var t1=Task.Run(() => WebLoad.LoadUrl(url));
            var t2=Task.Run(() => WebLoad.LoadUrl(url1));
            var t3=Task.Run(() => WebLoad.LoadUrl(url2));

            Task.WaitAny(t1, t2, t3);
            txbInfo.Text += "\nDobehol prvý task";

            sw.Stop();
            txbInfo.Text += $"\nElapsed millisecons: {sw.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;

        }

        private void btnTaskAll_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            string url = "https://seznam.cz";
            string url1 = "https://seznamzpravy.cz";
            string url2 = "https://www.ictpro.cz";

            var t1 = Task.Run(() => WebLoad.LoadUrl(url));
            var t2 = Task.Run(() => WebLoad.LoadUrl(url1));
            var t3 = Task.Run(() => WebLoad.LoadUrl(url2));

            Task.WaitAll(t1, t2, t3);
            txbInfo.Text += "\nDobehly všetky tasky";

            sw.Stop();
            txbInfo.Text += $"\nElapsed millisecons: {sw.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }

        private async void btnTaskFirst_Copy_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            string url = "https://seznamO.cz";
            string url1 = "https://seznamzpravy.cz";
            string url2 = "https://www.ictpro.cz";

            var t1 = Task.Run(() => WebLoad.LoadUrl(url));
            var t2 = Task.Run(() => WebLoad.LoadUrl(url1));
            var t3 = Task.Run(() => WebLoad.LoadUrl(url2));

            var firstDone = await Task.WhenAny(t1, t2, t3);
            txbInfo.Text += $"\nDobehol prvý task, web lenght {firstDone.Result}";

            sw.Stop();
            txbInfo.Text += $"\nElapsed millisecons: {sw.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }

        private async void btnTaskAll_Copy_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            string url = "https://seznamO.cz";
            string url1 = "https://seznamzpravy.cz";
            string url2 = "https://www.ictpro.cz";

            var t1 = Task.Run(() => WebLoad.LoadUrl(url));
            var t2 = Task.Run(() => WebLoad.LoadUrl(url1));
            var t3 = Task.Run(() => WebLoad.LoadUrl(url2));

            var allDone = await Task.WhenAll(t1, t2, t3);
            txbInfo.Text += $"\nWeby jsou dlohé {string.Join(", ", allDone)}";

            sw.Stop();
            txbInfo.Text += $"\nElapsed millisecons: {sw.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }
    }
}
