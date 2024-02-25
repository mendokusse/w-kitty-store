using kitty_store.Data;
using kitty_store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddRazorPages();
builder.Services.AddDbContext<kitty_storeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("kitty_storeContext") ?? throw new InvalidOperationException("Connection string 'kitty_storeContext' not found.")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<kitty_storeContext>();


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

app.UseAuthentication(); // Add this line to configure authentication
app.UseAuthorization();

app.MapRazorPages();

app.Run();