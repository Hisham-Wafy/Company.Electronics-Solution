using Company.Electronics.BLL.Repositories;
using Company.Electronics.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Company.Electronics.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController (DepartmentRepository department)
        {
           _departmentRepository = department ;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Result = _departmentRepository.GetAll();           
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }

     
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepository.Add(model);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            
            return View(model);
        }


        public IActionResult Details(int? id )
        {
            if (id is null) return BadRequest();
           var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Update( int? id)
        {

            if (id is null) return BadRequest();
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);


        }

        [HttpPost]
        public IActionResult Update([FromRoute] int? id , Department model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid) 
            {
                var department = _departmentRepository.Update(model);
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
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, Department model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var department = _departmentRepository.Delete(model);
                if (department > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);

        }


    }
}
