﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Books.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
