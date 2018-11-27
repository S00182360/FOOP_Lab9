using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FOOP_Lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Movie> movieList = new ObservableCollection<Movie>();

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
            

    }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //Read in information
            string title = tbx_Title.Text;
            string genre = tbx_Genre.Text;
            int rating = int.Parse(cbx_Rating.Text);

            Movie newMovie = new Movie(title, genre, rating);

            movieList.Add(newMovie);

        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            Movie movieSelect = lbx_MovieList.SelectedItem as Movie;

            if(lbx_MovieList != null)
            {
                movieList.Remove(movieSelect);
            }
        }
    }
}
