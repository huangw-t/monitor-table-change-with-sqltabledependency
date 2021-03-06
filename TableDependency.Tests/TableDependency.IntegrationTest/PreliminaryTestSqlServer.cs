﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableDependency.Exceptions;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Exceptions;

namespace TableDependency.IntegrationTest
{
    public class PreliminaryTestSqlServerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }
        public int Quantity { get; set; }
    }

    [TestClass]
    public class PreliminaryTestSqlServer
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SqlServer2008 Test_User"].ConnectionString;
        private const string TableName = "PreliminaryCheckTest";
        private const string InvalidValidConnectionString = "data source=.;initial catalog=NotExistingDB;integrated security=True";
        private const string InvalidTableName = "NotExistingTable";

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"IF OBJECT_ID('{TableName}', 'U') IS NOT NULL DROP TABLE [{TableName}];";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText =
                        $"CREATE TABLE [{TableName}]( " +
                        "[Id][int] IDENTITY(1, 1) NOT NULL, " +
                        "[First Name] [nvarchar](50) NOT NULL, " +
                        "[Second Name] [nvarchar](50) NOT NULL, " +
                        "[Born] [datetime] NULL)";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"DELETE FROM [{TableName}]";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"IF OBJECT_ID('{TableName}', 'U') IS NOT NULL DROP TABLE [{TableName}];";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        [TestCategory("SqlServer")]
        [TestMethod]
        [ExpectedException(typeof(ImpossibleOpenSqlConnectionException))]
        public void InvalidConnectionStringTest()
        {
            using (new SqlTableDependency<PreliminaryTestSqlServerModel>(InvalidValidConnectionString, TableName))
            {
            }
        }

        [TestCategory("SqlServer")]
        [TestMethod]
        [ExpectedException(typeof(NotExistingTableException))]
        public void InvalidTableNameTest()
        {
            using (new SqlTableDependency<PreliminaryTestSqlServerModel>(ConnectionString, InvalidTableName))
            {
            }
        }

        [TestCategory("SqlServer")]
        [TestMethod]
        [ExpectedException(typeof(ModelToTableMapperException))]
        public void MappertWithNullTest()
        {
            var mapper = new ModelToTableMapper<PreliminaryTestSqlServerModel>();
            mapper.AddMapping(c => c.Name, "FIRST name").AddMapping(c => c.Surname, null);

            using (new SqlTableDependency<PreliminaryTestSqlServerModel>(ConnectionString, TableName, mapper))
            {
            }
        }

        [TestCategory("SqlServer")]
        [TestMethod]
        [ExpectedException(typeof(ModelToTableMapperException))]
        public void MappertWithEmptyTest()
        {
            var mapper = new ModelToTableMapper<PreliminaryTestSqlServerModel>();
            mapper.AddMapping(c => c.Name, "FIRST name").AddMapping(c => c.Surname, string.Empty);

            using (new SqlTableDependency<PreliminaryTestSqlServerModel>(ConnectionString, TableName, mapper))
            {
            }
        }

        [TestCategory("SqlServer")]
        [TestMethod]
        [ExpectedException(typeof(ModelToTableMapperException))]
        public void InvalidMappertTest()
        {
            var mapper = new ModelToTableMapper<PreliminaryTestSqlServerModel>();
            mapper.AddMapping(c => c.Name, "FIRST name").AddMapping(c => c.Surname, "Not Exist");

            using (new SqlTableDependency<PreliminaryTestSqlServerModel>(ConnectionString, TableName, mapper))
            {
            }
        }

        [TestCategory("SqlServer")]
        [TestMethod]
        [ExpectedException(typeof(UpdateOfException))]
        public void EmptyUpdateOfModelListTest()
        {
            using (new SqlTableDependency<PreliminaryTestSqlServerModel>(ConnectionString, TableName, updateOf: new UpdateOfModel<PreliminaryTestSqlServerModel>()))
            {
            }
        }
    }
}