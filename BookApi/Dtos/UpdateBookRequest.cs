using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos
{
    public class UpdateBookRequest
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(1500, 2100)]
        public int Year { get; set; }
    }
}
