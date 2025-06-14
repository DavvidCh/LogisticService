using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbTransitRepository : IRepository<Transit>
    {
        public void Add(Transit instance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Transits VALUES(@DayCount, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@Id", instance.Id));
                    command.Parameters.Add(new SqlParameter("@DayCount", instance.DayCount));
                    command.Parameters.Add(new SqlParameter("@Coefficient", instance.Coefficient));
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
                    command.CommandText = "SELECT 1 FROM Transits WHERE Id = @Id";
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

        public IEnumerable<Transit> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Transits";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var transit = new Transit();
                            transit.Id = Convert.ToInt32(reader["Id"]);
                            transit.DayCount = Convert.ToInt32(reader["IsClosed"]);
                            transit.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
                            yield return transit;
                        }
                    }
                }
            }
        }

        public Transit? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Transits WHERE Id = @Id";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var transit = new Transit();
                            transit.Id = Convert.ToInt32(reader["Id"]);
                            transit.DayCount = Convert.ToInt32(reader["DayCount"]);
                            transit.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
                            return transit;
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
                    command.CommandText = "DELETE FROM Transits WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(Transit updatedInstance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Transit SET DayCount = @DayCount, Coefficient = @Coefficient WHERE Id = @Id";

                    command.Parameters.Add(new SqlParameter("@Id", updatedInstance.Id));
                    command.Parameters.Add(new SqlParameter("@DayCount", updatedInstance.DayCount));
                    command.Parameters.Add(new SqlParameter("@Coefficient", updatedInstance.Coefficient));
                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }
    }
}
