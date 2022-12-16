using M326_ProjektArbeit.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M326_ProjektArbeit.View
{
    /// <summary>
    /// Interaktionslogik für RasterAnschauen.xaml
    /// </summary>
    public partial class RasterAnschauen : Page
    {
        MainWindow main;
        public RasterAnschauen(MainWindow window)
        {
            main = window;
            InitializeComponent();
            comboBoxRaster.DataContext = new Data2();
        }

        private void RasterLaden(object sender, RoutedEventArgs e)
        {
            if (comboBoxRaster.SelectedItem == null)
            {
                FehlerMeldung.Text = "Sie müssen zuerst ein Raster auswählen";
            }
            else
            {
                FehlerMeldung.Text = "";
                using (DatabaseContext db = new DatabaseContext())
                {
                    CompetenceGrid grid = db.CompetenceGrids
                        .Where(b => b.Name == ((CompetenceGrid)comboBoxRaster.SelectedItem).Name)
                        .Include(x => x.Job)
                        .FirstOrDefault();

                    main.ShowCompetence(grid);
                }
            }
        }

    }

    public class Data2
    {
        public Data2()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                ListOfGrids = db.CompetenceGrids.ToList<CompetenceGrid>();
            }
        }
        public List<CompetenceGrid> ListOfGrids { get; set; }
    }

}