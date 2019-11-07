using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Repository;
using Rules;
using Services;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<ISlotRepository, SlotRepository>();
            services.AddScoped<ISlotValidation, SlotValidation>();
            services.AddDbContext<EFContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // gestion d'erreurs génériques (notamment erreurs de formattage de paramètres en entrée)
            app.UseExceptionHandler(GestionErreurs());

            app.UseMvc();
        }

        /// <summary>
        /// gestion des erreurs générales avant l'entrée dans le controleur.
        /// En cas d'erreur (par exemple problème de conversion de paramètre), on ne veut pas une page html
        /// mais un retour json interprétable par l'appelant.
        /// </summary>
        /// <returns>erreurs s'il y en a</returns>
        private static Action<IApplicationBuilder> GestionErreurs()
        {
            return a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result).ConfigureAwait(false);
            });
        }
    }
}
