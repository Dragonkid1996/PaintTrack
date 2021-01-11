using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for PaintTrackHome.xaml
    /// </summary>
    public partial class PaintTrackHome : Page
    {
        CRUDManager crudManager = new CRUDManager();
        public PaintTrackHome()
        {
            InitializeComponent();
            RefreshGames();
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.ShowDialog();
            RefreshGames();
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var gameChosen = lvGames.SelectedItem.ToString().Split(',');
                var onlyGame = gameChosen[1].Split('=');
                var gameName = onlyGame[1].Trim();
                var game = crudManager.GetGameFromName(gameName);
                crudManager.ID = game.GameId;

                GameView gameView = new GameView();
                gameView.lblID.Content = game.GameId.ToString();                
                gameView.lblName.Content = game.GameName;
                gameView.lblPublisher.Content = game.GamePublisher;
                gameView.lblMaxMinis.Content = game.GameMaximumMiniatures.ToString();
                gameView.lblPainted.Content = game.GameMiniaturesPainted.ToString();
                gameView.RefreshMinis();
                this.NavigationService.Navigate(gameView);
            }
            catch (Exception)
            {
                //Left blank intentionally, as the program won't crash on double clicking
                //without selecting an item
            }
        }

        private void RefreshGames()
        {
            lvGames.Items.Clear();
            var gamesList = crudManager.GetAllGames();
            foreach (var item in gamesList)
            {
                lvGames.Items.Add(new { ID = item.GameId, Names = item.GameName, 
                                        Publisher = item.GamePublisher, Link = item.GameLink});
            }
        }

        private void TextBlock_MouseDown(object sender, RequestNavigateEventArgs e)
        {
            var url = ((Hyperlink)sender).NavigateUri;
            Process.Start(new ProcessStartInfo(url.AbsoluteUri) { UseShellExecute=true });
            e.Handled = true;
        }
    }
}
