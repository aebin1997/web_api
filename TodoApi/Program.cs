// ASP.NET Core에서는 DB 컨텍스트와 같은 서비스를 DI(종속성 주입) 컨테이너에 등록해야 합니다. 컨테이너는 컨트롤러에 서비스를 제공합니다.
// 아래 코드는 Swagger 호출을 제거합니다.
// 사용하지 않는 using 지시문을 제거합니다.
// DI 컨테이너에 데이터베이스 컨텍스트를 추가합니다.
// 데이터베이스 컨텍스트가 메모리 내 데이터베이스를 사용하도록 지정합니다.
    
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

