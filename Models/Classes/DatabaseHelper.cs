using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CoffeeManagementSystem.Models.Classes
{
    public static class DatabaseHelper
    {
        // Connection string is now externalized to App.config
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["CoffeeDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Used for SELECT statements. Returns a DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Used for INSERT, UPDATE, DELETE. Returns number of rows affected.
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Used for getting a single value (e.g., COUNT, SUM, or SCOPE_IDENTITY).
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Handles complex tasks like saving a Report + its Details.
        /// Automatically rolls back both if one fails.
        /// </summary>
        public static void ExecuteTransaction(Action<SqlTransaction> action)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        action(trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        // Log the error here if needed
                        throw new Exception("Transaction failed and was rolled back: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Overload to allow running a query inside an existing transaction.
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters, SqlTransaction trans)
        {
            using (SqlCommand cmd = new SqlCommand(query, trans.Connection, trans))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Useful for checking the next manual ID or getting a specific count.
        /// Note: For IDENTITY columns, use SELECT SCOPE_IDENTITY() after an insert instead.
        /// </summary>
        public static int GetNextId(string tableName, string idColumn = "ID")
        {
            string query = $"SELECT ISNULL(MAX([{idColumn}]), 0) + 1 FROM [{tableName}]";
            return Convert.ToInt32(ExecuteScalar(query));
        }
    }
}