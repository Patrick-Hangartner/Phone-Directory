using Phone_Directory.Models;
using PhoneDirectory.Data;
using System;
using System.Linq;

namespace PhoneDirectory
{
    public class DbInitializer
    {
        public static void Seed(EmployeeContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        Department = "IT",
                        Title = "Director,",
                        Email = "JohnSmith@example.com",
                        MobilePhone = 720 - 145 - 5843,
                        OfficePhone = 720 - 555 - 9843,
                        Ext = 002,
                        Notes = "Sample employee"
                    },
                    new Employee
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Department = "HR",
                        Title = "Manager",
                        Email = "JaneDoe@example.com",
                        MobilePhone = 720 - 603 - 8374,
                        OfficePhone = 720 - 231 - 7639,
                        Ext = 745,
                        Notes = "Sample employee"
                    },
                    new Employee
                    {
                        FirstName = "Cesar",
                        LastName = "Lopez",
                        Department = "Sales",
                        Title = "Assistant Manager,",
                        Email = "CesarLopez@example.com",
                        MobilePhone = 720 - 808 - 8514,
                        OfficePhone = 720 - 205 - 1669,
                        Ext = 101,
                        Notes = "Sample employee"
                    },
                    new Employee
                     {
                        FirstName = "Molly",
                        LastName = "Johnson",
                        Department = "Sales",
                        Title = "Supervisor",
                        Email = "MollyJohnson@example.com",
                        MobilePhone = 720 - 931 - 5370,
                        OfficePhone = 720 - 231 - 4139,
                        Ext = 925,
                        Notes = "Sample employee"
                     },
                     new Employee
                      {
                         FirstName = "Brandon",
                         LastName = "Gracia",
                         Department = "IT",
                         Title = "Vp",
                         Email = "BrandonGracia@example.com",
                         MobilePhone = 720 - 847 - 0396,
                         OfficePhone = 720 - 584 - 6482,
                         Ext = 001,
                         Notes = "Sample employee"
                      },
                     new Employee
                      {
                         FirstName = "Sally",
                         LastName = "Lee",
                         Department = "HR",
                         Title = "Assistant Director,",
                         Email = "SallyLee@example.com",
                         MobilePhone = 720 - 582 - 1948,
                         OfficePhone = 720 - 679 - 6429,
                         Ext = 023,
                         Notes = "Sample employee"
                     }, 
                     new Employee
                     {
                         FirstName = "Tom",
                         LastName = "Miller",
                         Department = "IT",
                         Title = "Employee",
                         Email = "TomMiller@example.com",
                         MobilePhone = 720 - 221 - 4353,
                         OfficePhone = 720 - 524 - 2848,
                         Ext = 847,
                         Notes = "Sample employee"
                     },
                     new Employee
                     {
                         FirstName = "Lucy",
                         LastName = "Jones",
                         Department = "Sales",
                         Title = "Employee",
                         Email = "LucyJones@example.com",
                         MobilePhone = 720 - 673 - 3217,
                         OfficePhone = 720 - 352 - 4291,
                         Ext = 492,
                         Notes = "Sample employee"
                     },
                     new Employee
                     {
                         FirstName = "Andrew",
                         LastName = "Jones",
                         Department = "IT",
                         Title = "Employee",
                         Email = "AndrewJones@example.com",
                         MobilePhone = 720 - 159 - 4870,
                         OfficePhone = 720 - 231 - 5729,
                         Ext = 861,
                         Notes = "Sample employee"
                     }, new Employee
                     {
                         FirstName = "Joy",
                         LastName = "Vang",
                         Department = "HR",
                         Title = "Employee",
                         Email = "JoyVang@example.com",
                         MobilePhone = 720 - 603 - 8374,
                         OfficePhone = 720 - 231 - 7639,
                         Ext = 346,
                         Notes = "Sample employee"
                     }

                );
                context.SaveChanges();
            }
        }
    }
}
