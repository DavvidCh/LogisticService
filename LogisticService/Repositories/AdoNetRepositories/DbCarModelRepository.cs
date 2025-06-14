using LogisticService.Enums;
using LogisticService.Helpers;
using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.Data.SqlClient;

namespace LogisticService.Repositories.AdoNetRepositories
{
    internal class DbCarModelRepository : IRepository<CarModel>
    {
        public void Add(CarModel carModel)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO CarModels VALUES(@Model, @Year, @CarId, @CarBodyTypeId";
                    command.Parameters.Add(new SqlParameter("@Model", carModel.Model));
                    command.Parameters.Add(new SqlParameter("@Year", carModel.Year));
                    command.Parameters.Add(new SqlParameter("@CarId", carModel.CarId));
                    command.Parameters.Add(new SqlParameter("@CarBodyTypeId", carModel.CarBodyTypeId));

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
                    command.CommandText = "DELETE FROM CarModels WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Update(CarModel updatedcarModel)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                int rowsAffected;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE CarModels SET Mark = @Model, Year = @Year, CarId = @CarId, CarBodyTypeId = @CarBodyTypeId";
                    command.Parameters.Add(new SqlParameter("@Model", updatedcarModel.Model));
                    command.Parameters.Add(new SqlParameter("@Year", updatedcarModel.Year));
                    command.Parameters.Add(new SqlParameter("@CarId", updatedcarModel.CarId));
                    command.Parameters.Add(new SqlParameter("@CarBodyTypeId", updatedcarModel.CarBodyTypeId));

                    rowsAffected = command.ExecuteNonQuery();
                }
                return rowsAffected > 0;
            }
        }

        public bool ExistsById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1 FROM CarModels WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public bool Exists(string model, int year)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1 FROM CarModels WHERE Model = @Model AND Year = @Year";
                    command.Parameters.Add(new SqlParameter("@Model", model));
                    command.Parameters.Add(new SqlParameter("@Year", year));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public CarModel? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CarModels WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new CarModel()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Model = Convert.ToString(reader["Model"]),
                                Year = Convert.ToInt32(reader["Year"]),
                                CarId = Convert.ToInt32(reader["CarId"]),
                                CarBodyTypeId = Convert.ToInt32(reader["CarBodyTypeId"])
                            };
                        }
                    }
                }
                return null;
            }
        }

        public IEnumerable<CarModel> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CarModels";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarModel carModel = new CarModel();

                            carModel.Id = Convert.ToInt32(reader["Id"]);
                            carModel.Model = Convert.ToString(reader["Model"]);
                            carModel.Year = Convert.ToInt32(reader["Year"]);
                            carModel.CarBodyTypeId = Convert.ToInt32(reader["CarBodyTypeId"]);
                            carModel.CarBodyType = GetCarBodyTypeById(carModel.CarBodyTypeId);
                            carModel.CarId = Convert.ToInt32(reader["CarId"]);

                            yield return carModel;
                        }
                    }
                }
            }
        }

        public IEnumerable<CarModel> GetCarModelsByCarId(int carId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Model, Year, CarBodyTypeId FROM CarModels WHERE CarId = @CarId";
                    command.Parameters.Add(new SqlParameter("@CarId", carId));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var model = new CarModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Model = Convert.ToString(reader["Model"]),
                                Year = Convert.ToInt32(reader["Year"]),
                                CarBodyTypeId = Convert.ToInt32(reader["CarBodyTypeId"]),
                                CarId = carId,
                            };
                            yield return model;
                        }
                    }
                }
            }
        }

        public CarBodyType GetCarBodyTypeById(int id)
        {

            using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                var carBodyType = new CarBodyType();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM CarBodyTypes WHERE Id = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carBodyType = new CarBodyType
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                BodyType = (BodyType)(Convert.ToInt32(reader["BodyType"])),
                                Coefficient = Convert.ToDecimal(reader["Coefficient"])
                            };
                        }
                    }
                }
                return carBodyType;
            }
        }
    }
}
