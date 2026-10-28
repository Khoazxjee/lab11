using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.ViewComponents;

public class RenderViewComponent : ViewComponent
{
    private readonly List<MenuItem> MenuItems = new()
    {
        new MenuItem { Id = 1, Name = "Branches", Link = "Branches/List" },
        new MenuItem { Id = 2, Name = "Students", Link = "Students/List" },
        new MenuItem { Id = 3, Name = "Subjects", Link = "Subjects/List" },
        new MenuItem { Id = 4, Name = "Courses", Link = "Courses/List" }
    };

    public Task<IViewComponentResult> InvokeAsync()
    {
        return Task.FromResult<IViewComponentResult>(View("RenderLeftMenu", MenuItems));
    }
}
