using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ConsoleDatenbankausgabe.Repositories
{
    class AddressRepo
    { 
        public AddressRepo()
        {
        }

        public List<Model.Address> Read(SqlConnection conn)
        {
            List<Model.Address> data = new List<Model.Address>();
            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM viAddress", conn))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                DataRow[] currentRows = t.Select(null, null, DataViewRowState.CurrentRows);
                
                if (currentRows.Length >= 1)
                {
                    for (int j = 0; j < t.Rows.Count; j++)
                    {
                        int id = int.Parse(t.Rows[j][0].ToString());
                        int postcode = int.Parse(t.Rows[j][1].ToString());
                        string city = t.Rows[j][2].ToString();
                        string street = t.Rows[j][3].ToString();
                        string country = t.Rows[j][4].ToString();
                        data.Add(new Model.Address(id, postcode, city, street, country));
                    }
                }
            }
            return data;
        }
        public Model.Address Read(SqlConnection conn, int Id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM viAddress where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", Id);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                
                DataTable t = new DataTable();
                a.Fill(t);
                DataRow[] currentRows = t.Select(null, null, DataViewRowState.CurrentRows);

                    int id = int.Parse(t.Rows[0][0].ToString());
                    int postcode = int.Parse(t.Rows[0][1].ToString());
                    string city = t.Rows[0][2].ToString();
                    string street = t.Rows[0][3].ToString();
                    string country = t.Rows[0][4].ToString();
                    return new Model.Address(id, postcode, city, street, country);
            }

        }
        public int spInsertOrUpdate(SqlConnection conn, int Id, int Postcode, String City, String Street, String Country)
        {
            SqlCommand cmd = new SqlCommand("spInsertOrUpdateAddress", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@postcode", Postcode);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.Parameters.AddWithValue("@street", Street);
            cmd.Parameters.AddWithValue("@country", Country);
            int DBId = (int) cmd.ExecuteScalar();
            return DBId;
        }
        public int spDelete(SqlConnection conn, int Id)
        {
            SqlCommand cmd = new SqlCommand("spDeleteAddress", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            int DBId = (int)cmd.ExecuteScalar();
            return DBId;
        }
    }
}
