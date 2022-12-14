namespace WebAPI_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*  DI
             *  1. Teil: DI-Container  
             *      in DI-Container werden Klassen registriert (hier: OnlineshopContext - unsere DbManager-Klasse)
             *      der DI-Container erzeugt fpr uns die Instanz (hier als Singleton - es wird immer die gleiche Instanz zurückgegeben)
             *  2. Teil (siehe: OnlineshopControler): übergibt der DI-Container seine erzeugte Instanz (an den ctor) 
             */
            builder.Services.AddDbContext<OnlineshopContext>(ServiceLifetime.Singleton);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}