using System;
using System.Data.SqlClient;
using ConsoleDatenbankausgabe.Repositories;
namespace ConsoleDatenbankausgabe
{
    class main
    {
        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    try
                    {
                        conn.ConnectionString = ConsoleDatenbankausgabe.Properties.Resources.sqlConnectionString;
                        conn.Open();
                        bool x = true;
                        Address a = new Address();
                        Employee e = new Employee();
                        Company c = new Company();
                        Department d = new Department();

                        CompanyAddress ca = new CompanyAddress();
                        CompanyDepartment cd = new CompanyDepartment();
                        EmployeeDepartment ed = new EmployeeDepartment();
                        EmployeeAddress ea = new EmployeeAddress();
                        ManagerFromDepartmentsEmployee mde = new ManagerFromDepartmentsEmployee();
                        while (x)
                        {
                            object[] obj;
                            Console.WriteLine("1. Address Tabelle Bearbeiten ");
                            Console.WriteLine("2. Employee Tabelle Bearbeiten ");
                            Console.WriteLine("3. Company Tabelle Bearbeiten ");
                            Console.WriteLine("4. Department Tabelle Bearbeiten ");

                            Console.WriteLine("5. Company mit Adressen Tabelle Bearbeiten ");
                            Console.WriteLine("6. Company mit Departments Tabelle Bearbeiten ");
                            Console.WriteLine("7. Employee mit Departments Tabelle Bearbeiten ");
                            Console.WriteLine("8. Employee mit Adressen Tabelle Bearbeiten ");
                            Console.WriteLine("9. Manager aus Employee mit Departments Tabelle Bearbeiten ");
                            Console.WriteLine("10. EXIT");
                            int b = Int32.Parse(Console.ReadLine());
                            switch (b) {
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("Address Tabelle: ");
                                        a.Load(conn);
                                        obj = consoleAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1 || Int32.Parse(obj[1].ToString()) == 2)
                                        {
                                            int Id = -1;
                                            if (Int32.Parse(obj[1].ToString()) == 2)
                                            {
                                                Id = id();
                                            }
                                            Console.WriteLine("gib einen Postleitzahl ein: ");
                                            int postcode = Int32.Parse(Console.ReadLine());
                                            Console.WriteLine("gib eine Stadt ein: ");
                                            String city = Console.ReadLine();
                                            Console.WriteLine("gib eine Starße und Hausnummer ein: ");
                                            String street = Console.ReadLine();
                                            Console.WriteLine("gib ein Land ein: ");
                                            String country = Console.ReadLine();
                                            a.spInsertOrUpdate(conn, Id, postcode, city, street, country);
                                        }
                                        if (Int32.Parse(obj[1].ToString()) == 3)
                                        { 
                                            int Id1 = id();
                                            a.spDelete(conn, Id1);

                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 2:
                                    Console.WriteLine("Employee Tabelle: ");
                                    do
                                    {
                                        e.Load(conn);
                                        obj = consoleAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1 || Int32.Parse(obj[1].ToString()) == 2)
                                        {
                                            int Id = -1;
                                            if (Int32.Parse(obj[1].ToString()) == 2)
                                            {
                                                Id = id();
                                            }
                                            String name1 = name();
                                            Console.WriteLine("gib ein Geburtsdatum ein: ");
                                            DateTime birthdate = DateTime.Parse(Console.ReadLine());
                                            Console.WriteLine("gib ein Gehalt ein: ");
                                            decimal salary = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("gib ein geschlecht ein (1 männlich, 2 weiblich, 3 kompliziert): ");
                                            int gender = Int32.Parse(Console.ReadLine());
                                            e.spInsertOrUpdate(conn, Id, name1, birthdate, salary, gender);
                                        }
                                        if (Int32.Parse(obj[1].ToString()) == 3)
                                        {
                                            int Id1 = id();
                                            e.spDelete(conn, Id1);

                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 3:
                                    do
                                    {
                                        Console.WriteLine("Department Tabelle: ");
                                        c.Load(conn);
                                        obj = consoleAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1 || Int32.Parse(obj[1].ToString()) == 2)
                                        {
                                            int Id = -1;
                                            if (Int32.Parse(obj[1].ToString()) == 2)
                                            {
                                                Id = id();
                                            }
                                            String name2 = name();
                                            c.spInsertOrUpdate(conn, Id, name2);
                                        }
                                        if (Int32.Parse(obj[1].ToString()) == 3)
                                        {
                                            int Id1 = id();
                                            c.spDelete(conn, Id1);

                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 4:
                                    do
                                    {
                                        Console.WriteLine("Company Tabelle: ");
                                        d.Load(conn);
                                        obj = consoleAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1 || Int32.Parse(obj[1].ToString()) == 2)
                                        {
                                            int Id = -1;
                                            if (Int32.Parse(obj[1].ToString()) == 2)
                                            {
                                                Id = id();
                                            }
                                            String name3 = name();
                                            d.spInsertOrUpdate(conn, Id, name3);
                                        }
                                        if (Int32.Parse(obj[1].ToString()) == 3)
                                        {
                                            int Id1 = id();
                                            d.spDelete(conn, Id1);

                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 5:
                                    do
                                    {
                                        Console.WriteLine("Company + Address Tabelle: ");
                                        ca.Load(conn);
                                        Console.WriteLine("Company Tabelle:");
                                        c.Load(conn);
                                        Console.WriteLine("Adresssen Tabelle:");
                                        a.Load(conn);
                                        obj = consoleForeignKeyAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1)
                                        {
                                            int CompanyId = id("Company");
                                            int AddressId = id("Address");
                                            ca.spAddAddressToCompany(conn, CompanyId, AddressId);
                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 6:
                                    do
                                    {
                                        Console.WriteLine("Company + Department Tabelle: ");
                                        cd.Load(conn);
                                        Console.WriteLine("Company Tabelle:");
                                        c.Load(conn);
                                        Console.WriteLine("Department Tabelle:");
                                        d.Load(conn);
                                        obj = consoleForeignKeyAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1)
                                        {
                                            int DepartmentId = id("Department");
                                            int CompanyId = id("Company");
                                            cd.spAddDepartmentsToCompany(conn, DepartmentId, CompanyId);
                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 7:
                                    do
                                    {
                                        Console.WriteLine("Employee + Depatment Tabelle: ");
                                        ed.Load(conn);
                                        Console.WriteLine("Employee Tabelle:");
                                        e.Load(conn);
                                        Console.WriteLine("Department Tabelle:");
                                        d.Load(conn);
                                        obj = consoleForeignKeyAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1)
                                        {
                                            int EmployeeId = id("Employee");
                                            int DepartmentId = id("Department");
                                            ed.spAddEmployeeToDepartment(conn, EmployeeId, DepartmentId);
                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 8:
                                    do
                                    {
                                        Console.WriteLine("Employee + Address Tabelle: ");
                                        ea.Load(conn);
                                        Console.WriteLine("Employee Tabelle:");
                                        e.Load(conn);
                                        Console.WriteLine("Adresssen Tabelle:");
                                        a.Load(conn);
                                        obj = consoleForeignKeyAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1)
                                        {
                                            int AddressId = id("Address");
                                            int EmployeeId = id("Employee");
                                            ea.spAddEmployeesToAddresses(conn, AddressId, EmployeeId);
                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 9:
                                    do
                                    {
                                        Console.WriteLine("Manager(Employee)+ Department Tabelle: ");
                                        mde.Load(conn);
                                        Console.WriteLine("Department Tabelle:");
                                        d.Load(conn);
                                        Console.WriteLine("Employee Tabelle:");
                                        e.Load(conn);
                                        obj = consoleForeignKeyAction();
                                        if (Int32.Parse(obj[1].ToString()) == 1)
                                        {
                                            int ManagerEmployeeId = id("ManagerEmployee");
                                            int DepartmentId = id("Department");
                                            mde.spAddManagerFromDepartmentsToEmployee(conn, ManagerEmployeeId, DepartmentId);
                                        }
                                    } while (!Boolean.Parse(obj[0].ToString()));
                                    break;
                                case 10:
                                    x = false;
                                    break;
                            }
                            Console.WriteLine();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler, Verbindung zur DB nicht möglich");
            }
        }
        private static object[] consoleAction()
        {
            bool exit = false;
            Console.WriteLine("1. Objekt einfügen ");
            Console.WriteLine("2. Objekt ändern ");
            Console.WriteLine("3. Objekt Löschen ");
            Console.WriteLine("4. Zurück zum Menü");
            int b = Int32.Parse(Console.ReadLine());
            if (b == 4)
            {
                exit = true;
            }
            return new object[] { exit, b };
        }
        private static object[] consoleForeignKeyAction()
        {
            bool exit = false;
            Console.WriteLine("1. Fremdschlüssel einfügen ");
            Console.WriteLine("2. Zurück zum Menü");
            int b = Int32.Parse(Console.ReadLine());
            if (b == 2)
            {
                exit = true;
            }

            return new object[] { exit, b };
        }
        private static int id(String name = null)
        {
            Console.WriteLine("gib eine "+ name +"Id ein: ");
            int Id = Int32.Parse(Console.ReadLine());
            return Id;
        }
        private static String name()
        {
            Console.WriteLine("gib einen Namen ein: ");
            String name = Console.ReadLine();
            return name;
        }
    }
}
