using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Review4_.NET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review4_.NET.Controllers
{
    public class CommentController : Controller
    {
        private readonly MyContext _db;

        public CommentController(MyContext db)
        { _db = db; }

        public IActionResult Create(int id)
        {
            var model = new Comment();
            model.PostId = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Comments.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Comment scrap)
        {
            _db.Remove(scrap);
            _db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }
    }
}
