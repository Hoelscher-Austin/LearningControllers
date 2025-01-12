using System.ComponentModel.DataAnnotations;

namespace LearningControllers.Models.DTOs {
    public record CreateStudentDto (

        [Required][Length(1,50)] string? Name,
        [Required][Range(1, 99)] int Age,
        [Required] string? Year 
    );
}
