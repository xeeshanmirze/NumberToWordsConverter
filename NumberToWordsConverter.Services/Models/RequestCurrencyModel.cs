using System.ComponentModel.DataAnnotations;

namespace NumberToWordsConverter.Models
{
    /// <summary>
    /// Input Model for Words Conversion
    /// </summary>
    public class RequestCurrencyModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 9999999.99)]
        public decimal Currency { get; set; }
    }
}