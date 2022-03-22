// Implementing DI Containers

using ReflectionPlaying;
using ReflectionPlaying.Data;

IoCContainer container = new IoCContainer();

container.AddSingleton<IDbContext, DbContext>();
container.AddTransient<IAccountService, AccountService>();

var service = container.GetService<IAccountService>();

Console.WriteLine(service.RegisterUser("Ivan", "Ivan").Name);
