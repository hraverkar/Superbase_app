using CleanArchitecture.Core.Locations.Entities;
using CleanArchitecture.Core.Weather.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public class WeatherNoSqlContext : DbContext
    {
        private static readonly ILoggerFactory DebugLoggerFactory = new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });
        private readonly IHostEnvironment? _env;

        public WeatherNoSqlContext(DbContextOptions<WeatherNoSqlContext> options,
            IHostEnvironment? env) : base(options)
        {
            _env = env;
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
