using CRUDEmployees.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEmployees.Services
{
    public class EmployeeRepository : IEmployee
    {
        public List<EmployeeModel> employees = new List<EmployeeModel>
        {
            new EmployeeModel {Id = 1, Name = "anas"}
            
        };
        public IEnumerable<EmployeeModel> GetEmployee()
        {
            return employees;
        }
        public IEnumerable<EmployeeModel> addEmployee(EmployeeModel employee)
        {
            
            try
            {

                
            int newId = employees.LastOrDefault().Id + 1;
            EmployeeModel employeemodel = new EmployeeModel
            {
                Id = newId,
                Name = employee.Name
            };
                if(employee.Name == "John Doe")
                {
                    throw new InvalidOperationException("Invalid employee Name");
                }
            employees.Add(employeemodel);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }

            return employees;

                
            
           
           
        }

        public IEnumerable<EmployeeModel> deleteEmployee(int id)
        {
            var todel = employees.FirstOrDefault(x => x.Id == id);
            employees.Remove(todel);
            return employees;
        }

        public IEnumerable<EmployeeModel> editEmployee(int id, JsonPatchDocument<EmployeeModel> employee)
        {
            if(employee == null)
            {
                return employees;
            } else
            {
                var topatch = employees.FirstOrDefault(x => x.Id == id);
                EmployeeModel employeeModel = new EmployeeModel
                {
                    Id = topatch.Id,
                    Name = topatch.Name
                };
                employee.ApplyTo(employeeModel);
                topatch.Id = employeeModel.Id;
                topatch.Name = employeeModel.Name;

                return employees;
            }
        }
        
    }

    
}
