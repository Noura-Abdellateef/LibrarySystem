﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class AuthorDto:BaseDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<BookDto>? Books { get; set; }
    }
}
