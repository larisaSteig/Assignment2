using CPRG214.MvcCore.Assignment2.Data;
using CPRG214.MvcCore.Assignment2.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.MvcCore.Assignment2.BLL
{
    public class TypeManager
    {
        public static IList GetAsKeyValuePair()
        {
            var context = new AssetsContext();
            var types = context.AssetTypes.Select(o => new
            {
                Value = o.Id,
                Text = o.Name
            }).ToList();
            return types;
        }

        public static List<AssetType> GetAll()
        {
            var context = new AssetsContext();
            var assets = context.AssetTypes.ToList();
            return assets;
        }

        public static void Add(AssetType newAsset)
        {
            var context = new AssetsContext();
            context.AssetTypes.Add(newAsset);
            context.SaveChanges();

        }
    }
}
