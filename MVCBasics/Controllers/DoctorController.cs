using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using System.ComponentModel;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MVCBasics.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(double temp, string scale)
        {
            ViewBag.Temp = temp;
            ViewBag.Scale = scale;

            temp = (scale == "fahrenheit") ? DoctorModel.FahrenheitToCelsius(temp) : temp;

            ViewBag.Message = DoctorModel.CheckFever(temp);
            ViewBag.Color = DoctorModel.GetTemperatureColor(temp);

            return View();
        }
    }
}
