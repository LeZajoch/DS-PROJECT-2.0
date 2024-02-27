
using Microsoft.Data.SqlClient;

namespace DS_PROJECT_2._0;

public class CustomerDao
{
    /// <summary>
    /// Creates Customer, takes data from user and pushes them into DBServer
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <param name="CustomerName"></param>
    /// <param name="Surname"></param>
    /// <param name="Address"></param>
    /// <param name="Email"></param>
    /// <param name="Telephone"></param>
    /// <param name="consStringBuilder"></param>
    public static void CreateCustomer(int CustomerId, string CustomerName, string Surname, string Address, string Email,
        string Telephone, SqlConnectionStringBuilder consStringBuilder)
    {
        using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
        {
            string query = "insert into Customer (CustomerId, CustomerName, Surname, Address, Email, Telephone) values (@id, @name, @surname, @address, @email, @telephone)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", CustomerId);
            command.Parameters.AddWithValue("@name", CustomerName);
            command.Parameters.AddWithValue("@surname", Surname);
            command.Parameters.AddWithValue("@address", Address);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@telephone", Telephone);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
/// <summary>
/// Deletes a customer from DBServer
/// </summary>
/// <param name="CustomerId"></param>
/// <param name="consStringBuilder"></param>
    public static void DeleteCustomer(int CustomerId, SqlConnectionStringBuilder consStringBuilder)
    {
        using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
        {
            string query = "delete from customer where id =@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", CustomerId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
/// <summary>
/// Edits the Customer on DBServer using data from user 
/// </summary>
/// <param name="CustomerId"></param>
/// <param name="CustomerName"></param>
/// <param name="Surname"></param>
/// <param name="Address"></param>
/// <param name="Email"></param>
/// <param name="Telephone"></param>
/// <param name="consStringBuilder"></param>
    public static void EditCustomer(int CustomerId,  string CustomerName, string Surname, string Address, string Email,
        string Telephone, SqlConnectionStringBuilder consStringBuilder)
    {
        using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
        {
            string query = "update Customer set CustomerName = @name, Surname = @surname, Address = @address, Email = @email, Telephone = @telephone where CustomerID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", CustomerId);
            command.Parameters.AddWithValue("@name", CustomerName);
            command.Parameters.AddWithValue("@surname", Surname);
            command.Parameters.AddWithValue("@address", Address);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@telephone", Telephone);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

}