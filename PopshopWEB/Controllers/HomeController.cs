using PopshopWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopshopWEB.Controllers
{
    public class HomeController : Controller
    {
        PopshopContext db = new PopshopContext();

        int maxItem = 4;

        public ActionResult Index(int idcat = 0, int page = 1, string search="")
        {
            

            var model = new IPC();
            
            if (page < 1) page = 1;
            
           
            model.CurrentPage = page;
            if (idcat == 0)
            {

                model.Items = db.Item
                        .Where(i => i.Name.Contains(search)&&i.Status.Contains("Продается"))
                        .OrderBy(item => item.idItem);
                        


            }
            else
            {
                model.Items = db.Item
                    .Where(i => i.idCategory == idcat && i.Status.Contains("Продается")&& i.Name.Contains(search))
                    .OrderBy(item => item.idItem);
                    
            }
            model.MaxPage = (int)Math.Ceiling((decimal)model.Items.Count<Item>() / maxItem);
            model.Items=model.Items
                .Skip((page - 1) * maxItem)
                .Take(maxItem);
            if (model.Items.Count() == 0)model.MaxPage=0;
            model.Search = search;




            model.Photos = db.Photos;
            model.Categories = db.Category;
            return View(model);

        }
        public ActionResult GetImage(int id)
        {
            Photos photo = db.Photos
                .Where(p => p.idItem == id)
                .FirstOrDefault();
            if (photo == null)
                return null;
            return File(photo.Image, "image/jpg");
        }
        public ActionResult GetImages(int id)
        {
            Photos photo = db.Photos
                .Where(p => p.idPhoto == id)
                .FirstOrDefault();
                
                
            return File(photo.Image, "image/jpg");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Item(int id)
        {
            var model = new PhotoOfItem();
            model.Item = db.Item.Find(id);
            model.Photos = db.Photos
                .Where(p => p.idItem == id);
            model.first = false;
            return View(model);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}