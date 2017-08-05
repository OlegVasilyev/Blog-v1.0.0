using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using DataAccessLayerInterfaces.Interfaces;
using DataAccessLayerSQL.Repositories;

namespace BusinessLogicLayer.Infrastructure
{
    public class ServiceBlogModul : NinjectModule
    {
        private readonly string connectionString;
        public ServiceBlogModul(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IBlogRepository>().To<BlogRepositories>().WithConstructorArgument(connectionString);
        }
    }
}