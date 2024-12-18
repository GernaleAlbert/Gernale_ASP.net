using GERNALE_WEB_APP.Core.Interface;
using GERNALE_WEB_APP.Core.Model;

namespace GERNALE_WEB_APP.Infrastructure.Repository
{
    public class StudentRepository : IStudentService
    {
        public void AddStudent(Student student)
        {
            MyDatabase.students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return MyDatabase.students;
        }

        public Student? GetStudent(int id)
        {
            return MyDatabase.students.Find(x => x.Id == id);
        }
    }
}
