using System;
using System.Collections.Generic;
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
using PaintTrack;

namespace PaintTrack_GUI
{
    /// <summary>
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        CRUDManager crudManager = new CRUDManager();
        public AddGame()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            crudManager.AddGame(tbName.Text, tbPublisher.Text, tbLink.Text, tbMinis.Text);
            this.Close();
        }
    }
}
