using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
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
using System.Windows.Shapes;

namespace Zeiterfassung
{
    /// <summary>
    /// Interaktionslogik für DataView.xaml
    /// </summary>
    public partial class DataView : Window
    {

        private ICollectionView collectionView;
        private WorkTimeContext Context = new WorkTimeContext();
        public string sharedUID { get; set; }
        public DataView()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MA_id.Text = sharedUID;

            if (GetTimes(sharedUID)==true)
            {
                Context.tmp.Load();
                collectionView = CollectionViewSource.GetDefaultView(Context.tmp.Local);
                DataContext = collectionView;
            }

            Resturlaub.Content=GetResturlaub(sharedUID);

        }

        private int GetResturlaub(string UID)
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
                string sqlcom = $"SELECT Resturlaub FROM Mitarbeiter WHERE id_Mitarbeiter = {uid}";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    returnval = Convert.ToInt32(reader[0]);
                }
            }
            catch (Exception)
            {
                returnval = 0;
            }
            conn.Close();

            return returnval;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            DelTMP();
            Close();
        }

        private bool GetTimes(string UID)
        {
            int uid = Convert.ToInt32(UID);
            bool returnval = false;
            string db = "DB_WorkTime";
            string sqlcon = $"Data Source=. ; Initial Catalog= {db}; User ID=sa; Password=mssqlserver;" +
                "Connect Timeout=30; MultipleActiveResultSets=True";

            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            try
            {
                string sqldel = $"EXECUTE DelTMP";
                SqlCommand del = new SqlCommand(sqldel, conn);
                SqlDataReader reader = del.ExecuteReader();

                string sqlcom = $"EXECUTE GetTimes {uid}";
                SqlCommand sql = new SqlCommand(sqlcom, conn);
                SqlDataReader reader2 = sql.ExecuteReader();

                returnval= true;
            }
            catch (Exception)
            {
                returnval = false;
                throw;
            }
            conn.Close();

            return returnval;
        }

        private bool DelTMP()
        {
            bool returnval = false;
            string db = "DB_WorkTime";
            string sqlcon = $"Data Source=. ; Initial Catalog= {db}; User ID=sa; Password=mssqlserver;" +
                "Connect Timeout=30";

            SqlConnection conn = new SqlConnection(sqlcon);
            conn.Open();
            try
            {
                string sqlcom = $"EXECUTE DelTMP";
                returnval = true;
            }
            catch (Exception)
            {

                throw;
            }
            conn.Close();

            return returnval;
        }



    }
}
