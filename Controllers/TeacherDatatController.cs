using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PassionProjectS2024AN01648493.Models;

namespace PassionProjectS2024AN01648493.Controllers
{
    public class TeacherDatatController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Lists the teachers in the database
        /// </summary>
        /// <returns>
        /// An array of teachers dtos.
        /// </returns>
        //GET: api/TeacherData/ListTeachers->
        //[{"teacherId":1, "student_fname": Angela, "student_lname": Smith}],
        //[{"teacherId":2, "student_fname": Daniel, "student_lname": Joe}]
        [HttpGet]
        [Route("api/TeacherData/ListTeachers")]
        public List<TeacherDto> ListTeachers()
        {
            List<Teacher> Teachers = db.Teachers.ToList();

            List<TeacherDto> TeacherDtos = new List<TeacherDto>();

            foreach (Teacher teacher in Teachers)
            {
                TeacherDto Dto = new TeacherDto();

                Dto.teacherId = teacher.teacherId;
                Dto.teacher_fname = teacher.teacher_fname;
                Dto.teacher_lname = teacher.teacher_lname;
                TeacherDtos.Add(Dto);
            }

            return TeacherDtos;
        }
    }
}
