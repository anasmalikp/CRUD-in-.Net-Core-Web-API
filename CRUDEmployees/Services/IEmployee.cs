using CRUDEmployees.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace CRUDEmployees.Services
{
    public interface IEmployee
    {
        public IEnumerable<EmployeeModel> editEmployee(int id, JsonPatchDocument<EmployeeModel> employee);
        public IEnumerable<EmployeeModel> GetEmployee();
        public IEnumerable<EmployeeModel> addEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> deleteEmployee(int id);
    }
}
