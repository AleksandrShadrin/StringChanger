using Microsoft.Extensions.DependencyInjection;
using StringChanger.Application.StringPreprocessor;
using StringChanger.Application.StringSplitter;
using StringChanger.Application.StringTokenizer;

namespace StringChanger.Application
{
    public static class Extensions
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddSingleton<IStringPreprocessor, StringPreprocessor.StringPreprocessor>();
            services.AddSingleton<IStringSplitter, StringSplitter.StringSplitter>();
            services.AddSingleton<ITokenizer, Tokenizer>();

            return services;
        }
    }
}
