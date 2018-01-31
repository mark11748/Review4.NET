using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using Review4_.NET.Models;

namespace Review4_.NET.Controllers
{
    public class RepoController : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<User> _userManager;

        public RepoController(UserManager<User> userManager, MyContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            var RepoList = Repo.GetRepos().Take(3);

            return View(RepoList);
        }
    }
}
