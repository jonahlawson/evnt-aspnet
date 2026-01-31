using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var Configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
