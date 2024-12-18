using System.ComponentModel.DataAnnotations;

namespace GERNALE_WEB_APP.Core.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Student Number")]
        public required string StudentNumber { get; set; }
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        [Display(Name = "Section Id")]
        public int SectionId { get; set; }
    }
}
