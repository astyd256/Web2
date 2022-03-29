var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Calc/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calc}/{action=Index}/{id?}"
    );

app.MapGet("/api/calc/{value1:int}/{opperand}/{value2:int}", (int value1, string opperand, int value2) =>
{
    switch (opperand)
    {
        case "+":
            return value1 + value2;
        case "-":
            return value1 - value2;
        case "*":
            return value1 * value2;
        case "/":
            return value1 / value2;
        default:
            app.Logger.LogError("WRONG OPPERAND CHANGE NOW!");
            return 0;
    }
});
app.MapGet("/api/calc/summarize/{value1:int}/{value2:int}", (int value1, int value2) =>
{ return value1 + value2; });
app.MapGet("/api/calc/subtract/{value1:int}/{value2:int}", (int value1, int value2) =>
{ return value1 - value2; });
app.MapGet("/api/calc/multiply/{value1:int}/{value2:int}", (int value1, int value2) =>
{ return value1 * value2; });
app.MapGet("/api/calc/divide/{value1:int}/{value2:int}", (int value1, int value2) =>
{ return value1 / value2; });

app.Run();