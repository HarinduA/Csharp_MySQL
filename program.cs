using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Define the connection string (adjust this as necessary for your environment)
        string connectionString = "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;";

        // Create the SQL query for inserting data
        string insertQuery = "INSERT INTO your_table_name (Column1, Column2) VALUES (@Value1, @Value2)";

        // Establish the connection using the SqlConnection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Open the connection
                connection.Open();
                Console.WriteLine("Connection Opened");

                // Create the SqlCommand object and pass the query and the connection object
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Define parameters and add values to prevent SQL injection
                    command.Parameters.AddWithValue("@Value1", "SomeValue");
                    command.Parameters.AddWithValue("@Value2", 123);

                    // Execute the command
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
                Console.WriteLine("Connection Closed");
            }
        }
    }
}
