using Microsoft.Extensions.Configuration;
using Zoo.Common.Configuration;
using Zoo.Common.Helper;
using Zoo.Core.Implementations;
using Zoo.Core.Interfaces;

namespace Zoo.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IZooService, ZooService>();
            services.AddTransient<IDataHelper, DataHelper>();
            services.AddTransient<IParseHelper, ParseHelper>();
            services.AddSingleton<IConfigProvider, ConfigProvider>();
        }
    }
}
