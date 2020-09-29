using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MvcCore.Assignment2.Presentation.Models
{
    public class AssetViewModel
    {
        public int Id { get; set; }
       
        public string TagNumber { get; set; }
       
        [Display(Name ="Asset Type Name")]
        public string AssetType { get; set; }
        
        public string Manufacturer { get; set; }

        public string Model { get; set; }
     
        public string Description { get; set; }
       
        public string SerialNumber { get; set; }
      
    }
}
