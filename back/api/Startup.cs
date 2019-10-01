using api.Authentication;
using api.Extensions;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Swashbuckle.AspNetCore.Swagger;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace api
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
            services.AddCors(options => options.AddPolicy("AllowAll", p =>
            {
                p.AllowAnyOrigin();
                p.AllowAnyMethod();
                p.AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

            var version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new Info
                {
                    Title = Configuration.GetValue<string>("api_name"),
                    Version = version
                });
            });

             var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                    Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            services.AddAuthJwtConfigurations(signingConfigurations, tokenConfigurations);
            services.AddTransient<IConnectionFactory, ConnectionFactory>()
                .AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IUsuarioService, UsuarioService>();
            services.AddSingleton(factory => new MySqlConnection(Configuration.GetConnectionString("MySqlConnectionString")));

            services.AddSingleton<IRefeicaoRepository, RefeicaoRepository>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();

            services.AddSingleton<IRefeicaoService, RefeicaoService>();
            services.AddSingleton<IClienteService, ClienteService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");

            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", Configuration.GetValue<string>("api_name"));
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
