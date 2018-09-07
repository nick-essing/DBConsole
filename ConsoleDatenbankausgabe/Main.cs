using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe
{
    class main
    {
        static void Main(string[] args)
        {
            Console.Write("Ausgabe:");
            createConnection();
            List<List<String>> list = newSELECT("SELECT * FROM viEmployee");
            Console.WriteLine(list);
        }
        public static void createConnection()
        {
            using (SqlConnection conn = new SqlConnection("DataSource=TAPPQA;Initial Catalog=Training-NI-CompanyDB;IntegratedSecurity=True"))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {
                }
            }
        }
        public static List<List<String>> newSELECT(String SQLinput)
        {
            try
            {
                List<List<String>> list = new List<List<String>>();
                SqlCommand command = new SqlCommand(SQLinput);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    List<String> tmpList = new List<String>();
                    for (int i = 0; myReader[i] != null; i++) {
                        tmpList.Add(myReader[i].ToString());
                        Console.WriteLine(myReader[i].ToString());
                    }
                    list.Add(tmpList);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
