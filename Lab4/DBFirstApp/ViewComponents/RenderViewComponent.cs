using Microsoft.AspNetCore.Mvc;
using DBFirstApp.Models;
namespace DBFirstApp.ViewComponents;
public class RenderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View("RenderLeftMenu", new List<MenuItem>
    {
        new() { Id = 1, Name = "Người học", Link = "Learners" },
        new() { Id = 2, Name = "Ngành học", Link = "School/Majors" },
        new() { Id = 3, Name = "Môn học", Link = "School/Courses" },
        new() { Id = 4, Name = "Đăng ký học", Link = "School/Enrollments" }
    });
}
