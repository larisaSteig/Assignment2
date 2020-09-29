using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.MvcCore.Assignment2.BLL;
using CPRG214.MvcCore.Assignment2.Domain;
using CPRG214.MvcCore.Assignment2.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.MvcCore.Assignment2.Presentation.Controllers
{
   
    public class AssetController : Controller
    {

        public IActionResult GetPropertiesByType(int id)
        {
            return ViewComponent("AssetByType", id);
        }
        public IActionResult Search()
        {
            ViewBag.AssetType = GetAssetType();
            return View();
        }
        public IActionResult Index()
        {
            var asset = AssetManager.GetAll();
            var viewModel = asset.Select(r => new AssetViewModel
            {
                Id = r.Id,
                AssetType = r.AssetType.Name,
                Description = r.Description,
                Manufacturer = r.Manufacturer,
                Model = r.Model,
                SerialNumber = r.SerialNumber,
                TagNumber = r.TagNumber

            }).ToList();
            return View(viewModel);
        }

       
        public IActionResult Create()
        {

            ViewBag.AssetTypeID = GetAssetTypes();
            return View();
          
        }


        [HttpPost]
        public IActionResult Create(Asset newAsset)
        {
            try
            {
                AssetManager.Add(newAsset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            
        }

        public IActionResult Edit(int id)
        {
            var asset = AssetManager.Find(id);
            return View(asset);
        }

        [HttpPost]
        public IActionResult Edit(Asset asset)
        {
            try
            {
                //call the OwnerManager to EDIT
                AssetManager.Update(asset);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        protected IEnumerable GetAssetTypes()
        {
            var asset = TypeManager.GetAsKeyValuePair();
            var styles = new SelectList(asset, "Value", "Text");

            var list = styles.ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "All styles",
                Value = "0"
            });
            return list;
        }

        protected IEnumerable GetAssetType()
        {
            var types = TypeManager.GetAsKeyValuePair();
           // var styles = new SelectList(types, "Value", "Text");

            var list = new SelectList(types, "Value", "Text").ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "All Styles",
                Value = "0"
            });

            return list;
        }
    }
}
