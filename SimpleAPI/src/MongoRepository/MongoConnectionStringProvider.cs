using Constartors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace MongoRepository
{
    public class MongoConnectionStringProvider :
        IConnectionStringProvider
    {
        public IConfigurationRoot Configuration { get; }
        public MongoConnectionStringProvider(
            IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public string ConnectionString
        {
            get
            {
                return Configuration ?. GetConnectionString("Mongodb"); ;
            }
        }
    }
}
