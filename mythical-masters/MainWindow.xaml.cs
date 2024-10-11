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

namespace mythical_masters
{
    public partial class MainWindow : Window
    {
        private List<Hero> heroes;
        private Random rand;

        public MainWindow()
        {
            InitializeComponent();
            lblOut.Content = "Helden wählen!";
            rand = new Random();
            LoadHeroes();
            RefreshComboBoxes();
        }

        private void LoadHeroes()
        {
            heroes = new List<Hero>
            {
                CreatoRandomKrieger("Krieger"),
                CreateRandomMagier("Magier"),
                CreateRandomSchurke("Schurke"),
                CreateRandomMert("Mert")
            };
        }

        private Hero CreateRandomMert(string name)
        {
            return new Mert(
                name,
                rand.Next(0, 0), // Stärke
                rand.Next(0, 0), // Intelligenz
                rand.Next(0, 0), // Geschick
                rand.Next(0, 0)  // Mertigkeit
            );
        }

       private Hero CreatoRandomKrieger(string name)
        {
            return new Krieger(
                name,
                rand.Next(1, 5), // Stärke
                rand.Next(1, 5), // Intelligenz
                rand.Next(1, 5), // Geschick
                rand.Next(1, 5)  // Rüstung
            );
        }

        private Hero CreateRandomMagier(string name)
        {
            return new Magier(
                name,
                rand.Next(1, 5), // Stärke
                rand.Next(1, 5), // Intelligenz
                rand.Next(1, 5), // Geschick
                rand.Next(1, 5)  // Mana
            );
        }

        private Hero CreateRandomSchurke(string name)
        {
            return new Schurke(
                name,
                rand.Next(1, 5), // Stärke
                rand.Next(1, 5), // Intelligenz
                rand.Next(1, 5), // Geschick
                rand.Next(1, 5)  // Böse
            );
        }

        public void RefreshComboBoxes()
        {
            cbLeft.Items.Clear();
            cbLeft.Items.Add("Krieger");
            cbLeft.Items.Add("Magier");
            cbLeft.Items.Add("Schurke");
            cbLeft.Items.Add("Mert");

            cbRight.Items.Clear();
            cbRight.Items.Add("Krieger");
            cbRight.Items.Add("Magier");
            cbRight.Items.Add("Schurke");
            cbRight.Items.Add("Mert");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLeft.SelectedItem != null)
            {
                string selectedHero = cbLeft.SelectedItem.ToString();
                UpdateListBox(lbLeft, selectedHero);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbRight.SelectedItem != null)
            {
                string selectedHero = cbRight.SelectedItem.ToString();
                UpdateListBox(lbRight, selectedHero);
            }
        }

        private void UpdateListBox(ListBox listBox, string heroName)
        {
            listBox.Items.Clear();
            foreach (var hero in heroes)
            {
                if (hero.Name == heroName)
                {
                    listBox.Items.Add(hero.ToString());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbLeft.SelectedItem != null && cbRight.SelectedItem != null)
            {
                string? leftHeroName = cbLeft.SelectedItem?.ToString();
                string? rightHeroName = cbRight.SelectedItem?.ToString();

                Hero? leftHero = heroes.Find(h => h.Name == leftHeroName);
                Hero? rightHero = heroes.Find(h => h.Name == rightHeroName);

                if (leftHero != null && rightHero != null)
                {
                    int leftTotal = CalculateTotalAttributes(leftHero);
                    int rightTotal = CalculateTotalAttributes(rightHero);

                    if (leftTotal > rightTotal)
                    {
                        lblOut.Content = $"{leftHero.Name} gewinnt!";
                    }
                    else if (leftTotal < rightTotal)
                    {
                        lblOut.Content = $"{rightHero.Name} gewinnt!";
                    }
                    else
                    {
                        lblOut.Content = "Unentschieden!";
                    }
                }
            }
            else
            {
                lblOut.Content = "Bitte wählen Sie zwei Helden aus.";
            }
        }

        private int CalculateTotalAttributes(Hero hero)
        {
            int total = 0;

            if (hero.Stärke > 0)
            {
                total += hero.Stärke;
            }

            if (hero.Intelligenz > 0)
            {
                total += hero.Intelligenz;
            }

            if (hero.Geschick > 0)
            {
                total += hero.Geschick;
            }

            return total;
        }
    }
}