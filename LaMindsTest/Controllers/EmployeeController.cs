using LaMindsTest.Infrastructure.IRepository;
using LaMindsTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaMindsTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _services;

        public EmployeeController(IEmployee services)
        {


            _services = services;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            EmployeeinfoModel model = new EmployeeinfoModel();
            model.EmployeesList = _services.GetEmployeeData();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employeeinfo model=new Employeeinfo();
            model=_services.GetEmployeeById(id);
            return View(model);
        }

        //Add
        public ActionResult AddEditEmployee(int id)
        {
            Employeeinfo model=new Employeeinfo();
            model = _services.GetEmployeeById(id);
            if (model == null)
            {
                return View();
            }
            else
            {
                return View(model);
            }
        }

        // POST: EmployeeController/Create
        [HttpPost]
        
        public ActionResult Create(Employeeinfo infomodel)
        {
            Employeeinfo model=new Employeeinfo();
            try
            {
                model=_services.AddEmployee(infomodel);
                if (model.TotalRowCount>0) 
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        
        public ActionResult Delete(int id)
        {
            Employeeinfo model = new Employeeinfo();
            try
            {
                model = _services.DeleteEmployee(id);
                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
