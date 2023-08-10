using LaMindsTest.Models;

namespace LaMindsTest.Infrastructure.IRepository
{
    public interface IEmployee
    {
        List<Employeeinfo> GetEmployeeData();

        Employeeinfo GetEmployeeById(int id);
        Employeeinfo AddEmployee(Employeeinfo employeeinfo);
        Employeeinfo UpdateEmployee(Employeeinfo employeeinfo);
        Employeeinfo DeleteEmployee(int id);
    }
}
