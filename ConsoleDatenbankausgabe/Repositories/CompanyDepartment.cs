using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class CompanyDepartment
    {
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viCompanyDepartment", conn);
        }
        public void spAddDepartmentsToCompany(SqlConnection conn, int DepartmentId, int CompanyId)
        {
            SQLHandler.newStoredProcedure("spAddDepartmentsToCompany", conn, new string[] { "@DepartmentId", "@CompanyId" }, new object[] { DepartmentId, CompanyId });
        }
    }
}
