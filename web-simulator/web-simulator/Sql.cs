using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace web_simulator
{
    class Sql : ILog
    {
        ///public static readonly SqlConnection Connection;
        private static readonly string[] TableWhiteList = { "UserConsume", "UserProduce", "UserMethods" };
        private static readonly string Conn = ConfigurationManager.ConnectionStrings["local"].ConnectionString;


         public static void LogUserDequeue(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime)
        {
            if (!TableWhiteList.Contains(location)) return;
            var sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0} VALUES(@userType, @userName, @thread, @consumeDateTime)", location);
            var sql = sb.ToString();
            using (var connection = new SqlConnection(Conn))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userType", typeOfUser);
                    command.Parameters.AddWithValue("@userName", nameOfUser);
                    command.Parameters.AddWithValue("@thread", threadCount);
                    command.Parameters.AddWithValue("@consumeDateTime", dateTime);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

         public static void LogUserEnqueue(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
        {
            if (!TableWhiteList.Contains(location)) return;
            var sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0} VALUES(@userType, @userName, @produceDateTime)", location);
            var sql = sb.ToString();
            using (var connection = new SqlConnection(Conn))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userType", typeOfUser);
                    command.Parameters.AddWithValue("@userName", nameOfUser);
                    command.Parameters.AddWithValue("@produceDateTime", dateTime);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

         public static void LogEachMethod(string location, string typeOfUser, string nameOfUser, string methods, DateTime start, DateTime end)
        {
            if (!TableWhiteList.Contains(location)) return;
            var sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0} VALUES(@typeOfUser, @nameOfUser, @methods, @start, @end)", location);

            var sql = sb.ToString();

            using (var connection = new SqlConnection(Conn))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@typeOfUser", typeOfUser);
                    command.Parameters.AddWithValue("@nameOfUser", nameOfUser);
                    command.Parameters.AddWithValue("@methods", methods);
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@end", end);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

         void ILog.LogEachMethod(string location, string typeOfUser, string nameOfUser, string methods, DateTime start, DateTime end)
         {
             LogEachMethod(location, typeOfUser, nameOfUser, methods, start, end);
         }

        void ILog.LogDequeue(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime)
        {
            LogUserDequeue(location, typeOfUser, nameOfUser, threadCount, dateTime);
        }

        void ILog.LogEnqueue(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
        {
            LogUserEnqueue(location, typeOfUser, nameOfUser, dateTime);
        }
    }
}
