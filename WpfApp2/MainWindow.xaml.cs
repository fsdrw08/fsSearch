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
using System.IO;

namespace WpfApp2
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
        private void FolderSearch(object sender, RoutedEventArgs e)
        {
            SearchOption searchOption = new SearchOption();

            if (cbRecurse.IsChecked.Value)
            {
                searchOption = SearchOption.AllDirectories;
            }
            else
            {
                searchOption = SearchOption.TopDirectoryOnly;
            }

            //DirectoryInfo di = new DirectoryInfo(tbSearchFrom.Text);
            string[] result =
                Directory.GetDirectories(tbSearchFrom.Text, '*' + tbSearchTarget.Text + '*', searchOption);

            lvDirResult.ItemsSource = result;
            // Directory.GetDirectories(tbSearchFrom.Text, tbSearchTarget.Text, SearchOption.TopDirectoryOnly);
            tbDirCount.Text = result.Count().ToString();

            if ((result.Count() == 1) & cbAutoOpenDir.IsChecked.Value)
            {
                System.Diagnostics.Process.Start("explorer.exe", result[0].ToString());
            }
        }

        private void FileSearch(object sender, RoutedEventArgs e)
        {
            //DirectoryInfo di = new DirectoryInfo(tbSearchFrom.Text);
            //DirectoryInfo searchFrom = new DirectoryInfo(tbSearchFrom.Text);
            //FileInfo[] seaarchResult = searchFrom.GetFiles('*' + tbSearchTarget.Text + '*');

            SearchOption searchOption = new SearchOption();

            if (cbRecurse.IsChecked.Value)
            {
                searchOption = SearchOption.AllDirectories;
            } else
            {
                searchOption = SearchOption.TopDirectoryOnly; 
            }

            string[] result =
                Directory.GetFiles(tbSearchFrom.Text, '*' + tbSearchTarget.Text + '*', searchOption);


            lvDirResult.ItemsSource = result;
            // Directory.GetDirectories(tbSearchFrom.Text, tbSearchTarget.Text, SearchOption.TopDirectoryOnly);
            tbDirCount.Text = result.Count().ToString();

            if ((result.Count() == 1) & cbAutoOpenDir.IsChecked.Value)
            {
                System.Diagnostics.Process.Start(result[0].ToString());
            }
        }

        private void lvNameSorting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvFullNameSorting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_mouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = lvDirResult.SelectedItem;
            if (item != null)
            {
                string path = string.Format("\"{0}\"", item.ToString());
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
