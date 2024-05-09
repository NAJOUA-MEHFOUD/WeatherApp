using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models
{
    public class City
    {
        [Display(Name = "City Name :")]
        public string Name { get; set; }

        [Display(Name = "Temperature :")]
        public float Temperature { get; set; }

        [Display(Name = "Humidity :")]
        public int Humidity { get; set; }

        [Display(Name = "Pressure :")]
        public int Pressure { get; set; }

        [Display(Name = "Wind Speed :")]
        public float Wind { get; set; }

        [Display(Name = "Weather Condition :")]
        public string Weather { get; set; }

        [Display(Name = "Sunrise Time :")]
        public string Sunrise { get; set; }

        [Display(Name = "Sunset Time :")]
        public string Sunset { get; set; }

        [Display(Name = "Pays :")]
        public string country { get; set; }

       
    }


}
