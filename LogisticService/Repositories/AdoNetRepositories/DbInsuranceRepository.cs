using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbInsuranceRepository : IRepository<Insurance>
    {
        public void Add(Insurance instance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Insurances VALUES(@IsIncluded, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@IsIncluded", instance.IsIncluded));
                    command.Parameters.Add(new SqlParameter("@Coefficient", instance.Coefficient));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Insurances WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(Insurance updatedInstance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Insurances SET IsIncluded = @IsIncluded, Coefficient = @Coefficient WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", updatedInstance.Id));
                    command.Parameters.Add(new SqlParameter("IsIncluded", updatedInstance.IsIncluded));
                    command.Parameters.Add(new SqlParameter("Coefficient", updatedInstance.Coefficient));

                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }

        public bool ExistsById(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1 FROM Insurances WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }   
            }
        }

        public Insurance? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM Insurances WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter($"@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var insurance = new Insurance();
                            insurance.Id = Convert.ToInt32(reader["Id"].ToString());
                            insurance.IsIncluded = Convert.ToBoolean(reader["IsIncluded"]);
                            insurance.Coefficient = Convert.ToDecimal(reader["Coefficient"].ToString());
                            return insurance;
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Insurance> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Insurances";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Insurance insurance = new Insurance();
                            insurance.Id = Convert.ToInt32(reader["Id"].ToString());
                            insurance.IsIncluded = Convert.ToBoolean(reader["IsIncluded"]);
                            insurance.Coefficient = Convert.ToDecimal(reader["Coefficient"].ToString());

                            yield return insurance;
                        }
                    }
                }
            }
        }
    }
}
