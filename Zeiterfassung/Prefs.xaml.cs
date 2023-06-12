using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace Zeiterfassung
{
    /// <summary>
    /// Interaktionslogik für Prefs.xaml
    /// </summary>
    public partial class Prefs : Window
    {
        private ICollectionView collectionView;
        private WorkTimeContext Context = new WorkTimeContext();
        public Prefs()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Praeferenzen.Load();
            collectionView = CollectionViewSource.GetDefaultView(Context.Praeferenzen.Local);
            DataContext = collectionView;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Möchten Sie die Änderungen speichern?","Speichern",MessageBoxButton.OKCancel,MessageBoxImage.Question);
            if (res == MessageBoxResult.OK)
            {
                Context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Speichervorgang abgebrochen.","",MessageBoxButton.OK);
            }
        }
    }
}
