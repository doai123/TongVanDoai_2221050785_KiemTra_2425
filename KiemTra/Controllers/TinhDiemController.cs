using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiemTra.Data;

namespace KiemTra.Controllers
{
    public class TinhDiemController : Controller
    {

        public async Task<IActionResult> Create(TinhDiem tinhDiem)
        {

            return View(tinhDiem);
        }
         public IActionResult Index()
    {
        return View();
    }
       



    }
}