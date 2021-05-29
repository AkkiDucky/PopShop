using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace PopshopWEB.Controllers
{
    public class WebController : ApiController
    {
        PopshopContext db = new PopshopContext();
        [HttpGet]
        public IEnumerable<Item> GetItem()
        {
            return db.Item;
        }

        public Item GetItem(int id)
        {
            Item item = db.Item.Find(id);
            return item;
        }
        [HttpPost]
        public void CreateBook([FromBody] Item item)
        {
            db.Item.Add(item);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditBook(int id, [FromBody] Item item)
        {
            if (id == item.idItem)
            {
                db.Entry(item).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Item item = db.Item.Find(id);
            if (item != null)
            {
                db.Item.Remove(item);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}