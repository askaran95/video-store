using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    class Movies
    {
        SqlConnection Video_con = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=VSR_System;Integrated Security=True");

        SqlCommand cmd_Video = new SqlCommand();

        SqlDataReader Reader_Video;

        String Query_Video;

        public IEnumerable DefaultView { get; internal set; }

       


        public DataTable LoadMovies()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd_Video.Connection = Video_con;
                Query_Video = "Select * from Movies";

                cmd_Video.CommandText = Query_Video;
                //connection   opened
                Video_con.Open();

                // get data stream
                Reader_Video = cmd_Video.ExecuteReader();

                if (Reader_Video.HasRows)
                {
                    dt.Load(Reader_Video);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                // close reader
                if (Reader_Video != null)
                {
                    Reader_Video.Close();
                }

                // close connection
                if (Video_con != null)
                {
                    Video_con.Close();
                }
            }

        }

        public void CustomerUpdate(int CustID, string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                cmd_Video.Parameters.Clear();
                cmd_Video.Connection = Video_con;
                Query_Video = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                cmd_Video.Parameters.AddWithValue("@CustID", CustID);
                cmd_Video.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_Video.Parameters.AddWithValue("@LastName", LastName);
                cmd_Video.Parameters.AddWithValue("@Address", Address);
                cmd_Video.Parameters.AddWithValue("@Phone", Phone);

                cmd_Video.CommandText = Query_Video;

                //connection opened
                Video_con.Open();

                // Executed query
                cmd_Video.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Video_con != null)
                {
                    Video_con.Close();
                }
            }
        }

        public void AddVideos(string Rating, string Title, string Year, string Rental_Cost, string Plot, string Genre, int copies)
        {
            try
            {
                cmd_Video.Parameters.Clear();
                cmd_Video.Connection = Video_con;



                Query_Video = "Insert into Movies(Rating, Title, Year, Rental_Cost, Plot, Genre, copies) Values( @Rating, @Title, @Year, @Rental_Cost, @Plot, @Genre, @copies)";


                cmd_Video.Parameters.AddWithValue("@Rating", Rating);
                cmd_Video.Parameters.AddWithValue("@Title", Title);
                cmd_Video.Parameters.AddWithValue("@Year", Year);
                cmd_Video.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                cmd_Video.Parameters.AddWithValue("@Plot", Plot);
                cmd_Video.Parameters.AddWithValue("@Genre", Genre);
                cmd_Video.Parameters.AddWithValue("@copies", copies);

                cmd_Video.CommandText = Query_Video;

                //connection opened
                Video_con.Open();

                // Executed query
                cmd_Video.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Video_con != null)
                {
                    Video_con.Close();
                }
            }
        }

        public void DeleteVideo(int MovieID)
        {
            try
            {
                cmd_Video.Parameters.Clear();
                cmd_Video.Connection = Video_con ;


                String check = "";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                cmd_Video.Parameters.Add(parameterArray[0]);

                cmd_Video.CommandText = check;
                Video_con.Open();
                
                    check = "Delete from Movies where MovieID like @MovieID";
                    cmd_Video.CommandText = check;
                    cmd_Video.ExecuteNonQuery();
                    MessageBox.Show("Movie Deleted");
                
               
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (Video_con != null)
                {
                    Video_con.Close();
                }

            }
        }

       

        public void UpdateVideo(int MovieID, string Rating, string Title, int Year, string Plot, string Genre, int copies)
        {
            try
            {
                cmd_Video.Parameters.Clear();
                cmd_Video.Connection = Video_con;
                Query_Video = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MoviedID like @MovieID";


                cmd_Video.Parameters.AddWithValue("@MoviedID", MovieID);
                cmd_Video.Parameters.AddWithValue("@Rating", Rating);
                cmd_Video.Parameters.AddWithValue("@Title", Title);
                cmd_Video.Parameters.AddWithValue("@Year", Year);
                cmd_Video.Parameters.AddWithValue("@Plot", Plot);
                cmd_Video.Parameters.AddWithValue("@Genre", Genre);
                cmd_Video.Parameters.AddWithValue("@copies", copies);


                cmd_Video.CommandText = Query_Video;

                //connection opened
                Video_con.Open();

                // Executed query
                cmd_Video.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Video_con != null)
                {
                    Video_con.Close();
                }
            }
        }

        public DataTable Loadcustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd_Video .Connection = Video_con;
                Query_Video = "Select * from Coustmer";

                cmd_Video.CommandText = Query_Video;
                //connection   opened
                Video_con.Open();

                // get data stream
                Reader_Video = cmd_Video.ExecuteReader();

                if (Reader_Video.HasRows)
                {
                    dt.Load(Reader_Video);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                // close reader
                if (Reader_Video != null)
                {
                    Reader_Video.Close();
                }

                // close connection
                if (Video_con != null)
                {
                    Video_con.Close();
                }
            }

        }



        public void CustomerAdd(string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                cmd_Video.Parameters.Clear();
                cmd_Video.Connection = Video_con;



                Query_Video = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";


                cmd_Video.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_Video.Parameters.AddWithValue("@LastName", LastName);
                cmd_Video.Parameters.AddWithValue("@Address", Address);
                cmd_Video.Parameters.AddWithValue("@Phone", Phone);

                cmd_Video.CommandText = Query_Video;

                //connection opened
                Video_con.Open();

                // Executed query
                cmd_Video.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Video_con != null)
                {
                    Video_con.Close();
                }
            }
        }

        public void CustomerDelete(Int32 CustID)
        {
            try
            {
                cmd_Video.Parameters.Clear();
                cmd_Video.Connection = this.Video_con;


                String Strr = "";
                Strr = "select Count(*) from RentedMovies where CustIDFK= @CustID and isout ='1' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                cmd_Video.Parameters.Add(parameterArray[0]);

                cmd_Video.CommandText = Strr;
                Video_con.Open();
                int count = Convert.ToInt32(cmd_Video.ExecuteScalar());
                if (count == 0)
                {
                    Strr = "Delete from Coustmer where CustID like @CustID";
                    cmd_Video.CommandText = Strr;
                    cmd_Video.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has rented the movie. First take the movie back than you can delete the customer");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Video_con != null)
                {
                    this.Video_con.Close();
                }
            }
        }



        
    }
}
