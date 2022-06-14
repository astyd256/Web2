using System.ComponentModel.DataAnnotations;

namespace lab_2._4.Models
{
    public class ValidationModel
    {
        [Required (ErrorMessage="Data is empty!")]
        public string data { get; set;}
        [Required (ErrorMessage="Data is empty!")]
        public bool isActive { get; set; }
    }
}
