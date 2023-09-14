using System.ComponentModel.DataAnnotations;

namespace RealStateApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name cant be null or empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image Url Name cant be null or empty")]
        public string ImageUrl { get; set; }
        public ICollection<Property> Properties { get; set; }
        public string Description { get; set; }
    }
}
