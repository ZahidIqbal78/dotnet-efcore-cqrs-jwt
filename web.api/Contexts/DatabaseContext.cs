using employee.web.api.Entities;
using employee.web.api.Services;
using Microsoft.EntityFrameworkCore;

namespace employee.web.api.Contexts
{
	public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
	{
		#region DBSets
		public DbSet<EmployeeEntity>? Employees { get; set; }

		public DbSet<UserEntity>? Users { get; set; }
		#endregion
	}
}
