using System.Text;
using DotzAPI.Database;
using DotzAPI.Repositorios;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace DotzAPI
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
            string conexaoMysql = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<AplicacaoDbContexto>(options => options.UseMySql(conexaoMysql,
                                                                                      ServerVersion.AutoDetect(conexaoMysql)));
            services.AddCors();
            services.AddControllers();

            var chavePrivada = Encoding.ASCII.GetBytes(Configuracoes.ChavePrivada);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chavePrivada),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<AplicacaoDbContexto, AplicacaoDbContexto>();
            services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddTransient<IEnderecoServico, EnderecoServico>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotzAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotzAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
