using LearningControllers.Data;
using LearningControllers.Mappings;
using LearningControllers.Models.DTOs;
using LearningControllers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LearningControllers.Controllers {

    [ApiController] //Adds validation checking
    [Route("students")] //Base route for Students Controller
    public class StudentsController : Controller {

        private readonly LearningDbContext _dbContext;

        

        public StudentsController(LearningDbContext context) {
            _dbContext = context;
        }

        //Get a list of all Students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents() {

            List<Student> students = await _dbContext.Students.ToListAsync();

            return Ok(students);
        }

        //Get the information for one student
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudent(int id) {
            Student? student = await _dbContext.Students.FindAsync(id);

            if (student is null) {
                return NotFound();
            }

            return Ok(student);
        }

        //Add a new student to the database
        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentDto newStudent) {

            Student student = newStudent.ToStudent();

            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

            return Ok(student);

        }

        //Update current entry in Students table
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto updatedStudent) {

            Student? student = await _dbContext.Students.FindAsync(id);

            if (student is null) {
                return NotFound();
            }

            _dbContext.Entry(student).CurrentValues.SetValues(updatedStudent.UpdateStudent(id));

            await _dbContext.SaveChangesAsync();

            return Ok(student);
        }

        //Delete an entry in the Students table
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id) {

           await _dbContext.Students.Where(student => student.StudentId == id).ExecuteDeleteAsync();

           return NoContent();
        }
        
    }
}
















