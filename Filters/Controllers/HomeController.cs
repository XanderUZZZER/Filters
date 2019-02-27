﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    //[HttpsOnly]
    [Profile]
    public class HomeController : Controller
    {
        //[RequireHttps]
        public ViewResult Index() => View("Message",
                    "This is the Index action on the Home controller");

        //[RequireHttps]
        public ViewResult SecondAction() => View("Message",
                    "This is the SecondAction action on the Home controller");
    }
}
