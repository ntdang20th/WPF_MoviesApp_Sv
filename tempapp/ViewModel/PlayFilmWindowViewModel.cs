using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace tempapp.ViewModel
{
    public class PlayFilmWindowViewModel:BaseViewModel
    {
        DispatcherTimer timer;
        int count = 0;
        public ICommand MouseEnterGridCommand { get; set; }
        public ICommand MouseLeaveGridCommand { get; set; }
        public ICommand MouseDownGridCommand { get; set; }


        public PlayFilmWindowViewModel()
        {
            MouseEnterGridCommand = new RelayCommand<tempapp.MyUserCOntrol.ControlVideo>((p) => { return true; }, (p) =>
            {
                p.Visibility = Visibility.Visible;
                StartDispatcherTimer(p);
            });

            MouseLeaveGridCommand = new RelayCommand<tempapp.MyUserCOntrol.ControlVideo>((p) => { return true; }, (p) =>
            {
                p.Visibility = Visibility.Hidden;
            });

            MouseDownGridCommand = new RelayCommand<tempapp.MyUserCOntrol.ControlVideo>((p) => { return true; }, (p) =>
            {
                p.Visibility = Visibility.Visible;
                StartDispatcherTimer(p);
            });
        }

        private tempapp.MyUserCOntrol.ControlVideo GetMediaElement(FrameworkElement window)
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(window); i++)
            {
                var child = VisualTreeHelper.GetChild(window, i);
                if (child is tempapp.MyUserCOntrol.ControlVideo)
                {
                    return child as tempapp.MyUserCOntrol.ControlVideo;
                }
            }
            return null;
        }

        void StartDispatcherTimer(tempapp.MyUserCOntrol.ControlVideo p)
        {
            // Create a timer that will update the counters and the time slider
            count = 0;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0);
            timer.Tick += (sender, e) => TimerTick(sender, e, p);
            
            timer.Start();
        }
        void TimerTick(object sender, EventArgs e, tempapp.MyUserCOntrol.ControlVideo p)
        {
            count++;
            if(count > 10000)
            {
                p.Visibility = Visibility.Hidden;
                timer.Stop();
            }
        }

    }
}
