using System;
using API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "ClipItch",
          Version = "v1",
          Description = "Documentação dos EndPoints do Clipitch API",
          Contact = new OpenApiContact
          {
            Name = "Gustavo Castro",
            Url = new Uri("https://github.com/gstvcastroc")
          },
          License = new OpenApiLicense
          {
            Name = "License",
            Url = new Uri("https://openlearninglibrary.mit.edu/tos")
          }
        });
      });

      services.AddControllers()
        .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

      services.ResolveDependencies(Configuration);
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClipItch"); c.RoutePrefix = string.Empty; });
      }

      app.ResolveBuild();
    }
  }
}
