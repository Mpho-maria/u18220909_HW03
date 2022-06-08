using u18220909_HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u18220909_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: File
        public ActionResult IndexV()
        {

            string[] filePaths = Directory.GetFiles(HttpContext.Server.MapPath("~/Media/Videos/"));
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                FileModel filemodel = new FileModel();
                filemodel.FileName = Path.GetFileName(filePath);
                fileList.Add(filemodel);
            }

            return View(fileList);
        }

        public ActionResult Download(string FileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/Media/Videos/") + FileName;

            
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            
            return File(bytes, "application/octet-stream", FileName);

        }

        public ActionResult Delete(string FileName)
        {

            string fullPath = Request.MapPath("~/Media/Videos/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("IndexV");

        }
    }
}