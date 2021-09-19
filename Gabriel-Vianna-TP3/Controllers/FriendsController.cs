using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_Vianna_TP3.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
