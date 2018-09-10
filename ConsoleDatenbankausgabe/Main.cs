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
            createNewSELECT("SELECT * FROM viEmployeeAddress");
        }
        public static void createNewSELECT(String SQLInput)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=tappqa;Initial Catalog=Training-NI-CompanyDB;Integrated Security=True";
                    conn.Open();
                    using (SqlDataAdapter a = new SqlDataAdapter(SQLInput, conn))
                    {
                        DataTable t = new DataTable();
                        a.Fill(t);
                        DataRow[] currentRows = t.Select(
                        null, null, DataViewRowState.CurrentRows);

                        if (currentRows.Length < 1)
                            Console.WriteLine("No Current Rows Found");
                        else
                        {
                            foreach (DataRow row in currentRows)
                            {
                                foreach (DataColumn column in t.Columns)
                                    Console.Write("\t{0}", row[column]);

                                Console.WriteLine("\t");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("NULL");
            }
        }
    }
}
