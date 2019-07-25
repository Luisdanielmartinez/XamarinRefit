using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xamarin.Refit.Models;
using Xamarin.Refit.Models.Context;

namespace Xamarin.Refit.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;
        public UsersController(ApplicationContext context)
        {
            _context = context;
        }//sds
        [HttpGet]
        public IEnumerable<User> GET()
        {
            return _context.Users.ToList();
        }
    }
}