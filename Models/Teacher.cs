using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProjectS2024AN01648493.Models
{
    public class Teacher
    {
        [Key]
        public int teacherId { get; set; }
        public string teacher_fname { get; set; }
        public string teacher_lname { get; set; }
    }
    public class TeacherDto
    {
        public int teacherId { get; set; }
        public string teacher_fname { get; set; }
        public string teacher_lname { get; set; }
    }
}