using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class EmployeeAddress
    {
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viEmployeeAddress", conn);
        }
        public void spAddEmployeesToAddresses(SqlConnection conn, int AddressId, int EmployeeId)
        {
            SQLHandler.newStoredProcedure("spAddEmployeesToAddresses", conn, new string[] { "@AddressId", "@EmployeeId" }, new object[] { AddressId, EmployeeId });
        }
    }
}
