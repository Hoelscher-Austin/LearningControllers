﻿using System.ComponentModel.DataAnnotations;

namespace LearningControllers.Models.Entities {
    public class Student {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Year { get; set; }
    }
}
