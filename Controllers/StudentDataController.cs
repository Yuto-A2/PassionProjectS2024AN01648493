using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PassionProjectS2024AN01648493.Models;

namespace PassionProjectS2024AN01648493.Controllers
{
    public class StudentDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Lists the students in the database
        /// </summary>
        /// <returns>
        /// An array of students dtos.
        /// </returns>
        //GET: api/StudentData/ListStudents->
        //[{"studentId":1, "student_fname": John, "student_lname": Lennon}],
        //[{"studentId":2, "student_fname": Paul, "student_lname": McCartney}]
        [HttpGet]
        [Route("api/StudentData/ListStudents")]
        public List<StudentDto> ListStudents()
        {
            List<Student>Students = db.Students.ToList();

            List<StudentDto>StudentDtos = new List<StudentDto>();

            foreach(Student student in Students)
            {
                StudentDto Dto = new StudentDto();

                Dto.studentId = student.studentId;
                Dto.student_fname = student.student_lname;
                Dto.student_lname = student.student_fname;
                StudentDtos.Add(Dto);
            }

            return StudentDtos;
        }
    }
}
