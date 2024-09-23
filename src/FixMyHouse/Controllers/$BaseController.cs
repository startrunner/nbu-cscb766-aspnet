using Microsoft.AspNetCore.Mvc;

namespace FixMyHouse.Controllers;

public abstract class BaseController : Controller
{
    protected TimeSpan TimeZoneOffset => TimeSpan.FromHours(double.Parse(Request.Cookies["TZOffset"] ?? "0"));
}
