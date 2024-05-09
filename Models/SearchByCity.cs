using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage ="City name is Empty!")]
        [Display(Name = "City Name :")]
        [StringLength(30,MinimumLength =2,ErrorMessage ="Invalid Input,Lenght Must be between 2 to 20 characters")]
        public String CityName { get; set; }
    }
}
