using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using System.Timers;
using System.Threading;

namespace Timer
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        private int seconds = 0;
        private int minutes = 0;
        bool TimerOn = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void dtTicker(object sender, EventArgs e)
        {

            TimeLabel.Content = seconds.ToString();
            MinuteLabel.Content =  minutes.ToString();
            if(TimerOn == false)
            {
                seconds++;
                if (seconds >= 60)
                {
                    minutes++;
                    MinuteLabel.Content = minutes.ToString();
                    seconds = 0;
                }
                TimeLabel.Content = seconds.ToString();
            }
            if (TimerOn == true)
            {
                
                if (seconds <= 0)
                {
                    
                    minutes--;
                    TimeLabel.Content = seconds.ToString();
                    seconds = 60;
                }
                seconds--;
            }


        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            TimeLabel.Content = "0";
            MinuteLabel.Content = "0";
            seconds = 0;
            minutes = 0;
            TimerOn = false;
            
        }

        private void Alarm_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                   
                    
                    if (Convert.ToInt32(Ptimer.Text) > 0 && (Convert.ToInt32(Ptimer.Text) < 100000))
                {
                    minutes = Convert.ToInt32(Ptimer.Text);
                    TimerOn = true;
                    seconds = 0;
                }

                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid value.");
                }
                
                


            
            
                
        }

    }
}
