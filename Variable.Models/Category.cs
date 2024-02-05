using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Variable.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        
        public String Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

    
    }
}
