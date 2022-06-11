using System.ComponentModel.DataAnnotations;

namespace lab_2._3.Models
{
    public class ValidationModel
    {
        [Required (ErrorMessage="Field is empty!")]
        public int answer { get; set;}
    }
}
