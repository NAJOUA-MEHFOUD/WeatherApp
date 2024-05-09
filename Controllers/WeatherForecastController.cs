using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WeatherForecastApp.Models;
using WeatherForecastApp.OpenWeatherMap_Model;
using WeatherForecastApp.Repositories;
using System;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WforecastRepository;

        public WeatherForecastController(IWForecastRepository WForecastRepository)
        {
            _WforecastRepository = WForecastRepository;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { City = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _WforecastRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature = weatherResponse.Main.Temp;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;

                // Convert Unix timestamps to DateTime for Sunrise and Sunset
                viewModel.Sunrise = UnixTimeStampToTimeString(weatherResponse.Sys.Sunrise);
                viewModel.Sunset = UnixTimeStampToTimeString(weatherResponse.Sys.Sunset);
                viewModel.country = weatherResponse.Sys.Country;


            }

            return View(viewModel);
        }

        // Helper method to convert Unix timestamp to DateTime
        // Méthode d'aide pour convertir le timestamp Unix en DateTime avec le format HH:mm:ss
        private string UnixTimeStampToTimeString(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime.ToString("HH:mm:ss");
        }

    }
}
