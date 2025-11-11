using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsUsers
    {
       
        public static DataTable ShowLastUsers()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select * from  Users";

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
        public static bool Find(string Password, string UserName, ref string LastName, ref string FirstName, ref string Phone,
         ref int ID, ref int Permetor)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Qurey = "select * from Users Where Password = @ID and UserName=@UserName";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@ID", Password);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];

                    Permetor = (int)reader["Permitions"];

                    ID = (int)reader["ID"];

                }
                reader.Close();
            }
            catch (Exception Ex)
            {///
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool FindByPassword(string Password, ref string UserName, ref string LastName, ref string FirstName, ref string Phone,
        ref int ID, ref int Permetor)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Qurey = "select * from Users Where Password = @ID ";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@ID", Password);
         

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    UserName = (string)reader["UserName"];

                    Permetor = (int)reader["Permitions"];

                    ID = (int)reader["ID"];

                }
                reader.Close();
            }
            catch (Exception Ex)
            {///
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static int AddNewUser(string UserName, string FirstName, string LastName, string Password, string Phone, int Permitions)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            int Number = -1;
           

            string query = @" INSERT INTO Users
           (UserName,FirstName,LastName ,Phone,Password,Permitions)
          VALUES (@UserName,@FirstName,@LastName,@Password,@Phone,@Permitions);
             select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permitions", Permitions);
          

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
            catch (Exception ex)
            {
                Number = -1;
            }
            finally
            {
                connection.Close();
            }
            return Number;
        }
        public static bool UpdateUser(string Password, string FirrstName, string LastName,
         string UserName, string Phone,int Permitions)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = @"Update Users Set FirstName = @FirstName,LastName = @LastName,UserName= @UserName,

                      Phone=@Phone,Permitions  = @Permitions,Password=@Password
                      Where Password = @Password";

            int RewsAffctat = 0;
            SqlCommand commend = new SqlCommand(Qurey, connection);
            commend.Parameters.AddWithValue("@Password", Password);

            commend.Parameters.AddWithValue("@FirstName", FirrstName);
            commend.Parameters.AddWithValue("@LastName", LastName);
            commend.Parameters.AddWithValue("@Phone", Phone);

            commend.Parameters.AddWithValue("@Permitions", Permitions);
            commend.Parameters.AddWithValue("@UserName", UserName);
           
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
        public static bool DeleteUser(string ID)
        {
            bool c = false;

            string query = @"delete from Users where Password=@ID ";
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                c = true;
               int v = command.ExecuteNonQuery();


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
        public static DataTable Sheresh(string UserName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select * from  Users where UserName=@UserName";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
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

    }
}
