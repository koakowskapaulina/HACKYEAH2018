using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BE.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddCors();

            var builder = new ContainerBuilder();
            builder.RegisterType<RaffleService>().As<IRaffleService>();
            builder.RegisterType<MockService>().As<IMockService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<BazkaContext>();
            //builder.RegisterType<x>().As<Ix>();

            builder.Populate(services);
            var container = builder.Build();


            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
