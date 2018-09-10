using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                        //newStoredProcedure("spInsertOrUpdateEmployee", conn, new string[] { "@name", "@birthdate", "@salary", "@gender" }, new object[] { "nick", "2000-05-16", "3321321314", 3 });
                        newSelect("SELECT * FROM viEmployeeAddress", conn);

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
        public static void newSelect(String SQLInput, SqlConnection conn)
        {
            using (SqlDataAdapter a = new SqlDataAdapter(SQLInput, conn))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                DataRow[] currentRows = t.Select(
                null, null, DataViewRowState.CurrentRows);
                List<int> paddings = getRowPaddings(t);

                if (currentRows.Length < 1)
                    Console.WriteLine("No Current Rows Found");
                else
                {
                    Console.Write(" \u2554");
                    for (int x = 0; x < paddings.Count; x++)
                    {
                        for (int y = 0; y < paddings[x] + 2; y++)
                        {
                            Console.Write("\u2550");
                        }
                        if (x != paddings.Count - 1)
                        {
                            Console.Write("\u2566");
                        }
                    }
                    Console.Write("\u2557");
                    Console.WriteLine();


                    for (int i = 0; i < t.Columns.Count; i++){
                        Console.Write(" \u2551 ");
                        Console.Write(t.Columns[i].ColumnName.PadRight(paddings[i],' '));
                    }
                    Console.Write(" \u2551");
                    Console.WriteLine();


                    Console.Write(" \u2560");
                    for (int x = 0; x < paddings.Count; x++)
                    {
                        for (int y = 0; y < paddings[x] + 2; y++)
                        {
                            Console.Write("\u2550");
                        }
                        if (x != paddings.Count - 1)
                        {
                            Console.Write("\u256C");
                        }
                    }
                    Console.Write("\u2563");
                    Console.WriteLine();


                    for (int j = 0; j < t.Rows.Count; j++)
                    {
                        for (int z = 0; z < t.Columns.Count; z++)
                        {
                            Console.Write(" \u2551 ");
                            Console.Write(t.Rows[j][z].ToString().PadRight(paddings[z], ' '));
                        }
                        Console.Write(" \u2551");
                        Console.WriteLine();
                    }


                    Console.Write(" \u255A");
                    for (int x = 0; x < paddings.Count; x++)
                    {
                        for (int y = 0; y < paddings[x] + 2 ;y++)
                        {
                            Console.Write("\u2550");
                        }
                        if (x != paddings.Count - 1) {
                            Console.Write("\u2569");
                        }
                    }
                    Console.Write("\u255D");
                    Console.WriteLine();
                }
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
        public static List<int> getRowPaddings(DataTable t)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < t.Columns.Count; j++)
            {
                int longestColumn = t.Columns[j].ColumnName.Length;
                for (int i = 0; i < t.Rows.Count;i++)
                {
                    if(longestColumn < t.Rows[i][j].ToString().Length)
                    {
                        longestColumn = t.Rows[i][j].ToString().Length;
                    }
                }
                list.Add(longestColumn);
            }
            return list;
        }
    }
}
