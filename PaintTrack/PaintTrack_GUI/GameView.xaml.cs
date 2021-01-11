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
using System.Windows.Shapes;
using PaintTrack;

namespace PaintTrack_GUI
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Page
    {
        CRUDManager crudManager = new CRUDManager();
        public GameView()
        {
            InitializeComponent();
        }

        private void btnAddMiniature_Click(object sender, RoutedEventArgs e)
        {
            AddMini addMini = new AddMini();
            addMini.ShowDialog();
            crudManager.AddMiniature(addMini.tbMiniName.Text, addMini.tbPhoto.Text, Int32.Parse(lblID.Content.ToString()));
            crudManager.AddPainted(lblID.Content.ToString());
            RefreshMinis();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PaintTrackHome paintTrackHome = new PaintTrackHome();
            this.NavigationService.Navigate(paintTrackHome);
        }

        private void btnDeleteGame_Click(object sender, RoutedEventArgs e)
        {
            bool isInt = Int32.TryParse(lblID.Content.ToString(), out int result);
            if (!isInt)
            {
                MessageBox.Show("The ID is not an integer");
            }
            else
            {
                crudManager.DeleteGame(result);
            }
        }

        public void RefreshMinis()
        {
            lvMinis.Items.Clear();
             
            var miniList = crudManager.GetMiniaturesForGame(Int32.Parse(lblID.Content.ToString()));
            foreach (var item in miniList)
            {
                lvMinis.Items.Add(new { Photo = item.MiniPhoto, Names = item.MiniName });
            }

            var game = crudManager.GetGameFromName(lblName.Content.ToString());
            lblPainted.Content = game.GameMiniaturesPainted;
        }
    }
}
