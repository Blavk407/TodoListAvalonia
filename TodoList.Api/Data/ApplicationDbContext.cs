using Microsoft.EntityFrameworkCore;
using TodoList.Api.Models;

namespace TodoList.Api.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

	protected ApplicationDbContext() {}

	public DbSet<Todo> Todo => Set<Todo>();

}