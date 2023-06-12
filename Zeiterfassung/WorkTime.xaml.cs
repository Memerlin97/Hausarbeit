using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using System.Data.Entity;
using System.ComponentModel;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Zeiterfassung
{
    /// <summary>
    /// Interaktionslogik für WorkTime.xaml
    /// </summary>
    public partial class WorkTime : Window
    {
        private int pause = 0;
        private ICollectionView collectionView;
        private WorkTimeContext Context = new WorkTimeContext();
        public string sharedUID { get; set; }
        public WorkTime()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Zeiten.Load();
            collectionView = CollectionViewSource.GetDefaultView(Context.Zeiten.Local);
            DataContext = collectionView;
            Start.Text = DateTime.Now.ToShortTimeString();
            Date.DisplayDate = DateTime.Now.Date;
            MA_id.Text = sharedUID;
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (Date.Text == "" || Start.Text == "" || End.Text == "")
            {
                MessageBox.Show("Alle Felder müssen vor dem Spechern ausgfefüllt sein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DateTime S = DateTime.Parse(Start.Text);
                DateTime E = DateTime.Parse(End.Text);
                if (S > E)
                {
                    MessageBox.Show("Geht-Zeit muss größer als Komm-Zeit sein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
                else
                {
                    MessageBoxResult res = MessageBox.Show("Möchten Sie die Änderungen speichern?", "Speichern", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (res == MessageBoxResult.OK)
                    {
                        Zeiten new_Record = new Zeiten();

                        new_Record.Datum = Convert.ToDateTime(Date.Text);

                        new_Record.BeginnAZ = Start.Text;

                        new_Record.EndeAZ = End.Text;

                        new_Record.Urlaub = false;

                        new_Record.sonstAbw = false;

                        new_Record.NettoAZ = BerechneNetto(Start.Text, End.Text);

                        new_Record.Pause = pause;

                        Context.Zeiten.Add(new_Record);

                        Context.SaveChanges();

                        int z = GetTimeID();

                        int m = Convert.ToInt32(MA_id.Text);

                        SetMA_Zeiten(m, z);
                    }
                    else
                    {
                        MessageBox.Show("Speichervorgang abgebrochen.", "", MessageBoxButton.OK);
                    }
                }
            }
            Close();
        }

        private double BerechneNetto(string Start, string Ende )
        {
            var min = 0;
            int max = 0;

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
                    min = Convert.ToInt32(reader[2]); 
                    
                }
               
            }
            catch (Exception)
            {                
                throw;
            }
            try
            {
                string sqlcom = "Select * From Praeferenzen";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    max = Convert.ToInt32(reader[3]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            conn.Close();

            
        

        double ReturnVal = 0;

            DateTime S = Convert.ToDateTime(Start);
            DateTime E = Convert.ToDateTime(Ende);
            TimeSpan timeSpan = E - S;
            
            double StundenGes = timeSpan.Hours;
            double MinutenGes = Convert.ToDouble(timeSpan.Minutes) / 60;
            //6-9h --> 30 Min.
            //>9h --> 45min
            ReturnVal = StundenGes + MinutenGes;
            if (ReturnVal <0)
            {
                ReturnVal += 24;
            }
            if (ReturnVal >= 6 && ReturnVal <=9)
            {
                ReturnVal -= Convert.ToDouble(min) / 60;
                pause = min;
            }
            else if (ReturnVal > 9)
            {
                ReturnVal -= Convert.ToDouble(max) / 60;
                pause = max;
            }
            return Math.Round(ReturnVal,2);
        }

        private void Start_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Start.Text.Length == 4)
            {
                string s1 = Start.Text.Substring(0, 2);
                string s2 = Start.Text.Substring(2, 2);

                Start.Text = $"{s1}:{s2}";    
            }
        }

        private void End_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (End.Text.Length == 4)
            {                
                string s1 = End.Text.Substring(0, 2);
                string s2 = End.Text.Substring(2, 2);

                End.Text = $"{s1}:{s2}";
            }
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
                    returnval =Convert.ToInt32(reader[0].ToString());
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
    }
}
