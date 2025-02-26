
using LazyDI.Core;

namespace LazyDI.WebAppTest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddLazyDI(
        //    Assembly.Load("LazyDI.Test.Infra"),
        //    Assembly.Load("LazyDI.Test.Services"),
        //    Assembly.Load("LazyDI.WebAppTest")
        //);

        builder.Services.AddLazyDI(
            "LazyDI.Test.Infra",
            "LazyDI.Test.Services",
            "LazyDI.WebAppTest"
        );

        var app = builder.Build();

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
