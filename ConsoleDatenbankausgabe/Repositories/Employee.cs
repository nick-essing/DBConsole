using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class Employee
    { 
        public Employee()
        {

        }
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viEmployee", conn);
        }
        public void spInsertOrUpdate(SqlConnection conn, int Id, String name, DateTime birthdate, decimal salary, int gender)
        {
            SQLHandler.newStoredProcedure("spInsertOrUpdateEmployee", conn, new string[] {  "@Id", "@name", "@birthdate", "@salary", "@gender" }, new object[] { Id, name, birthdate, Math.Round(salary,2), gender });
        }
        public void spDelete(SqlConnection conn, int Id)
        {
            SQLHandler.newStoredProcedure("spDeleteEmployee", conn, new string[] { "@Id" }, new object[] { Id });
        }
    }
}
