using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ConsoleDatenbankausgabe.Repositories
{
    class Address
    {
        public Address()
        {
        }

        public List<Model.Address> Read(SqlConnection conn)
        {
            var retVal = new List<Model.Address>();
            
            // Daten laden

            return retVal;
        }
        public void spInsertOrUpdate(SqlConnection conn, int Id, int Postcode, String City, String Street, String Country)
        {
            SQLHandler.newStoredProcedure("spInsertOrUpdateAddress", conn, new string[] { "@Id", "@postcode", "@city", "@street", "@country" }, new object[] { Id, Postcode, City, Street, Country });
        }
        public void spDelete(SqlConnection conn, int Id)
        {
            SQLHandler.newStoredProcedure("spDeleteAddress", conn, new string[] { "@Id" }, new object[] { Id });
        }
    }
}
