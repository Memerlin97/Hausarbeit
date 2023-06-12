using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Interaktionslogik für TimeAway.xaml
    /// </summary>
    public partial class TimeAway : Window
    {
        private ICollectionView collectionView;
        private WorkTimeContext Context = new WorkTimeContext();
        public string sharedUID { get; set; }
        public TimeAway()
        {
            InitializeComponent();

        }     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Zeiten.Load();
            collectionView = CollectionViewSource.GetDefaultView(Context.Zeiten.Local);
            DataContext = collectionView;
            DateStart.DisplayDate = DateTime.Now.Date;
            DateEnd.DisplayDate = DateTime.Now.Date.AddDays(1);
            reason.Focus();
            reason.Select(0, reason.Text.Length);
            MA_id.Text = sharedUID;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (DateStart.Text=="" || DateEnd.Text=="")
            {
                MessageBox.Show("Alle Start- und Enddatum müssen vor dem Spechern ausgfefüllt sein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else 
            {
                if (holiday.IsChecked == true)
                {
                    MessageBoxResult res = MessageBox.Show("Möchten Sie die Änderungen speichern?", "Speichern", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (res == MessageBoxResult.OK)
                    {
                        DateTime temp = Convert.ToDateTime(DateStart.Text);

                        while (temp <= Convert.ToDateTime(DateEnd.Text))
                        {
                            Zeiten new_Record = new Zeiten();

                            new_Record.Datum = temp;

                            new_Record.Urlaub = true;

                            Context.Zeiten.Add(new_Record);

                            Context.SaveChanges();

                            int z = GetTimeID();

                            int m = Convert.ToInt32(MA_id.Text);

                            SetMA_Zeiten(m, z);

                            temp = temp.AddDays(1);
                        }
                        MessageBox.Show("Urlaub gespeichert", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Speichervorgang abgebrochen.", "", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBoxResult res = MessageBox.Show("Möchten Sie die Änderungen speichern?", "Speichern", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (res == MessageBoxResult.OK)
                    {
                        DateTime temp = DateStart.DisplayDate;

                        while (temp <= DateEnd.DisplayDate)
                        {
                            Zeiten new_Record = new Zeiten();

                            new_Record.Datum = temp;

                            new_Record.sonstAbw = true;

                            new_Record.AbwGrund = reason.Text;

                            Context.Zeiten.Add(new_Record);

                            Context.SaveChanges();

                            int z = GetTimeID();

                            int m = Convert.ToInt32(MA_id.Text);

                            SetMA_Zeiten(m, z);

                            temp = temp.AddDays(1);
                        }
                        MessageBox.Show("Abwesenheit gespeichert", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Speichervorgang abgebrochen.", "", MessageBoxButton.OK);
                    }
                }
            }
            UrlaubCalc();
        }

        private int GetTimeID()
        {
            int returnval = 0;
            string db = "DB_WorkTime";
            string sqlcon = $"Data Source=. ; Initial Catalog= {db}; User ID=sa; Password=mssqlserver;" +
                "Connect Timeout=30; MultipleActiveResultSets=True";

            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            try
            {
                string sqlcom = $"SELECT MAX(id_Zeiten) FROM Zeiten";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    returnval = Convert.ToInt32(reader[0].ToString());
                }

            }
            catch (Exception)
            {
                throw;
            }
            conn.Close();

            return returnval;
        }

        private void SetMA_Zeiten(int Mitarbeiter, int Zeit)
        {

            string db = "DB_WorkTime";
            string sqlcon = $"Data Source=. ; Initial Catalog= {db}; User ID=sa; Password=mssqlserver;" +
                "Connect Timeout=30; MultipleActiveResultSets=True";

            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            try
            {
                string sqlcom = $"INSERT INTO Mitarbeiter_Zeiten (id_Mitarbeiter, id_Zeiten)" +
                    $"VALUES({Mitarbeiter},{Zeit})";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                sql.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            conn.Close();
        }

        private int GetUrlaub(string UID)
        {
            int uid = Convert.ToInt32(UID);
            int returnval = 0;
            string db = "DB_WorkTime";
            string sqlcon = $"Data Source=. ; Initial Catalog= {db}; User ID=sa; Password=mssqlserver;" +
                "Connect Timeout=30; MultipleActiveResultSets=True";

            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            try
            {
                string sqlcom = $"EXECUTE GetUrlaub {uid}";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    returnval= Convert.ToInt32(reader[0]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            conn.Close();

            return returnval;
        }

        private void UrlaubCalc()
        {
            int Urlaub = 0;

            string db = "DB_WorkTime";
            string sqlcon = $"Data Source=. ; Initial Catalog= {db}; User ID=sa; Password=mssqlserver;" +
                "Connect Timeout=30; MultipleActiveResultSets=True";

            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            try
            {
                string sqlcom = "Select * From Praeferenzen";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    Urlaub = Convert.ToInt32(reader[1]);

                }

            }
            catch (Exception)
            {
                throw;
            }


            Urlaub -= GetUrlaub(sharedUID);
            try
            {
                string sqlcom = $"UPDATE Mitarbeiter SET Resturlaub = {Urlaub} WHERE id_Mitarbeiter ={sharedUID}";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                sql.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            conn.Close();
        }
    }
}
