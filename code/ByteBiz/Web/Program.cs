using BusinessObjects.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Account;
using Repositories.CV;
using Repositories.Field;
using Repositories.Project;
using Repositories.ProjectBidding;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<MyDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
		.AddEntityFrameworkStores<MyDbContext>()
		.AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60*24); // Thiết lập thời gian tồn tại là 60 phút
    options.SlidingExpiration = true; // Gia hạn thời gian khi có hoạt động
    options.AccessDeniedPath = "/NotFound"; // Trang chuyển hướng khi bị từ chối truy cập
    options.LoginPath = "/Accounts/Login";
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian chờ phiên
	options.Cookie.HttpOnly = true; // Chỉ cho phép cookie từ máy chủ
	options.Cookie.IsEssential = true; // Cookie cần thiết cho ứng dụng
});
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IProjectRepository,ProjectRepository>();
builder.Services.AddScoped<ICVRepository,CVRepository>();
builder.Services.AddScoped<IProjectBiddingRepository, ProjectBiddingRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToPage("/Customs/Home");
});
app.Run();
