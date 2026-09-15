using Microsoft.AspNetCore.Mvc;
using Tyle.SaaS.Backend.Food.Api.Controllers;

namespace Tyle.SaaS.Backend.Food.Api.Tests;

public sealed class HomeControllerRouteTests
{
    [Fact]
    public void StatusRoute_UsesGetApiHomeStatus()
    {
        var route = typeof(HomeController).GetCustomAttributes(typeof(RouteAttribute), false).Cast<RouteAttribute>().Single();
        var action = typeof(HomeController).GetMethod(nameof(HomeController.GetStatus))!;
        var httpGet = action.GetCustomAttributes(typeof(HttpGetAttribute), false).Cast<HttpGetAttribute>().Single();

        Assert.Equal("api/home", route.Template);
        Assert.Equal("status", httpGet.Template);
    }
}
