using Company.Electronics.BLL.Interfaces;
using Company.Electronics.BLL.Repositories;
using Company.Electronics.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Electronics.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(EmployeeRepository employee , DepartmentRepository department)
        {

            _employeeRepository = employee;
            _departmentRepository = department;
        }
        
        public IActionResult Index(string InputSearch)
        {
            var employee = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(InputSearch))
            {
                employee = _employeeRepository.GetAll();

            }
            else
            {
                employee = _employeeRepository.GetByName(InputSearch);
            }


            //View's Dictionary : Transfer Date from Action to View (one ways)
            // 1. ViewData : Property Inherited from controller class, type of => Dictionary
            //  ViewData["Data01"] = "Hello World from ViewData";
            // 2. ViewBag : Property Inherited from Controller class , type of => dynamic 
            //ViewBag.Data02 = "Hello world from ViewBag";
            // 3. TempData
            TempData["Data03"] = "Hello World from TempData";

            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {

           var department = _departmentRepository.GetAll();
            ViewData["department"] = department;
            return View();
        }


        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var Count = _employeeRepository.Add(model);
                    if (Count > 0)
                    {
                        TempData["Message"] = "Employee Created";
                    }
                    else
                    {
                        TempData["Message"] = "Employee Not Created";

                    }
                    return RedirectToAction(nameof(Index));
                    
                }
                catch (Exception ex)
                {
                  // 1. Log Exception
                  // 1. Friendly Exception
                  ModelState.AddModelError(string.Empty , ex.Message);
                }
            }
            return View(model);
        }

        
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            var department = _employeeRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id is null) return BadRequest();
            var department = _employeeRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);


        }

        [HttpPost]
        public IActionResult Update([FromRoute] int? id, Employee model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var department = _employeeRepository.Update(model);
                if (department > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);

        }

        [HttpGet]

        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            var employee = _employeeRepository.Get(id.Value);
            if (employee is null) return NotFound();

            return View(employee);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, Employee model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var department = _employeeRepository.Delete(model);
                if (department > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);

        }

    }
}
