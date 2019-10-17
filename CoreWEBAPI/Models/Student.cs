using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CoreWEBAPI.Models
{
    public class Student
    {
        [Key] // primary identity key
        public int StudentUniqueId { get; set; }
        [Required(ErrorMessage ="Student Id is Must")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Student Name is Must")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Course Name is Must")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "University is Must")]
        public string University { get; set; }
        [Required(ErrorMessage = "Educational Year is Must")]
        public string EducationYear { get; set; }
    }
}
