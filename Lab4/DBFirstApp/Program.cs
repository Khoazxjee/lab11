using Microsoft.EntityFrameworkCore;
using DBFirstApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(options =>
{
    var messages = options.ModelBindingMessageProvider;
    messages.SetAttemptedValueIsInvalidAccessor((value, field) => $"Giá trị nhập cho {field} không hợp lệ.");
    messages.SetValueMustBeANumberAccessor(field => $"{field} phải là một số hợp lệ.");
    messages.SetValueMustNotBeNullAccessor(value => "Vui lòng nhập thông tin bắt buộc.");
    messages.SetUnknownValueIsInvalidAccessor(field => $"Giá trị nhập cho {field} không hợp lệ.");
});
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SchoolContext")
    ?? throw new InvalidOperationException("Chưa cấu hình ConnectionStrings:SchoolContext.")));
var app = builder.Build();
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Learners}/{action=Index}/{id?}");
app.Run();
