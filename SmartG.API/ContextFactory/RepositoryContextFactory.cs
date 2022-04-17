using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SmartG.Repository;

namespace SmartG.API.ContextFactory
{
	public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
	{
		// remember to install package ms.efcore.sqlserver & the .Tools
		public RepositoryContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json").Build();
			var builder = new DbContextOptionsBuilder<RepositoryContext>()
				.UseSqlServer(configuration.GetConnectionString("SGDatabase"), b => b.MigrationsAssembly("SmartG.API"));
			return new RepositoryContext(builder.Options);
		}
	}
}

