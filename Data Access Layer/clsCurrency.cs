using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace DataAccess
{
    public class clsCurrency
    {

        
        public static DataTable ShowCurrency()
        {
           
                SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

                string Qurey = "select * from  Country";

                SqlCommand command = new SqlCommand(Qurey, connection);

                DataTable table = new DataTable();

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        table.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception Ex)
                {

                }
                finally
                {
                    connection.Close();
                }
                return table;
            }
        public static bool FindByCode(string Code,ref string Name, ref double Rote, ref string Country)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Qurey = "select * from Country where Code=@Code ";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@Code", Code);
          

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    Name = (string)reader["Name"];
                    Country = (string)reader["Country"];
                    Rote = Convert.ToDouble(reader["Rate"]);

                   
                }
                reader.Close();
            }
            catch (Exception Ex)
            {///
                IsFound = false;
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static DataTable SearcehByCode(string Code)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select *from  Country Where Code like +''+@Code+'%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return data;
        }
        public static bool UpdateRate(double Rate,string Code)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = @"Update Country Set Rate = @Rate
                      Where Code = @Code";

            int RewsAffctat = 0;
            SqlCommand commend = new SqlCommand(Qurey, connection);
            commend.Parameters.AddWithValue("@Rate", Rate);

            commend.Parameters.AddWithValue("@Code", Code);
            

            try
            {
                connection.Open();
                RewsAffctat = commend.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (RewsAffctat > 0);
        }
        public static int SumAllAccountBalance()
        {
            int SumBalance = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "Select sum(AccountBalace) from Client";

       
            SqlCommand commend = new SqlCommand(Qurey, connection);
           

            try
            {
                connection.Open();
                object sum = commend.ExecuteScalar();
                if (int.TryParse(sum.ToString(), out int DataSum))
                    SumBalance = DataSum;
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (SumBalance);
        }


    }
}
