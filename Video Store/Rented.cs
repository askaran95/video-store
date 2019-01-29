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
    class Rented
    {
        
        SqlConnection Conn_Rented = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=VSR_System;Integrated Security=True");

        SqlCommand cmd_Rented = new SqlCommand();

        SqlDataReader Reader_Rented;

        String Query_Rented;

        public IEnumerable DefaultView { get; internal set; }
        public string S2 { get; private set; }
        public string Strr { get; private set; }

        internal object RentedDG()
        {
            throw new NotImplementedException();
        }


        public DataTable ListRented()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd_Rented.Connection = Conn_Rented;
                Query_Rented = "Select * from RentedMovies";

                cmd_Rented.CommandText = Query_Rented;
                //connection   opened
                Conn_Rented.Open();

                // get data stream
                Reader_Rented = cmd_Rented.ExecuteReader();

                if (Reader_Rented.HasRows)
                {
                    dt.Load(Reader_Rented);
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
                if (Reader_Rented  != null)
                {
                    Reader_Rented.Close();
                }

                // close connection
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }

        }



        public void AddRented(int MovieIDFK, int CustIDFK, DateTime  DateRented, int copies, int isout)
        {
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;



                Query_Rented = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented ,isout) Values( @MovieIDFk, @CustIDFK, @DateRented, @isout)";
                
                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MovieIDFK );
                cmd_Rented.Parameters.AddWithValue("@CustIDFK", CustIDFK );
                cmd_Rented.Parameters.AddWithValue("@DateRented", DateRented );
                cmd_Rented.Parameters.AddWithValue("@isout", isout);
                cmd_Rented.Parameters.AddWithValue("@copies", copies);


                cmd_Rented.CommandText = Query_Rented;

                //connection opened
                Conn_Rented.Open();

                // Executed query
                cmd_Rented.ExecuteNonQuery();

                Query_Rented = "Update Movies set copies = copies-1 where MovieID = @MovieIDFK";
                cmd_Rented.CommandText = Query_Rented;
                cmd_Rented.ExecuteNonQuery();
                

               
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }
        }


        public void UpdateRented(int RMID, int MovieID, DateTime  DateRent, DateTime  DateReturned)
        {
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                int RentTotal = 0, Cost = 0;
                double days = (DateReturned - DateRent).TotalDays;

                string S1 = "Select Rental_Cost from Movies where MovieID = @MovieIDFK";
                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MovieID);

                cmd_Rented.CommandText = S1;
                Conn_Rented.Open();
                Cost = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    RentTotal = Cost;
                }
                else
                {
                    RentTotal = Cost * Convert.ToInt32(days);
                }


                S2 = "Update RentedMovies Set DateReturned='" + DateReturned +"' where RMID = @RMID";
                cmd_Rented.Parameters.AddWithValue("@DateReurned", DateReturned);
                cmd_Rented.Parameters.AddWithValue("@RMID", RMID);
               
                cmd_Rented.CommandText = S2;

                cmd_Rented.ExecuteNonQuery();


                S2 = "Update Movies set copies = copies+1 where MovieID = @MovieIDFK";
                this.cmd_Rented.CommandText = this.S2;

                this.cmd_Rented.ExecuteNonQuery();

                S2 = "Update RentedMovies set isout = 0 where RMID = @RMID";
                this.cmd_Rented.CommandText = this.S2;

                this.cmd_Rented.ExecuteNonQuery();

                MessageBox.Show("Total cost is " + RentTotal);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }


        }

        public void BestBuyer()
        {
            int Best_Buy = 0, Max_numb = 0, Total_Cusr = 0;
            string Strr = "";
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                string Strr1 = "Select IDENT_CURRENT('Coustmer')";

                cmd_Rented.CommandText = Strr1;
                Conn_Rented.Open();
                Total_Cusr = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                for (int i = 1; i <= Total_Cusr; i++)
                {

                    Strr = "select Count(*) from RentedMovies where CustIDFK= '" + i + "'";


                    cmd_Rented .CommandText = Strr;
                    int count = Convert.ToInt32(cmd_Rented.ExecuteScalar());
                    if (count > Max_numb)
                    {
                        Max_numb = count;
                        Best_Buy = i;
                    }
                }
                this.S2 = "Select FirstName from Coustmer where CustID ='" + Best_Buy + "'";
                this.cmd_Rented.CommandText = this.S2;
                String FirstName = Convert.ToString(cmd_Rented.ExecuteScalar());
                MessageBox.Show(FirstName + " (CustID " + Best_Buy + " ) is maximum movie buyer with " + Max_numb + " times");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }

        }


        public void TopMovie()
        {
            int Top_Mov = 0, Max_numb = 0, Total_Mov = 0;
            string Strr = "";
            try
            {
                cmd_Rented .Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented; 
                string Strr1 = "Select IDENT_CURRENT('Movies')";

                cmd_Rented.CommandText = Strr1;
                Conn_Rented.Open();
                Total_Mov = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                for (int i = 1; i <= Total_Mov; i++)
                {

                    Strr = "select Count(*) from RentedMovies where MovieIDFK= '" + i + "'";


                    cmd_Rented.CommandText = Strr;
                    int count = Convert.ToInt32(cmd_Rented.ExecuteScalar());
                    if (count > Max_numb)
                    {
                        Max_numb = count;
                        Top_Mov = i;
                    }
                }

                
                this.Strr= "Select Title from Movies where MoviedID ='" + Top_Mov + "'";
                this.cmd_Rented.CommandText = this.Strr;
                String Title = Convert.ToString(cmd_Rented.ExecuteScalar());
                MessageBox.Show(Title + " (MoviedID " + Top_Mov + " ) is maximum rented movie with " + Max_numb + " times");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }

        }
    }
}

