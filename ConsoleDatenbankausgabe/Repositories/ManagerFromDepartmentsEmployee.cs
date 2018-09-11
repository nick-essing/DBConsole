using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class ManagerFromDepartmentsEmployee
    {
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viManagerFromDepartmentsEmployee", conn);
        }
        public void spAddManagerFromDepartmentsToEmployee(SqlConnection conn, int ManagerEmployeeId, int DepartmentId)
        {
            SQLHandler.newStoredProcedure("spAddManagerFromDepartmentsToEmployee", conn, new string[] { "@ManagerEmployeeId", "@DepartmentId" }, new object[] { ManagerEmployeeId, DepartmentId });
        }
    }
}
