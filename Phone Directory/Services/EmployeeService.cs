using Phone_Directory.Models;
using PhoneDirectory.Data;


namespace PhoneDirectory.Data
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            return _employeeRepository.SearchEmployees(searchTerm);
        }

        public void InsertEmployee(AddEmployee employee)
        {
            _employeeRepository.InsertEmployee(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            _context.SaveChanges();
        }


    }
}
