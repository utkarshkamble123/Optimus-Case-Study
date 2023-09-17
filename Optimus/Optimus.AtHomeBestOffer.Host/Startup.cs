using Optimus.AtHomeBestOffer.Application.Dto;
using Optimus.AtHomeBestOffer.Application.Service;
using Optimus.AtHomeBestOffer.Host.Infrastructure;

namespace Optimus.AtHomeBestOffer.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method is used to configure services for the application.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services, such as controllers, authentication, and databases.
            // Configure services here
            services.AddAutoMapper(typeof(Program));

            services.AddScoped<IOfferProcessService, OfferProcessService>();
            services.AddScoped<IProposalService<Company1OrderDto, Company1ProposedOffer>, Company1ProposalService>();
            services.AddScoped<IProposalService<Company2OrderDto, Company2ProposedOffer>, Company2ProposalService>();
            services.AddScoped<IProposalService<Company3OrderDto, Company3ProposedOffer>, Company3ProposalService>();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method is used to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Add the global exception handling middleware
            app.UseMiddleware<GlobalExceptionMiddleware>();
           
            // Configure routing.
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure endpoint routing for controllers.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}