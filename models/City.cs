using System.ComponentModel.DataAnnotations;

namespace CityManager.WebAPI.models
{
    public class City
    {
        [Key]
        public Guid  cityId { get; set; } 
        public string? cityName { get; set; }    
    }
}
