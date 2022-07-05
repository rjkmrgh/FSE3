using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e-auction.Controllers
{
    public class HomeController : Controller
{
    public IActionResult Get()
    {
        return Ok();
    }
}
}
