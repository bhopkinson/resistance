using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using Resistance.Web.Hubs;
using Resistance.Web.Services;
using Resistance.Web.Services.Mqtt;
using SimpleMediator.Extensions.Microsoft.DependencyInjection;
using System.Reflection;
using MqttServerOptions = Resistance.Web.Services.Mqtt.MqttServerOptions;

namespace Resistance.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IMqttServerConnectionValidator, MqttServerConnectionValidator>()
                .AddSingleton<IMqttServerSubscriptionInterceptor, MqttServerSubscriptionInterceptor>()
                .AddHostedMqttServer<MqttServerOptions>()
                .AddMqttConnectionHandler()
                .AddConnections();

            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services
                .AddSimpleMediator()
                .AddSimpleMediatorMiddleware();

            services.AddSignalR(options =>
            {
                if (Environment.IsDevelopment())
                {
                    options.EnableDetailedErrors = true;
                }

            });

            services
                .AddTransient<ICodeGenerator, CodeGenerator>()
                .AddTransient<ICharacterAssignment, CharacterAssignment>()
                .AddTransient<IClientMessageDispatcher, ClientMessageDispatcher>()
                .AddTransient<ILobbyService, LobbyService>()
                .AddTransient<IMissionInitialisation, MissionInitialisation>()
                .AddTransient<IPlayerOrderInitialisation, PlayerOrderInitialisation>();

            services
                .AddSingleton<IGameManager, GameManager>()
                .AddSingleton<IGameConnectionIdStore, GameConnectionIdStore>();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!Environment.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapConnectionHandler<MqttConnectionHandler>("/mqtt", options =>
                {
                    options.WebSockets.SubProtocolSelector = MQTTnet.AspNetCore.ApplicationBuilderExtensions.SelectSubProtocol;
                });
                endpoints.MapHub<LobbyHub>("/lobby");
                endpoints.MapHub<GameHub>("/game");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (Environment.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
