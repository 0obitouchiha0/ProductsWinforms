using Npgsql;
using System.Text;

namespace products
{
    internal class DB
    {
        NpgsqlConnection connection;

        public DB(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public NpgsqlConnection getConnection()
        {
            return connection;
        }

        public List<Product> getProducts(string searchString = "", string orderField = "name", string orderDirection = "DESC", string type = "", int offset = 0, int itemsPerPage = 100)
        {
            List<Product> result = new List<Product>();

            connection.Open();
            string commandString = $"SELECT * FROM product WHERE type LIKE '%{type}%' AND name LIKE '%{searchString}%' ORDER BY {orderField} {orderDirection} OFFSET {offset} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";
            var command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Product(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5)));
            }

            connection.Close();

            return result;
        }

        public List<Product> findProducts(string searchString)
        {
            List<Product> result = new List<Product>();

            connection.Open();
            string commandString = $"SELECT * FROM product WHERE name LIKE '%{searchString}%'";
            var command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Product(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5)));
            }

            connection.Close();

            return result;
        }
    }
}
