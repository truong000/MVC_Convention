using System.ComponentModel.DataAnnotations;

namespace MVC_Demo.Models
{
    public class UserModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập UserName")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Passwork")]
        [Display(Name = "Passwork")]
        public string Password { get; set; }

        public bool Equals(UserModel user)
        {
            return UserName == user.UserName && Password == user.Password;
        }
    }
    
}
