using Npgsql;

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

        public List<Product> getProducts(string searchString = "", string orderField = "title", string orderDirection = "DESC", string type = "", int offset = 0, int itemsPerPage = 100)
        {
            List<Product> result = new List<Product>();

            connection.Open();
            string commandString = $"SELECT * FROM product WHERE type LIKE '%{type}%' AND title LIKE '%{searchString}%' ORDER BY {orderField} {orderDirection} OFFSET {offset} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";
            var command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(7), reader.GetString(8), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
            }

            connection.Close();

            return result;
        }
    }
}
