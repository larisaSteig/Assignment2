using System;
using System.ComponentModel.DataAnnotations;

namespace CPRG214.MvcCore.Assignment2.Domain
{
    public class Asset
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        [Required]
        public int AssetTypeID { get; set; }
        [Required]
        public string Manufacturer { get; set; }

        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        //navigation property
        public AssetType Assets { get; set; }
    }
}
