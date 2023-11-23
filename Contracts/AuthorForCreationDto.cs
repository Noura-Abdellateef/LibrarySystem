using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class AuthorForCreationDto:BaseDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(150, ErrorMessage = "Name can't be longer than 250 characters")]
        public string? Name { get; set; }

       
       
    }
}
