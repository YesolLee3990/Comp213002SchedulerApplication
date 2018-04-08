using Comp213002SchedulerApplication.AppCode.controls.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Comp213002SchedulerApplication.AppCode.controls.util {
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
            DataTable dt = Select(query);
            if (dt.Rows.Count == 0) return null;
            else return dt.Rows[0];
        }

        public static T SelectOne<T>(string query)
         where T : new() {
            DataRow dataRow = SelectOne(query);
            T item = new T();
            if (dataRow != null) {
                foreach (DataColumn column in dataRow.Table.Columns) {
                    PropertyInfo property = item.GetType().GetProperty(column.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (property != null && dataRow[column] != DBNull.Value) {
                        object result = Convert.ChangeType(dataRow[column], property.PropertyType);
                        property.SetValue(item, result, null);
                    }
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

        private const string comma = ", ";

        public static String BuildUpdateQuery(Object obj, String[] colnames) {
            string sql = "UPDATE " + obj.GetType().Name + " SET ";
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (string col in colnames) {
                foreach (PropertyInfo prop in props.Where(prop => prop.Name.ToUpper() == col.ToUpper())) {
                    object val = prop.GetValue(obj);

                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(val.ToString(), out dt)) {
                        sql += col + " = '" + GetDTS(dt) + "', ";
                    } else {
                        sql += col + " = '" + val + "', ";
                    }
                }
            }
            sql = removeComma(sql);

            int id = (int)obj.GetType().GetProperty("ID", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(obj);
            sql += " WHERE ID = '" + id + "'";

            return sql;
        }
        public static String BuildInsertQuery(Object obj) {
            string sql = "INSERT INTO " + obj.GetType().Name + " (";
            string sqlValues = " VALUES(";
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props) {
                object val = prop.GetValue(obj);
                if (val != null) {
                    if (prop.Name.ToUpper().Equals("ID")) continue;
                    sql += prop.Name + comma;
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(val.ToString(), out dt)) {
                        sqlValues += "'" + GetDTS(dt) + "'" + comma;
                    } else {
                        sqlValues += "'" + val + "'" + comma;
                    }
                }
            }
            sql = any(sql);
            sqlValues = any(sqlValues);

            return sql + sqlValues;
        }

        private static string any(String sql) {
            sql = removeComma(sql);
            sql += ") ";
            return sql;
        }

        private static string removeComma(String sql) {
            sql = sql.Trim();
            if(sql.EndsWith(",")) sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

        private static string GetDTS(DateTime dt) {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static T SelectOneById<T>(int key) where T : new() {
            return SelectOne<T>("SELECT * FROM " + typeof(T).Name + " WHERE ID = '" + key + "'");
        }
    }
}