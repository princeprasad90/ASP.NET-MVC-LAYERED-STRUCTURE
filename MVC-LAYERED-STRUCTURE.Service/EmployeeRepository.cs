using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_LAYERED_STRUCTURE.Model.Model;
using System.Data.Entity;

namespace MVC_LAYERED_STRUCTURE.Service
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        MyNewDatabaseEntities db = new MyNewDatabaseEntities();

        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        public void InsertEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            Save();
        }
        public Employee GetEmployeeByID(int EmployeeId)
        {
            return db.Employees.Find(EmployeeId);
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            Save();
        }
        public void DeleteEmployee(int EmployeeId)
        {
            Employee employee = db.Employees.Find(EmployeeId);
            db.Employees.Remove(employee);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
