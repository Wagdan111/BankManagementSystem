using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public  class clsDataLog
    {
        
        public   DataTable  ShowDataLog()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Qurey = "select UserName,DataTime,FirstName,LastName,Phone,Password,Permitions from Users join LogData on LogData.UserID=Users.ID";

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
        public  int AddDataLog(DateTime LogData, int IDUser)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            int Number = -1;

           
            


            string query = @" INSERT INTO LogData
           (DataTime,UserID)
          VALUES (@LogData,@IDUser);
             select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LogData", LogData);
            command.Parameters.AddWithValue("@IDUser", IDUser);

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

            }
            finally
            {
                connection.Close();
            }

            return Number;
        }
        public  DataTable SearcehByName(string Name)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select UserName, DataTime, FirstName, LastName, Phone, Password, Permitions from Users join LogData on LogData.UserID = Users.ID where UserName=@Name";

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
    }
}
