using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbContainerRepository : IRepository<Container>
    {
        public void Add(Container instance)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Containers VALUES(@IsClosed, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@Id", instance.Id));
                    command.Parameters.Add(new SqlParameter("@IsClosed", instance.IsClosed));
                    command.Parameters.Add(new SqlParameter("@Coefficient", instance.Id));
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
                    command.CommandText = "SELECT 1 FROM Containers WHERE Id = @Id";
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

        public IEnumerable<Container> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Containers";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var container = new Container();
                            container.Id = Convert.ToInt32(reader["Id"]);
                            container.IsClosed = Convert.ToBoolean(reader["IsClosed"]);
                            container.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
                            yield return container;
                        }
                    }
                }
            }
        }

        public Container? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Containers WHERE Id = @Id";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var container = new Container();
                            container.Id = Convert.ToInt32(reader["Id"]);
                            container.IsClosed = Convert.ToBoolean(reader["IsClosed"]);
                            container.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
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
                    command.CommandText = "DELETE FROM Containers WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(Container updatedInstance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Containers SET IsClosed = @IsClosed, Coefficient = @Coefficient WHERE Id = @Id";

                    command.Parameters.Add(new SqlParameter("@Id", updatedInstance.Id));
                    command.Parameters.Add(new SqlParameter("@IsClosed", updatedInstance.IsClosed));
                    command.Parameters.Add(new SqlParameter("@Coefficient", updatedInstance.Coefficient));
                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }
    }
}
