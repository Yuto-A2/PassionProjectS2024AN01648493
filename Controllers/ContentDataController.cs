using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProjectS2024AN01648493.Models;
using System.Diagnostics;

namespace PassionProjectS2024AN01648493.Controllers
{
    public class ContentDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Lists the contents in the database
        /// </summary>
        /// <returns>
        /// An array of contents dtos.
        /// </returns>
        //GET: api/ContentData/ListContents->
        //[{"contentId":1, "content": Fui a Mexio., "Date": May 30, "comment": Goode job, }],
        [HttpGet]
        public IEnumerable<ContentDto> ListContents()
        {
            List<Content> Contents = db.Contents.ToList();

            List<ContentDto> ContentDtos = new List<ContentDto>();

            Contents.ForEach(content => ContentDtos.Add(new ContentDto()
            {
                content_Id = content.content_Id,
                title = content.title,
                content = content.content,
                Post_date = content.Post_date,
                comment = content.comment,
                student_fname = content.Student.student_fname,
                student_lname = content.Student.student_lname,
                teacher_fname = content.Teacher.teacher_fname,
                teacher_lname = content.Teacher.teacher_lname
            }));
          

            return ContentDtos;
        }

        /// <summary>
        /// Find a particular content given its id
        /// </summary>
        /// <returns>
        /// An array of contents dtos.
        /// </returns>
        /// <param name="id">
        /// The id of the content.
        /// </param>
        //GET: api/ContentData/ListContents/1->
        //[{"contentId":1, "content": Fui a Mexio., "Date": May 30, "comment": Goode job, }],
        [HttpGet]
        [Route("api/ContentData/FindContent/{id}")]
        public ContentDto FindContent(int id)
        {
            Content Content = db.Contents.Find(id);

           
            ContentDto Dto = new ContentDto();

            Dto.content_Id = Content.content_Id;
            Dto.title = Content.title;
            Dto.content = Content.content;
            Dto.Post_date = Content.Post_date;
            Dto.comment = Content.comment;
            Dto.student_fname = Content.Student.student_fname;
            Dto.student_lname = Content.Student.student_lname;
            Dto.teacher_fname = Content.Teacher.teacher_fname;
            Dto.teacher_lname = Content.Teacher.teacher_lname;


            return Dto;
        }

        // POST: api/ContentData/UpdateContent/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateContent(int id, Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != content.content_Id)
            {

                return BadRequest();
            }

            db.Entry(content).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContentData/AddContent
        [ResponseType(typeof(Content))]
        [HttpPost]
        public IHttpActionResult AddContent(Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contents.Add(content);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/ContentData/DeleteContent/5
        [ResponseType(typeof(Content))]
        [HttpPost]
        public IHttpActionResult DeleteContent(int id)
        {
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return NotFound();
            }

            db.Contents.Remove(content);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool ContentExists(int id)
        {
            return db.Contents.Count(e => e.content_Id == id) > 0;
        }
    }
}
