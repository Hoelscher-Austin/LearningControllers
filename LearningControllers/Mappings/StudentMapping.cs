using LearningControllers.Models.Entities;
using LearningControllers.Models.DTOs;


namespace LearningControllers.Mappings {
    public static class StudentMapping {


        public static Student ToStudent(this CreateStudentDto newStudent) {

            return new Student() {

                Name = newStudent.Name,
                Age = newStudent.Age,
                Year = newStudent.Year
            };
        }

        public static Student UpdateStudent(this UpdateStudentDto updatedStudent, int id) {

            return new Student() {
                StudentId = id,
                Name = updatedStudent.Name,
                Age = updatedStudent.Age,
                Year = updatedStudent.Year
            };
        }
    }
}
