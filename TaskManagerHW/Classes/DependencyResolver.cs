using Autofac;
using TaskManagerHW.DataBaseResources;
using System.Data.SQLite;

namespace TaskManagerHW.Classes
{
    public static class DependencyResolver
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TaskManager>().AsSelf();
            builder.Register(c => new TaskDbContext(@"Data Source=Tasks.db;Version=3;"))
                   .AsSelf()
                   .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
