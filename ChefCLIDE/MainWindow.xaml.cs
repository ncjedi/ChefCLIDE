using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ChefCLIDE
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("input.txt"))
            {
                writer.WriteLine(CodeText.Text);
            }

            System.Diagnostics.Process.Start("Chef Interpereter.exe", "input.txt");
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void CodeText_Initialized(object sender, EventArgs e)
        {
            CodeText.Text = "Name.\n\nIngredients.\n\nMethod.\n\nServes 1.";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("input.txt"))
            {
                writer.WriteLine(CodeText.Text);
            }

            System.Diagnostics.Process.Start("Chef Interpereter.exe", "input.txt");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chef Programs (*.chef)|*.chef|All files (*.*)|*.*";

            if(openFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(openFileDialog.FileName)) 
                {
                    writer.WriteLine(CodeText.Text);
                }
            }*/

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var folderPath = System.IO.Path.Combine(path, "Chef Programs");
            var fullPath = System.IO.Path.Combine(folderPath, $"{SaveTextbox.Text}.chef");

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(CodeText.Text);
            }
        }

        private void SaveTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var folderPath = System.IO.Path.Combine(path, "Chef Programs");
            string fileTitle = null;
            string saveTextFill = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = folderPath;
            openFileDialog.Filter = "Chef Programs (*.chef)|*.chef|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                fileTitle = openFileDialog.SafeFileName;
                CodeText.Text = File.ReadAllText(openFileDialog.FileName);
            }

            if (fileTitle != null)
            {
                for (int x = 0; x < fileTitle.Length - 5; x++)
                {
                    saveTextFill += fileTitle[x];
                }

                SaveTextbox.Text = saveTextFill;
            }
        }
    }
}
