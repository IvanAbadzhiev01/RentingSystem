using Microsoft.AspNetCore.Mvc;
using RentingSystem.ModelBinders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(option =>
{
    option.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    option.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
        name: "Car Details",
        pattern: "/Car/Details/{id}/{information}",
        defaults: new { Controller = "Car", Action = "Details" }
        );
app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
  );

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.CreateAdminRoleAsync();

await app.RunAsync();
