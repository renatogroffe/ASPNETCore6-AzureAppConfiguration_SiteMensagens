var builder = WebApplication.CreateBuilder(args);

var connectionAppConfiguration =
    builder.Configuration.GetConnectionString("AppConfiguration");
var useAppConfiguration =
    !String.IsNullOrWhiteSpace(connectionAppConfiguration);

if (useAppConfiguration)
{
    builder.Host.ConfigureAppConfiguration(cfg => {
        cfg.AddAzureAppConfiguration(options =>
        {
            options.Connect(connectionAppConfiguration)
                .ConfigureRefresh(refresh =>
                {
                    refresh.Register("Mensagens:Aviso").SetCacheExpiration(
                        TimeSpan.FromSeconds(20));
                });
        });
    });

    builder.Services.AddAzureAppConfiguration();
}

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (useAppConfiguration)
    app.UseAzureAppConfiguration();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();