using Phone_Directory.Models;

namespace PhoneDirectory.Data
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int id);
        List<Employee> GetAllEmployees();
        void InsertEmployee(AddEmployee employee);
        List<Employee> SearchEmployees(string searchTerm);
        void UpdateEmployee(Employee employee);
    }
}