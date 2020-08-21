using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OverflowInt_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Timers.Timer _timer = new System.Timers.Timer();
        int TimeBoxNumber = 0;
        bool turnOn = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IniciarLancamento();
        }

        private void IniciarLancamento()
        {
            IniciarTimer();
        }

        private void IniciarTimer()
        {
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeEvent);
            _timer.Interval = 1000;
            _timer.Enabled = true;
            _timer.Start();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            TimeBoxNumber++;
            int velocity = 10;
            Calculos calculos = new Calculos();
            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    lblTimer.Content = "Correção Nº " + TimeBoxNumber.ToString();
                    int y = calculos.CalculoTrajetoria(TimeBoxNumber, velocity);

                    if(y < 0)
                    {
                        lblTrajetoria.Foreground = Brushes.Red;
                        lblTrajetoria.Content = "Trajetória -> " + y.ToString();
                        if (turnOn)
                        {
                            turnOn = false;
                            lblTrajetoria.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            turnOn = true;
                            lblTrajetoria.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        lblTrajetoria.Foreground = Brushes.Green;
                        lblTrajetoria.Content = "Trajetória -> " + y.ToString();
                    }
                }));
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

        }
    }
}
