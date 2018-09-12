using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using ConsoleDatenbankausgabe.Model;
using System.Linq;

namespace ConsoleDatenbankausgabe.Repositories
{
    class AddressRepo
    { 
        public AddressRepo()
        {
        }

        public List<Model.Address> Read(SqlConnection conn)
        {
            var result =  conn.Query<Model.Address>("SELECT * FROM viAddress").ToList();
            return result;
        }
        public Model.Address Read(SqlConnection conn, int Id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            var result = conn.QueryFirstOrDefault<Model.Address>("SELECT * FROM viAddress where Id = @Id",param);
            return result;
        }
        public Model.Address spInsertOrUpdate(SqlConnection conn, int Id, int Postcode, string City, string Street, string Country)
        {
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            param.Add("@postcode", Postcode);
            param.Add("@city", City);
            param.Add("@street", Street);
            param.Add("@country", Country);
            var result = conn.QueryFirstOrDefault<Model.Address>("spInsertOrUpdateAddress", param, null, null, CommandType.StoredProcedure);
            return result;
        }
        public Model.Address spDelete(SqlConnection conn, int Id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            var result = conn.QueryFirstOrDefault<Model.Address>("spDeleteAddress", param, null, null, CommandType.StoredProcedure);
            return result;
        }
    }
}
