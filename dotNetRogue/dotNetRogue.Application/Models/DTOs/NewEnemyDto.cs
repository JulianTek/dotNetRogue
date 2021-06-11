using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// Used to provide new enemy data to the application layer
    /// </summary>
    public class NewEnemyDto
    {
        [Required(ErrorMessage = "A name is required")]
        [MinLength(1, ErrorMessage = "A name must contain at least 1 character")]
        [MaxLength(1024, ErrorMessage = "A name cannot exceed 1024 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Health is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Health { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Required(ErrorMessage = "Attack is required")]
        public int Attack { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Required(ErrorMessage = "Defense is required")]
        public int Defense { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Required(ErrorMessage = "Speed is required")]
        public int Speed { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Required(ErrorMessage = "Gold on kill is required")]
        public int GoldOnKill { get; set; }
    }
}
