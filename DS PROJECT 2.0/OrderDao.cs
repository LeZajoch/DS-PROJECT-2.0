using Microsoft.Data.SqlClient;

namespace DS_PROJECT_2._0;

public class OrderDao
{
    /// <summary>
    /// Creates Order, takes data from user and pushes them into DBServer
    /// </summary>
    /// <param name="OrderId"></param>
    /// <param name="CustomerId"></param>
    /// <param name="OrderDate"></param>
    /// <param name="OrderState"></param>
    /// <param name="consStringBuilder"></param>
    public static void CreateOrder(int OrderId, int CustomerId, DateOnly OrderDate, string OrderState,
        SqlConnectionStringBuilder consStringBuilder)
    {
        using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
        {
            string query = "insert into Ord_r (OrderId, CustomerId, OrderDate, OrderState) values (@id, @Customer_id, @orderDate ,@orderState)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", OrderId);
            command.Parameters.AddWithValue("@Customer_id", CustomerId);
            command.Parameters.AddWithValue("@orderDate", OrderDate);
            command.Parameters.AddWithValue("@orderState", OrderState);
        }
    }
    /// <summary>
    /// Deletes a customer from DBServer
    /// </summary>
    /// <param name="OrderId"></param>
    /// <param name="consStringBuilder"></param>
    public static void DeleteOrder(int OrderId, SqlConnectionStringBuilder consStringBuilder)
    {
        using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
        {
            string query = "delete from Ord_r where id =@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", OrderId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    /// <summary>
    /// Edits the Customer on DBServer using data from user 
    /// </summary>
    /// <param name="OrderId"></param>
    /// <param name="CustomerId"></param>
    /// <param name="OrderDate"></param>
    /// <param name="OrderState"></param>
    /// <param name="consStringBuilder"></param>
    public static void EditOrder(int OrderId, int CustomerId, DateOnly OrderDate, string OrderState,
        SqlConnectionStringBuilder consStringBuilder)
    {
        using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
        {
            string query = "update Ord_r set CustomerId = @Customer_id, OrderDate = @orderDate, OrderState = @orderState where OrderID = @OrderId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", OrderId);
            command.Parameters.AddWithValue("@Customer_id", CustomerId);
            command.Parameters.AddWithValue("@orderDate", OrderDate);
            command.Parameters.AddWithValue("@orderState", OrderState);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    
    
    
    
    
    
}