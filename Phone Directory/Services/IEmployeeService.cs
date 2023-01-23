using Phone_Directory.Models;

namespace PhoneDirectory.Data
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        List<Employee> SearchEmployees(string searchTerm);
        public void InsertEmployee(AddEmployee employee);
        public void UpdateEmployee(Employee employee);

        public void DeleteEmployee(int id);
    }
}