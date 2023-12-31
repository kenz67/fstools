using fstools.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBootstrapBlazor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<TimerService>();
builder.Services.AddSingleton<ChartService>();
builder.Services.AddSingleton<NotesService>();
builder.Services.AddSingleton<WeatherService>();

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
//TODO: first page
//TODO: EU: https://www.eurocontrol.int/service/european-ais-database     https://www.ead.eurocontrol.int/fwf-eadbasic/public/cms/cmscontent.faces?configKey=default.home.page
//TODO: found spot for Austrailia  -  http://www.airservicesaustralia.com/aip/current/dap/AeroProcChartsTOC.htm