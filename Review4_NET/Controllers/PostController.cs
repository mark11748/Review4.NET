using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Review4_.NET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review4_.NET.Controllers
{
    public class PostController : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<User> _userManager;

        public PostController(UserManager<User> userManager, MyContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null) 
                { var currentUser = await _userManager.FindByIdAsync(userId); }
            var model = _db.Posts.Include(x=>x.Comments).ToList();

            //get posts associated with user
            //var blogPosts = _db.Posts.Include(p => p.Comments).Where(x => x.UserId == currentUser.Id).ToList();
            //foreach (Post post in blogPosts)
            //{
            //    post.Comments = _db.Comments.Where(c => c.PostId == post.Id).ToList();
            //    foreach (Comment comment in post.Comments)
            //    {
            //        User commentAuthor = await _userManager.FindByNameAsync(comment.Author);
            //        if (commentAuthor != null)
            //        { continue; }
            //        else
            //        { 
            //            comment.User = new User { UserName = "Guest" , Email = "N/A" , ImgString = "http://media.culturemap.com/crop/06/03/320x240/Anonymous_Group_logo_this.jpg" };
            //            comment.Author = "Guest";
            //        } 
            //    }
            //}
            return View(model);
        }
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            { return View(); }
            else
            { return RedirectToAction("Index"); }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userManager.FindByIdAsync(userId)!=null)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Post trashPost = _db.Posts.FirstOrDefault(p => p.Id == id);
            _db.Posts.Remove(trashPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit( int id )
        {
            var model = _db.Posts.FirstOrDefault(post => post.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit( Post target )
        {
                _db.Entry(target).State = EntityState.Modified;
                _db.SaveChanges();
        
            return RedirectToAction("Index");
        }

    }
}
