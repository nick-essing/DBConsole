using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConsoleDatenbankausgabe.Model;

namespace ConsoleDatenbankausgabe.Controller
{
    class AddressController
    {
        public AddressController(List<Model.Address> t)
        {
            List<int> paddings = getRowPaddings(t);
            headAddress(paddings);

            for (int j = 0; j < t.Count; j++)
            {
                Console.Write(" \u2551 ");
                Console.Write(t[j].Id.ToString().PadRight(paddings[0], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t[j].Postcode.ToString().PadRight(paddings[1], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t[j].City.ToString().PadRight(paddings[2], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t[j].Street.ToString().PadRight(paddings[3], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t[j].Country.ToString().PadRight(paddings[4], ' '));
                Console.Write(" \u2551");
                Console.WriteLine();
            }

            Console.Write(" \u255A");
            for (int x = 0; x < paddings.Count; x++)
            {
                for (int y = 0; y < paddings[x] + 2; y++)
                {
                    Console.Write("\u2550");
                }
                if (x != paddings.Count - 1)
                {
                    Console.Write("\u2569");
                }
            }
            Console.Write("\u255D");
            Console.WriteLine();
        }
        public AddressController(Model.Address t)
        {
            List<int> paddings = getRowPaddings(t);
            headAddress(paddings);

                Console.Write(" \u2551 ");
                Console.Write(t.Id.ToString().PadRight(paddings[0], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t.Postcode.ToString().PadRight(paddings[1], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t.City.ToString().PadRight(paddings[2], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t.Street.ToString().PadRight(paddings[3], ' '));
                Console.Write(" \u2551 ");
                Console.Write(t.Country.ToString().PadRight(paddings[4], ' '));
                Console.Write(" \u2551");
                Console.WriteLine();

            Console.Write(" \u255A");
            for (int x = 0; x < paddings.Count; x++)
            {
                for (int y = 0; y < paddings[x] + 2; y++)
                {
                    Console.Write("\u2550");
                }
                if (x != paddings.Count - 1)
                {
                    Console.Write("\u2569");
                }
            }
            Console.Write("\u255D");
            Console.WriteLine();
        }
        private List<int> getRowPaddings(Model.Address address)
        {
            List<int> list = new List<int>();
            list.Add(address.Id.ToString().Length < 9 ? 9: address.Id.ToString().Length);
            list.Add(address.Postcode.ToString().Length < 8 ? 8 : address.Postcode.ToString().Length);
            list.Add(address.City.Length < 4 ? 4 : address.City.ToString().Length);
            list.Add(address.Street.Length < 6 ? 6 : address.Street.ToString().Length);
            list.Add(address.Country.Length < 7 ? 7 : address.Country.ToString().Length);
            return list;
        }
        private void headAddress(List<int> paddings)
        {
            object[] obj = { "AddressId", "Postcode", "City", "Street", "Country" };
            Console.Write(" \u2554");
            for (int x = 0; x < paddings.Count; x++)
            {
                for (int y = 0; y < paddings[x] + 2; y++)
                {
                    Console.Write("\u2550");
                }
                if (x != paddings.Count - 1)
                {
                    Console.Write("\u2566");
                }
            }
            Console.Write("\u2557");
            Console.WriteLine();

            for (int i = 0; i < obj.Length; i++)
            {
                Console.Write(" \u2551 ");
                Console.Write((obj[i].ToString()).PadRight(paddings[i], ' '));
            }
            Console.Write(" \u2551");
            Console.WriteLine();


            Console.Write(" \u2560");
            for (int x = 0; x < paddings.Count; x++)
            {
                for (int y = 0; y < paddings[x] + 2; y++)
                {
                    Console.Write("\u2550");
                }
                if (x != paddings.Count - 1)
                {
                    Console.Write("\u256C");
                }
            }
            Console.Write("\u2563");
            Console.WriteLine();
        }
        private List<int> getRowPaddings(List<Model.Address> addressList)
        {
            int longestColumn;
            List<int> list = new List<int>();
            longestColumn = 9;
            for (int j = 0; j < addressList.Count; j++)
            {
               if (longestColumn < addressList[j].Id.ToString().Length)
                {
                    longestColumn = addressList[j].Id.ToString().Length;
                }
            }
            list.Add(longestColumn);
            longestColumn = 8;
            for (int j = 0; j < addressList.Count; j++)
            {
                if (longestColumn < addressList[j].Postcode.ToString().Length)
                {
                    longestColumn = addressList[j].Postcode.ToString().Length;
                }
            }
            list.Add(longestColumn);
            longestColumn = 4;
            for (int j = 0; j < addressList.Count; j++)
            {
                if (longestColumn < addressList[j].City.ToString().Length)
                {
                    longestColumn = addressList[j].City.ToString().Length;
                }
            }
            list.Add(longestColumn);
            longestColumn = 6;
            for (int j = 0; j < addressList.Count; j++)
            {
                if (longestColumn < addressList[j].Street.ToString().Length)
                {
                    longestColumn = addressList[j].Street.ToString().Length;
                }
            }
            list.Add(longestColumn);
            longestColumn = 7;
            for (int j = 0; j < addressList.Count; j++)
            {
                if (longestColumn < addressList[j].Country.ToString().Length)
                {
                    longestColumn = addressList[j].Country.ToString().Length;
                }
            }
            list.Add(longestColumn);
            return list;
        }
    }
}
