using MyWebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(options =>
{
    var messages = options.ModelBindingMessageProvider;
    messages.SetAttemptedValueIsInvalidAccessor((value, field) => $"Giá trị nhập cho {field} không hợp lệ.");
    messages.SetValueMustBeANumberAccessor(field => $"{field} phải là một số hợp lệ.");
    messages.SetValueMustNotBeNullAccessor(value => "Vui lòng nhập thông tin bắt buộc.");
    messages.SetUnknownValueIsInvalidAccessor(field => $"Giá trị nhập cho {field} không hợp lệ.");
});
builder.Services.AddSingleton<StudentRepository>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("StudentList", "Admin/Student/List", new { controller = "Student", action = "Index" });
app.MapControllerRoute("StudentAdd", "Admin/Student/Add", new { controller = "Student", action = "Create" });
app.MapControllerRoute("Students", "Students/List", new { controller = "Student", action = "Index" });
app.MapControllerRoute("default", "{controller=Student}/{action=Index}/{id?}");
app.Run();
