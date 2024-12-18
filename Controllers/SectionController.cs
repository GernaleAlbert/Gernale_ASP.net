using GERNALE_WEB_APP.Core.Interface;
using GERNALE_WEB_APP.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace GERNALE_WEB_APP.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService sectionRepository;

        public SectionController(ISectionService sectionRepository)
        {
            this.sectionRepository = sectionRepository;
        }

        public IActionResult Index()
        {
            return View(MyDatabase.sections);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Add(Section section)
        {
            Section searchedSection = MyDatabase.sections.Find(x => x.Name == section.Name);
            if (searchedSection == null)
            {
                if (MyDatabase.sections.Count > 0)
                {
                    int id = MyDatabase.sections[MyDatabase.sections.Count - 1].Id + 1;
                    section.Id = id;
                    MyDatabase.sections.Add(section);
                    return RedirectToAction("Index");
                }
                else
                {
                    section.Id = 1;
                    MyDatabase.sections.Add(section);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewData["error"] = true;
                ViewData["message"] = "Section already exist.";
                return View("Create", searchedSection);
            }
        }

        public IActionResult Edit(int id)
        {
            return View(sectionRepository.GetSectionById(id));
        }

        public IActionResult Save(Section section)
        {
            sectionRepository.SaveSection(section);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(sectionRepository.GetSectionById(id));
        }

        public IActionResult Delete(int id)
        {
            Console.WriteLine(id);
            Section section = MyDatabase.sections.Find(x => x.Id == id);
            if (section.Students.Count > 0)
            {
                return BadRequest("Can't delete section. Student list is not empty.");
            }
            else
            {
                int index = MyDatabase.sections.FindIndex(x => x.Id == id);
                MyDatabase.sections.RemoveAt(index);
                return Ok("Section successfully deleted.");
            }
        }

        [HttpPost]
        public IActionResult Assign(int id, [FromBody] List<StudentId> list)
        {
            var studentList = sectionRepository.GetSectionById(id).Students;
            foreach (var idList in list)
            {
                studentList.Add(idList.id);
                Student student = MyDatabase.students.Find(x => x.Id == idList.id);
                student.SectionId = id;
            }
            return Ok("Student assigned successfully!");
        }

        public IActionResult Remove(int id, int studentId)
        {
            Section section = MyDatabase.sections.Find(x => x.Id == id);
            int studentIndex1 = section.Students.FindIndex(x => x == studentId);
            section.Students.RemoveAt(studentIndex1);
            int studentIndex2 = MyDatabase.students.FindIndex(x => x.Id == studentId);
            MyDatabase.students[studentIndex2].SectionId = 0;
            return Ok("Student successfully removed from this section.");
        }
    }

    public class StudentId()
    {
        public int id { get; set; }
    }
}
