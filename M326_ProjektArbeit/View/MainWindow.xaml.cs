using M326_ProjektArbeit.Model;
using M326_ProjektArbeit.Repositories;
using M326_ProjektArbeit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace M326_ProjektArbeit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_rasterErstellen_page(object sender, RoutedEventArgs e)
        {
            Main.Content = new RasterErstellen(this);

        }
        private void CheckIfAdmin(object sender, RoutedEventArgs e)
        {
            
            bool isAdmin = UserRepository.DbCheckIfAdmin();
            if (isAdmin == true)
            {
                btn_rasterErstellen.Visibility = Visibility.Visible;
            }
            else
            {
                btn_rasterErstellen.Visibility = Visibility.Hidden;
            }
        }
        private void btn_rasterAnschauen_page(object sender, RoutedEventArgs e)
        {
            Main.Content = new RasterAnschauen(this);
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void CreateCompetence()
        {
            Main.Content = new KompetenzErstellen(this);
        }
        public void CreateGrid()
        {
            Main.Content = new RasterErstellen(this);
        }
        public void ShowCompetence(CompetenceGrid grid)
        {
            Main.Content = new KompetenzenAnschauen(grid);
        }
    }
}
