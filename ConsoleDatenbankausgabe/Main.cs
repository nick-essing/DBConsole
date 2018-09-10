using System;
using System.Data.SqlClient;
using System.Data;
namespace ConsoleDatenbankausgabe
{
    class main
    {
        static void Main(string[] args)
        {
            createNewConnection();
        }
        public static void createNewConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    try
                    {
                        conn.ConnectionString = ConsoleDatenbankausgabe.Properties.Resources.sqlConnectionString;
                        conn.Open();

                        newStoredProcedure("spInsertOrUpdateEmployee", conn, new string[] { "@name", "@birthdate", "@salary", "@gender" }, new object[] { "nick", "2000-05-16", "3321321314", 3 });
                        TblHandler.displayTbl("SELECT * FROM viEmployeeAddress", conn);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler Keine Tabelle gefunden oder verbindung möglich");
            }
        }
        public static void newStoredProcedure(String procedureName, SqlConnection conn, String[] paramName = null, object[] param = null)
        { 
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < paramName.Length && i < param.Length; i++)
                cmd.Parameters.AddWithValue(paramName[i],param[i]);
            cmd.ExecuteNonQuery();
        }
    }
}
