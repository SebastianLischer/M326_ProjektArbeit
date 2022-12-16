using M326_ProjektArbeit.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace M326_ProjektArbeit.View
{
    /// <summary>
    /// Interaktionslogik für RasterErstellen.xaml
    /// </summary>
    public partial class RasterErstellen : Page
    {
        MainWindow main;
        public RasterErstellen(MainWindow window)
        {
            main = window;
            InitializeComponent();
            DataContext = new Data();
        }

        private void btnRasterErstelen(object sender, RoutedEventArgs e)
        {
            if (RasterName.Text == "" || JobComboBox.SelectedItem == null || CompetenceListBox.SelectedItems.Count == 0)
            {
                string errormessage = "";
                if (RasterName.Text == "")
                {
                    errormessage += "Sie müssen dem Raster einen Namen geben.\n";
                }
                if (JobComboBox.SelectedItem == null)
                {
                    errormessage += "Sie müssen das Raster einem Job zuweisen.\n";
                }
                if (CompetenceListBox.SelectedItems.Count == 0)
                {
                    errormessage += "Sie müssen mindestens eine Kompetenz hinzufügen.";
                }
                ErrorTextBlock.Text = errormessage;
            }
            else
            {
                ErrorTextBlock.Text = "";

                using (var ctx = new DatabaseContext())
                {
                    var Job = ctx.Jobs
                        .Where(b => b.JobName == ((Job)JobComboBox.SelectedItem).JobName)
                        .FirstOrDefault();
                    var stud = new CompetenceGrid() { Name = RasterName.Text, Job = Job };

                    ctx.CompetenceGrids.Add(stud);
                    ctx.SaveChanges();

                    var SelectedCompetences = CompetenceListBox.SelectedItems;

                    foreach (Competence selectedcompetence in SelectedCompetences)
                    {
                        var competencegrid = ctx.CompetenceGrids
                            .Where(b => b.Name == RasterName.Text)
                            .FirstOrDefault();

                        var competence = ctx.Competences
                            .Where(b => b.CompetenceId == selectedcompetence.CompetenceId)
                            .FirstOrDefault();

                        var temp = new CompetenceGridCompentence() { CompetenceId = competence.CompetenceId, CompetenceGridId = competencegrid.CompetenceGridId };

                        ctx.CompetenceGridCompetences.Add(temp);
                        ctx.SaveChanges();
                    }
                }

                JobComboBox.SelectedItem = null;
                RasterName.Text = "";
                CompetenceListBox.SelectedItem = null;
                ErrorTextBlock.Text = "Raster wurde erfolgreich erstellt.";
            }
        }

        private void KompetenzErstellen(object sender, RoutedEventArgs e)
        {
            main.CreateCompetence();
        }
    }

    public class Data
    {
        public Data()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                ListOfJobs = db.Jobs.ToList<Job>();
                ListOfCompetences = db.Competences.ToList<Competence>();
            }
        }
        public List<Job> ListOfJobs { get; set; }
        public List<Competence> ListOfCompetences { get; set; }
    }
}