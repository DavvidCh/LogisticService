using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbDirectionRepository : IRepository<Direction>
    {
        public void Add(Direction instance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Directions VALUES(@FromLocation, @ToLocation, @Distance, @Price)";
                    command.Parameters.Add(new SqlParameter("@Id", instance.Id));
                    command.Parameters.Add(new SqlParameter("@FromLocation", instance.FromLocation));
                    command.Parameters.Add(new SqlParameter("@ToLocation", instance.ToLocation));
                    command.Parameters.Add(new SqlParameter("@Distance", instance.Distance));
                    command.Parameters.Add(new SqlParameter("@Price", instance.Price));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1 FROM Directions WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            return false;
        }

        public IEnumerable<Direction> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Directions";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var container = new Direction();
                            container.Id = Convert.ToInt32(reader["Id"]);
                            container.FromLocation = Convert.ToString(reader["FromLocation"]);
                            container.ToLocation = Convert.ToString(reader["ToLocation"]);
                            container.Distance = Convert.ToDecimal(reader["Distance"]);
                            container.Price = Convert.ToDecimal(reader["Price"]);
                            yield return container;
                        }
                    }
                }
            }
        }

        public Direction? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Directions WHERE Id = @Id";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var container = new Direction();
                            container.Id = Convert.ToInt32(reader["Id"]);
                            container.FromLocation = Convert.ToString(reader["FromLocation"]);
                            container.ToLocation = Convert.ToString(reader["ToLocation"]);
                            container.Distance = Convert.ToDecimal(reader["Distance"]);
                            container.Price = Convert.ToDecimal(reader["Price"]);
                            return container;
                        }
                    }
                }
            }
            return null;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Directions WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(Direction updatedInstance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Directions SET FromLocation = @FromLocation, ToLocation = @ToLocation,  WHERE Id = @Id";

                    command.Parameters.Add(new SqlParameter("@Id", updatedInstance.Id));
                    command.Parameters.Add(new SqlParameter("@FromLocation", updatedInstance.FromLocation));
                    command.Parameters.Add(new SqlParameter("@ToLocation", updatedInstance.ToLocation));
                    command.Parameters.Add(new SqlParameter("@Distance", updatedInstance.Distance));
                    command.Parameters.Add(new SqlParameter("@Price", updatedInstance.Price));
                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }
    }
}
