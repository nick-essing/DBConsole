using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class Department
    {
        public Department()
        {

        }
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viDepartment", conn);
        }
        public void spInsertOrUpdate(SqlConnection conn, int Id, String Name)
        {
            SQLHandler.newStoredProcedure("spInsertOrUpdateDepartment", conn, new string[] { "@Id", "@name", }, new object[] { Id, Name });
        }
        public void spDelete(SqlConnection conn, int Id)
        {
            SQLHandler.newStoredProcedure("spDeleteEDepartment", conn, new string[] { "@Id" }, new object[] { Id });
        }
    }
}
