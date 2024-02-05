using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }    
        [Required]
        [DisplayName("Product Name")]
        public String ProductName { get; set; }
        [Required]
        public String Storage { get; set; }

        [Required]
        public String Brand { get; set; }
        [Required]
        public String Color { get; set; }

        [Required]
        public String Description1 { get; set; }
        [Required]
        public String Description2 { get; set; }
        [Required]
        public String Description3 { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double DisccountPrice { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public String ImageURl { get; set; }
    }
}
