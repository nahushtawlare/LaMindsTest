using System.Reflection;

namespace LaMindsTest.Models
{
    public class Employeeinfo
    {
       public int Id { get; set; }
       public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public Int64 Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string States { get; set; }
        public string City { get; set; }
       public string Hobby { get; set; }
        public int TotalRowCount { get; set; }
    }

    public class EmployeeinfoModel
    {
        private List<Employeeinfo> _employees=new List<Employeeinfo>();
        public  List<Employeeinfo> EmployeesList
        {
            get { return _employees; }
            set { _employees = value; }
        }
    }
}
