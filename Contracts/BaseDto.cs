using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class BaseDto
    {
        [Required(ErrorMessage = "CreatedBy is required")]
        [StringLength(150, ErrorMessage = "CreatedBy can't be longer than 150 characters")]
        public string? CreatedBy { get; set; }
        [Required(ErrorMessage = "CreatedOnUtc is required")]
        public DateTime CreatedOnUtc { get; set; }
        [Required(ErrorMessage = "LastModifiedBy is required")]
        [StringLength(150, ErrorMessage = "LastModifiedBy can't be longer than 150 characters")]
        public string? LastModifiedBy { get; set; }
        [Required(ErrorMessage = "LastModifiedOnUtc is required")]
        public DateTime? LastModifiedOnUtc { get; set; }
        public bool IsDeleted { get; set; }
     
    }
}
