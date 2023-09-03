using OBiletCase.Services;
using OBiletCase.WebUI.Middlewares;
using OBiletCase.WebUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddOBiletApiClient(builder.Configuration)
                .AddServiceBindings();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BusLocation}/{action=Index}/{id?}");

app.Run();
