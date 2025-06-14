using LogisticService.Enums;
using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbCarBodyTypeRepository : IRepository<CarBodyType>
    {
        public void Add(CarBodyType carBodyType)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO CarBodyTypes VALUES(@BodyType, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@BodyType", carBodyType.BodyType.ToString()));
                    command.Parameters.Add(new SqlParameter("@Coefficient", carBodyType.Coefficient));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remove(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM CarBodyTypes WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(CarBodyType updatedCarBodyType)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE CarBodyTypes SET BodyType = @BodyType, Coefficient = @Coefficient WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", updatedCarBodyType.Id));
                    command.Parameters.Add(new SqlParameter("@BodyType", updatedCarBodyType.BodyType.ToString()));
                    command.Parameters.Add(new SqlParameter("@Coefficient", updatedCarBodyType.Coefficient));

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
                    command.CommandText = "SELECT 1 FROM CarBodyTypes WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public CarBodyType? GetById(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CarBodyTypes WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var carBodyType = new CarBodyType();
                            carBodyType.Id = Convert.ToInt32(reader["Id"]);
                            carBodyType.BodyType = Enum.Parse<BodyType>(Convert.ToString(reader["BodyType"]));
                            carBodyType.Coefficient = Convert.ToDecimal(reader["Coefficient"]);
                            return carBodyType;
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<CarBodyType> GetAll()
        {
            using(SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CarBodyTypes";
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new CarBodyType()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                BodyType = Enum.Parse<BodyType>(Convert.ToString(reader["BodyType"])),
                                Coefficient = Convert.ToDecimal(reader["Coefficient"])
                            };
                        }
                    }
                }
            }
        }

        public int GetCarBodyTypeIdByName(string bodyTypeName)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Id FROM CarBodyTypes WHERE BodyType = @BodyType", connection))
                {
                    command.Parameters.Add(new SqlParameter("@BodyType", bodyTypeName));
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            throw new Exception($"Car Body Type '{bodyTypeName}' not found.");
        }

        //public CarBodyType GetCarBodyTypeById(int id)
        //{

        //    using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
        //    {
        //        connection.Open();
        //        var carBodyType = new CarBodyType();

        //        using (SqlCommand command = new SqlCommand(
        //            "SELECT * FROM CarBodyTypes WHERE Id = @Id", connection))
        //        {
        //            command.Parameters.Add(new SqlParameter("@Id", id));

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    carBodyType = new CarBodyType
        //                    {
        //                        Id = Convert.ToInt32(reader["Id"]),
        //                        BodyType = (BodyType)(Convert.ToInt32(reader["BodyType"])),
        //                        Coefficient = Convert.ToDecimal(reader["Coefficient"])
        //                    };
        //                }
        //            }
        //        }
        //        return carBodyType;
        //    }
        //}
    }
}
