using System.ComponentModel.DataAnnotations;

namespace RealStateApi.DTO
{
    public class UserDTO
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be at least {2}, and maximum {1} characters")]
        public string Name { get; set; }
    }
}
