using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.MvcCore.Assignment2.Domain
{
    [Table("Assets")]
    public class Asset
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }


        [Display(Name = "Asset type Name")]
        public int AssetTypeID { get; set; }
        [Required]
        public string Manufacturer { get; set; }

        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        //navigation property
        public AssetType AssetType { get; set; }
    }
}
