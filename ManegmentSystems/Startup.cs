using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ManegmentSystems.Data;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using ManegmentSystems.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Pioneer.Pagination;
using ManegmentSystems.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems
{
    public class Startup
    {
        private IHostingEnvironment Environment { get; }
        private readonly AsyncLocal<Scope> scopeProvider = new AsyncLocal<Scope>();
        private IKernel Kernel { get; set; }

        private object Resolve(Type type) => Kernel.Get(type);
        private object RequestScope(IContext context) => scopeProvider.Value;

        private sealed class Scope : DisposableObject { }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
.SetBasePath(env.ContentRootPath)
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
.AddEnvironmentVariables();
            Environment = env;
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<CarMangerContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultUI()
      .AddDefaultTokenProviders();


            services.AddAuthentication();


            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("https://localhost:44396/v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
           
          
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddRequestScopingMiddleware(() => scopeProvider.Value = new Scope());
            services.AddCustomControllerActivation(Resolve);
            services.AddCustomViewComponentActivation(Resolve);
            services.AddTransient<IManufacture, ManufactureRepo>();
            services.AddTransient<ICar, CarRepo>();
            services.AddTransient<IOutcome, OutComeRepo>();
            services.AddTransient<IBuyRecords, BuyRecordRepo>();
            services.AddTransient<IBuyRecords, BuyRecordRepo>();
            services.AddTransient<IBuy, BuyRepos>();
            services.AddTransient<IPaginatedMetaService, PaginatedMetaService>();
            services.AddTransient<Ifile, Filerepo>();
            services.AddTransient<ISale, SaleRepo>();
            services.AddTransient<ISellrecord, SellRecordRepo>();
            services.AddTransient<IIncome, IncomeRepo>();
            services.AddTransient<ICustomer, CustomerRepo>();
            services.AddTransient<ICash, CashRepo>();
            services.AddTransient<IcarInfo, carInfo>();
            services.AddTransient<Iperson, SalepersonRepos>();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddTransient<ICheck, CheckRepo>();
            services.AddTransient<IAfterBuyExpncess, AfterBuyExpencessRepo>();
            services.AddTransient<IAfterSellExpncess, AfterSellExpencessRepo>();
            services.AddTransient<ICapitalShare, CapitalshareRepo>();





        }
        private IKernel RegisterApplicationComponents(IApplicationBuilder app)
        {
            // IKernelConfiguration config = new KernelConfiguration();
            var kernel = new StandardKernel();

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                kernel.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            // This is where our bindings are configurated
            kernel.Bind<Iperson>().To<SalepersonRepos>().InScope(RequestScope);
            kernel.Bind<IBuyRecords>().To<BuyRecordRepo>().InScope(RequestScope);
            kernel.Bind<IBuy>().To<BuyRepos>().InScope(RequestScope);
            kernel.Bind<ICash>().To<CashRepo>().InScope(RequestScope);
            kernel.Bind<ICheck>().To<CheckRepo>().InScope(RequestScope);
            kernel.Bind<ICar>().To<CarRepo>().InScope(RequestScope);
            kernel.Bind<IOutcome>().To<OutComeRepo>().InScope(RequestScope);
            kernel.Bind<IModel>().To<ModelRepo>().InScope(RequestScope);
            kernel.Bind<ICustomer>().To<CustomerRepo>().InScope(RequestScope);
            kernel.Bind<Ifile>().To<Filerepo>().InScope(RequestScope);
            kernel.Bind<IHostingEnvironment>().To<HostingEnvironment>().InScope(RequestScope);
            kernel.Bind<IManufacture>().To<ManufactureRepo>().InScope(RequestScope);



            // Cross-wire required framework services
            kernel.BindToMethod(app.GetRequestService<IViewBufferScope>);

            return kernel;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            this.Kernel = this.RegisterApplicationComponents(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSwagger();

            
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseStaticFiles();


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Check")),
                RequestPath = "/Check"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "ID")),
                RequestPath = "/ID"
            });

            app.UseSession();
            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
           

        }
    }
}
