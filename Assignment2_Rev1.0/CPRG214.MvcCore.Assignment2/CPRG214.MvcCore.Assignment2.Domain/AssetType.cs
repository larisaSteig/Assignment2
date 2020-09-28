using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPRG214.MvcCore.Assignment2.Domain
{
    public class AssetType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
