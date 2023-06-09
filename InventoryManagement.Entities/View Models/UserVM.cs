using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.View_Models
{
    public class UserVM
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[789]\d{9}$", ErrorMessage = "Invalid Phone Number")]
        public string ContactNumber { get; set; }

        public int userStatus { get; set; }
    }
}
