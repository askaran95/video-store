using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        
        Movies Obj_Movies = new Movies();
        Rented Obj_Rented = new Rented();
        

        public int CustID;
        public int MoviedID;
        private object dialogResult;

        public Main()
        {
            InitializeComponent();
            dateissue.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

       

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (Firsttb.Text != "" && Lasttb.Text != "" && Addresstb_txt.Text != "" && Phonetb.Text != "")
            {
                Obj_Movies .CustomerAdd( Firsttb.Text, Lasttb.Text, Addresstb_txt.Text, Phonetb.Text);
                Customer_data.ItemsSource = Obj_Movies.Loadcustomer().DefaultView;
                Addresstb_txt.Text = "";
                Phonetb.Text = "";
                Firsttb.Text = "";
                Lasttb.Text = "";
                

            }
        }

        

        private void Customer_load(object sender, RoutedEventArgs e)
        {
            Customer_data.ItemsSource = Obj_Movies.Loadcustomer().DefaultView;
        }
   
        private void Select(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Customer_data.SelectedItems[0];
            Custid.Text = Convert.ToString(row["CustID"]);
            Firsttb.Text = Convert.ToString(row["FirstName"]);
            Lasttb.Text = Convert.ToString(row["Lastname"]);
            Addresstb_txt.Text = Convert.ToString(row["Address"]);
            Phonetb.Text = Convert.ToString(row["Phone"]);

            Customer_data.ItemsSource = Obj_Movies .Loadcustomer() .DefaultView;
        }

        private void AddMovies_Click(object sender, RoutedEventArgs e)
        {
            
            if (Rating_box.Text != "" && Title_box.Text != "" && Year_tx.Text != "" &&  Plot_box.Text != "" && Genre_box.Text != "" && copiestb.Text != "")
            {
                int Mov_year = Convert.ToInt32(Year_tx.Text);
                int copies = Convert.ToInt32(copiestb.Text);
                string rent;
                if (2018 - Mov_year > 5)
                {
                    rent = "2";
                        
                }
                else
                {
                    rent = "5";
                }

                Obj_Movies.AddVideos(Rating_box.Text, Title_box.Text, Year_tx.Text, rent, Plot_box.Text, Genre_box.Text, copies);
                Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
                Title_box.Text = ""; 
                Rating_box.Text = "";
                Plot_box.Text = "";
                Year_tx.Text = "";
                Genre_box.Text = "";
                copiestb.Text = "";

            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = Firsttb.Text;
            string LastName = Lasttb.Text;
            string Address = Addresstb_txt.Text;
            string Phone = Phonetb.Text;
            int CustID = Convert.ToInt32(Custid.Text);
            Obj_Movies.CustomerUpdate(CustID, FirstName, LastName, Address, Phone);

            Customer_data.ItemsSource = Obj_Movies.Loadcustomer().DefaultView;
            Firsttb.Text = "";
            Lasttb.Text = "";
            Phonetb.Text = "";
            Addresstb_txt.Text = "";
        }
        

        private void DeletecustomerClick(object sender, RoutedEventArgs e)
        {
            int CustID = Convert.ToInt32(Custid.Text);
            
                Obj_Movies.CustomerDelete(CustID);
                Customer_data.ItemsSource = Obj_Movies.Loadcustomer().DefaultView;
                Firsttb.Text = "";
                Addresstb_txt.Text = "";
                Lasttb.Text = "";

                Phonetb.Text = "";
            
        }
        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            
                int movie = Convert.ToInt32(Movieidt.Text);



                Obj_Movies .DeleteVideo( movie);
                Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
                Title_box.Text = "";
                Rating_box.Text = "";
                Plot_box.Text = "";
                Year_tx.Text = "";
                Genre_box.Text = "";
                Movieidt.Text = "";


            
            


        }

        private void Video_loaded(object sender, RoutedEventArgs e)
        {
           Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
        }

        private void SelectMovieRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Mvie_datagrid.SelectedItems[0];
            Title_box.Text = Convert.ToString(row["Title"]);
            Plot_box.Text = Convert.ToString(row["Plot"]);
            Genre_box.Text = Convert.ToString(row["Genre"]);
            Year_tx.Text = Convert.ToString(row["Year"]);
            Rating_box.Text = Convert.ToString(row["Rating"]);
            Movieidt.Text = Convert.ToString(row["MovieID"]);
            copiestb.Text = Convert.ToString(row["copies"]);

            Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
        }

        private void TabControl_SelectionChanged()
        {

        }

        private void Movieid_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateMovies_Click(object sender, RoutedEventArgs e)
        {
            int MoviedID = Convert.ToInt32(Movieidt.Text);
            int copies = Convert.ToInt32(copiestb.Text);


            string Title = Title_box.Text;
            string Rating = Rating_box.Text;
            string Plot = Plot_box.Text;
            string Genre = Genre_box.Text;
            int Year = Convert.ToInt32(Year_tx.Text);
            Obj_Movies.UpdateVideo(MoviedID, Rating, Title, Year, Plot, Genre, copies);
            Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
            Title_box.Text = "";
            Rating_box.Text = "";
            Plot_box.Text = "";
            Year_tx.Text = "";
            Genre_box.Text = "";
            copiestb.Text = "";
        }
        private void Movieid_txt_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Retur_Click(object sender, RoutedEventArgs e)
        {
            int RMID = Convert.ToInt32(Rmid_txt.Text);
            int MoviedID = Convert.ToInt32(Movieidt.Text);
            


            Obj_Rented.UpdateRented(RMID, MoviedID, Convert.ToDateTime(dateissue.Text), DateTime.Now);

            Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;
            Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
            Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies .Loadcustomer().DefaultView;
            Movieidt.Text = "";
            Custid.Text = "";
            Genre_box.Text = "";
            Year_tx.Text = "";
            Rating_box.Text = "";
            Movieidt.Text = "";
            copiestb.Text = "";
            Firsttb.Text = "";
            Lasttb.Text = "";
            Title_box.Text = "";
            Plot_box.Text = "";
            
            Addresstb_txt.Text = "";
            Phonetb.Text = "";


        }

        private void Video_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Customer_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Issue_btn_Click(object sender, RoutedEventArgs e)
        {
            if (copiestb.Text != "0")

            {
                if (Movieidt.Text != "" && Custid.Text != "" && dateissue.Text != "")
                {
                    int MovieID = Convert.ToInt32(Movieidt.Text);
                    int Customerid = Convert.ToInt32(Custid.Text);
                    dateissue.Text = DateTime.Today.ToString("dd-MM-yyyy");
                    int copies = Convert.ToInt32(copiestb.Text);
                    int R = 1;
                   


                    Obj_Rented.AddRented(MovieID, Customerid, DateTime.Now, copies, R);
                    Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
                    Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;
                    Customer_data.ItemsSource = Obj_Movies .Loadcustomer().DefaultView;
                    Movieidt.Text = "";
                    Custid.Text = "";
                    Year_tx.Text = "";
                    Rating_box.Text = "";
                    Movieidt.Text = "";
                    copiestb.Text = "";
                    Firsttb.Text = "";
                    Title_box.Text = "";
                    Plot_box.Text = "";
                    Genre_box.Text = "";
                   
                    Lasttb.Text = "";
                    Addresstb_txt.Text = "";
                    Phonetb.Text = "";

                }

            }
                else
                {
                    MessageBox.Show("No More Copies Left");
                }

        }
        private void Topcust_btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_Rented.BestBuyer();
        }

        private void Topmovie_Click(object sender, RoutedEventArgs e)
        {
            Obj_Rented.TopMovie();
        }
        private void Rental_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Rented(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Rent_datagrid.SelectedItems[0];
            Movieidt.Text = Convert.ToString(row["MovieIDFK"]);
            Custid.Text = Convert.ToString(row["CustIDFK"]);
            Rmid_txt.Text = Convert.ToString(row["RMID"]);
            dateissue.Text = Convert.ToString(row["DateRented"]);
            dateretuned.Text = DateTime.Now.ToString("dd-MM-yyyy");



            Rent_datagrid.ItemsSource = Obj_Rented .ListRented().DefaultView;
        }

        private void video_load(object sender, RoutedEventArgs e)
        {
            Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;

        }

        private void rented(object sender, RoutedEventArgs e)
        {
            Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            int RMID = Convert.ToInt32(Rmid_txt.Text);
            dateretuned.Text = DateTime.Today.ToString("dd-MM-yyyy");
            int MoviedID = Convert.ToInt32(Movieidt.Text);



            Obj_Rented.UpdateRented(RMID, MoviedID, Convert.ToDateTime(dateissue.Text), DateTime.Now);

            Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;
            Mvie_datagrid.ItemsSource = Obj_Movies.LoadMovies().DefaultView;
            Rent_datagrid.ItemsSource = Obj_Rented.ListRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Loadcustomer().DefaultView;
            Movieidt.Text = "";
            Custid.Text = "";
            Genre_box.Text = "";
            Year_tx.Text = "";
            Rating_box.Text = "";
            Movieidt.Text = "";
            copiestb.Text = "";
            Firsttb.Text = "";
            Title_box.Text = "";
            Plot_box.Text = "";
            
            Lasttb.Text = "";
            Addresstb_txt.Text = "";
            Phonetb.Text = "";


        }

      
    }
}
