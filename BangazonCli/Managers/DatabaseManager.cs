using System.Linq;
using System;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class DatabaseManager
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseManager(string dbLocation)
        {
            _connectionString = $"Data Source={System.Environment.GetEnvironmentVariable(dbLocation)}";
            _connection = new SqliteConnection(_connectionString);
        }

        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                dbcmd.ExecuteNonQuery ();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose ();
            }

            return insertedItemId;
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader())
                {
                    handler (dataReader);
                }

                dbcmd.Dispose ();
            }
        }


        public void CheckCustomerTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `CustomerId` FROM `Customer`";

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
        public void CheckOrderTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `OrderId` FROM `CustomerOrder`";

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
                        dbcmd.CommandText = $@"CREATE TABLE `CustomerOrder` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `PaymentId` TEXT NOT NULL,
                            `CustomerId` TEXT NOT NULL,
                            `StartedOn` TEXT NOT NULL                                                                                                            
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
        public void CheckProductTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `ProductId` FROM `Product`";

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
                        dbcmd.CommandText = $@"CREATE TABLE `Product` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `CustomerId` TEXT NOT NULL,
                            `Price` TEXT NOT NULL,
                            `Name` TEXT NOT NULL,
                            `Description` TEXT NOT NULL,
                            `Quantity` TEXT NOT NULL,
                            `AmtSold` TEXT NOT NULL,
                            `CreatedOn` TEXT NOT NULL
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
        public void CheckProductOrderJoinTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `ProductOrderJoinId` FROM `ProductOrderJoin`";

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
                            `ProductId` TEXT NOT NULL,
                            `OrderId` TEXT NOT NULL,
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
        public void CheckPaymentTypeTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `PaymentTypeId` FROM `PaymentType`";

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
                        dbcmd.CommandText = $@"CREATE TABLE `PaymentType` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `CustomerId` TEXT NOT NULL,
                            `AccountNumber` TEXT NOT NULL,
                            `Name` TEXT NOT NULL,
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