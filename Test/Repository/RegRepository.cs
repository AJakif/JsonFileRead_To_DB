using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using Test.Models;
using Test.Repository.IRepository;

namespace Test.Repository
{
    public class RegRepository : IRegRepository
    {
        private readonly IConfiguration _config;

        public RegRepository(IConfiguration config)
        {
            _config = config;
        }

        public int AddUser(RegestrationModel reg)
        {
            //if user exists then returns to Account controller and redirects to register view
            string Query = "Insert into [dbo].[User] (Name,Phone,Email,Password,Address)" +
                $"values ('{reg.Name}','{reg.Phone}','{reg.Email}','{reg.Password}','{reg.Address}')";
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                connection.Close();
                return Result;
            }
            catch (Exception e)
            {
                Console.Write(e);
                connection.Close();
                return -1;
            }
        }
    }
}
