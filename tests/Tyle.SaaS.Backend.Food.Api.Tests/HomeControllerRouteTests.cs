using Microsoft.AspNetCore.Mvc;
using Tyle.Packages.Bases.Controllers;
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

    [Fact]
    public void HomeController_RendersHtmlHomeThroughBaseController()
    {
        var controller = new HomeController();
        var result = controller.Index();

        var content = Assert.IsType<ContentResult>(result);

        Assert.True(typeof(BaseController).IsAssignableFrom(typeof(HomeController)));
        Assert.Equal("text/html", content.ContentType);
        Assert.Contains("Tyle Food API", content.Content);
    }
}
