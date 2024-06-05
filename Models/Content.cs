using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProjectS2024AN01648493.Models
{
    public class Content
    {
        [Key]
        public int content_Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime Post_date { get; set; }
        public string comment { get; set; }

       [ForeignKey("Student")]
        public int studentId { get; set; }
        public virtual Student Student { get; set; }

       [ForeignKey("Teacher")]
       public int teacherId { get; set; }
       public virtual Teacher Teacher { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
    public class ContentDto
    {
        public int content_Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime Post_date { get; set;}
        public string comment { get; set; }

        public int studentId { get; set; }
        public string student_fname { get; set; }
        public string student_lname { get; set; }

        public int teacherId { get; set; }
        public string teacher_fname { get; set; }
        public string teacher_lname { get; set; }
    }
}