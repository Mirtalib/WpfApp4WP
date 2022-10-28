using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp4WP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                ComboboxFontSize.Items.Add(i.ToString());
            }
        }



        private void WriteFile(string fileName, SaveFileDialog _saveFileDialog)
        {
            _saveFileDialog.FileName = fileName;
            if (_saveFileDialog.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(_saveFileDialog.OpenFile());
                writer.WriteLine(txtBoxWrite.Text);
                writer.Dispose();
                writer.Close();
                MessageBox.Show("File Succesfully Saved...", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All files|*.*|Text files|*.txt";
            openFile.FilterIndex = 2;

            if (openFile.ShowDialog() == true)
                using (StreamReader sr = new StreamReader(openFile.FileName))
                    txtBoxWrite.Text = sr.ReadToEnd();
            txtBoxFileName.Text = openFile.FileName;

        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";

            if (string.IsNullOrEmpty(txtBoxFileName.Text))
            {
                WriteFile("Text.txt", saveFileDialog);
            }
            else
            {
                WriteFile(txtBoxFileName.Text, saveFileDialog);
            }
        }

        private void FontStyle_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn is null)
                return;
            switch (btn?.Content)
            {
                case "𝘪𝘵":
                    txtBoxWrite.FontStyle = FontStyles.Italic;
                    break;
                case "Ob":
                    txtBoxWrite.FontStyle = FontStyles.Oblique;
                    break;
                case "N":
                    txtBoxWrite.FontStyle = FontStyles.Normal;
                    break;
            }
        }



        private void ComboboxFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int size;
            size = Convert.ToInt32(ComboboxFontSize.SelectedItem);
            txtBoxWrite.FontSize = size;
        
        }
    }
}
