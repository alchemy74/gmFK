using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmFucker.DataAccess.Adapters
{

    /// <summary>
    /// 資料庫連接的基底型別
    /// </summary>
    public abstract class DataAdapterBase
    {
        /// <summary>
        /// 執行資料庫預存程序
        /// </summary>
        /// <param name="storedProcedureName">資料庫預存程序名稱</param>
        /// <param name="sqlParameters">資料庫預存程序參數</param>
        /// <returns>受影響的資料筆數</returns>
        protected int executeStoredProcedure(string storedProcedureName, params SqlParameter[] sqlParameters)
        {
            int affectedDataRowCount = 0;
            using (SqlConnection connection = new SqlConnection(this.ConnectString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (sqlParameters != null)
                {
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        command.Parameters.Add(sqlParameter);
                    }
                }
                connection.Open();
                affectedDataRowCount = command.ExecuteNonQuery();
                connection.Close();
            }
            return affectedDataRowCount;
        }

        /// <summary>
        /// 執行資料庫預存程序,並以字典型別作為預存程序參數進行資料傳輸
        /// </summary>
        /// <param name="storedProcedureName">資料庫預存程序名稱</param>
        /// <param name="sqlParameters">資料庫預存程序參數</param>
        /// <returns>受影響的資料筆數</returns>
        protected int executeStoredProcedure(string storedProcedureName, Dictionary<string, object> sqlParameters = null)
        {
            int affectedDataRowCount = 0;
            using (SqlConnection connection = new SqlConnection(this.ConnectString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (sqlParameters != null)
                {
                    foreach (string key in sqlParameters.Keys)
                    {
                        command.Parameters.AddWithValue(key, sqlParameters[key]);
                    }
                }
                connection.Open();
                affectedDataRowCount = command.ExecuteNonQuery();
                connection.Close();
            }
            return affectedDataRowCount;
        }

        /// <summary>
        /// 執行資料庫預存程序並回傳資料
        /// </summary>
        /// <typeparam name="T">回傳資料的型別</typeparam>
        /// <param name="storedProcedureName">資料庫預存程序名稱</param>
        /// <param name="sqlParameters">資料庫預存程序參數</param>
        /// <returns>資料實體集合</returns>
        protected IEnumerable<T> executeStoredProcedure_WithReturnValue<T>(string storedProcedureName, Func<SqlDataReader, T> getEntityData, Dictionary<string, object> sqlParameters = null)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (sqlParameters != null)
                    {
                        foreach (string key in sqlParameters.Keys)
                        {
                            command.Parameters.AddWithValue(key, sqlParameters[key]);
                        }
                    }
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return getEntityData(reader);
                    }
                    connection.Close();
                }
            }
        }


        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        private string ConnectString { get; } = ConfigurationManager.ConnectionStrings[" Your Custom DataBase Name "].ToString();
    }
}
