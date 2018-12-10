using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
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

namespace FOOP_Lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Movie> movieList = new ObservableCollection<Movie>();
        ObservableCollection<Movie> filteredList = new ObservableCollection<Movie>();


        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Movie loading
            Movie M1 = new Movie("Gone Girl", "Drama", 5);
            movieList.Add(M1);
            Movie M2 = new Movie("Tomb Raider", "Action", 5);
            movieList.Add(M2);
            Movie M3 = new Movie("Harry Potter and the Prizoner of Azkaban", "Fantasy", 4);
            movieList.Add(M3);

            lbx_MovieList.ItemsSource = movieList;
            tbk_Featured.Text = M2.ToString();

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //Read in information
            string title = tbx_Title.Text;
            string genre = tbx_Genre.Text;
            int rating = int.Parse(cbx_Rating.Text);
            //Create Movie from boxes and create new list item
            Movie newMovie = new Movie(title, genre, rating);
            movieList.Add(newMovie);
            //Clear Text Boxes
            tbx_Title.Clear();
            tbx_Genre.Clear();

        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            Movie movieSelect = lbx_MovieList.SelectedItem as Movie;

            if(lbx_MovieList != null)
            {
                movieList.Remove(movieSelect);
            }
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(movieList, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(@"c:\temp\movies.json"))
            {
                sw.Write(json);
            }
        }

        private void Btn_Load_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"c:\temp\movies.json"))
            {
                string json = sr.ReadToEnd();
                movieList = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(json);
            }

            lbx_MovieList.ItemsSource = movieList;
        }

        private void Tbx_Filter_KeyUp(object sender, KeyEventArgs e)
        {
            filteredList.Clear();
            string search = tbx_Filter.Text.ToLower();

            lbx_MovieList.ItemsSource = movieList.Where(m => m.Title.ToLower().Contains(search));
        }
    }
}
