using fstools.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBootstrapBlazor().AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<TimerService>()
    .AddScoped<ChartService>()
    .AddScoped<NotesService>()
    .AddScoped<WeatherService>()
    .AddScoped<BrowserService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

//
//TODO: Checklist page?
//EU: https://www.eurocontrol.int/service/european-ais-database     https://www.ead.eurocontrol.int/fwf-eadbasic/public/cms/cmscontent.faces?configKey=default.home.page
//found spot for Austrailia  -  http://www.airservicesaustralia.com/aip/current/dap/AeroProcChartsTOC.htm