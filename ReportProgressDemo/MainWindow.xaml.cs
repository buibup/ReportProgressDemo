using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ReportProgressDemo
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<int>(value =>
            {
                _progressBar.Value = value;
                _textBlock.Text = $"{value}%";
            });

            await Task.Run( () => LoopThroughNumbers(100, progress));

            _textBlock.Text = "Completed";
        }

        void LoopThroughNumbers(int count, IProgress<int> progress)
        {
            for(int x = 0; x < count; x++)
            {
                Thread.Sleep(100);
                var percentComplete = (x * 100) / count;
                progress.Report(percentComplete);
            }
        }
    }
}
