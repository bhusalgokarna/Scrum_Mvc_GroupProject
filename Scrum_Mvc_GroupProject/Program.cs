using Microsoft.EntityFrameworkCore;
using Scrum_Mvc_GroupProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ForumConStr")));
#elif AREEJDEBUG
builder.Services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ForumConStr2")));
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// add migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ForumDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Forum}/{action=Index}/{id?}");

app.Run();
