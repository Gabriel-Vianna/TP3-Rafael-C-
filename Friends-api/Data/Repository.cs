using Dapper;
using Friends_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Friends_api.Data
{
    public class Repository
    {
        private string ConnectionString = "Server=tcp:infnet.database.windows.net,1433;Initial Catalog=friends-database;Persist Security Info=False;User ID=gvianna;Password=Ervilhag140994;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        public List<Friends> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM Friends";
                return connection.Query<Friends>(sql).ToList();
            }
        }

        public Friends GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM Friends where id = @id";
                return connection.QueryFirstOrDefault<Friends>(sql, new { id = id });
            }

        }

        public int Save(Friends friend)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = @"    INSERT INTO Friends (FirstName, LastName, Email, Phone, BirthDate)
                                                   Values (@FirstName, @LastName, @Email, @Phone, @BirthDate);
                                       SELECT @@IDENTITY;
                            ";

                var lastId = connection.ExecuteScalar<int>(sql, friend);
                return lastId;
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = @"DELETE FROM Friends where id = @id";

                connection.Execute(sql, new { id = id});
            }
        }

        public int Update(Friends friend)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = @"UPDATE Friends SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, BirthDate = @BirthDate
                            WHERE id = @id";

                var friendUpdated = connection.Execute(sql, friend);
                return friendUpdated;
            }
        }
    }
}
