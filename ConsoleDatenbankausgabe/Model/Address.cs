using System;

namespace ConsoleDatenbankausgabe.Model
{
    public class Address
    {
        public Address(int id, int postcode, String city, String street, String country)
        {
            Id = id;
            Postcode = postcode;
            City = city;
            Street = street;
            Country = country;
        }
        public int Id { get; set; }
        public int Postcode { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String Country { get; set; }
    }
    //SQLHandler.SQLCommand("SELECT * FROM viAddress", conn);
}
