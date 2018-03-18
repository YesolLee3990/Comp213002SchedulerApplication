using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web;

namespace Comp213002SchedulerApplication.App_Code.controls.util {
    public class DBUtil {

        public static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
        }

        public static bool HasData(string query) {
            return Select(query).Rows.Count > 0;
        }

        public static DataTable Select(string query) {
            DataTable table = new DataTable();

            using (SqlConnection cn = new SqlConnection(GetConnectionString())) {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cn)) {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        adapter.Fill(table);
                    }
                }
                cn.Close();
            }

            return table;
        }

        public static DataRow SelectOne(string query) {
            if (Select(query).Rows.Count == 0) return null;
            else return Select(query).Rows[0];
        }

        public static T SelectOne<T>(string query)
         where T : new() {
            DataRow dataRow = SelectOne(query);
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns) {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value) {
                    object result = Convert.ChangeType(dataRow[column], property.PropertyType);
                    property.SetValue(item, result, null);
                }
            }

            return item;
        }

        public static void ExecuteWithTransaction(List<string> sqls) {

            using (SqlConnection db = new SqlConnection(GetConnectionString())) {
                db.Open();
                SqlTransaction transaction = db.BeginTransaction();
                try {
                    foreach (string sql in sqls) {
                        new SqlCommand(sql, db, transaction).ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (SqlException sqlError) {
                    transaction.Rollback();
                    throw sqlError;
                }
                db.Close();
            }
        }

        public static int GetNewId(string tableName) {
            return int.Parse(SelectOne("SELECT ISNULL(MAX(ID) + 1, 1) AS ID FROM " + tableName)["id"].ToString());
        }

        public static int Execute(string sql) {
            int affected = 0;
            using (SqlConnection cn = new SqlConnection(GetConnectionString())) {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn)) {
                    affected = cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
            return affected;
        }

        public static T GV<T>(DataTable dt, string colName) {
            return (T)dt.Rows[0][colName];
        }

        public static List<string> SelectOneColumn(string sql, string colName) {
            List<string> list = new List<string>();
            DataTable dt = Select(sql);
            foreach (DataRow dr in dt.Rows) {
                list.Add(((string)dr[colName]));
            }
            return list;
        }
    }
}