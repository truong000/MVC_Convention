using System.ComponentModel.DataAnnotations;

namespace MVC_Demo.Models.Student
{
    [Serializable]
    public class StudentItemModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Age")]
        [Display(Name = "Age")]
        public int? Age { get; set; }

    }
}
