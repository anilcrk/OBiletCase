using OBiletCase.Services;
using OBiletCase.WebUI.Middlewares;
using OBiletCase.WebUI;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OBiletCase.WebUI.Models;
using OBiletCase.WebUI.Models.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddFluentValidation(f =>
                {
                    f.RegisterValidatorsFromAssemblyContaining<BusJourneySearchViewModelValidator>();
                });

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();


builder.Services.AddOBiletApiClient(builder.Configuration)
                .AddServiceBindings();

builder.Services.AddScoped<IValidator<BusJourneySearchViewModel>, BusJourneySearchViewModelValidator>();

// Defined in ServiceRegistration.cs for binding ModelServices
builder.Services.AddModelServices();

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

app.UseMiddleware<DeviceSessionInformationMiddleware>();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BusJourney}/{action=Index}/{id?}");

app.Run();
