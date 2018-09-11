using System;
using System.Data.SqlClient;

namespace ConsoleDatenbankausgabe.Repositories
{
    class CompanyAddress
    {
        public CompanyAddress()
        {

        }
        public void Load(SqlConnection conn)
        {
            SQLHandler.SQLCommand("SELECT * FROM viCompanyAddress", conn);
        }
        public void spAddAddressToCompany(SqlConnection conn, int CompanyId, int AddressId)
        {
            SQLHandler.newStoredProcedure("spAddAddressToCompany", conn, new string[] { "@CompanyId", "@AddressId" }, new object[] { CompanyId, AddressId });
        }
    }
}
