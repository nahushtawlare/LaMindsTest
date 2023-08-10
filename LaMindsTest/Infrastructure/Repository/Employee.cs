using LaMindsTest.Infrastructure.IRepository;
using LaMindsTest.Models;
using System.Data;
using Dapper;


namespace LaMindsTest.Infrastructure.Repository
{
    public class Employee : IEmployee
    {
        private readonly IDapperServices _dapper;

        public Employee(IDapperServices dapper)
        {
            _dapper = dapper;
        }

        public Employeeinfo AddEmployee(Employeeinfo employeeinfo)
        {
            Employeeinfo model = new Employeeinfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Id", employeeinfo.Id);
                dbPara.Add("EmployeeName", employeeinfo.EmployeeName);
                dbPara.Add("Gender", employeeinfo.Gender);
                dbPara.Add("Salary", employeeinfo.Salary);
                dbPara.Add("Email", employeeinfo.Email);
                dbPara.Add("PhoneNumber", employeeinfo.PhoneNumber);
                dbPara.Add("States ", employeeinfo.States);
                dbPara.Add("City ", employeeinfo.City);
                dbPara.Add("Hobby", employeeinfo.Hobby);
                model.TotalRowCount = Task.FromResult(_dapper.ExeecuteScaler<Employeeinfo>("EmployeeAddEdit" ,dbPara, commandType: CommandType.Text)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public Employeeinfo DeleteEmployee(int Id)
        {
            Employeeinfo model = new Employeeinfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Id", Id);
                model.TotalRowCount = Task.FromResult(_dapper.ExeecuteScaler<Employeeinfo>("EmployeeAddEdit", dbPara, commandType: CommandType.Text)).Result;
            }

            catch (Exception)
            {
                throw;
            }
            return model;
          
        }

        public Employeeinfo GetEmployeeById(int Id)
        {
            var query = @"Select * from Employee where Id=@Id";
            Employeeinfo employeeinfo=new Employeeinfo();
            try
            {
                var dbPara=new DynamicParameters();
                dbPara.Add("Id", Id);
                employeeinfo = Task.FromResult(_dapper.Get<Employeeinfo>(query, null, commandType: CommandType.Text)).Result;
            }
            catch (Exception) 
            {
                throw;
            }
            return employeeinfo;
        }

        public List<Employeeinfo> GetEmployeeData()
        {
            var query = @"Select * from Employee";
            List<Employeeinfo> employeeinfos= new List<Employeeinfo>();
            try
            {
                employeeinfos = Task.FromResult(_dapper.GetAll<Employeeinfo>(query, null, commandType: CommandType.Text)).Result;
            }
            catch (Exception ) 
            {
                throw;
            }
            return employeeinfos;
        }

        public Employeeinfo UpdateEmployee(Employeeinfo employeeinfo)
        {
            throw new NotImplementedException();
        }
    }
}
