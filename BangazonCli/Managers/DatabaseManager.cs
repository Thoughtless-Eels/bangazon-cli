using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class DatabaseManager
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseInterface()
        {
            // Replace {you} with the correct value
            _connectionString = $"Data Source=/home/gward2489/workspace/group-projects/bangazon-cli/bangazonCli.db";
            _connection = new SqliteConnection(_connectionString);
        }


        public void CheckCustomerTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `Id` FROM `Customer`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Customer` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `FirstName` TEXT NOT NULL,
                            `LastName` TEXT NOT NULL,
                            `City` TEXT NOT NULL,
                            `State` TEXT NOT NULL,
                            `Postal Code` TEXT NOT NULL,
                            `PhoneNumber` TEXT NOT NULL,
                            `CreatedOn` TEXT NOT NULL,
                            `DaysInactive` TEXT NOT NULL                                                                                                                
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
    }
}