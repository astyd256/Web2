var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRand, RandRealisation>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CalcService}/{action=Index}/{id?}"
    );


app.Run();

public interface IRand
{
    public string GetFirstval();
    public string GetSecondval();
    public string Add();
    public string Sub();
    public string Mult();
    public string Div();
}
public class RandRealisation : IRand

{
    private int _firstval;
    private int _secondval;

    public RandRealisation()
    {
        Random random = new Random();
        _firstval = random.Next() % 11;
        _secondval = random.Next() % 11;
    }

    public string Add()
    {
        return Convert.ToString(_firstval + _secondval);
    }
    public string Sub()
    {
        return Convert.ToString(_firstval - _secondval);
    }
    public string Mult()
    {
        return Convert.ToString(_firstval * _secondval);
    }
    public string Div()
    {
        return Convert.ToBoolean(_secondval) ? Convert.ToString(_firstval / _secondval) : "Error!";
    }

    public string GetFirstval() 
    {
        return Convert.ToString(_firstval);
    }

    public string GetSecondval()
    {
        return Convert.ToString(_secondval);
    }
}