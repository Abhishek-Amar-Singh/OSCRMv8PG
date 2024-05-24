var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//--add IServiceCollection custom services
builder.Services.AddPersistenceServices(builder.Configuration);

//--add IHostBuilder custom services (like AWSSecretManager services and many more)
//builder.Host.ConfigureHostBuilderServices();

var app = builder.Build();

//--enable legacy Npgsql Timestamp
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

//--use WebApplication custom services
app.UseWebAppServices();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
