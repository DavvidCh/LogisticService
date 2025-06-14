using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbCarConditionRepository : IRepository<CarCondition>
    {
        public void Add(CarCondition condition)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO CarConditions VALUES(@IsRunning, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@IsRunning", condition.IsRunning));
                    command.Parameters.Add(new SqlParameter("@Coefficient", condition.Coefficient));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1 FROM CarConditions WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    
                    using(SqlDataReader reader = command.ExecuteReader())
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

        public IEnumerable<CarCondition> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CarConditions";

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var carCondition = new CarCondition();
                            carCondition.Id = Convert.ToInt32(reader["Id"]);
                            carCondition.IsRunning = Convert.ToBoolean(reader["IsRunning"]);
                            carCondition.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
                            yield return carCondition;
                        }
                    }
                }
            }
        }

        public CarCondition? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CarConditions WHERE Id = @Id";

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var carCondition = new CarCondition();
                            carCondition.Id = Convert.ToInt32(reader["Id"]);
                            carCondition.IsRunning = Convert.ToBoolean(reader["IsRunning"]);
                            carCondition.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
                            return carCondition;
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
                    command.CommandText = "DELETE FROM CarConditions WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(CarCondition updatedInstance)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE CarConditions SET IsRunning = @IsRunning, Coefficient = @Coefficient WHERE Id = @Id";

                    command.Parameters.Add(new SqlParameter("@Id", updatedInstance.Id));
                    command.Parameters.Add(new SqlParameter("@IsRunning", updatedInstance.IsRunning));
                    command.Parameters.Add(new SqlParameter("@Coefficient", updatedInstance.Coefficient));
                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }
    }
}
