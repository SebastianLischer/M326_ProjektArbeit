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
    /// Interaktionslogik für KompetenzErstellen.xaml
    /// </summary>
    public partial class KompetenzErstellen : Page
    {
        MainWindow main;
        public KompetenzErstellen(MainWindow window)
        {
            main = window;
            InitializeComponent();
        }

        private void CreateCompentence(object sender, RoutedEventArgs e)
        {
            if (CompetenceName.Text == "" || CompetenceDescription.Text == "")
            {
                string errormessage = "";
                if (CompetenceName.Text == "")
                {
                    errormessage += "Sie müssen der Kompetenz einen Namen geben.\n";
                }
                if (CompetenceDescription.Text == "")
                {
                    errormessage += "Sie müssen der Kompetenz eine \nBeschreibung hinzufügen..\n";
                }
                FehlerMeldungTxtBox.Text = errormessage;
            }
            else
            {
                FehlerMeldungTxtBox.Text = "";

                using (var ctx = new DatabaseContext())
                {
                    var competence = new Competence() { CompetenceName = CompetenceName.Text, CompetenceString = CompetenceDescription.Text };
                    ctx.Competences.Add(competence);
                    ctx.SaveChanges();
                    main.CreateGrid();
                }
            }
        }
    }
}
