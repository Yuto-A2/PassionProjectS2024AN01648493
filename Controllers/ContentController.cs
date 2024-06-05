using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Diagnostics;
using PassionProjectS2024AN01648493.Models;
using System.Web.Script.Serialization;

namespace PassionProjectS2024AN01648493.Controllers
{
    public class ContentController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        static ContentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44302/api/contentdata/");
        }

        // GET: Content/List
        public ActionResult List()
        {
            //curl localhost:xx/api/ContentData/ListContents
            string url = "listcontents";

            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<ContentDto> Contents = response.Content.ReadAsAsync<IEnumerable<ContentDto>>().Result;
            //Views/Content/List.cshtml

            return View(Contents);
        }

        //GET: Content/Details/{id}
        public ActionResult Details(int id)
        {
            //curl api/ContentData/FindContent/{id}
            string url = "findcontent/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            ContentDto content = response.Content.ReadAsAsync<ContentDto>().Result;
            //Views/Content/Show.cshtml


            return View(content);
        }

        public ActionResult Error()
        {
            return View();
        }

        //GET: Content/New
        public ActionResult New()
        {
            return View();
        }

        //POST: Content/Create
        [HttpPost]
        public ActionResult Create(Content content)
        {
            string url = "addcontent";
            string jsonpayload = jss.Serialize(content);

            //curl -H "Content -Type:application/jason" -d @content.json https://localhost:44302/api/contentdata/addcontent
            HttpContent httpContent = new StringContent(jsonpayload);
            httpContent.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        //GET: Content/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "findcontent/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            ContentDto content = response.Content.ReadAsAsync<ContentDto>().Result;
            return View(content);
        }

        //POST: Content/Update/5
        [HttpPost]
        public ActionResult Update(int id, Content content)
        {
            try
            {
                string url = "UpdateContent" + id;
                string jsonpayload = jss.Serialize(content);

                HttpContent httpContent = new StringContent(jsonpayload);
                httpContent.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        //GET: Content/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {
            return View();
        }

        //POST: Content/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                //curl -d "" localhost:xx//api/contentdata/deletecontent

                string url = "deletecontent/" + id;
                HttpContent content = new StringContent("");

                client.PostAsync(url, content);

                return RedirectToAction("List");

            }
            catch
            {
                return View();
            }
        }
    }
}