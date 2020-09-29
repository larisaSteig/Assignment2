using CPRG214.MvcCore.Assignment2.Data;
using CPRG214.MvcCore.Assignment2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace CPRG214.MvcCore.Assignment2.BLL
{
    public class AssetManager
    {
        public static void Add(Asset newAsset)
        {
            var context = new AssetsContext();
            context.Assets.Add(newAsset);
            context.SaveChanges();
        }
        public static List<Asset> GetAll()
        {
            var context = new AssetsContext();
            var assets = context.Assets.Include(r => r.AssetType).ToList();
            return assets;
        }

        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetsContext();
            var assets = context.Assets.
                Where(p => p.AssetTypeID == id).Include(rp => rp.AssetType).ToList();
            return assets;
        }

        public static IList GetAsKeyValuePair()
        {
            var context = new AssetsContext();
            var types = context.Assets.Select(o => new
            {
                Vaue = o.Id,
                Text = o.Description
            }).ToList();
            return types;
        }

        public static Asset Find(int id)
        {
            var context = new AssetsContext();
            var originalAsset = context.Assets.Find(id);
            return originalAsset;
        }

        public static void Update(Asset asset)
        {
            var context = new AssetsContext();
            var originalAsset = context.Assets.Find(asset.Id);
            originalAsset.Manufacturer = asset.Manufacturer;
            originalAsset.Model = asset.Model;
            originalAsset.SerialNumber = asset.SerialNumber;
            originalAsset.TagNumber = asset.TagNumber;
            originalAsset.Description = asset.Description;
            originalAsset.AssetType = asset.AssetType;
            context.SaveChanges();
        }
    }
}
