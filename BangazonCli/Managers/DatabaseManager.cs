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
            _connection.Close();
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

        public void Update(string command)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery ();
                dbcmd.Dispose ();

            }
        }

        public void CheckCustomerOrderTable () 
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = @"CREATE TABLE IF NOT EXISTS
                `CustomerOrder` (
                    `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    `PaymentId` INTEGER,
                    `CustomerId` INTEGER NOT NULL,
                    `StartedOn` TEXT NOT NULL)";

                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
                _connection.Close();
            }
        }

        public void CheckCustomerTable () 
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = @"CREATE TABLE IF NOT EXISTS
                `Customer` (
                    `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    `FirstName` TEXT NOT NULL,
                    `LastName` TEXT NOT NULL,
                    `Address`TEXT NOT NULL,
                    `City` TEXT NOT NULL,
                    `State` TEXT NOT NULL,
                    `PostalCode` TEXT NOT NULL,
                    `PhoneNumber` TEXT NOT NULL,
                    `CreatedOn` TEXT NOT NULL,
                    `LastLogin` TEXT NOT NULL)";

                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
                _connection.Close();
            }
        }

        public void CheckProductTable () 
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = @"CREATE TABLE IF NOT EXISTS
                `Product` (
                `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                `CustomerId` INTEGER NOT NULL,
                `Price` INTEGER NOT NULL,
                `Name` TEXT NOT NULL,
                `Description` TEXT NOT NULL,
                `Quantity` INTEGER NOT NULL,
                `QuantitySold` INTEGER,
                `CreatedOn` TEXT NOT NULL,
                FOREIGN KEY(`CustomerId`) REFERENCES `Customer`(`Id`)
                )";

                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
                _connection.Close();
            }
        }

        public void CheckPaymentTypeTable () 
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = @"CREATE TABLE IF NOT EXISTS
                `PaymentType` (
                    `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    `CustomerId` TEXT NOT NULL,
                    `AccountNumber` TEXT NOT NULL,
                    `Name` TEXT NOT NULL
                    )";

                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
                _connection.Close();
            }
        }

        public void CheckProductOrderJoinTable () 
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = @"CREATE TABLE IF NOT EXISTS
                `ProductOrderJoin` (
                    `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    `ProductId` TEXT NOT NULL,
                    `OrderId` TEXT NOT NULL
                    )";

                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
                _connection.Close();
            }
        }

        public void CheckTables()
        {
            this.CheckCustomerTable();
            this.CheckProductTable();
            this.CheckPaymentTypeTable();
            this.CheckProductOrderJoinTable();
            this.CheckCustomerOrderTable();
        }
    }
}