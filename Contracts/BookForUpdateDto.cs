using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
  public class BookForUpdateDto:BaseDto
    {

        [Required(ErrorMessage = "Title is required")]
        [StringLength(250, ErrorMessage = "Name can't be longer than 250 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "AuthorId is required")]
        public  long  AuthorId { get; set; }
    }
}
