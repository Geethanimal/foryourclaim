using foryourclaim___0._2V.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foryourclaim___0._2V.Controllers
{
    public class WebMasterController : Controller
    {
        private readonly ILogger<WebMasterController> _logger;
        WMlogin wmob = new WMlogin();

        
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Index([Bind] WebMaster ad)
        {
            int res = wmob.logincheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Admin";
            }
            else
            {
                TempData["msg"] = "Admin id or password is wrong";
            }
            return View();

        }
        public WebMasterController(ILogger<WebMasterController> logger)
        {
            _logger = logger;
        }
    }
}
