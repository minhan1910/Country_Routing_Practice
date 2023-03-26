using ContryRoutePractice.Enum;
using ContryRoutePractice.Entity;
using ContryRoutePractice.Factory;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    var countryDict = CountryFactory.Countries();
    
    endpoints.Map("countries/{countryId:int:range(1,100)?}", async context =>
    {
        var countriesCount = countryDict.Count;    
        
        if (!context.Request.RouteValues.ContainsKey("countryId"))
        {
            var countries = GetIdNameCountriesFormatted(countryDict);
            await context.Response.WriteAsync(countries.ToString());
        }
        else
        {
           int countryId = Convert.ToInt32(context.Request.RouteValues["countryId"]);

            if (countryId < 1 || countryId > 5)
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 404;
                await context.Response.WriteAsync("[No Country]");
            } else
            {
                var country = countryDict[(CountryEnum)countryId];

                await context.Response.WriteAsync(country.Name);
            }
        }
    });

    endpoints.MapGet("countries/{countryId:int:minlength(101)}", async context =>
    {
        if (context.Response.StatusCode == 200)
            context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("No Response");
});

app.Run();

static StringBuilder GetIdNameCountriesFormatted(Dictionary<CountryEnum,Country> countryDict) { 
    StringBuilder countries = new StringBuilder("");

    foreach (var country in countryDict)
    {
        countries.Append(country.Value.IdNameFormatted)
            .Append('\n');
    }

    return countries;
}
