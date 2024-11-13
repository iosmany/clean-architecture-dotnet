using ecommerce.persistence;
using System.Runtime.Loader;

var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "ecommerce*.dll");

var assemblies = files
    .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOwnDbContext(builder.Configuration);
builder.Services.AddControllersWithViews();

builder.Services.Scan(p => p.FromAssemblies(assemblies)
            .AddClasses()
            .AsMatchingInterface());

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
