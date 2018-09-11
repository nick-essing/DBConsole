using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class Company
    {
        public Company()
        {

        }
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viCompany", conn);
        }
        public void spInsertOrUpdate(SqlConnection conn, int Id, String Name )
        {
            SQLHandler.newStoredProcedure("spInsertOrUpdateCompany", conn, new string[] { "@Id", "@name", }, new object[] { Id, Name });
        }
        public void spDelete(SqlConnection conn, int Id)
        {
            SQLHandler.newStoredProcedure("spDeleteCompany", conn, new string[] { "@Id" }, new object[] { Id });
        }
    }
}
