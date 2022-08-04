namespace MVC_Demo.Models
{
    public class UserModel
    {
        public string UserName { get; set; }    
        public string Password { get; set; }

        public bool Equals(UserModel user)
        {
            return UserName == user.UserName && Password == user.Password;
        }
    }
    
}
