using M326_ProjektArbeit.Model;
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

namespace M326_ProjektArbeit.View
{
    /// <summary>
    /// Interaktionslogik für KompetenzenAnschauen.xaml
    /// </summary>
    public partial class KompetenzenAnschauen : Page
    {
        public KompetenzenAnschauen(CompetenceGrid grid)
        {
            InitializeComponent();
            DataContext = new Data3(grid);
            RasterNameTextBlock.Text = grid.Name;
            RasterJobTextBlock.Text = grid.Job.JobName;
        }

        public class Data3
        {
            //load list of Jobs from Database
            public Data3(CompetenceGrid grid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var competenceGridCompentence = db.CompetenceGridCompetences
                    .Where(x => x.CompetenceGridId == grid.CompetenceGridId)
                    .ToList();

                    foreach (CompetenceGridCompentence competence in competenceGridCompentence)
                    {
                        ListOfCompetences2.Add(db.Competences.Where(x => x.CompetenceId == competence.CompetenceId).FirstOrDefault());
                    }
                }
            }
            public List<Competence> ListOfCompetences2 { get; set; } = new();
        }
    }
}
