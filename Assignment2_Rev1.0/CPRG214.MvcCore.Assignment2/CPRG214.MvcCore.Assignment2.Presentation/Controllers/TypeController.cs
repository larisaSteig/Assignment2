using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.MvcCore.Assignment2.BLL;
using CPRG214.MvcCore.Assignment2.Domain;
using CPRG214.MvcCore.Assignment2.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.MvcCore.Assignment2.Presentation.Controllers
{
    public class TypeController : Controller
    {

        public IActionResult Index()
        {
            var asset = TypeManager.GetAll();
            var viewModel = asset.Select(r => new TypeViewModel
            {
                Id = r.Id,
                Name = r.Name

            }).ToList();
            return View(viewModel);
        }

        public IActionResult Create()
        {

            
            return View();

        }


        [HttpPost]
        public IActionResult Create(AssetType newAsset)
        {
            try
            {
                TypeManager.Add(newAsset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }
}
