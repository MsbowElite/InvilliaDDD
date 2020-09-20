using System.Security.Claims;
using System.Text;
using AutoMapper;
using InvilliaDDD.Identity.API.Configuration;
using InvilliaDDD.Identity.API.Data;
using InvilliaDDD.Identity.API.Data.Interfaces;
using InvilliaDDD.Identity.API.Helpers;
using InvilliaDDD.Identity.API.Services;
using InvilliaDDD.WebApi.Core.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvilliaDDD.Identity.API
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
            services.AddCors();
            services.AddControllers();

            services.AddMvc()
                .AddMvcOptions(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddDbContext<IdentityManagerContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("LocalDbConnection")));

            services.AddJwtConfiguration(Configuration);

            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            dbInitializer.Initialize();

            app.UseAuthConfiguration();

            app.UseApiConfiguration(env);

            app.UseSwaggerSetup();
        }
    }
}
