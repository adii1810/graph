using demoGraphQl.Schema;
using demoGraphQl.Schema.Mutations;
using demoGraphQl.Schema.Subscriptions;
using demoGraphQl.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using demoGraphQl.Services.Courses;

namespace demoGraphQl
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer().AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscriptions>();

            services.AddInMemorySubscriptions();

            string connectionString = _configuration.GetConnectionString("default") ;
            services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));
            services.AddScoped<CoursesRepository>();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseWebSockets();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
