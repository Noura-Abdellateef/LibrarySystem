using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
        public abstract class BaseEntity<T> : IEntity
        {
            [Required]
        public long Id { get; set; }


      long IEntity.Id
            {
                get { return Id; }
                set { }
            }

            [Required]
            public string? CreatedBy { get; set; }

            [Required]
            public DateTime CreatedOnUtc { get; set; }

            public string? LastModifiedBy { get; set; }

            public DateTime? LastModifiedOnUtc { get; set; }
           public bool IsDeleted { get; set; }
        }
    }

