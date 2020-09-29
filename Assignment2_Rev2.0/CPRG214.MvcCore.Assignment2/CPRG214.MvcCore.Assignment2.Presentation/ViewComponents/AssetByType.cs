using CPRG214.MvcCore.Assignment2.BLL;
using CPRG214.MvcCore.Assignment2.Domain;
using CPRG214.MvcCore.Assignment2.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace CPRG214.MvcCore.Assignment2.Presentation.ViewComponents
{
    public class AssetByTypeViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> AssetType = null;

            if(id == 0)
            {
                AssetType = AssetManager.GetAll();

            }
            else
            {
                AssetType = AssetManager.GetAllByAssetType(id);
            }
            // transform to new View model

            var newModel = AssetType.Select(p => new AssetViewModel
            {
                AssetType = p.AssetType.Name,
                Description = p.Description,
                Id = p.Id,
                Manufacturer = p.Manufacturer,
                Model = p.Model,
                SerialNumber = p.SerialNumber,
                TagNumber = p.TagNumber

            }).ToList();

            return View(newModel);
        }
    }
}
