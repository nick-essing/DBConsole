using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe
{
    class TblHandler
    {
        public static void displayTbl(String SQLInput, SqlConnection conn)
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


                    for (int i = 0; i < t.Columns.Count; i++)
                    {
                        Console.Write(" \u2551 ");
                        Console.Write(t.Columns[i].ColumnName.PadRight(paddings[i], ' '));
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
                        for (int y = 0; y < paddings[x] + 2; y++)
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
        public static List<int> getRowPaddings(DataTable t)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < t.Columns.Count; j++)
            {
                int longestColumn = t.Columns[j].ColumnName.Length;
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    if (longestColumn < t.Rows[i][j].ToString().Length)
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
