using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProjectS2024AN01648493.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        public string student_fname { get; set; }

        public string student_lname { get; set; }

    }
    public class StudentDto
    {
        public int studentId { get; set; }
        public string student_fname { get; set; }
        public string student_lname { get; set; }

        //No affect database. Not necessary update-database.
    }
}