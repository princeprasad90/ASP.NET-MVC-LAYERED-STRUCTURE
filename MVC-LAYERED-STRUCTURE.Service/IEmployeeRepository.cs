using MVC_LAYERED_STRUCTURE.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_LAYERED_STRUCTURE.Service
{
   public interface IEmployeeRepository:IDisposable
    {

        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int EmployeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int EmployeeId);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
