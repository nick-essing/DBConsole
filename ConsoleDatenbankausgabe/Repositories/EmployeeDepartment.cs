using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class EmployeeDepartment
    {
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viEmployeeDepartment", conn);
        }
        public void spAddEmployeeToDepartment(SqlConnection conn, int EmployeeId, int DepartmentId)
        {
            SQLHandler.newStoredProcedure("spAddEmployeesToDepartment", conn, new string[] { "@EmployeeId", "@DepartmentId" }, new object[] { EmployeeId, DepartmentId });
        }
    }
}
