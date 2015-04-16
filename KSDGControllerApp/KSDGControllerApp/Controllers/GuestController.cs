using KSDGControllerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSDGControllerApp.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Index()
        {
            // query database.
            using (var context = new GuestMessageDbContext())
            {
                var query = context.GuestMessages.OrderByDescending(m => m.DatePosted);
                return View(query.ToList());
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(GuestMessage Msg)
        {
            if (!this.ModelState.IsValid)
                return View();

            var files = Request.Files;

            if (files.Count > 0)
            {
                string fileStorePath = Server.MapPath(VirtualPathUtility.ToAbsolute("~/files"));
                string fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(files[0].FileName);
                files[0].SaveAs(fileStorePath + "/" + fileName);
                Msg.FilePath = "~/files/" + fileName;
            }

            // write to database.
            using (var context = new GuestMessageDbContext())
            {
                context.GuestMessages.Add(Msg);
                context.SaveChanges();
            }

            return Redirect("Index");
        }

        public ActionResult Download(string Id = null)
        {
            if (string.IsNullOrEmpty(Id))
                return HttpNotFound();

            string filename = null;

            using (var context = new GuestMessageDbContext())
            {
                var query = context.GuestMessages.Where(m => m.Id == new Guid(Id));
                if (!query.Any())
                    return HttpNotFound();
                else
                    filename = query.First().FilePath;
            }

            string fileStorePath = Server.MapPath(VirtualPathUtility.ToAbsolute(filename));
            FileStream fs = new FileStream(fileStorePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(fs, 
                string.Format("content-disposition; attachment={0}", Path.GetFileName(fileStorePath)));
        }
    }
}