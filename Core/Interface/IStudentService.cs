using GERNALE_WEB_APP.Core.Model;

namespace GERNALE_WEB_APP.Core.Interface
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student? GetStudent(int id);
    }
}
