using AutoMapper;
using Fcc.Aeat.Api.Models;
using Fcc.Aeat.Core.Data.Connection;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using Fcc.Aeat.Factura.Handlers;
using Fcc.Aeat.Factura.Managers;
using Fcc.Aeat.Factura.Queries.Contracts;
using Fcc.Aeat.Factura.Queries.Impl;
using Fcc.Aeat.Factura.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Fcc.Aeat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureAutoMapper(services);

            ConfigureManagers(services);

            ConfigureHandlers(services);

            ConfigureDapperConnectionStrings(services);

            ConfigureServiceQueries(services);

            ConfigureServiceRepositories(services);

            services.AddControllers().AddFluentValidation(s =>
            {
                s.RegisterValidatorsFromAssemblyContaining<Startup>();
                s.DisableDataAnnotationsValidation = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fcc.Aeat.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fcc.Aeat.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FacturaRequestDto, FacturaAddCommand>();
                cfg.CreateMap<FacturaRequestDto, FacturaUpdateCommand>();
                cfg.CreateMap<FacturaRequestDto, FacturaRequest>();
            });

            var mapper = new Mapper(mapperConfig);

            services.AddSingleton(mapper);
        }

        private void ConfigureDapperConnectionStrings(IServiceCollection services)
        {
            string FccConnectionstring = Configuration.GetConnectionString("FccConnectionString");

            var connectionString = new ConnectionString(FccConnectionstring);

            services.AddSingleton(connectionString);
        }

        private void ConfigureHandlers(IServiceCollection services)
        {
            services.AddMediatR(typeof(FacturaAddCommandHandler).Assembly);

            services.AddMediatR(typeof(FacturaUpdateCommandHandler).Assembly);

            services.AddMediatR(typeof(FacturaDeleteCommandHandler).Assembly);
        }

        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<IAddFacturaManager, AddFacturaManager>();

            services.AddScoped<IUpdateFacturaManager, UpdateFacturaManager>();

            services.AddScoped<IDeleteFacturaManager, DeleteFacturaManager>();
        }

        private void ConfigureServiceQueries(IServiceCollection services)
        {
            services.AddScoped<IFacturaQueries, FacturaQueries>();
        }

        private void ConfigureServiceRepositories(IServiceCollection services)
        {
            services.AddScoped<IFacturaRepository, FacturaRepository>();
        }
    }
}
