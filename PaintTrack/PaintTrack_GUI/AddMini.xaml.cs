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
using Microsoft.Win32;
using PaintTrack;

namespace PaintTrack_GUI
{
    /// <summary>
    /// Interaction logic for AddMini.xaml
    /// </summary>
    public partial class AddMini : Window
    {
        CRUDManager crudManager = new CRUDManager();
        public AddMini()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbMiniName.Text == "" || tbPhoto.Text == "")
                MessageBox.Show("Please enter a value in all fields");
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                tbPhoto.Text = op.FileName;
            }
        }
    }
}
