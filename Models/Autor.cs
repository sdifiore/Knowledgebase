﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models

{
    [Table("Autores")]
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public Fonte? Fonte { get; set; }
    }
}
