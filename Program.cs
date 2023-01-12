using Microsoft.OpenApi.Models;
using System.Dynamic;
using System.Reflection;
using VehiclesService.IoC;

const string ApiName = "VehiclesService";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = ApiName,
        Version = "v1",
        Description = $"API de Integração {ApiName}",
        Contact = new OpenApiContact
        {
            Name = "VupTech",
            Email = "contato@vuptech.com.br",
            Url = new Uri("https://vuptech.com.br")
        },
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    //windows => bin\Debug\net7.0\VehiclesService.xml
    //osx | linux => bin/Debug/net7.0/VehiclesService.xml
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    
    config.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

    config.UseInlineDefinitionsForEnums();

    config.CustomSchemaIds(CustomSchemaIdStrategy);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseReDoc(c =>
{
    c.DocumentTitle = $"{ApiName} v1";
    c.SpecUrl = "/swagger/v1/swagger.json";
    c.RoutePrefix = string.Empty;
    c.ConfigObject.AdditionalItems.Add("theme", GetRedocTheme());
});

app.UseInfrastructure();

app.MapControllers();

app.Run();

static string CustomSchemaIdStrategy(Type currentClass)
{
    string returnedValue = currentClass.Name;

    if (returnedValue.EndsWith("Vm"))
        returnedValue = returnedValue.Replace("Vm", string.Empty);

    return returnedValue;
}

static dynamic GetRedocTheme()
{
    dynamic theme = new ExpandoObject();
    theme.colors = new ExpandoObject();
    theme.colors.primary = new ExpandoObject();
    theme.colors.primary.main = "#ec660c";
    return theme;
}