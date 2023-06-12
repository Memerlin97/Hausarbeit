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

using System.Data.Entity;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Threading;

namespace Zeiterfassung
{    
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {    

        private ICollectionView collectionView;
        private WorkTimeContext Context = new WorkTimeContext();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Praeferenzen.Load();
            collectionView = CollectionViewSource.GetDefaultView(Context.Praeferenzen.Local);
            DataContext = collectionView;
            DispatcherTimer();
        }

        public void DispatcherTimer()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (MA_id.Text.Length == 0)
            {
                view.IsEnabled = false;
                enter_away.IsEnabled = false;
                enter_work.IsEnabled = false;
            }
            else
            {
                view.IsEnabled = true;
                enter_away.IsEnabled = true;
                enter_work.IsEnabled = true;
            }
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            DataView dv = new DataView();
            dv.sharedUID = MA_id.Text; 
            dv.Show();

        }

        private void enter_work_Click(object sender, RoutedEventArgs e)
        {
            WorkTime wt = new WorkTime();
            wt.sharedUID = MA_id.Text;
            wt.Show();
        }

        private void enter_away_Click(object sender, RoutedEventArgs e)
        {
            TimeAway ta = new TimeAway();
            ta.sharedUID = MA_id.Text;
            ta.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Prefs prefs = new Prefs();
            prefs.Show();
        }


    }
}
