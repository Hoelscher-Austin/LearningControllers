using LearningControllers.Data;
using LearningControllers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LearningControllers.Controllers {

    [ApiController] //Adds validation checking
    [Route("students")] //Route for students controller and associated actions
    public class StudentsController : Controller {

        private readonly LearningDbContext _context;

        public StudentsController(LearningDbContext context) {
            _context = context;
        }


    }
}
