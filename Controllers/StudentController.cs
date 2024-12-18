using GERNALE_WEB_APP.Core.Interface;
using GERNALE_WEB_APP.Core.Model;
using GERNALE_WEB_APP.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GERNALE_WEB_APP.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentRepository;

        public StudentController(IStudentService studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View(studentRepository.GetAllStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Add(Student student)
        {
            if (MyDatabase.students.Find(x => x.StudentNumber == student.StudentNumber) != null)
            {
                ViewData["error"] = true;
                ViewData["message"] = "Student already exist.";
                return View("Create", student);
            } 
            else
            {
                if (MyDatabase.students.Count > 0)
                {
                    int id = MyDatabase.students[MyDatabase.students.Count - 1].Id + 1;
                    student.Id = id;
                    studentRepository.AddStudent(student);
                    return RedirectToAction("Index");
                }
                else
                {
                    student.Id = 1;
                    studentRepository.AddStudent(student);
                    return RedirectToAction("Index");
                }
            }
        }

        public IActionResult Edit(int id)
        {
            return View(studentRepository.GetStudent(id));
        }

        public IActionResult Save(Student student)
        {
            int index = MyDatabase.students.FindIndex(x => x.Id == student.Id);
            MyDatabase.students[index] = student;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(studentRepository.GetStudent(id));
        }

        public IActionResult Delete(int id)
        {
            if (MyDatabase.students.Count > 0)
            {
                Student student = MyDatabase.students.Find(x => x.Id == id);
                if (student.SectionId == 0)
                {
                    int index = MyDatabase.students.FindIndex(x => x.Id == student.Id);
                    MyDatabase.students.RemoveAt(index);
                    return Ok("Student record successfully deleted.");
                }
                else
                {
                    return BadRequest("Failed to delete! Student is currently registered to a section.");
                }
            }
            else
            {
                return Ok("Empty student record.");
            }
        }

        public IActionResult GetFilteredList(int id)
        {
            var list = studentRepository.GetAllStudents().Where(x => x.SectionId != id && x.SectionId == 0).ToList();
            return Ok(list);
        }
    }
}
