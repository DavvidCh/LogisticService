using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbCarRepository : IRepository<Car>
    {
        public void Add(Car car)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Cars VALUES (@Mark)";
                    command.Parameters.Add(new SqlParameter("@Mark", car.Mark));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Cars WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(Car updatedCar)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Cars SET Mark = @Mark WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", updatedCar.Id));
                    command.Parameters.Add(new SqlParameter("@Mark", updatedCar.Mark));

                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }

        public bool Exists(string mark)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1 FROM Cars WHERE Mark = @Mark";
                    command.Parameters.Add(new SqlParameter("@Mark", mark));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
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
                    command.CommandText = "SELECT 1 FROM Cars WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public Car? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Cars WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Car()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Mark = Convert.ToString(reader["Mark"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Car> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Cars";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Car car = new Car();

                            car.Id = Convert.ToInt32(reader["Id"]);
                            car.Mark = Convert.ToString(reader["Mark"]);
                            yield return car;
                        }
                    }
                }
            }
        }

        public int GetCarIdByMark(string mark)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id FROM Cars WHERE Mark = @Mark";
                    command.Parameters.Add(new SqlParameter("@Mark", mark));
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }
            return 0;
        }
    }
}
