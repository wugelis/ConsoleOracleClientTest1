using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Test_OracleGetConnectionString.Models;
using Xunit;

namespace Test_OracleGetConnectionString
{
    public class Tests_OracleGetConnection
    {
        private IConfigurationRoot _configuration;

        private DbContextOptions<HousingLoansDbContext> _dbContextOptions;
        [Fact]
        public void Test_OracleConfigurare_Connect()
        {
            bool actual;
            bool expected = true;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");

            _configuration = builder.Build();
            _dbContextOptions = new DbContextOptionsBuilder<HousingLoansDbContext>()
                .UseOracle(_configuration.GetConnectionString("Orcl.Connection"))
                .Options;

            HousingLoansDbContext context = new HousingLoansDbContext(_dbContextOptions);
            var accounts = context.Accounts;

            actual = accounts.CountAsync().Result > 0;
            Assert.Equal(expected, actual);
        }
    }
}