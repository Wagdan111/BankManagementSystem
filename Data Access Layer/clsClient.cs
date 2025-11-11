using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace DataAccess
{
    public class clsClient
    {
       
        public static DataTable ShowListClient()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select AccoutNumber,pincode,FirstName,LastName,Email,AccountBalace,Phone from  Client";

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
        public static DataTable ShowListClientbyOrderbyAsc()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select AccoutNumber,pincode,FirstName,LastName,Email,Phone,AccountBalace from  Client Order by AccoutNumber";

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
        public static DataTable ShowAccoutNumber()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select AccoutNumber,FirstName,AccountBalace from  Client ";

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
        public static DataTable ShowClientbyOrderAccoutDesc()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select AccoutNumber,pincode,FirstName,LastName,Phone,Email,AccountBalace from  Client Order by AccoutNumber desc";
 

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
        public static int CountsClients()
        {
            int Res = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select Count(*) from  Client ";

            SqlCommand command = new SqlCommand(Qurey, connection);

            DataTable table = new DataTable();

            try
            {
                connection.Open();
             
                object c= command.ExecuteScalar();

                if(c!=null&& int.TryParse(c.ToString(),out int Result))
                {
                    Res = Result;
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Res;
        }
        public static DataTable SearcehByName(string Name)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select AccoutNumber,pincode,FirstName,LastName,Phone,Email,AccountBalace  from Client Where AccoutNumber like +''+@Name+'%'";
         
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
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
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return data;
        }
        public static DataTable SearcehAccountNumberByName(string Name)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select AccoutNumber,FirstName,AccountBalace  from Client Where AccoutNumber like +''+@Name+'%'"; 

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
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
        public static int AddNwClint(string FirstName,string LastName,string Phone,string Email,string AccountNumber,string Pincode,int AccountBalance)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            int Number = -1;
         //   string query = @"insert INTO Client (pincode,LastName,FirstName,Phone,Email,AccoutNumber,AccountBalace) values (@Pincode,@LastName,@FirstName,@Phone,@Email,@AccountNumber,@AccuntBalance) ";

            string query = @" INSERT INTO Client
           (pincode,FirstName,LastName ,Email ,Phone,AccoutNumber,AccountBalace)
          VALUES (@pincode,@FirstName,@LastName,@Email,@Phone,@AccoutNumber,@AccountBalace);
             select SCOPE_IDENTITY();";


            SqlCommand command=new SqlCommand(query, connection);
        
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@Pincode", Pincode);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@AccoutNumber", AccountNumber);
            command.Parameters.AddWithValue("@AccountBalace", AccountBalance);

            try
            {
                connection.Open();
                object ConsctID = command.ExecuteScalar();

                if (ConsctID != null && int.TryParse(ConsctID.ToString(), out int ConstcID))
                {
                    Number = ConstcID;
                }
                else
                {
                    Number = -1;
                }


            }
            catch(Exception ex)
            {
                Number =-1;
            }
            finally
            {
                connection.Close();
            }
            return Number;
        }
        public static bool FindbyAccountNumber(string ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email, ref string Pincode,  ref int AccountBalance)
        {
           // public static string ConnectionString = "Server =.;Database = Bank;User Id = sa;Password = 123456";
        bool c = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select AccoutNumber,pincode,FirstName,LastName,Phone,Email,AccountBalace  from Client Where AccoutNumber =@ID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    c = true;
                    FirstName =(string) reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    AccountBalance = (int)reader["AccountBalace"];
                
                    Pincode = (string)reader["pincode"]; 
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                c = false;
            }
            finally
            {
                connection.Close();
            }
            return c;
        }
        public static bool UpdateContcst(string Accountnumber, string FirrstName, string LastName,
           string Emil, string Phone, string pincode, int AccounBalance)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = @"Update Client Set FirstName = @FirstName,LastName = @LastName,pincode= @pincode,

                      Phone=@Phone,Email  = @Email,AccountBalace=@AccountBalace
                      Where AccoutNumber = @Accountnumber";

            int RewsAffctat = 0;
            SqlCommand commend = new SqlCommand(Qurey, connection);
            commend.Parameters.AddWithValue("@Accountnumber", Accountnumber);
           
            commend.Parameters.AddWithValue("@FirstName", FirrstName);
            commend.Parameters.AddWithValue("@LastName", LastName);
            commend.Parameters.AddWithValue("@pincode", pincode);

            commend.Parameters.AddWithValue("@AccountBalace", AccounBalance);
            commend.Parameters.AddWithValue("@Phone", Phone);
            commend.Parameters.AddWithValue("@Email", Emil);
          //  commend.Parameters.AddWithValue("@Accountnumber", Accountnumber);
           
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
    }
}
