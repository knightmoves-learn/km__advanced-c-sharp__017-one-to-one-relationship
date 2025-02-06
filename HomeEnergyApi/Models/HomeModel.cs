using System.ComponentModel.DataAnnotations;
namespace HomeEnergyApi.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OwnerLastName { get; set; }

        [StringLength(40)]
        public string? StreetAddress { get; set; }

        public string? City { get; set; }

        [Range(0, 50000, ErrorMessage = "Monthly electric usage is limited to positive numbers of 50,000 kWh or less")]
        public int? MonthlyElectricUsage { get; set; }

        public Home(string ownerLastName, string? streetAddress, string? city, int? monthlyElectricUsage)
        {
            OwnerLastName = ownerLastName;
            StreetAddress = streetAddress;
            City = city;
            MonthlyElectricUsage = monthlyElectricUsage;
        }
    }
}