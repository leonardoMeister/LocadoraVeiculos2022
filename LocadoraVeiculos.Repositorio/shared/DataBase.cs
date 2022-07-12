using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraVeiculos.RepositorioProject.shared
{
    public delegate T ConverterDelegate<T>(IDataReader reader);

    public static class DataBase
    {
        private static readonly string connectionString;
        private static readonly string nomeProvider;
        private static readonly SqlConnection conection;


        static DataBase()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            connectionString = configuracao
                .GetSection("ConnectionStrings")
                .GetSection("SqlServer")
                .Value;

            nomeProvider = "System.Data.SqlClient";

            conection = new SqlConnection(connectionString);
        }

        public static void Insert(string sql, Dictionary<string, object> parameters)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql.AppendSelectIdentity();
            command.Connection = connection;
            command.SetParameters(parameters);

            connection.Open();

            var id = command.ExecuteNonQuery();
        }

        public static void Update(string sql, Dictionary<string, object> parameters = null)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql;

            command.Connection = connection;

            command.SetParameters(parameters);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public static void Delete(string sql, Dictionary<string, object> parameters)
        {
            Update(sql, parameters);
        }

        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters = null)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql;

            command.Connection = connection;

            command.SetParameters(parameters);

            connection.Open();

            var list = new List<T>();

            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var obj = convert(reader);
                list.Add(obj);
            }

            return list;
        }

        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql;

            command.Connection = connection;

            command.SetParameters(parameters);

            connection.Open();

            T t = default;

            using IDataReader reader = command.ExecuteReader();

            if (reader.Read())
                t = convert(reader);

            return t;
        }

        public static void InsertNoReturn(string sql, Dictionary<string, object> parameters)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql;
            command.Connection = connection;
            command.SetParameters(parameters);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public static void ExecutarComando(string sql)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql;
            command.Connection = connection;

            connection.Open();
            command.ExecuteNonQuery();
        }

        public static bool Exists(string sql, Dictionary<string, object> parameters)
        {
            using IDbConnection connection = conection;
            connection.ConnectionString = connectionString;

            using IDbCommand command = conection.CreateCommand();
            command.CommandText = sql;

            command.Connection = connection;

            command.SetParameters(parameters);

            connection.Open();

            int numberRows = Convert.ToInt32(command.ExecuteScalar());

            return numberRows > 0;
        }

        private static void SetParameters(this IDbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                string name = parameter.Key;

                object value = parameter.Value.IsNullOrEmpty() ? DBNull.Value : parameter.Value;

                IDataParameter dbParameter = command.CreateParameter();

                dbParameter.ParameterName = name;
                dbParameter.Value = value;

                command.Parameters.Add(dbParameter);
            }
        }

        private static string AppendSelectIdentity(this string sql)
        {
            return nomeProvider switch
            {
                "System.Data.SqlClient" => sql + ";SELECT SCOPE_IDENTITY()",
                "System.Data.SQLite" => sql + ";SELECT LAST_INSERT_ROWID()",
                _ => sql,
            };
        }

        public static bool IsNullOrEmpty(this object value)
        {
            return (value is string @string && string.IsNullOrEmpty(@string)) ||
                    value == null;
        }
    }
}
