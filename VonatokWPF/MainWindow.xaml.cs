using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vonatok;

namespace VonatokWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Program.Beolvas();
            var vonalszamok = Program.varakozasok.Select(v => v.Vonal).Distinct();
            cbxVonalSzam.ItemsSource = vonalszamok;
        }

        private void cbxVonalSzam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kivalasztottVonal = Program.varakozasok.Where(v => v.Vonal == cbxVonalSzam.SelectedValue.ToString());
            txblAdatok.Text = "";
            string adatSzoveg = "";
            foreach (var item in kivalasztottVonal)
            {
                adatSzoveg += item.ToString()+"\n";
            }
            txblAdatok.Text = adatSzoveg;
        }
    }
}