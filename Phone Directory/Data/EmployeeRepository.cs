using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Phone_Directory.Models;
using PhoneDirectory.Data;
using Microsoft.Extensions.Configuration;


namespace PhoneDirectory.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqliteConnection _connection;

      
        public EmployeeRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
        }

        public void InsertEmployee(AddEmployee employee)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Employee (FirstName, LastName, Division, Title, Email, MobilePhone, OfficePhone, Ext, Notes) VALUES (@FirstName, @LastName, @Division, @Title, @Email, @MobilePhone, @OfficePhone, @Ext, @Notes)";
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Division", employee.Department);
                command.Parameters.AddWithValue("@Title", employee.Title);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@MobilePhone", employee.MobilePhone);
                command.Parameters.AddWithValue("@OfficePhone", employee.OfficePhone);
                command.Parameters.AddWithValue("@Ext", employee.Ext);
                command.Parameters.AddWithValue("@Notes", employee.Notes);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Division = @Division, Title = @Title, Email = @Email, MobilePhone = @MobilePhone, OfficePhone = @OfficePhone, Ext = @Ext, Notes = @Notes WHERE EmployeeId = @Id";
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Division", employee.Department);
                command.Parameters.AddWithValue("@Title", employee.Title);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@MobilePhone", employee.MobilePhone);
                command.Parameters.AddWithValue("@OfficePhone", employee.OfficePhone);
                command.Parameters.AddWithValue("@Ext", employee.Ext);
                command.Parameters.AddWithValue("@Notes", employee.Notes);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Employee WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Employee";
                using (var reader = command.ExecuteReader())
                {
                    var employees = new List<Employee>();
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            // other properties
                        };
                        employees.Add(employee);
                    }
                    return employees;
                }
            }
        }
        public List<Employee> SearchEmployees(string searchTerm)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Employee WHERE FirstName LIKE @searchTerm OR LastName LIKE @searchTerm OR Email LIKE @searchTerm OR MobilePhone LIKE @searchTerm OR OfficePhone LIKE @searchTerm OR Ext LIKE @searchTerm";
                command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                using (var reader = command.ExecuteReader())
                {
                    var employees = new List<Employee>();
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                           
                        };
                        employees.Add(employee);
                    }
                    return employees;
                }
            }
        }
 
    }
}

