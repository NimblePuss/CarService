using System;
using BeetrootApi.Provider;
using Microsoft.Extensions.Logging;

namespace BeetrootApi.Extension
{
    public static class FileLoggerExtension
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
