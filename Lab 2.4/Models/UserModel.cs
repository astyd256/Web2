using System.ComponentModel.DataAnnotations;

namespace lab_2._4.Models
{
    public struct birthday{

    }
    public class UserModel
    {
        [Required (ErrorMessage="Data is empty!")]
        public string firstName { get; set; }
        [Required (ErrorMessage="Data is empty!")]
        public string lastName { get; set; }
        [Required (ErrorMessage="Data is empty!")]
        public int day { get; set; }
        [Required (ErrorMessage="Data is empty!")]
        public string month { get; set;}
        [Required (ErrorMessage="Data is empty!")]
        public int year { get; set; }
        [Required (ErrorMessage="Data is empty!")]
        public string gender { get; set; }
        public string email { get; set; }
        [Required (ErrorMessage="Data is empty!")]
        [StringLength(255,ErrorMessage="Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required (ErrorMessage="Data is empty!")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="Passwords should be same")]
        public string confirmPassword { get; set; }
        [Required (ErrorMessage="You must remember your password!")]
        public bool remember{ get; set;}
        public bool isSignUp{ get; set;}
        public bool firstPartComplete { get; set; }
        public UserModel()
        {   
            isSignUp = false;
            firstPartComplete = false;            
        }
    }
}
