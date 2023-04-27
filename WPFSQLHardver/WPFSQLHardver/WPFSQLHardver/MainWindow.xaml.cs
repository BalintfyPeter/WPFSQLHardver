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
using System.IO;



namespace WPFSQLHardver
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string kapcsolatLeiro = "datasource=127.0.0.1;port=3306;usernme=root;password=;database=Hardver";
        List<Termek> termekek = new List<Termek>();
        MySqlConnection SQLKapcsolat;
        public MainWindow()
        {


            //Dtabase stuff
            InitializeComponent();

            AdatbzisMegnyitas();
            KategoriakBeltoltese();
            GyartokBetoltese();
            TermekekBetolteseListaba();
            AdatbzisLezarasa();


            private void AdatbazisMegnyitas()
            {
                try
                {
                    SQLKapcsolat = new MySqlConnection(kapcsolatLeiro);
                    SQLKapcsolat.Open();
                }

                catch (Exception)
                {
                    MessageBox.Show("Nem tud kapcsolódni az datbázishoz!");
                    this.Close();
                }
            };

            private void AdtbzisLezarasa()
            {
                SQLKapcsolat.Close();
                SQLKapcsolat.Dispose();
            };


            private void BtnMentes_Click(object sender, RoutedEventArgs e)
            {
                StreamWriter sw = new StreamWriter("fajl.csv");
                foreach(var item in termekek)
                {
                    sw.WriteLine(item.ToCSVString());
                }
                sw.Close();
            }


        }
    }
}
