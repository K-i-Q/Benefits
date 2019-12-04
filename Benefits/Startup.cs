using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Microsoft.AspNetCore.Identity;
using Domain;

namespace Benefits
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;//precisa ser falso para que não solicite cookie check
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Configurando a injeção de dependência
            services.AddScoped<UsuarioDAO>();
            services.AddScoped<PlanoDAO>();
            services.AddScoped<ClienteDAO>();
            services.AddScoped<EmpresaDAO>();
            services.AddScoped<BeneficioDAO>();
            services.AddScoped<EmpresaClienteDAO>();
            services.AddScoped<EmpresaEmpresaDAO>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext < Context >
                (options => options.UseSqlServer(
                Configuration.GetConnectionString
                ("BenefitsConnection")));
        

        //Config sessão deve ser antes da injeção de dependência do MVC
        services.AddSession();//habilita sessão
            services.AddDistributedMemoryCache(); //melhora desempenho(distribui mémória);

              //Configurar o Identity na aplicação
            services.AddIdentity<UsuarioLogado, IdentityRole>().
                AddEntityFrameworkStores<Context>().
                AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.AccessDeniedPath = "/Usuario/AcessoNegado";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

}
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();//minha aplicação usa sessão
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Home}/{id?}");
            });
        }
    }
}
